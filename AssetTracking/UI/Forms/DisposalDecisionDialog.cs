using AssetTracking.BLL;

namespace AssetTracking.Forms;

/// <summary>اعتماد أو رفض التخريد (UC-12) — المدير.</summary>
public partial class DisposalDecisionDialog : DialogBase
{
    private readonly int _disposalId;

    public DisposalDecisionDialog(int disposalId, string assetTitle, string reason)
    {
        InitializeComponent();
        _disposalId = disposalId;
        lblAssetValue.Text = assetTitle;
        lblReasonValue.Text = reason;
    }

    private void rdoApprove_CheckedChanged(object? sender, EventArgs e) => txtDocumentNo.Enabled = rdoApprove.Checked;

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        if (rdoApprove.Checked && !Ui.Confirm("بعد الاعتماد تصبح حالة الأصل \"مُخرَّد\" ولا يُسلَّم بعدها. متابعة؟")) return false;
        OperationsService.DecideDisposal(_disposalId, rdoApprove.Checked, txtDocumentNo.Text);
        return true;
    });
}
