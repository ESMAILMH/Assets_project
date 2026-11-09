using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>الأشخاص (أصحاب العهد): الفعّالون والمعطّلون.</summary>
public partial class PersonsPage : PageBase
{
    public PersonsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الاسم، الرقم الوظيفي، القسم، الهاتف...";
        InitChips("active", btnChipActive, btnChipInactive, btnChipAll);
        InitRowActions(btnEdit, btnEdit, btnStatement);
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is DataRowView r && !(bool)r["IsActive"])
                e.CellStyle!.ForeColor = Theme.MutedText;
        };
    }

    public override void RefreshData()
    {
        var all = MasterDataDal.Persons(Ui.NullIfEmpty(txtSearch.Text));
        var rows = all.AsEnumerable().ToList();
        int active = rows.Count(r => (bool)r["IsActive"]);
        ChipText(btnChipActive, "فعّال", active);
        ChipText(btnChipInactive, "معطّل", rows.Count - active);
        ChipText(btnChipAll, "الكل", rows.Count);
        var shown = rows.Where(r => Chip == null || (bool)r["IsActive"] == (Chip == "active")).ToList();
        Bind(shown.Count > 0 ? shown.CopyToDataTable() : all.Clone());
    }

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
