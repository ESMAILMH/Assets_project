using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>شاشة تسجيل الدخول.</summary>
public sealed class LoginForm : Form
{
    private readonly TextBox _user;
    private readonly TextBox _pass;
    private readonly Label _error;

    public LoginForm()
    {
        Text = "تسجيل الدخول";
        Ui.ApplyRtl(this);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(440, 470);
        BackColor = Theme.Surface;

        var header = new Panel { Dock = DockStyle.Top, Height = 150, BackColor = Theme.Primary };
        var icon = new Label
        {
            Text = "📦", Font = new Font("Segoe UI Emoji", 30F), ForeColor = Color.White,
            Dock = DockStyle.Top, Height = 64, TextAlign = ContentAlignment.BottomCenter
        };
        var title = new Label
        {
            Text = "نظام حصر الأصول وتتبع العهد", Font = Theme.Subtitle, ForeColor = Color.White,
            Dock = DockStyle.Top, Height = 34, TextAlign = ContentAlignment.MiddleCenter
        };
        var org = new Label
        {
            Text = AppSettings.OrganizationName, Font = Theme.Small, ForeColor = Color.FromArgb(210, 225, 240),
            Dock = DockStyle.Top, Height = 26, TextAlign = ContentAlignment.MiddleCenter
        };
        header.Controls.Add(org);
        header.Controls.Add(title);
        header.Controls.Add(icon);

        var body = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(50, 22, 50, 10), ColumnCount = 1 };
        body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        _user = new TextBox { Dock = DockStyle.Top, Font = new Font(Theme.FontName, 12F), PlaceholderText = "اسم المستخدم" };
        _pass = new TextBox { Dock = DockStyle.Top, Font = new Font(Theme.FontName, 12F), PlaceholderText = "كلمة المرور", UseSystemPasswordChar = true };
        var show = new CheckBox { Text = "إظهار كلمة المرور", AutoSize = true, ForeColor = Theme.MutedText };
        show.CheckedChanged += (_, _) => _pass.UseSystemPasswordChar = !show.Checked;
        _error = new Label { AutoSize = true, ForeColor = Theme.Danger, Text = "" };

        var login = Ui.MakeButton("دخول", Theme.Primary, (_, _) => DoLogin());
        login.Dock = DockStyle.Top;
        login.Height = 42;
        login.AutoSize = false;

        var settings = new LinkLabel { Text = "إعدادات الاتصال بقاعدة البيانات", AutoSize = true, LinkColor = Theme.Info };
        settings.LinkClicked += (_, _) => { using var d = new ConnectionDialog(); d.ShowDialog(this); };

        body.Controls.Add(Ui.MakeLabel("اسم المستخدم", Theme.Bold));
        body.Controls.Add(_user);
        body.Controls.Add(Ui.MakeLabel("كلمة المرور", Theme.Bold));
        body.Controls.Add(_pass);
        body.Controls.Add(show);
        body.Controls.Add(_error);
        body.Controls.Add(login);
        body.Controls.Add(settings);
        foreach (Control c in body.Controls) c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        show.Anchor = settings.Anchor = _error.Anchor = AnchorStyles.Right;

        Controls.Add(body);
        Controls.Add(header);
        AcceptButton = login;
    }

    private void DoLogin()
    {
        _error.Text = "";
        if (string.IsNullOrWhiteSpace(_user.Text) || string.IsNullOrEmpty(_pass.Text))
        {
            _error.Text = "الرجاء إدخال اسم المستخدم وكلمة المرور.";
            return;
        }

        Cursor = Cursors.WaitCursor;
        try
        {
            var user = BLL.UserService.Login(_user.Text, _pass.Text);
            if (user == null)
            {
                _error.Text = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                _pass.SelectAll();
                _pass.Focus();
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
