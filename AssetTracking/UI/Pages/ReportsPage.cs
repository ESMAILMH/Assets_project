using AssetTracking.DAL;

namespace AssetTracking.Pages;

/// <summary>التقارير: اختيار التقرير ← المرشحات ← عرض، طباعة، PDF، Excel.</summary>
public partial class ReportsPage : UserControl, IPage
{
    /// <summary>عناصر كل مرشح (العنوان + الأداة) لإظهارها حسب التقرير المختار.</summary>
    private readonly Dictionary<ReportFilter, Control[]> _filters;
    private bool _loaded;

    public ReportsPage()
    {
        InitializeComponent();
        Ui.StyleGrid(grid);
        _filters = new()
        {
            [ReportFilter.Department] = new Control[] { lblDepartment, cmbDepartment },
            [ReportFilter.Location] = new Control[] { lblLocation, cmbLocation },
            [ReportFilter.Category] = new Control[] { lblCategory, cmbCategory },
            [ReportFilter.AssetStatus] = new Control[] { lblStatus, cmbStatus },
            [ReportFilter.Person] = new Control[] { lblPerson, cmbPerson },
            [ReportFilter.Asset] = new Control[] { lblAsset, cmbAsset },
            [ReportFilter.InventorySession] = new Control[] { lblSession, cmbSession },
            [ReportFilter.User] = new Control[] { lblUser, cmbUser },
            [ReportFilter.Custody] = new Control[] { lblCustody, cmbCustody },
            [ReportFilter.DateRange] = new Control[] { lblFrom, dtpFrom, lblTo, dtpTo },
            [ReportFilter.Months] = new Control[] { lblMonths, numMonths },
        };
        dtpFrom.Value = new DateTime(DateTime.Today.Year, 1, 1);
        dtpTo.Value = DateTime.Today;
        lstReports.DrawItem += DrawReportItem;
        lstReports.Items.AddRange(ReportCatalog.All.Where(r => !r.ManagerOnly || Session.IsManager).Cast<object>().ToArray());
        cmbDepartment.SelectedIndexChanged += (_, _) =>
        {
            if (_loaded) Ui.Try(() => Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(Ui.SelectedId(cmbDepartment)), "— الكل —"));
        };
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!DesignMode && !_loaded) Ui.Try(RefreshData);
    }

    public void RefreshData()
    {
        _loaded = false;
        Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— الكل —");
        Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(), "— الكل —");
        Ui.BindCombo(cmbCategory, MasterDataDal.CategoryList(), "— الكل —");
        Ui.BindCombo(cmbStatus, Labels.WithAll(Labels.AssetStatuses));
        Ui.BindCombo(cmbPerson, MasterDataDal.PersonList(), "— اختر —");
        Ui.BindCombo(cmbAsset, ReportLists.Assets(), "— الكل —");
        Ui.BindCombo(cmbSession, ReportLists.Sessions(), "— اختر —");
        Ui.BindCombo(cmbCustody, ReportLists.CustodyOperations(), "— اختر —");
        if (Session.IsManager) Ui.BindCombo(cmbUser, ReportLists.Users(), "— الكل —");
        _loaded = true;
        if (lstReports.SelectedIndex < 0 && lstReports.Items.Count > 0) lstReports.SelectedIndex = 0;
        else lstReports_SelectedIndexChanged(null, EventArgs.Empty);
    }

    private ReportDefinition? Current => lstReports.SelectedItem as ReportDefinition;

    /// <summary>إظهار مرشحات التقرير المختار فقط.</summary>
    private void lstReports_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (Current is not { } def) return;
        foreach (var (flag, controls) in _filters)
            foreach (var c in controls) c.Visible = def.Filters.HasFlag(flag);
        grid.DataSource = null;
        lblPreviewTitle.Text = "";
    }

    private ReportResult Build()
    {
        var def = Current ?? throw new AppException("اختر تقريراً.");
        void Need(ReportFilter f, ComboBox c, string name)
        {
            if (def.Required.HasFlag(f) && Ui.SelectedId(c) is null) throw new AppException($"الرجاء اختيار {name}.");
        }
        Need(ReportFilter.Person, cmbPerson, "الشخص");
        Need(ReportFilter.Asset, cmbAsset, "الأصل");
        Need(ReportFilter.InventorySession, cmbSession, "جلسة الجرد");
        Need(ReportFilter.Custody, cmbCustody, "العملية");
        if (def.Filters.HasFlag(ReportFilter.DateRange) && dtpFrom.Value.Date > dtpTo.Value.Date)
            throw new AppException("تاريخ البداية بعد تاريخ النهاية.");

        bool Has(ReportFilter f) => def.Filters.HasFlag(f);
        string? Pick(ReportFilter f, ComboBox c, string name) => Has(f) && c.SelectedIndex > 0 ? $"{name}: {c.Text}" : null;
        int? Id(ReportFilter f, ComboBox c) => Has(f) ? Ui.SelectedId(c) : null;

        var parts = new[]
        {
            Pick(ReportFilter.Department, cmbDepartment, "القسم"), Pick(ReportFilter.Location, cmbLocation, "الموقع"),
            Pick(ReportFilter.Category, cmbCategory, "التصنيف"), Pick(ReportFilter.AssetStatus, cmbStatus, "الحالة"),
            Pick(ReportFilter.Asset, cmbAsset, "الأصل"), Pick(ReportFilter.User, cmbUser, "المستخدم"),
            Pick(ReportFilter.Person, cmbPerson, "الشخص"),
            Has(ReportFilter.DateRange) ? $"من {dtpFrom.Value:yyyy/MM/dd} إلى {dtpTo.Value:yyyy/MM/dd}" : null,
            Has(ReportFilter.Months) ? $"خلال {numMonths.Value} شهر" : null
        }.Where(p => p != null);

        return def.Build(new ReportFilterValues
        {
            DepartmentId = Id(ReportFilter.Department, cmbDepartment),
            LocationId = Id(ReportFilter.Location, cmbLocation),
            CategoryId = Id(ReportFilter.Category, cmbCategory),
            AssetStatus = Has(ReportFilter.AssetStatus) ? Ui.SelectedCode(cmbStatus) : null,
            PersonId = Id(ReportFilter.Person, cmbPerson),
            AssetId = Id(ReportFilter.Asset, cmbAsset),
            SessionId = Id(ReportFilter.InventorySession, cmbSession),
            UserId = Id(ReportFilter.User, cmbUser),
            CustodyId = Id(ReportFilter.Custody, cmbCustody),
            From = dtpFrom.Value.Date,
            To = dtpTo.Value.Date,
            Months = (int)numMonths.Value,
            Description = string.Join("   |   ", parts)
        });
    }

    /// <summary>الجدول الرئيسي في التقرير (للعرض والتصدير).</summary>
    private static DataTable MainTable(ReportResult r)
    {
        var data = r.Sections.Select(s => s.Table)
            .Where(t => !(t.Columns.Count == 2 && t.Columns[0].ColumnName == "البيان")).ToList();
        if (data.Count == 0) return r.Sections[0].Table;
        var main = data.OrderByDescending(t => t.Rows.Count).First();
        var same = data.Where(t => t.Columns.Count == main.Columns.Count).ToList();
        if (same.Count == 1) return main;
        var merged = same[0].Clone();
        foreach (var t in same) foreach (DataRow row in t.Rows) merged.ImportRow(row);
        return merged;
    }

    private void btnShow_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        var r = Build();
        Ui.BindGrid(grid, MainTable(r));
        lblPreviewTitle.Text = r.Title + (string.IsNullOrEmpty(r.Subtitle) ? "" : "  —  " + r.Subtitle);
    });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => ReportPrinter.Preview(Build(), FindForm()));
    private void btnPdf_Click(object? sender, EventArgs e) => Ui.Try(() => ReportPrinter.SavePdf(Build(), FindForm()));

    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        var r = Build();
        Ui.ExportExcel(MainTable(r), r.Title, FindForm());
    });

    private void DrawReportItem(object? sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;
        bool selected = (e.State & DrawItemState.Selected) != 0;
        using var back = new SolidBrush(selected ? Theme.Primary : Theme.Surface);
        e.Graphics.FillRectangle(back, e.Bounds);
        TextRenderer.DrawText(e.Graphics, lstReports.Items[e.Index].ToString(), e.Font, Rectangle.Inflate(e.Bounds, -10, 0),
            selected ? Color.White : Theme.Text,
            TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft | TextFormatFlags.EndEllipsis);
    }
}
