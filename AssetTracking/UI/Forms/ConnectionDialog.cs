using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>ضبط الاتصال بخادم SQL Server وحفظه في ملف الإعدادات.</summary>
public partial class ConnectionDialog : DialogBase
{
    public ConnectionDialog()
    {
        InitializeComponent();
        var b = new SqlConnectionStringBuilder();
        try { b.ConnectionString = AppSettings.ConnectionString; } catch (ArgumentException) { /* نص اتصال غير صالح */ }

        txtServer.Text = string.IsNullOrEmpty(b.DataSource) ? @".\SQLEXPRESS" : b.DataSource;
        txtDatabase.Text = string.IsNullOrEmpty(b.InitialCatalog) ? "AssetsDB" : b.InitialCatalog;
        cmbAuth.Items.AddRange(new object[] { "مصادقة Windows", "مصادقة SQL Server" });
        cmbAuth.SelectedIndex = b.IntegratedSecurity ? 0 : 1;
        txtSqlUser.Text = b.UserID;
        txtSqlPass.Text = b.Password;
        txtOrg.Text = AppSettings.OrganizationName;
        txtDept.Text = AppSettings.DepartmentName;
        cmbAuth.SelectedIndexChanged += (_, _) => UpdateAuth();
        UpdateAuth();
    }

    private void UpdateAuth() => txtSqlUser.Enabled = txtSqlPass.Enabled = cmbAuth.SelectedIndex == 1;

    private string BuildConnectionString()
    {
        var b = new SqlConnectionStringBuilder
        {
            DataSource = txtServer.Text.Trim(),
            InitialCatalog = txtDatabase.Text.Trim(),
            TrustServerCertificate = true,
            ConnectTimeout = 10
        };
        if (cmbAuth.SelectedIndex == 0) b.IntegratedSecurity = true;
        else
        {
            b.UserID = txtSqlUser.Text.Trim();
            b.Password = txtSqlPass.Text;
        }
        return b.ConnectionString;
    }

    private void btnTest_Click(object? sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        bool ok = Db.TestConnection(BuildConnectionString(), out string err);
        Cursor = Cursors.Default;
        if (ok) Ui.Info("تم الاتصال بقاعدة البيانات بنجاح ✔");
        else Ui.Warn("فشل الاتصال:\n" + err + "\n\nتأكد من تشغيل سكربت إنشاء قاعدة البيانات أولاً.");
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        if (string.IsNullOrWhiteSpace(txtServer.Text) || string.IsNullOrWhiteSpace(txtDatabase.Text))
            throw new AppException("الرجاء إدخال اسم الخادم وقاعدة البيانات.");
        AppSettings.ConnectionString = BuildConnectionString();
        AppSettings.OrganizationName = txtOrg.Text.Trim();
        AppSettings.DepartmentName = txtDept.Text.Trim();
        AppSettings.Save();
        Ui.Info("تم حفظ الإعدادات.");
        return true;
    });
}
