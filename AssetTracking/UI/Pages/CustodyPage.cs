using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>التسليم والاستلام: العهد المفتوحة أو كل الحركات خلال فترة، مع طباعة المحاضر.</summary>
public partial class CustodyPage : PageBase
{
    public CustodyPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الأصل، الرقم التسلسلي، صاحب العهدة...";
        dtpFrom.Value = DateTime.Today.AddMonths(-6);
        dtpTo.Value = DateTime.Today;
        dtpFrom.ValueChanged += Filter_Changed;
        dtpTo.ValueChanged += Filter_Changed;
        InitChips("open", btnChipOpen, btnChipAll);
        InitRowActions(btnDocument, btnDocument, btnReceive);
    }

    private bool OpenOnly => Chip == "open";

    public override void RefreshData()
    {
        string? text = Ui.NullIfEmpty(txtSearch.Text);
        dtpFrom.Enabled = dtpTo.Enabled = lblFrom.Enabled = lblTo.Enabled = !OpenOnly;
        var open = CustodyDal.Search(text, true, null, null);
        ChipText(btnChipOpen, "العهد المفتوحة", open.Rows.Count);
        Bind(OpenOnly ? open : CustodyDal.Search(text, false, dtpFrom.Value, dtpTo.Value));
    }

    /// <summary>"استلام" للعهد المفتوحة فقط.</summary>
    protected override void OnRowSelected(DataRowView? row) =>
        btnReceive.Enabled = row != null && row["تاريخ الاستلام"] == DBNull.Value;

    private void btnHandover_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new HandoverDialog()));
    private void btnReceive_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new ReceiveDialog((int)r["AssetId"])); });
    private void btnDocument_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) ReportPrinter.Preview(ReportCatalog.CustodyDocument((int)r["Id"]), FindForm()); });

    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => PrintGrid("حركات العهد", OpenOnly ? "العهد المفتوحة" : $"من {dtpFrom.Value:yyyy/MM/dd} إلى {dtpTo.Value:yyyy/MM/dd}"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("حركات العهد"));
}
