using AssetTracking.DAL;

namespace AssetTracking.Reports;

/// <summary>المرشحات التي يحتاجها كل تقرير.</summary>
[Flags]
public enum ReportFilter
{
    None = 0, Department = 1, Location = 2, Category = 4, AssetStatus = 8, Person = 16,
    Asset = 32, DateRange = 64, Months = 128, InventorySession = 256, User = 512, Custody = 1024
}

public sealed class ReportFilterValues
{
    public int? DepartmentId { get; init; }
    public int? LocationId { get; init; }
    public int? CategoryId { get; init; }
    public string? AssetStatus { get; init; }
    public int? PersonId { get; init; }
    public int? AssetId { get; init; }
    public int? SessionId { get; init; }
    public int? UserId { get; init; }
    public int? CustodyId { get; init; }
    public DateTime From { get; init; }
    public DateTime To { get; init; }
    public int Months { get; init; } = 12;
    /// <summary>وصف المرشحات المختارة لطباعته تحت عنوان التقرير.</summary>
    public string? Description { get; init; }
}

public sealed class ReportDefinition(string title, ReportFilter filters, ReportFilter required,
                                     Func<ReportFilterValues, ReportResult> build, bool managerOnly = false)
{
    public string Title { get; } = title;
    public ReportFilter Filters { get; } = filters;
    public ReportFilter Required { get; } = required;
    public Func<ReportFilterValues, ReportResult> Build { get; } = build;
    public bool ManagerOnly { get; } = managerOnly;
    public override string ToString() => Title;
}

/// <summary>تقارير النظام (القسم 10 من وثيقة التحليل) ومحاضر التسليم والاستلام.</summary>
public static class ReportCatalog
{
    private static readonly string[] StoreSign = { "أمين المخزن", "المدير" };

    public static readonly ReportDefinition[] All =
    {
        // ---- عامة
        new("التقرير الإحصائي العام", ReportFilter.None, ReportFilter.None, GeneralStatistics),

        new("سجل الأصول", ReportFilter.Department | ReportFilter.Category | ReportFilter.AssetStatus, ReportFilter.None,
            f => Simple("سجل الأصول", AssetDal.Search(null, f.CategoryId, f.DepartmentId, null, f.AssetStatus), f, "التكلفة", "القيمة الدفترية")),

        new("ملخص الأصول حسب التصنيف", ReportFilter.None, ReportFilter.None,
            f => Simple("ملخص الأصول حسب التصنيف", WithTotal(ReportDal.Summary(byDepartment: false)), f)),

        new("ملخص الأصول حسب القسم", ReportFilter.None, ReportFilter.None,
            f => Simple("ملخص الأصول حسب القسم", WithTotal(ReportDal.Summary(byDepartment: true)), f)),

        new("الأصول حسب القسم أو الموقع", ReportFilter.Department | ReportFilter.Location, ReportFilter.None, ByLocation),

        // ---- العهد
        new("الأصول حسب الشخص (كشف عهدة)", ReportFilter.Person, ReportFilter.Person, PersonStatement),

        new("العهد المفتوحة (الأصول المسلّمة حالياً)", ReportFilter.Person, ReportFilter.None,
            f => Simple("العهد المفتوحة", Drop(CustodyDal.Search(null, true, null, null, f.PersonId),
                "تاريخ الاستلام", "الحالة عند الاستلام", "العهدة"), f)),

        new("حركة التسليم والاستلام خلال فترة", ReportFilter.DateRange | ReportFilter.Person, ReportFilter.None,
            f => Simple("حركة التسليم والاستلام", CustodyDal.Search(null, false, f.From, f.To, f.PersonId), f)),

        new("محضر تسليم / استلام", ReportFilter.Custody, ReportFilter.Custody, f => CustodyDocument(f.CustodyId!.Value)),

        new("سجل حركات أصل", ReportFilter.Asset, ReportFilter.Asset,
            f => Simple("سجل حركات أصل", Drop(CustodyDal.Search(null, false, null, null, assetId: f.AssetId), "العهدة"), f)),

        // ---- الصيانة والقيمة
        new("سجل صيانة أصل", ReportFilter.Asset | ReportFilter.DateRange, ReportFilter.None,
            f => Simple("سجل الصيانة", MaintenanceDal.Search(f.AssetId, f.From, f.To), f, "التكلفة")),

        new("القيمة الدفترية", ReportFilter.Category | ReportFilter.Department, ReportFilter.None,
            f => Simple("القيمة الدفترية للأصول", ReportDal.BookValues(f.CategoryId, f.DepartmentId), f,
                        "التكلفة", "الإهلاك المتراكم", "القيمة الدفترية")),

        new("الأصول المنتهية أو القريبة من الانتهاء", ReportFilter.Months, ReportFilter.None,
            f => Simple("الأصول المنتهية أو القريبة من الانتهاء", ReportDal.EndOfLife(f.Months), f, "القيمة الدفترية")),

        // ---- التخريد والجرد والرقابة
        new("الأصول المُخرَّدة", ReportFilter.DateRange, ReportFilter.None,
            f => Simple("الأصول المُخرَّدة", Drop(DisposalDal.Search("Approved", f.From, f.To), "الحالة"), f)),

        new("كشف الجرد ونتيجته", ReportFilter.InventorySession, ReportFilter.InventorySession,
            f => InventoryResult(f.SessionId!.Value)),

        new("سجل العمليات", ReportFilter.User | ReportFilter.DateRange, ReportFilter.None,
            f => Simple("سجل العمليات", AuditDal.Search(f.UserId, f.From, f.To), f, signatures: false), managerOnly: true),
    };

    // ------------------------------------------------------------ مساعدات
    private static ReportResult Simple(string title, DataTable t, ReportFilterValues f, params string[] totals) =>
        Simple(title, t, f, true, totals);

    private static ReportResult Simple(string title, DataTable t, ReportFilterValues f, bool signatures, params string[] totals)
    {
        string sectionTitle = string.Join("   —   ", totals.Where(t.Columns.Contains).Select(c =>
            $"إجمالي {c}: {Ui.Money(t.AsEnumerable().Sum(r => r[c] is decimal d ? d : 0))}"));
        return new ReportResult(title, new[] { new ReportSection(sectionTitle, t) }, f.Description,
            signatures ? StoreSign : Array.Empty<string>());
    }

    private static DataTable Drop(DataTable t, params string[] columns)
    {
        foreach (var c in columns) if (t.Columns.Contains(c)) t.Columns.Remove(c);
        return t;
    }

    /// <summary>يضيف سطر "الإجمالي" يجمع الأعمدة الرقمية (العمود الأول نص).</summary>
    private static DataTable WithTotal(DataTable t)
    {
        if (t.Rows.Count == 0) return t;
        var total = t.NewRow();
        total[0] = "الإجمالي";
        foreach (DataColumn c in t.Columns)
        {
            if (c.Ordinal == 0) continue;
            if (c.DataType == typeof(decimal)) total[c] = t.AsEnumerable().Sum(r => r[c] is decimal d ? d : 0);
            else if (c.DataType == typeof(int)) total[c] = t.AsEnumerable().Sum(r => r[c] is int i ? i : 0);
        }
        t.Rows.Add(total);
        return t;
    }

    public static DataTable KeyValue(params (string Key, string Value)[] items)
    {
        var t = new DataTable();
        t.Columns.Add("البيان");
        t.Columns.Add("القيمة");
        foreach (var (k, v) in items) t.Rows.Add(k, v);
        return t;
    }

    // ------------------------------------------------------------ التقارير
    /// <summary>التقرير الإحصائي العام: صورة سريعة عن وضع الأصول والعهد والقيمة.</summary>
    private static ReportResult GeneralStatistics(ReportFilterValues f)
    {
        var s = ReportDal.GeneralStats();
        string N(string col) => Convert.ToInt32(s[col]).ToString("N0");
        string M(string col) => Ui.Money((decimal)s[col]);
        return new ReportResult("التقرير الإحصائي العام", new[]
        {
            new ReportSection("الأصول", KeyValue(
                ("كل الأصول المسجلة", N("AllAssets")), ("متاح", N("Available")), ("في عهدة أشخاص", N("InCustody")),
                ("مُخرَّد", N("Disposed")), ("مؤرشف", N("Archived"))), false),
            new ReportSection("العهد والتنبيهات", KeyValue(
                ("الأشخاص الفعّالون", N("Persons")), ("أشخاص في عهدتهم أصول", N("Holders")),
                ("أصول انتهى عمرها", N("Expired")), ("أصول في آخر سنة من عمرها", N("LastYear")),
                ("طلبات تخريد بانتظار المدير", N("PendingDisposals")), ("جلسات جرد مفتوحة", N("OpenSessions"))), false),
            new ReportSection("القيمة (للأصول القائمة)", KeyValue(
                ("إجمالي التكلفة", M("Cost")), ("الإهلاك المتراكم", M("Depreciation")),
                ("القيمة الدفترية الحالية", M("BookValue")), ($"تكاليف الصيانة لسنة {DateTime.Today.Year}", M("MaintenanceThisYear"))), false),
        }, $"حتى تاريخ {DateTime.Today:yyyy/MM/dd}", StoreSign);
    }

    /// <summary>كشف العهدة الشخصية: الأصول التي في عهدة شخص، للتوقيع.</summary>
    public static ReportResult PersonStatement(ReportFilterValues f)
    {
        var p = MasterDataDal.Person(f.PersonId!.Value) ?? throw new AppException("الشخص غير موجود.");
        var assets = AssetDal.Search(null, null, null, null, null, f.PersonId);
        Drop(assets, "صاحب العهدة", "الحالة");
        var info = KeyValue(("الاسم", (string)p["FullName"]), ("الرقم الوظيفي", Ui.Format(p["EmployeeNo"])),
                            ("القسم", (string)p["DepartmentName"]), ("عدد الأصول في عهدته", assets.Rows.Count.ToString()));
        return new ReportResult("كشف عهدة شخصية",
            new[] { new ReportSection("", info, false), new ReportSection("الأصول التي في عهدته", assets) },
            null, new[] { "صاحب العهدة", "أمين المخزن", "المدير" });
    }

    private static ReportResult ByLocation(ReportFilterValues f)
    {
        var all = ReportDal.ByLocation(f.DepartmentId, f.LocationId);
        var sections = all.AsEnumerable()
            .GroupBy(r => $"{r["Dept"]} / {r["Loc"]}")
            .Select(g => new ReportSection(g.Key, g.CopyToDataTable()))
            .ToList();
        if (sections.Count == 0) sections.Add(new ReportSection("", all));
        return new ReportResult("توزيع الأصول حسب القسم والموقع", sections, f.Description, StoreSign);
    }

    /// <summary>بطاقة أصل: بياناته وقيمته الدفترية وسجل حركاته وصيانته.</summary>
    public static ReportResult AssetCard(int assetId)
    {
        var a = AssetDal.Get(assetId) ?? throw new AppException("الأصل غير موجود.");
        var cat = MasterDataDal.Category((int)a["CategoryId"]);
        var loc = a["LocationId"] is int l ? MasterDataDal.Location(l) : null;
        var info = KeyValue(
            ("الرقم التسلسلي", (string)a["SerialNo"]), ("الاسم", (string)a["Name"]),
            ("التصنيف", cat?["Name"] as string ?? ""), ("الموديل", Ui.Format(a["Model"])),
            ("الموقع", loc?["Name"] as string ?? "—"), ("الحالة", Labels.Of(Labels.AssetStatuses, (string)a["Status"])),
            ("تاريخ الشراء", Ui.Format(a["PurchaseDate"])), ("تاريخ بدء الاستخدام", Ui.Format(a["InServiceDate"])),
            ("التكلفة", Ui.Money((decimal)a["Cost"])), ("العمر الافتراضي", $"{a["LifeYears"]} سنة"),
            ("قيمة الخردة", Ui.Money((decimal)a["SalvageValue"])),
            ("الإهلاك المتراكم", Ui.Money((decimal)a["AccumulatedDepreciation"])),
            ("القيمة الدفترية الحالية", Ui.Money((decimal)a["BookValue"])),
            ("المتبقي من العمر", $"{Convert.ToInt32(a["RemainingMonths"])} شهر"));
        var moves = Drop(CustodyDal.Search(null, false, null, null, assetId: assetId), "الرقم التسلسلي", "الأصل", "ملاحظات");
        var maint = Drop(MaintenanceDal.Search(assetId, null, null), "الرقم التسلسلي", "الأصل");
        return new ReportResult("بطاقة أصل", new[]
        {
            new ReportSection("البيانات", info, false),
            new ReportSection("سجل الحركات (التسليم والاستلام)", moves),
            new ReportSection("سجل الصيانة", maint),
        }, null, StoreSign) { Picture = Ui.ToImage(AssetDal.GetImage(assetId)) };
    }

    /// <summary>كشف الجرد ونتيجته.</summary>
    public static ReportResult InventoryResult(int sessionId)
    {
        var s = InventoryDal.GetSession(sessionId) ?? throw new AppException("جلسة الجرد غير موجودة.");
        var lines = InventoryDal.Lines(sessionId);
        string Count(string? r) => lines.AsEnumerable().Count(x => x["Result"] as string == r).ToString();
        var summary = KeyValue(("موجود", Count("Found")), ("مفقود", Count("Missing")), ("زائد", Count("Surplus")),
                               ("مكانه مختلف", Count("DifferentLocation")), ("لم يُسجَّل بعد", Count(null)));
        return new ReportResult("كشف الجرد ونتيجته",
            new[] { new ReportSection("ملخص النتيجة", summary, false), new ReportSection("تفاصيل الأصول", lines) },
            $"جلسة رقم {sessionId} — {Ui.Format(s["SessionDate"])} — {s["DepartmentName"]} / {s["LocationName"]}",
            new[] { "عضو لجنة الجرد", "أمين المخزن", "رئيس اللجنة" });
    }

    /// <summary>محضر تسليم أو استلام بسيط يولّده النظام لكل عملية.</summary>
    public static ReportResult CustodyDocument(int custodyId)
    {
        var c = CustodyDal.Get(custodyId) ?? throw new AppException("العهدة غير موجودة.");
        bool returned = c["ReturnDate"] != DBNull.Value;
        var rows = new List<(string, string)>
        {
            ("رقم العملية", custodyId.ToString()),
            ("الرقم التسلسلي", (string)c["SerialNo"]),
            ("الأصل", (string)c["AssetName"] + (c["Model"] is string m ? " — " + m : "")),
            ("صاحب العهدة", (string)c["FullName"]),
            ("الرقم الوظيفي", Ui.Format(c["EmployeeNo"])),
            ("القسم", (string)c["DepartmentName"]),
            ("تاريخ التسليم", Ui.Format(c["HandoverDate"])),
            ("حالة الأصل عند التسليم", (string)c["ConditionAtHandover"]),
        };
        if (returned)
        {
            rows.Add(("تاريخ الاستلام", Ui.Format(c["ReturnDate"])));
            rows.Add(("حالة الأصل عند الاستلام", Ui.Format(c["ConditionAtReturn"])));
        }
        if (c["Notes"] is string n) rows.Add(("ملاحظات", n));

        string pledge = returned
            ? "تم استلام الأصل المذكور أعلاه من صاحب العهدة بالحالة الموضحة، وأُخليت عهدته منه."
            : "أقر باستلام الأصل المذكور أعلاه، وأتعهد بالمحافظة عليه وإعادته عند الطلب.";
        return new ReportResult(returned ? "محضر استلام أصل" : "محضر تسليم أصل",
            new[] { new ReportSection("", KeyValue(rows.ToArray()), false), new ReportSection("", KeyValue(("الإقرار", pledge)), false) },
            null, returned ? new[] { "صاحب العهدة", "أمين المخزن" } : new[] { "المستلم", "أمين المخزن" });
    }
}
