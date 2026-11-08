using AssetTracking.BLL;

namespace AssetTracking.Forms;

/// <summary>أول تشغيل: إنشاء حساب المدير.</summary>
public partial class FirstRunDialog : DialogBase
{
    public FirstRunDialog()
    {
        InitializeComponent();
        lblInfo.Text = "لا يوجد أي مستخدم في النظام. أنشئ حساب المدير.";
        txtUser.Text = "admin";
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        if (txtPass.Text != txtConfirm.Text) throw new AppException("كلمة المرور وتأكيدها غير متطابقين.");
        UserService.CreateFirstManager(txtUser.Text, txtPass.Text);
        Ui.Info("تم إنشاء حساب المدير. سجّل الدخول الآن.");
        return true;
    });
}
