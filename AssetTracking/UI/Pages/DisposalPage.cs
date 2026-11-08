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
        cmbStatus.SelectedIndexChanged += Filter_Changed;
        grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && Session.IsManager) btnDecide_Click(null, EventArgs.Empty); };
        Ui.ColorBy(grid, "Status", "الحالة", s => s switch
        {
            "Proposed" => Theme.Warning, "Approved" => Theme.Danger, _ => Theme.MutedText
        });
    }

    public override void RefreshData()
    {
        if (cmbStatus.DataSource == null)
        {
            Ui.BindCombo(cmbStatus, Labels.WithAll(Labels.DisposalStatuses));
            cmbStatus.SelectedValue = "Proposed";
        }
        Bind(DisposalDal.Search(Ui.SelectedCode(cmbStatus), null, null));
    }

    private void btnDecide_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        if ((string)r["Status"] != "Proposed") { Ui.Info("تم البت في هذا الطلب مسبقاً."); return; }
        OpenDialog(new DisposalDecisionDialog((int)r["Id"], $"{r["الرقم التسلسلي"]} - {r["الأصل"]}", (string)r["السبب"]));
    });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("طلبات التخريد"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("طلبات التخريد"));
}
