using AssetTracking.BLL;

namespace AssetTracking.Forms;

public partial class ChangePasswordDialog : DialogBase
{
    public ChangePasswordDialog()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        if (txtNew.Text != txtConfirm.Text) throw new AppException("كلمة المرور الجديدة وتأكيدها غير متطابقين.");
        UserService.ChangeOwnPassword(txtCurrent.Text, txtNew.Text);
        Ui.Info("تم تغيير كلمة المرور بنجاح.");
        return true;
    });
}
