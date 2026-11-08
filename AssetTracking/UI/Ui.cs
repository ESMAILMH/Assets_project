using System.Globalization;
using System.Text.RegularExpressions;

namespace AssetTracking.Common;

/// <summary>
/// دوال مساعدة لبناء الواجهة بشكل موحد (اتجاه من اليمين لليسار، أزرار، جداول، رسائل).
/// </summary>
public static partial class Ui
{
    private const MessageBoxOptions RtlOptions = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;

    // ------------------------------------------------------------------ رسائل
    public static void Info(string message) =>
        MessageBox.Show(message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, RtlOptions);

    public static void Warn(string message) =>
        MessageBox.Show(message, "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, RtlOptions);

    public static bool Confirm(string message) =>
        MessageBox.Show(message, "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, RtlOptions) == DialogResult.Yes;

    /// <summary>يعرض الخطأ برسالة عربية مفهومة بدلاً من رسالة SQL الخام.</summary>
    public static void ShowError(Exception ex)
    {
        if (ex is AppException)
        {
            Warn(ex.Message);
            return;
        }

        string message = ex switch
        {
            SqlException { Number: 50001 } => "الأصل غير موجود.",
            SqlException { Number: 50002 } => "لا يمكن تسليم الأصل: حالته ليست \"متاح\" (في عهدة شخص آخر أو مُخرَّد أو مؤرشف). استلمه أولاً إن كان في عهدة.",
            SqlException { Number: 50003 } => "الشخص غير موجود أو معطّل.",
            SqlException { Number: 50004 } => "لا توجد عهدة مفتوحة لهذا الأصل.",
            SqlException { Number: 50005 } => "لا يُقترح للتخريد إلا أصل متاح (غير مسلّم لأحد). استلمه أولاً.",
            SqlException { Number: 50006 } => "اعتماد التخريد من صلاحية المدير فقط.",
            SqlException { Number: 50007 } => "طلب التخريد ليس قيد الانتظار.",
            SqlException { Number: 50008 } => "يجب استلام الأصل من صاحب العهدة قبل تخريده.",
            SqlException { Number: 2627 or 2601 } ex2 when ex2.Message.Contains("UX_Disposal_OneLive") => "يوجد طلب تخريد قائم لهذا الأصل.",
            SqlException { Number: 2627 or 2601 } => "القيمة المدخلة موجودة مسبقاً (مكررة). الرجاء إدخال قيمة مختلفة.",
            SqlException { Number: 547 } => "لا يمكن تنفيذ العملية لارتباط هذا السجل ببيانات أخرى في النظام.",
            SqlException { Number: 4060 or 18456 or -1 or 2 or 53 } =>
                "تعذر الاتصال بقاعدة البيانات. تأكد من تشغيل SQL Server ومن إعدادات الاتصال.\n\n" + ex.Message,
            SqlException sql => "خطأ في قاعدة البيانات:\n" + sql.Message,
            _ => "حدث خطأ غير متوقع:\n" + ex.Message
        };
        MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, RtlOptions);
    }

    /// <summary>ينفذ إجراءً ويعرض أي خطأ للمستخدم. يرجع true عند النجاح.</summary>
    public static bool Try(Action action)
    {
        try
        {
            action();
            return true;
        }
        catch (Exception ex)
        {
            ShowError(ex);
            return false;
        }
    }

    // ------------------------------------------------------------------ نماذج
    public static void ApplyRtl(Control c)
    {
        c.RightToLeft = RightToLeft.Yes;
        c.Font = Theme.Base;
        if (c is Form f) f.RightToLeftLayout = true;
    }

    public static Button MakeButton(string text, Color back, EventHandler? onClick = null, int width = 0)
    {
        var b = new Button
        {
            Text = text,
            BackColor = back,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = Theme.Bold,
            Height = 34,
            AutoSize = width == 0,
            MinimumSize = new Size(90, 34),
            Padding = new Padding(10, 0, 10, 0),
            Margin = new Padding(4),
            Cursor = Cursors.Hand,
            UseVisualStyleBackColor = false
        };
        if (width > 0) b.Width = width;
        b.FlatAppearance.BorderSize = 0;
        b.FlatAppearance.MouseOverBackColor = ControlPaint.Dark(back, 0.1f);
        if (onClick != null) b.Click += onClick;
        return b;
    }

    public static Label MakeLabel(string text, Font? font = null, Color? color = null) => new()
    {
        Text = text,
        AutoSize = true,
        Font = font ?? Theme.Base,
        ForeColor = color ?? Theme.Text,
        Margin = new Padding(4, 10, 4, 4)
    };

    public static TextBox MakeTextBox(int width = 200, string placeholder = "") => new()
    {
        Width = width,
        PlaceholderText = placeholder,
        Margin = new Padding(4, 7, 4, 4)
    };

    public static ComboBox MakeCombo(int width = 160) => new()
    {
        Width = width,
        DropDownStyle = ComboBoxStyle.DropDownList,
        Margin = new Padding(4, 7, 4, 4)
    };

    public static DateTimePicker MakeDate(bool nullable = false) => new()
    {
        Format = DateTimePickerFormat.Custom,
        CustomFormat = "yyyy/MM/dd",
        ShowCheckBox = nullable,
        Value = DateTime.Today,
        Width = 160,
        RightToLeftLayout = false
    };

    public static NumericUpDown MakeMoney() => new()
    {
        DecimalPlaces = 3,
        Maximum = 1_000_000_000,
        Minimum = 0,
        ThousandsSeparator = true,
        Width = 160,
        TextAlign = HorizontalAlignment.Right
    };

    // ------------------------------------------------------------------ قوائم منسدلة
    /// <summary>ربط قائمة منسدلة بجدول (Id, Name) مع إمكانية إضافة خيار فارغ.</summary>
    public static void BindCombo(ComboBox combo, DataTable table, string? emptyText = null)
    {
        if (emptyText != null)
        {
            var row = table.NewRow();
            row["Id"] = 0;
            row["Name"] = emptyText;
            table.Rows.InsertAt(row, 0);
        }
        combo.DisplayMember = "Name";
        combo.ValueMember = "Id";
        combo.DataSource = table;
    }

    public static void BindCombo(ComboBox combo, IEnumerable<ListItem> items)
    {
        combo.DisplayMember = nameof(ListItem.Text);
        combo.ValueMember = nameof(ListItem.Value);
        combo.DataSource = items.ToList();
    }

    /// <summary>يرجع المعرّف المختار أو null عند اختيار الخيار الفارغ.</summary>
    public static int? SelectedId(ComboBox combo) =>
        combo.SelectedValue is int id && id > 0 ? id : null;

    public static string? SelectedCode(ComboBox combo) =>
        combo.SelectedValue is string s && s.Length > 0 ? s : null;

    // ------------------------------------------------------------------ جداول
    public static DataGridView MakeGrid()
    {
        var g = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            RowHeadersVisible = false,
            BackgroundColor = Theme.Surface,
            BorderStyle = BorderStyle.None,
            GridColor = Theme.Border,
            EnableHeadersVisualStyles = false,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            ColumnHeadersHeight = 38,
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        };
        g.RowTemplate.Height = 32;
        g.ColumnHeadersDefaultCellStyle.BackColor = Theme.Primary;
        g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        g.ColumnHeadersDefaultCellStyle.Font = Theme.Bold;
        g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Primary;
        g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(207, 226, 243);
        g.DefaultCellStyle.SelectionForeColor = Theme.Text;
        g.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        g.AlternatingRowsDefaultCellStyle.BackColor = Theme.GridAlt;
        g.DataError += (_, e) => e.ThrowException = false;
        typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            ?.SetValue(g, true); // رسم أنعم عند التمرير
        return g;
    }

    [GeneratedRegex("^[A-Za-z0-9_]+$")]
    private static partial Regex TechnicalName();

    /// <summary>
    /// الأعمدة ذات الأسماء الإنجليزية (مثل Id و Status) أعمدة تقنية تُخفى من العرض والطباعة،
    /// أما الأعمدة ذات العناوين العربية فهي التي تظهر للمستخدم.
    /// </summary>
    public static bool IsTechnical(DataColumn c) => TechnicalName().IsMatch(c.ColumnName);

    public static List<DataColumn> VisibleColumns(DataTable t) =>
        t.Columns.Cast<DataColumn>().Where(c => !IsTechnical(c)).ToList();

    public static void BindGrid(DataGridView grid, DataTable table)
    {
        grid.DataSource = table;
        foreach (DataGridViewColumn col in grid.Columns)
        {
            var dc = table.Columns[col.DataPropertyName];
            if (dc == null) continue;
            col.Visible = !IsTechnical(dc);
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            if (dc.DataType == typeof(DateTime)) col.DefaultCellStyle.Format = IsDateTimeColumn(dc) ? "yyyy/MM/dd HH:mm" : "yyyy/MM/dd";
            else if (dc.DataType == typeof(decimal)) col.DefaultCellStyle.Format = "N3";
        }
    }

    /// <summary>تلوين عمود عربي حسب قيمة عمود تقني مخفي (مثل Status).</summary>
    public static void ColorBy(DataGridView grid, string codeColumn, string displayColumn, Func<string, Color?> color)
    {
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex < 0 || grid.Columns[e.ColumnIndex].DataPropertyName != displayColumn) return;
            if (grid.Rows[e.RowIndex].DataBoundItem is not DataRowView r || r[codeColumn] is not string code) return;
            if (color(code) is not { } c) return;
            e.CellStyle!.ForeColor = c;
            e.CellStyle.Font = Theme.Bold;
        };
    }

    public static Color? AssetStatusColor(string status) => status switch
    {
        "Available" => Theme.Success,
        "InCustody" => Theme.Info,
        "Disposed" or "Archived" => Theme.MutedText,
        _ => null
    };

    public static DataRowView? CurrentRow(DataGridView grid) =>
        grid.CurrentRow?.DataBoundItem as DataRowView;

    // ------------------------------------------------------------------ تنسيق
    public static string Format(object? value) => value switch
    {
        null or DBNull => "",
        DateTime d => d.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture),
        decimal m => m.ToString("N3", CultureInfo.InvariantCulture),
        bool b => b ? "نعم" : "لا",
        _ => value.ToString() ?? ""
    };

    /// <summary>أعمدة التاريخ التي تحتوي على وقت (مثل وقت العملية وآخر دخول).</summary>
    public static bool IsDateTimeColumn(DataColumn c) =>
        c.DataType == typeof(DateTime) &&
        (c.ColumnName.Contains("وقت") || c.ColumnName.Contains("دخول") || c.ColumnName.Contains("الإنشاء"));

    public static string Format(object? value, DataColumn column) =>
        value is DateTime d && IsDateTimeColumn(column)
            ? d.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture)
            : Format(value);

    public static string Money(decimal value) => value.ToString("N3", CultureInfo.InvariantCulture) + " د.ل";

    public static string? NullIfEmpty(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

    // ------------------------------------------------------------------ تصدير
    /// <summary>تصدير الجدول (الأعمدة الظاهرة فقط) إلى ملف Excel.</summary>
    public static void ExportExcel(DataTable table, string fileName, IWin32Window? owner = null)
    {
        using var dlg = new SaveFileDialog
        {
            Filter = "ملف Excel|*.xlsx",
            FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx"
        };
        if (dlg.ShowDialog(owner) != DialogResult.OK) return;

        var cols = VisibleColumns(table);
        using var wb = new ClosedXML.Excel.XLWorkbook();
        var ws = wb.AddWorksheet("تقرير");
        ws.RightToLeft = true;
        for (int c = 0; c < cols.Count; c++)
        {
            ws.Cell(1, c + 1).Value = cols[c].ColumnName;
            ws.Cell(1, c + 1).Style.Font.Bold = true;
            ws.Cell(1, c + 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromHtml("#D9E7F5");
        }
        for (int r = 0; r < table.Rows.Count; r++)
            for (int c = 0; c < cols.Count; c++)
            {
                var v = table.Rows[r][cols[c]];
                var cell = ws.Cell(r + 2, c + 1);
                switch (v)
                {
                    case DateTime d: cell.Value = d; cell.Style.DateFormat.Format = IsDateTimeColumn(cols[c]) ? "yyyy/mm/dd hh:mm" : "yyyy/mm/dd"; break;
                    case decimal m: cell.Value = m; cell.Style.NumberFormat.Format = "#,##0.000"; break;
                    case int or long or double: cell.Value = Convert.ToDouble(v); break;
                    default: cell.Value = Format(v); break;
                }
            }
        ws.Columns().AdjustToContents();
        wb.SaveAs(dlg.FileName);
        Info("تم التصدير إلى:\n" + dlg.FileName);
    }

    /// <summary>مؤقت لتأخير البحث أثناء الكتابة حتى لا يُستعلم عند كل حرف.</summary>
    public static void OnTextChangedDebounced(TextBox box, Action action, int ms = 350)
    {
        var timer = new System.Windows.Forms.Timer { Interval = ms };
        timer.Tick += (_, _) => { timer.Stop(); action(); };
        box.TextChanged += (_, _) => { timer.Stop(); timer.Start(); };
        box.Disposed += (_, _) => timer.Dispose();
    }
}
