using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>تنبيهات انتهاء العمر (UC-15): أصول انتهى عمرها وأصول في آخر سنة من عمرها.</summary>
public partial class AlertsPage : PageBase
{
    public AlertsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount);
        btnDispose.Visible = Session.CanManage;
        foreach (var c in new[] { cmbDepartment, cmbCategory }) c.SelectedIndexChanged += Filter_Changed;
        InitChips(null, btnChipAll, btnChipExpired, btnChipLastYear);
        InitRowActions(btnCard, btnCard, btnDispose);
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is DataRowView r)
                e.CellStyle!.ForeColor = (string)r["AlertType"] == "Expired" ? Theme.Danger : Theme.Warning;
        };
    }

    public override void RefreshData()
    {
        bool ready = Ready;
        Ready = false;
        Rebind(cmbDepartment, () => Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— الكل —"));
        Rebind(cmbCategory, () => Ui.BindCombo(cmbCategory, MasterDataDal.CategoryList(), "— الكل —"));
        Ready = ready;

        // كل التنبيهات مرة واحدة، ثم العدّ والتصفية حسب التبويب المختار
        var all = AssetDal.Alerts(null, Ui.SelectedId(cmbDepartment), Ui.SelectedId(cmbCategory));
        var rows = all.AsEnumerable().ToList();
        ChipText(btnChipAll, "الكل", rows.Count);
        ChipText(btnChipExpired, "انتهى عمره", rows.Count(r => (string)r["AlertType"] == "Expired"));
        ChipText(btnChipLastYear, "في آخر سنة", rows.Count(r => (string)r["AlertType"] == "LastYear"));
        var shown = rows.Where(r => Chip == null || (string)r["AlertType"] == Chip).ToList();
        Bind(shown.Count > 0 ? shown.CopyToDataTable() : all.Clone());
    }

    /// <summary>اقتراح التخريد للأصل المتاح فقط (غير المسلّم لأحد).</summary>
    protected override void OnRowSelected(DataRowView? row) =>
        btnDispose.Enabled = row != null && (string)row["Status"] == "Available";

    private void btnCard_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new AssetDialog((int)r["Id"])); });
    private void btnDispose_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new ProposeDisposalDialog((int)r["Id"])); });
    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("تنبيهات انتهاء العمر"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("تنبيهات انتهاء العمر"));
}
