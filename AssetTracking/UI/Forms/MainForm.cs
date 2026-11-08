using AssetTracking.BLL;
using AssetTracking.DAL;
using AssetTracking.Pages;

namespace AssetTracking.Forms;

/// <summary>
/// النافذة الرئيسية: قائمة جانبية بالصفحات ومنطقة عرض الصفحة.
/// أزرار القائمة مصممة في المصمم، ويُخفى منها ما لا يسمح به دور المستخدم.
/// كل زر يحمل في خاصية Tag اسم الصفحة التي يفتحها.
/// </summary>
public partial class MainForm : Form
{
    private static readonly Font MenuFont = new(Theme.FontName, 10.5F);
    private static readonly Font MenuFontActive = new(Theme.FontName, 10.5F, FontStyle.Bold);
    private readonly Dictionary<string, Control> _pages = new();
    private readonly System.Windows.Forms.Timer _alertTimer = new() { Interval = 5 * 60 * 1000 };
    private Button? _active;

    public bool LogoutRequested { get; private set; }

    public MainForm()
    {
        InitializeComponent();
        var user = Session.Current ?? throw new InvalidOperationException("لا يوجد مستخدم مسجل.");
        Text = "نظام حصر الأصول وتتبع العهد - " + AppSettings.OrganizationName;
        lblFooter.Text = AppSettings.OrganizationName;
        lblCurrentUser.Text = $"👤 {user.DisplayName}  ({Labels.Of(Labels.Roles, user.Role.ToString())})";
        ApplyRole(user);

        KeyDown += (_, e) =>   // F5 = تحديث الصفحة الحالية
        {
            if (e.KeyCode != Keys.F5 || pnlContent.Controls.Count == 0 || pnlContent.Controls[0] is not IPage page) return;
            Ui.Try(page.RefreshData);
            UpdateAlertCount();
        };
        _alertTimer.Tick += (_, _) => UpdateAlertCount();
        _alertTimer.Start();
        Shown += (_, _) => flpMenu.Controls.Cast<Button>().First(b => b.Visible).PerformClick();
    }

    /// <summary>إظهار أزرار القائمة حسب الدور (الصلاحية تُفحص أيضاً داخل كل عملية في طبقة المنطق).</summary>
    private void ApplyRole(AppUser user)
    {
        bool employee = user.Role == UserRole.Employee, manager = user.Role == UserRole.Manager;
        foreach (Button b in flpMenu.Controls)
        {
            string page = (string)b.Tag!;
            b.Visible = page switch
            {
                "MyAssets" => employee || user.PersonId != null,
                "Users" or "Audit" => manager,
                _ => !employee
            };
        }
        UpdateAlertCount();
    }

    /// <summary>الصفحة التي يفتحها كل زر (حسب Tag).</summary>
    private static Control CreatePage(string key) => key switch
    {
        "Dashboard" => new DashboardPage(),
        "Assets" => new AssetsPage(),
        "Custody" => new CustodyPage(),
        "Alerts" => new AlertsPage(),
        "Disposal" => new DisposalPage(),
        "Inventory" => new InventoryPage(),
        "Persons" => new PersonsPage(),
        "MasterData" => new MasterDataPage(),
        "Reports" => new ReportsPage(),
        "MyAssets" => new MyAssetsPage(),
        "Users" => new UsersPage(),
        "Audit" => new AuditPage(),
        _ => throw new ArgumentException(key)
    };

    private void Menu_Click(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        Ui.Try(() =>
        {
            string key = (string)button.Tag!;
            bool isNew = !_pages.TryGetValue(key, out var page);
            if (isNew)
            {
                page = CreatePage(key);
                page.Dock = DockStyle.Fill;
                _pages[key] = page;
            }
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page!);
            if (!isNew && page is IPage p) p.RefreshData();

            if (_active != null) { _active.BackColor = Theme.Sidebar; _active.Font = MenuFont; }
            _active = button;
            button.BackColor = Theme.SidebarActive;
            button.Font = MenuFontActive;
            UpdateAlertCount();
        });
    }

    /// <summary>عدّاد التنبيهات على زر التنبيهات (FR-20).</summary>
    private void UpdateAlertCount()
    {
        if (!btnAlerts.Visible) return;
        try
        {
            int n = AssetDal.AlertCount();
            btnAlerts.Text = n > 0 ? $"⏰   التنبيهات  ({n})" : "⏰   التنبيهات";
            btnAlerts.ForeColor = n > 0 ? Color.FromArgb(255, 196, 92) : Color.White;
        }
        catch (Exception) { /* لا نوقف الواجهة بسبب العدّاد */ }
    }

    private void btnChangePassword_Click(object? sender, EventArgs e)
    {
        using var d = new ChangePasswordDialog();
        d.ShowDialog(this);
    }

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        if (!Ui.Confirm("هل تريد تسجيل الخروج؟")) return;
        Ui.Try(UserService.Logout);
        LogoutRequested = true;
        Close();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _alertTimer.Dispose();
        foreach (var p in _pages.Values) p.Dispose();
        base.OnFormClosed(e);
    }
}
