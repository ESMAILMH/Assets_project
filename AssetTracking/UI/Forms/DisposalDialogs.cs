using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>اقتراح إحالة أصل للتخريد (UC-11) — أمين المخزن.</summary>
public sealed class ProposeDisposalDialog : BaseDialog
{
    private readonly int _assetId;
    private readonly TextBox _reason;

    public ProposeDisposalDialog(int assetId, string? reason = null) : base("اقتراح إحالة للتخريد", 540)
    {
        _assetId = assetId;
        var a = AssetDal.Get(assetId) ?? throw new AppException("الأصل غير موجود.");
        AddInfo("الأصل", $"{a["SerialNo"]} - {a["Name"]}");
        AddInfo("القيمة الدفترية", Ui.Money((decimal)a["BookValue"]));
        AddInfo("المتبقي من العمر", $"{Convert.ToInt32(a["RemainingMonths"])} شهر");
        _reason = AddText("سبب التخريد *", 300, multiline: true);
        _reason.Text = reason ?? (Convert.ToInt32(a["RemainingMonths"]) == 0 ? "انتهاء العمر الافتراضي" : "");
        BtnSave.Text = "إرسال للمدير";
    }

    protected override bool Save()
    {
        OperationsService.ProposeDisposal(_assetId, _reason.Text);
        Ui.Info("تم إرسال الاقتراح إلى المدير لاعتماده.");
        return true;
    }
}

/// <summary>اعتماد أو رفض التخريد (UC-12) — المدير.</summary>
public sealed class DisposalDecisionDialog : BaseDialog
{
    private readonly int _disposalId;
    private readonly RadioButton _approve, _reject;
    private readonly TextBox _doc;

    public DisposalDecisionDialog(int disposalId, string assetTitle, string reason) : base("قرار التخريد", 520)
    {
        _disposalId = disposalId;
        AddInfo("الأصل", assetTitle);
        AddInfo("السبب", reason);
        var choice = new FlowLayoutPanel { AutoSize = true };
        _approve = new RadioButton { Text = "اعتماد التخريد", Checked = true, AutoSize = true };
        _reject = new RadioButton { Text = "رفض (يبقى الأصل في الخدمة)", AutoSize = true };
        choice.Controls.Add(_approve);
        choice.Controls.Add(_reject);
        AddField("القرار", choice);
        _doc = AddText("رقم المحضر", 50);
        _reject.CheckedChanged += (_, _) => _doc.Enabled = _approve.Checked;
        BtnSave.Text = "تأكيد";
    }

    protected override bool Save()
    {
        if (_approve.Checked && !Ui.Confirm("بعد الاعتماد تصبح حالة الأصل \"مُخرَّد\" ولا يُسلَّم بعدها. متابعة؟")) return false;
        OperationsService.DecideDisposal(_disposalId, _approve.Checked, _doc.Text);
        return true;
    }
}
