using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>جلسات الجرد.</summary>
public sealed class InventoryPage : PageBase
{
    public InventoryPage() : base("الجرد")
    {
        AddAction("➕ جلسة جرد جديدة", Theme.Primary, NewSession);
        AddAction("📋 فتح الجلسة", Theme.Info, OpenSelected);
        AddAction("🖨 كشف الجرد", Theme.Neutral, () =>
        {
            if (RequireSelection() is { } r) ReportPrinter.Preview(ReportCatalog.InventoryResult((int)r["Id"]), FindForm());
        });
        Grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) Ui.Try(OpenSelected); };
    }

    public override void RefreshData() => Bind(InventoryDal.Sessions());

    private void NewSession()
    {
        using var d = new NewInventoryDialog();
        if (d.ShowDialog(FindForm()) != DialogResult.OK) return;
        Open(d.SessionId);
    }

    private void OpenSelected()
    {
        if (RequireSelection() is { } r) Open((int)r["Id"]);
    }

    private void Open(int id)
    {
        using var f = new InventorySessionForm(id);
        f.ShowDialog(FindForm());
        RefreshData();
    }
}
