using AssetTracking.DAL;

namespace AssetTracking.Pages;

/// <summary>التقارير: اختيار التقرير ← المرشحات ← عرض، طباعة، PDF، Excel.</summary>
public sealed class ReportsPage : UserControl, IPage
{
    private readonly ListBox _list;
    private readonly ComboBox _dept, _loc, _cat, _status, _person, _asset, _session, _user, _custody;
    private readonly DateTimePicker _from, _to;
    private readonly NumericUpDown _months;
    private readonly Dictionary<ReportFilter, Control[]> _filters = new();
    private readonly DataGridView _preview = Ui.MakeGrid();
    private readonly Label _previewTitle;

    public ReportsPage()
    {
        Ui.ApplyRtl(this);
        Dock = DockStyle.Fill;
        BackColor = Theme.Background;
        Padding = new Padding(20, 14, 20, 14);

        _list = new ListBox
        {
            Dock = DockStyle.Right, Width = 280, Font = new Font(Theme.FontName, 10.5F), ItemHeight = 34,
            DrawMode = DrawMode.OwnerDrawFixed, BorderStyle = BorderStyle.None, IntegralHeight = false
        };
        _list.DrawItem += DrawItem;
        _list.Items.AddRange(ReportCatalog.All.Where(r => !r.ManagerOnly || Session.IsManager).Cast<object>().ToArray());
        _list.SelectedIndexChanged += (_, _) => OnReportChanged();

        var filterPanel = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, WrapContents = true, Padding = new Padding(10, 8, 10, 6), BackColor = Theme.Surface };
        _dept = Combo(filterPanel, ReportFilter.Department, "القسم:");
        _loc = Combo(filterPanel, ReportFilter.Location, "الموقع:", 180);
        _cat = Combo(filterPanel, ReportFilter.Category, "التصنيف:");
        _status = Combo(filterPanel, ReportFilter.AssetStatus, "الحالة:", 110);
        _person = Combo(filterPanel, ReportFilter.Person, "الشخص:", 200);
        _asset = Combo(filterPanel, ReportFilter.Asset, "الأصل:", 240);
        _session = Combo(filterPanel, ReportFilter.InventorySession, "جلسة الجرد:", 200);
        _user = Combo(filterPanel, ReportFilter.User, "المستخدم:");
        _custody = Combo(filterPanel, ReportFilter.Custody, "العملية:", 380);
        _dept.SelectedIndexChanged += (_, _) =>
            Ui.Try(() => Ui.BindCombo(_loc, MasterDataDal.LocationList(Ui.SelectedId(_dept)), "— الكل —"));
        _from = Ui.MakeDate();
        _to = Ui.MakeDate();
        _from.Value = new DateTime(DateTime.Today.Year, 1, 1);
        Add(filterPanel, ReportFilter.DateRange, Ui.MakeLabel("من:"), _from, Ui.MakeLabel("إلى:"), _to);
        _months = new NumericUpDown { Minimum = 0, Maximum = 120, Value = 12, Width = 70 };
        Add(filterPanel, ReportFilter.Months, Ui.MakeLabel("خلال (شهر):"), _months);

        var buttons = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(10, 4, 10, 8), BackColor = Theme.Surface };
        buttons.Controls.Add(Ui.MakeButton("👁 عرض", Theme.Primary, (_, _) => Ui.Try(ShowPreview)));
        buttons.Controls.Add(Ui.MakeButton("🖨 طباعة", Theme.Neutral, (_, _) => Ui.Try(() => ReportPrinter.Preview(Build(), FindForm()))));
        buttons.Controls.Add(Ui.MakeButton("PDF", Theme.Danger, (_, _) => Ui.Try(() => ReportPrinter.SavePdf(Build(), FindForm()))));
        buttons.Controls.Add(Ui.MakeButton("Excel", Theme.Success, (_, _) => Ui.Try(Export)));

        _previewTitle = new Label { Dock = DockStyle.Top, Height = 32, Font = Theme.Subtitle, TextAlign = ContentAlignment.MiddleLeft };
        var right = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 0, 12, 0) };
        right.Controls.Add(_preview);
        right.Controls.Add(_previewTitle);
        right.Controls.Add(buttons);
        right.Controls.Add(filterPanel);

        Controls.Add(right);
        Controls.Add(_list);
        Controls.Add(new Label { Text = "التقارير", Font = Theme.Title, ForeColor = Theme.Primary, Dock = DockStyle.Top, Height = 44, TextAlign = ContentAlignment.MiddleLeft });
        Load += (_, _) => Ui.Try(RefreshData);
    }

    private ComboBox Combo(FlowLayoutPanel host, ReportFilter f, string label, int width = 150)
    {
        var c = Ui.MakeCombo(width);
        Add(host, f, Ui.MakeLabel(label), c);
        return c;
    }

    private void Add(FlowLayoutPanel host, ReportFilter f, params Control[] controls)
    {
        host.Controls.AddRange(controls);
        _filters[f] = controls;
    }

    public void RefreshData()
    {
        Ui.BindCombo(_dept, MasterDataDal.DepartmentList(), "— الكل —");
        Ui.BindCombo(_loc, MasterDataDal.LocationList(), "— الكل —");
        Ui.BindCombo(_cat, MasterDataDal.CategoryList(), "— الكل —");
        Ui.BindCombo(_status, Labels.WithAll(Labels.AssetStatuses));
        Ui.BindCombo(_person, MasterDataDal.PersonList(), "— اختر —");
        Ui.BindCombo(_asset, ReportLists.Assets(), "— الكل —");
        Ui.BindCombo(_session, ReportLists.Sessions(), "— اختر —");
        Ui.BindCombo(_custody, ReportLists.CustodyOperations(), "— اختر —");
        if (Session.IsManager) Ui.BindCombo(_user, ReportLists.Users(), "— الكل —");
        if (_list.SelectedIndex < 0 && _list.Items.Count > 0) _list.SelectedIndex = 0;
        else OnReportChanged();
    }

    private ReportDefinition? Current => _list.SelectedItem as ReportDefinition;

    private void OnReportChanged()
    {
        if (Current is not { } def) return;
        foreach (var (flag, controls) in _filters)
            foreach (var c in controls) c.Visible = def.Filters.HasFlag(flag);
        _preview.DataSource = null;
        _previewTitle.Text = "";
    }

    private ReportResult Build()
    {
        var def = Current ?? throw new AppException("اختر تقريراً.");
        void Need(ReportFilter f, ComboBox c, string name)
        {
            if (def.Required.HasFlag(f) && Ui.SelectedId(c) is null) throw new AppException($"الرجاء اختيار {name}.");
        }
        Need(ReportFilter.Person, _person, "الشخص");
        Need(ReportFilter.Asset, _asset, "الأصل");
        Need(ReportFilter.InventorySession, _session, "جلسة الجرد");
        Need(ReportFilter.Custody, _custody, "العملية");
        if (def.Filters.HasFlag(ReportFilter.DateRange) && _from.Value.Date > _to.Value.Date)
            throw new AppException("تاريخ البداية بعد تاريخ النهاية.");

        string? Pick(ReportFilter f, ComboBox c, string name) =>
            def.Filters.HasFlag(f) && c.SelectedIndex > 0 ? $"{name}: {c.Text}" : null;
        var parts = new[]
        {
            Pick(ReportFilter.Department, _dept, "القسم"), Pick(ReportFilter.Location, _loc, "الموقع"),
            Pick(ReportFilter.Category, _cat, "التصنيف"), Pick(ReportFilter.AssetStatus, _status, "الحالة"),
            Pick(ReportFilter.Asset, _asset, "الأصل"), Pick(ReportFilter.User, _user, "المستخدم"),
            Pick(ReportFilter.Person, _person, "الشخص"),
            def.Filters.HasFlag(ReportFilter.DateRange) ? $"من {_from.Value:yyyy/MM/dd} إلى {_to.Value:yyyy/MM/dd}" : null,
            def.Filters.HasFlag(ReportFilter.Months) ? $"خلال {_months.Value} شهر" : null
        }.Where(p => p != null);

        T? Val<T>(ReportFilter f, Func<T?> get) where T : struct => def.Filters.HasFlag(f) ? get() : null;
        return def.Build(new ReportFilterValues
        {
            DepartmentId = Val(ReportFilter.Department, () => Ui.SelectedId(_dept)),
            LocationId = Val(ReportFilter.Location, () => Ui.SelectedId(_loc)),
            CategoryId = Val(ReportFilter.Category, () => Ui.SelectedId(_cat)),
            AssetStatus = def.Filters.HasFlag(ReportFilter.AssetStatus) ? Ui.SelectedCode(_status) : null,
            PersonId = Val(ReportFilter.Person, () => Ui.SelectedId(_person)),
            AssetId = Val(ReportFilter.Asset, () => Ui.SelectedId(_asset)),
            SessionId = Val(ReportFilter.InventorySession, () => Ui.SelectedId(_session)),
            UserId = Val(ReportFilter.User, () => Ui.SelectedId(_user)),
            CustodyId = Val(ReportFilter.Custody, () => Ui.SelectedId(_custody)),
            From = _from.Value.Date,
            To = _to.Value.Date,
            Months = (int)_months.Value,
            Description = string.Join("   |   ", parts)
        });
    }

    /// <summary>للعرض والتصدير: أكبر جزء في التقرير (الجدول الرئيسي).</summary>
    private static DataTable MainTable(ReportResult r)
    {
        var data = r.Sections.Select(s => s.Table)
            .Where(t => !(t.Columns.Count == 2 && t.Columns[0].ColumnName == "البيان")).ToList();
        if (data.Count == 0) return r.Sections[0].Table;
        var main = data.OrderByDescending(t => t.Rows.Count).First();
        var same = data.Where(t => t.Columns.Count == main.Columns.Count).ToList();
        return same.Count > 1 ? Merge(same) : main;
    }

    private static DataTable Merge(IEnumerable<DataTable> tables)
    {
        var list = tables.ToList();
        var merged = list[0].Clone();
        foreach (var t in list) foreach (DataRow r in t.Rows) merged.ImportRow(r);
        return merged;
    }

    private void ShowPreview()
    {
        var r = Build();
        Ui.BindGrid(_preview, MainTable(r));
        _previewTitle.Text = r.Title + (string.IsNullOrEmpty(r.Subtitle) ? "" : "  —  " + r.Subtitle);
    }

    private void Export()
    {
        var r = Build();
        Ui.ExportExcel(MainTable(r), r.Title, FindForm());
    }

    private void DrawItem(object? sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;
        bool selected = (e.State & DrawItemState.Selected) != 0;
        using var back = new SolidBrush(selected ? Theme.Primary : Theme.Surface);
        e.Graphics.FillRectangle(back, e.Bounds);
        TextRenderer.DrawText(e.Graphics, _list.Items[e.Index].ToString(), e.Font, Rectangle.Inflate(e.Bounds, -10, 0),
            selected ? Color.White : Theme.Text,
            TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft | TextFormatFlags.EndEllipsis);
    }
}
