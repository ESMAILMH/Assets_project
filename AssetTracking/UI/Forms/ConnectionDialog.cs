using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>ضبط الاتصال بخادم SQL Server وحفظه في ملف الإعدادات.</summary>
public sealed class ConnectionDialog : BaseDialog
{
    private readonly TextBox _server, _database, _user, _pass, _org, _dept;
    private readonly ComboBox _auth;

    public ConnectionDialog() : base("إعدادات الاتصال بقاعدة البيانات", 560)
    {
        var b = new SqlConnectionStringBuilder();
        try { b.ConnectionString = AppSettings.ConnectionString; } catch { /* نص اتصال غير صالح */ }

        _server = AddText("اسم الخادم");
        _server.Text = string.IsNullOrEmpty(b.DataSource) ? @".\SQLEXPRESS" : b.DataSource;
        _server.RightToLeft = RightToLeft.No;

        _database = AddText("قاعدة البيانات");
        _database.Text = string.IsNullOrEmpty(b.InitialCatalog) ? "AssetsDB" : b.InitialCatalog;
        _database.RightToLeft = RightToLeft.No;

        _auth = AddField("طريقة الدخول", Ui.MakeCombo());
        _auth.Items.AddRange(new object[] { "مصادقة Windows", "مصادقة SQL Server" });
        _auth.SelectedIndex = b.IntegratedSecurity ? 0 : 1;

        _user = AddText("اسم مستخدم SQL");
        _user.Text = b.UserID;
        _user.RightToLeft = RightToLeft.No;
        _pass = AddText("كلمة مرور SQL");
        _pass.UseSystemPasswordChar = true;
        _pass.Text = b.Password;

        _org = AddText("اسم المؤسسة (للتقارير)");
        _org.Text = AppSettings.OrganizationName;
        _dept = AddText("القسم (للتقارير)");
        _dept.Text = AppSettings.DepartmentName;

        _auth.SelectedIndexChanged += (_, _) => UpdateAuth();
        UpdateAuth();

        var test = Ui.MakeButton("اختبار الاتصال", Theme.Info, (_, _) =>
        {
            Cursor = Cursors.WaitCursor;
            bool ok = Db.TestConnection(Build(), out string err);
            Cursor = Cursors.Default;
            if (ok) Ui.Info("تم الاتصال بقاعدة البيانات بنجاح ✔");
            else Ui.Warn("فشل الاتصال:\n" + err + "\n\nتأكد من تشغيل سكربت إنشاء قاعدة البيانات أولاً.");
        });
        Buttons.Controls.Add(test);
    }

    private void UpdateAuth() => _user.Enabled = _pass.Enabled = _auth.SelectedIndex == 1;

    private string Build()
    {
        var b = new SqlConnectionStringBuilder
        {
            DataSource = _server.Text.Trim(),
            InitialCatalog = _database.Text.Trim(),
            TrustServerCertificate = true,
            ConnectTimeout = 10
        };
        if (_auth.SelectedIndex == 0) b.IntegratedSecurity = true;
        else
        {
            b.UserID = _user.Text.Trim();
            b.Password = _pass.Text;
        }
        return b.ConnectionString;
    }

    protected override bool Save()
    {
        if (string.IsNullOrWhiteSpace(_server.Text) || string.IsNullOrWhiteSpace(_database.Text))
            throw new AppException("الرجاء إدخال اسم الخادم وقاعدة البيانات.");
        AppSettings.ConnectionString = Build();
        AppSettings.OrganizationName = _org.Text.Trim();
        AppSettings.DepartmentName = _dept.Text.Trim();
        AppSettings.Save();
        Ui.Info("تم حفظ الإعدادات.");
        return true;
    }
}
