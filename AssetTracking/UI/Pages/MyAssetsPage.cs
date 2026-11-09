using AssetTracking.BLL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>أصولي (UC-14): الموظف يرى الأصول التي في عهدته فقط.</summary>
public partial class MyAssetsPage : PageBase
{
    public MyAssetsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الرقم التسلسلي أو الاسم...";
        InitRowActions(btnCard, btnCard);
    }

    public override void RefreshData() => Bind(AssetService.MyAssets(txtSearch.Text));

    private void btnCard_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        using var d = new AssetDialog((int)r["Id"], readOnly: true);
        d.ShowDialog(FindForm());
    });

    private void btnStatement_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (Session.Current?.PersonId is int id)
            ReportPrinter.Preview(ReportCatalog.PersonStatement(new ReportFilterValues { PersonId = id }), FindForm());
    });
}
