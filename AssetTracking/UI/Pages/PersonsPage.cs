using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>الأشخاص (أصحاب العهد).</summary>
public partial class PersonsPage : PageBase
{
    public PersonsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الاسم، الرقم الوظيفي، القسم، الهاتف...";
        grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) btnEdit_Click(null, EventArgs.Empty); };
    }

    public override void RefreshData() => Bind(MasterDataDal.Persons(Ui.NullIfEmpty(txtSearch.Text)));

    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new PersonDialog(null)));
    private void btnEdit_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new PersonDialog((int)r["Id"])); });

    private void btnStatement_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is { } r)
            ReportPrinter.Preview(ReportCatalog.PersonStatement(new ReportFilterValues { PersonId = (int)r["Id"] }), FindForm());
    });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("الأشخاص"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("الأشخاص"));
}
