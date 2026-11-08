using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>الأشخاص (أصحاب العهد).</summary>
public sealed class PersonsPage : PageBase
{
    private readonly TextBox _search;

    public PersonsPage() : base("الأشخاص")
    {
        _search = AddSearchBox("الاسم، الرقم الوظيفي، القسم، الهاتف...");
        AddAction("➕ إضافة", Theme.Primary, () => Edit(null));
        AddAction("✏ تعديل", Theme.Info, () => { if (RequireSelection() is { } r) Edit((int)r["Id"]); });
        AddAction("📑 كشف عهدته", Theme.Warning, () =>
        {
            if (RequireSelection() is { } r)
                ReportPrinter.Preview(ReportCatalog.PersonStatement(new ReportFilterValues { PersonId = (int)r["Id"] }), FindForm());
        });
        AddPrintExport("الأشخاص");
        Grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && Selected is { } r) Ui.Try(() => Edit((int)r["Id"])); };
    }

    public override void RefreshData() =>
        Bind(MasterDataDal.Persons(string.IsNullOrWhiteSpace(_search.Text) ? null : _search.Text.Trim()));

    private void Edit(int? id)
    {
        OpenDialog(new PersonDialog(id));
    }
}
