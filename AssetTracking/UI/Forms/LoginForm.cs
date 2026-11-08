using AssetTracking.BLL;

namespace AssetTracking.Forms;

/// <summary>شاشة تسجيل الدخول.</summary>
public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        lblOrg.Text = AppSettings.OrganizationName;
        txtUser.PlaceholderText = "اسم المستخدم";
        txtPass.PlaceholderText = "كلمة المرور";
    }

    private void chkShow_CheckedChanged(object? sender, EventArgs e) => txtPass.UseSystemPasswordChar = !chkShow.Checked;

    private void lnkSettings_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        using var d = new ConnectionDialog();
        d.ShowDialog(this);
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        lblError.Text = "";
        if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
        {
            lblError.Text = "الرجاء إدخال اسم المستخدم وكلمة المرور.";
            return;
        }

        Cursor = Cursors.WaitCursor;
        try
        {
            if (UserService.Login(txtUser.Text, txtPass.Text) == null)
            {
                lblError.Text = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                txtPass.SelectAll();
                txtPass.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            Ui.ShowError(ex);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }
}
