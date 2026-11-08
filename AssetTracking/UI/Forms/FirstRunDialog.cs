using AssetTracking.BLL;

namespace AssetTracking.Forms;

/// <summary>أول تشغيل: إنشاء حساب المدير (كلمة المرور تُشفَّر في C#).</summary>
public sealed class FirstRunDialog : BaseDialog
{
    private readonly TextBox _user, _pass, _confirm;

    public FirstRunDialog() : base("أول تشغيل — إنشاء حساب المدير", 480)
    {
        AddInfo("", "لا يوجد أي مستخدم في النظام. أنشئ حساب المدير:");
        _user = AddText("اسم المستخدم", 50);
        _user.Text = "admin";
        _pass = AddText("كلمة المرور", 100);
        _confirm = AddText("تأكيد كلمة المرور", 100);
        _pass.UseSystemPasswordChar = _confirm.UseSystemPasswordChar = true;
        BtnSave.Text = "إنشاء";
    }

    protected override bool Save()
    {
        if (_pass.Text != _confirm.Text) throw new AppException("كلمة المرور وتأكيدها غير متطابقين.");
        UserService.CreateFirstManager(_user.Text, _pass.Text);
        Ui.Info("تم إنشاء حساب المدير. سجّل الدخول الآن.");
        return true;
    }
}
