using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>التسليم والاستلام: العهد المفتوحة وسجل الحركات، مع طباعة المحاضر.</summary>
public partial class CustodyPage : PageBase
{
    public CustodyPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الأصل، الرقم التسلسلي، صاحب العهدة...";
        cmbView.Items.AddRange(new object[] { "العهد المفتوحة", "كل الحركات" });
        cmbView.SelectedIndex = 0;
        dtpFrom.Value = DateTime.Today.AddMonths(-6);
        dtpTo.Value = DateTime.Today;
        cmbView.SelectedIndexChanged += Filter_Changed;
        dtpFrom.ValueChanged += Filter_Changed;
        dtpTo.ValueChanged += Filter_Changed;
        grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) btnDocument_Click(null, EventArgs.Empty); };
    }

    private bool OpenOnly => cmbView.SelectedIndex == 0;

    public override void RefreshData()
    {
        dtpFrom.Enabled = dtpTo.Enabled = !OpenOnly;
        Bind(OpenOnly
            ? CustodyDal.Search(Ui.NullIfEmpty(txtSearch.Text), true, null, null)
            : CustodyDal.Search(Ui.NullIfEmpty(txtSearch.Text), false, dtpFrom.Value, dtpTo.Value));
    }

    private void btnHandover_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new HandoverDialog()));

    private void btnReceive_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        if (r["تاريخ الاستلام"] != DBNull.Value) { Ui.Info("هذه العهدة مغلقة (تم الاستلام)."); return; }
        OpenDialog(new ReceiveDialog((int)r["AssetId"]));
    });

    private void btnDocument_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is { } r) ReportPrinter.Preview(ReportCatalog.CustodyDocument((int)r["Id"]), FindForm());
    });

    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => PrintGrid("حركات العهد", OpenOnly ? "العهد المفتوحة" : $"من {dtpFrom.Value:yyyy/MM/dd} إلى {dtpTo.Value:yyyy/MM/dd}"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("حركات العهد"));
}
