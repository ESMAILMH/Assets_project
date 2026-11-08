namespace AssetTracking.Forms;

public sealed class ChangePasswordDialog : BaseDialog
{
    private readonly TextBox _current, _new, _confirm;

    public ChangePasswordDialog() : base("تغيير كلمة المرور", 460)
    {
        _current = AddText("كلمة المرور الحالية");
        _new = AddText("كلمة المرور الجديدة");
        _confirm = AddText("تأكيد كلمة المرور");
        _current.UseSystemPasswordChar = _new.UseSystemPasswordChar = _confirm.UseSystemPasswordChar = true;
    }

    protected override bool Save()
    {
        if (_new.Text != _confirm.Text) throw new AppException("كلمة المرور الجديدة وتأكيدها غير متطابقين.");
        BLL.UserService.ChangeOwnPassword(_current.Text, _new.Text);
        Ui.Info("تم تغيير كلمة المرور بنجاح.");
        return true;
    }
}
