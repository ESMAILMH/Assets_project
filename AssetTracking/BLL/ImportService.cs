using System.Globalization;
using AssetTracking.DAL;
using ClosedXML.Excel;

namespace AssetTracking.BLL;

/// <summary>حقل من حقول الأصل يمكن مطابقته مع عمود في ملف Excel.</summary>
public sealed record ImportField(string Key, string Title, bool Required);

/// <summary>سطر من ملف الاستيراد بعد التحقق: إما أصل صالح للحفظ أو سبب الرفض.</summary>
public sealed class ImportRow
{
    public int RowNo { get; init; }
    public AssetInput? Asset { get; init; }
    public string? Error { get; init; }
    public bool IsValid => Error == null;
    public string Serial { get; init; } = "";
    public string Name { get; init; } = "";
}

/// <summary>
/// استيراد الأصول من Excel (UC-05): قراءة الملف ← مطابقة الأعمدة ← معاينة ← حفظ الأسطر الصحيحة فقط.
/// </summary>
public static class ImportService
{
    public static readonly ImportField[] Fields =
    {
        new("SerialNo", "الرقم التسلسلي", true),
        new("Name", "الاسم", true),
        new("Category", "التصنيف", true),
        new("Model", "الموديل", false),
        new("PurchaseDate", "تاريخ الشراء", false),
        new("InServiceDate", "تاريخ بدء الاستخدام", true),
        new("Cost", "التكلفة", true),
        new("LifeYears", "العمر الافتراضي", false),
        new("SalvageValue", "قيمة الخردة", false),
        new("Location", "الموقع", false),
    };

    /// <summary>قالب Excel جاهز بالأعمدة المطلوبة (FR-09).</summary>
    public static void CreateTemplate(string path)
    {
        using var wb = new XLWorkbook();
        var ws = wb.AddWorksheet("الأصول");
        ws.RightToLeft = true;
        for (int i = 0; i < Fields.Length; i++)
        {
            var cell = ws.Cell(1, i + 1);
            cell.Value = Fields[i].Title;
            cell.Style.Font.Bold = true;
            cell.Style.Fill.BackgroundColor = Fields[i].Required ? XLColor.FromHtml("#D9E7F5") : XLColor.FromHtml("#F2F2F2");
        }
        object[] sample = { "PC-0001", "حاسوب مكتبي", "أجهزة حاسوب", "Dell OptiPlex", new DateTime(2025, 1, 10),
                            new DateTime(2025, 1, 15), 2000, 5, 0, "معمل الحاسوب" };
        for (int i = 0; i < sample.Length; i++) ws.Cell(2, i + 1).Value = XLCellValue.FromObject(sample[i]);
        ws.Range(2, 5, 1000, 6).Style.DateFormat.Format = "yyyy/mm/dd";

        var notes = wb.AddWorksheet("تعليمات");
        notes.RightToLeft = true;
        string[] lines =
        {
            "الأعمدة الملوّنة بالأزرق إلزامية.",
            "الرقم التسلسلي يجب ألا يتكرر في الملف ولا في النظام.",
            "التصنيف والموقع يُكتبان بنفس الاسم المسجل في النظام.",
            "إذا تُرك العمر الافتراضي فارغاً يُؤخذ العمر الافتراضي للتصنيف، وقيمة الخردة الفارغة = صفر.",
            "احذف سطر المثال قبل الاستيراد."
        };
        for (int i = 0; i < lines.Length; i++) notes.Cell(i + 1, 1).Value = lines[i];
        ws.Columns().AdjustToContents();
        notes.Column(1).Width = 80;
        wb.SaveAs(path);
    }

    /// <summary>قراءة أول ورقة: السطر الأول عناوين، والباقي بيانات (القيم كما هي: نص أو رقم أو تاريخ).</summary>
    public static DataTable ReadExcel(string path)
    {
        if (!path.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
            throw new AppException("صيغة الملف غير مدعومة. الرجاء اختيار ملف Excel بصيغة ‎.xlsx");

        using var wb = new XLWorkbook(path);
        var ws = wb.Worksheet(1);
        var lastRow = ws.LastRowUsed()?.RowNumber() ?? 0;
        var lastCol = ws.LastColumnUsed()?.ColumnNumber() ?? 0;
        if (lastRow < 2) throw new AppException("الملف لا يحتوي على بيانات.");

        var t = new DataTable();
        t.Columns.Add("__row", typeof(int));
        for (int c = 1; c <= lastCol; c++)
        {
            string header = ws.Cell(1, c).GetString().Trim();
            if (header.Length == 0) header = "عمود " + c;
            while (t.Columns.Contains(header)) header += " ";
            t.Columns.Add(header, typeof(object));
        }
        for (int r = 2; r <= lastRow; r++)
        {
            if (ws.Row(r).IsEmpty()) continue;
            var row = t.NewRow();
            row[0] = r;
            for (int c = 1; c <= lastCol; c++)
            {
                var cell = ws.Cell(r, c);
                row[c] = cell.DataType switch
                {
                    XLDataType.DateTime => cell.GetDateTime(),
                    XLDataType.Number => cell.GetDouble(),
                    XLDataType.Blank => DBNull.Value,
                    _ => cell.GetFormattedString().Trim()
                };
            }
            t.Rows.Add(row);
        }
        return t;
    }

    /// <summary>اقتراح المطابقة تلقائياً حسب تشابه عنوان العمود مع اسم الحقل.</summary>
    public static string? GuessColumn(DataTable t, ImportField f) =>
        t.Columns.Cast<DataColumn>().Skip(1).Select(c => c.ColumnName)
         .FirstOrDefault(n => n.Trim() == f.Title || n.Trim().Equals(f.Key, StringComparison.OrdinalIgnoreCase));

    /// <summary>التحقق من كل سطر (FR-08): رقم تسلسلي مكرر أو حقل ناقص أو قيمة غير صحيحة ← رفض مع السبب.</summary>
    public static List<ImportRow> Validate(DataTable t, IReadOnlyDictionary<string, string?> map)
    {
        foreach (var f in Fields.Where(f => f.Required))
            if (map.GetValueOrDefault(f.Key) is null) throw new AppException($"الرجاء مطابقة الحقل الإلزامي: {f.Title}");

        var categories = MasterDataDal.CategoryList().AsEnumerable()
            .ToDictionary(r => r.Field<string>("Name")!.Trim(), r => (Id: r.Field<int>("Id"), Life: r.Field<int>("DefaultLifeYears")),
                          StringComparer.OrdinalIgnoreCase);
        var locations = MasterDataDal.LocationList().AsEnumerable().ToList();
        var dbSerials = AssetDal.AllSerials();
        var fileSerials = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var result = new List<ImportRow>();

        foreach (DataRow r in t.Rows)
        {
            object? V(string key) => map.GetValueOrDefault(key) is { } col && r[col] is not DBNull ? r[col] : null;
            string S(string key) => Convert.ToString(V(key), CultureInfo.InvariantCulture)?.Trim() ?? "";

            string serial = S("SerialNo"), name = S("Name");
            string? error = null;
            var a = new AssetInput { SerialNo = serial, Name = name, Model = NullIfEmpty(S("Model")) };

            if (serial.Length == 0) error = "الرقم التسلسلي فارغ";
            else if (!fileSerials.Add(serial)) error = "الرقم التسلسلي مكرر داخل الملف";
            else if (dbSerials.Contains(serial)) error = "الرقم التسلسلي موجود مسبقاً في النظام";
            else if (name.Length == 0) error = "الاسم فارغ";
            else if (!categories.TryGetValue(S("Category"), out var cat)) error = $"التصنيف ({S("Category")}) غير موجود";
            else
            {
                a.CategoryId = cat.Id;
                string? e1 = Date(V("InServiceDate"), true, out var service, "تاريخ بدء الاستخدام");
                string? e2 = Date(V("PurchaseDate"), false, out var purchase, "تاريخ الشراء");
                string? e3 = Number(V("Cost"), true, out var cost, "التكلفة");
                string? e4 = Number(V("LifeYears"), false, out var life, "العمر الافتراضي");
                string? e5 = Number(V("SalvageValue"), false, out var salvage, "قيمة الخردة");
                error = e1 ?? e2 ?? e3 ?? e4 ?? e5;
                if (error == null)
                {
                    a.InServiceDate = service!.Value;
                    a.PurchaseDate = purchase;
                    a.Cost = cost ?? 0;
                    a.LifeYears = life is { } l ? (int)l : cat.Life;
                    a.SalvageValue = salvage ?? 0;

                    string loc = S("Location");
                    if (loc.Length > 0)
                    {
                        var match = locations.FirstOrDefault(x => x.Field<string>("Name")!.Trim() == loc)
                                 ?? locations.FirstOrDefault(x => x.Field<string>("ShortName")!.Trim() == loc);
                        if (match == null) error = $"الموقع ({loc}) غير موجود";
                        else a.LocationId = match.Field<int>("Id");
                    }
                    error ??= AssetService.Validate(a);
                }
            }

            result.Add(new ImportRow { RowNo = (int)r[0], Asset = error == null ? a : null, Error = error, Serial = serial, Name = name });
        }
        return result;
    }

    /// <summary>حفظ الأسطر الصحيحة فقط في معاملة واحدة (BR-10: بعد المعاينة واعتماد المستخدم).</summary>
    public static int Save(IEnumerable<ImportRow> rows, string fileName)
    {
        Session.Demand(Session.CanManage);
        var valid = rows.Where(r => r.IsValid).ToList();
        if (valid.Count == 0) throw new AppException("لا توجد أسطر صحيحة للحفظ.");
        Db.Transaction((c, t) =>
        {
            foreach (var r in valid) AssetDal.Insert(r.Asset!, c, t);
            AuditDal.Log("ImportAssets", "Asset", null, $"{Path.GetFileName(fileName)}: {valid.Count} أصل", c, t);
        });
        return valid.Count;
    }

    /// <summary>جدول المعاينة / تقرير أخطاء الاستيراد.</summary>
    public static DataTable PreviewTable(IEnumerable<ImportRow> rows, bool errorsOnly = false)
    {
        var t = new DataTable();
        t.Columns.Add("Valid", typeof(bool));
        t.Columns.Add("السطر في الملف", typeof(int));
        t.Columns.Add("الرقم التسلسلي");
        t.Columns.Add("الاسم");
        t.Columns.Add("النتيجة");
        t.Columns.Add("سبب الرفض");
        foreach (var r in rows.Where(r => !errorsOnly || !r.IsValid))
            t.Rows.Add(r.IsValid, r.RowNo, r.Serial, r.Name, r.IsValid ? "صحيح" : "مرفوض", r.Error);
        return t;
    }

    private static string? NullIfEmpty(string s) => s.Length == 0 ? null : s;

    private static string? Date(object? v, bool required, out DateTime? value, string title)
    {
        value = null;
        switch (v)
        {
            case null: return required ? $"{title} فارغ" : null;
            case DateTime d: value = d.Date; return null;
            case double num when num > 0 && num < 2958466: value = DateTime.FromOADate(num).Date; return null;
            case string s when DateTime.TryParseExact(s, new[] { "yyyy/MM/dd", "yyyy-MM-dd", "dd/MM/yyyy", "d/M/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var p):
                value = p; return null;
            default: return $"{title} غير صحيح";
        }
    }

    private static string? Number(object? v, bool required, out decimal? value, string title)
    {
        value = null;
        switch (v)
        {
            case null: return required ? $"{title} فارغ" : null;
            case double d: value = (decimal)d; return null;
            case string s when decimal.TryParse(s.Replace(",", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out var p):
                value = p; return null;
            default: return $"{title} غير صحيح";
        }
    }
}
