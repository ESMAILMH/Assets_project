using AssetTracking.BLL;

namespace AssetTracking.Forms;

public partial class ResetPasswordDialog : DialogBase
{
    private readonly int _userId;

    public ResetPasswordDialog(int userId, string username)
    {
        InitializeComponent();
        _userId = userId;
        lblUserValue.Text = username;
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        if (txtPass.Text != txtConfirm.Text) throw new AppException("كلمة المرور وتأكيدها غير متطابقين.");
        UserService.ResetPassword(_userId, txtPass.Text);
        Ui.Info("تم تعيين كلمة المرور الجديدة.");
        return true;
    });
}
