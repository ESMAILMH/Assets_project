using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>اقتراح إحالة أصل للتخريد (UC-11) — أمين المخزن.</summary>
public partial class ProposeDisposalDialog : DialogBase
{
    private readonly int _assetId;

    public ProposeDisposalDialog(int assetId, string? reason = null)
    {
        InitializeComponent();
        _assetId = assetId;
        var a = AssetDal.Get(assetId) ?? throw new AppException("الأصل غير موجود.");
        int remaining = Convert.ToInt32(a["RemainingMonths"]);
        lblAssetValue.Text = $"{a["SerialNo"]} - {a["Name"]}";
        lblBookValue.Text = Ui.Money((decimal)a["BookValue"]);
        lblRemainingValue.Text = $"{remaining} شهر";
        txtReason.Text = reason ?? (remaining == 0 ? "انتهاء العمر الافتراضي" : "");
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        OperationsService.ProposeDisposal(_assetId, txtReason.Text);
        Ui.Info("تم إرسال الاقتراح إلى المدير لاعتماده.");
        return true;
    });
}
