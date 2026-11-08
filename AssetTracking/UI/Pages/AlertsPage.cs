using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>تنبيهات انتهاء العمر (UC-15): أصول في آخر سنة من عمرها وأصول انتهى عمرها.</summary>
public partial class AlertsPage : PageBase
{
    public AlertsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount);
        btnDispose.Visible = Session.CanManage;
        foreach (var c in new[] { cmbType, cmbDepartment, cmbCategory }) c.SelectedIndexChanged += Filter_Changed;
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
        if (cmbType.DataSource == null) Ui.BindCombo(cmbType, Labels.WithAll(Labels.AlertTypes));
        Rebind(cmbDepartment, () => Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— الكل —"));
        Rebind(cmbCategory, () => Ui.BindCombo(cmbCategory, MasterDataDal.CategoryList(), "— الكل —"));
        Ready = ready;
        Bind(AssetDal.Alerts(Ui.SelectedCode(cmbType), Ui.SelectedId(cmbDepartment), Ui.SelectedId(cmbCategory)));
    }

    private void btnCard_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new AssetDialog((int)r["Id"])); });
    private void btnDispose_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new ProposeDisposalDialog((int)r["Id"])); });
    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("تنبيهات انتهاء العمر"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("تنبيهات انتهاء العمر"));
}
