using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>جلسات الجرد.</summary>
public partial class InventoryPage : PageBase
{
    public InventoryPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount);
        grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) btnOpen_Click(null, EventArgs.Empty); };
    }

    public override void RefreshData() => Bind(InventoryDal.Sessions());

    private void Open(int id)
    {
        using var f = new InventorySessionForm(id);
        f.ShowDialog(FindForm());
        RefreshData();
    }

    private void btnNew_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        using var d = new NewInventoryDialog();
        if (d.ShowDialog(FindForm()) == DialogResult.OK) Open(d.SessionId);
    });

    private void btnOpen_Click(object? sender, EventArgs e) => Ui.Try(() => { if (RequireSelection() is { } r) Open((int)r["Id"]); });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is { } r) ReportPrinter.Preview(ReportCatalog.InventoryResult((int)r["Id"]), FindForm());
    });
}
