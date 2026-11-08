using AssetTracking.DAL;

namespace AssetTracking.Pages;

/// <summary>سجل العمليات: من فعل ماذا ومتى (للمدير فقط).</summary>
public partial class AuditPage : PageBase
{
    public AuditPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount);
        dtpFrom.Value = DateTime.Today.AddDays(-30);
        dtpTo.Value = DateTime.Today;
        cmbUser.SelectedIndexChanged += Filter_Changed;
        dtpFrom.ValueChanged += Filter_Changed;
        dtpTo.ValueChanged += Filter_Changed;
    }

    public override void RefreshData()
    {
        Session.Demand(Session.IsManager);
        if (cmbUser.DataSource == null) Ui.BindCombo(cmbUser, ReportLists.Users(), "— الكل —");
        Bind(AuditDal.Search(Ui.SelectedId(cmbUser), dtpFrom.Value, dtpTo.Value));
    }

    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => PrintGrid("سجل العمليات", $"من {dtpFrom.Value:yyyy/MM/dd} إلى {dtpTo.Value:yyyy/MM/dd}"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("سجل العمليات"));
}
