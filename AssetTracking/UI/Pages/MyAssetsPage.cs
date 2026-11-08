using AssetTracking.BLL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>أصولي (UC-14): الموظف يرى الأصول التي في عهدته فقط.</summary>
public sealed class MyAssetsPage : PageBase
{
    private readonly TextBox _search;

    public MyAssetsPage() : base("أصولي")
    {
        _search = AddSearchBox("الرقم التسلسلي أو الاسم...");
        AddAction("📄 بطاقة الأصل", Theme.Info, () =>
        {
            if (RequireSelection() is not { } r) return;
            using var d = new AssetDialog((int)r["Id"], readOnly: true);
            d.ShowDialog(FindForm());
        });
        AddAction("🖨 كشف عهدتي", Theme.Neutral, () =>
        {
            if (Session.Current?.PersonId is int id)
                ReportPrinter.Preview(ReportCatalog.PersonStatement(new ReportFilterValues { PersonId = id }), FindForm());
        });
    }

    public override void RefreshData() => Bind(AssetService.MyAssets(_search.Text));
}
