using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>التخريد: طلبات أمين المخزن واعتماد المدير.</summary>
public partial class DisposalPage : PageBase
{
    public DisposalPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount);
        btnDecide.Visible = Session.IsManager;
        InitChips("Proposed", btnChipProposed, btnChipApproved, btnChipRejected, btnChipAll);
        InitRowActions(btnDecide, btnDecide);
        Ui.ColorBy(grid, "Status", "الحالة", s => s switch
        {
            "Proposed" => Theme.Warning, "Approved" => Theme.Danger, _ => Theme.MutedText
        });
    }

    public override void RefreshData()
    {
        var counts = DisposalDal.CountByStatus();
        int N(string s) => counts.GetValueOrDefault(s);
        ChipText(btnChipProposed, "بانتظار المدير", N("Proposed"));
        ChipText(btnChipApproved, "معتمد", N("Approved"));
        ChipText(btnChipRejected, "مرفوض", N("Rejected"));
        ChipText(btnChipAll, "الكل", counts.Values.Sum());
        Bind(DisposalDal.Search(Chip, null, null));
    }

    /// <summary>القرار للطلبات المنتظرة فقط.</summary>
    protected override void OnRowSelected(DataRowView? row) =>
        btnDecide.Enabled = row != null && (string)row["Status"] == "Proposed";

    private void btnDecide_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        OpenDialog(new DisposalDecisionDialog((int)r["Id"], $"{r["الرقم التسلسلي"]} - {r["الأصل"]}", (string)r["السبب"]));
    });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("طلبات التخريد"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("طلبات التخريد"));
}
