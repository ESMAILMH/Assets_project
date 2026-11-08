using AssetTracking.BLL;
using AssetTracking.DAL;
using AssetTracking.Pages;

namespace AssetTracking.Forms;

/// <summary>النافذة الرئيسية: قائمة جانبية حسب دور المستخدم، ومنطقة عرض الصفحة.</summary>
public sealed class MainForm : Form
{
    private readonly Panel _content;
    private readonly FlowLayoutPanel _menu;
    private readonly Dictionary<string, Control> _pages = new();
    private Button? _active, _alertsButton;
    private readonly System.Windows.Forms.Timer _alertTimer = new() { Interval = 5 * 60 * 1000 };

    private static readonly Font MenuFont = new(Theme.FontName, 10.5F);
    private static readonly Font MenuFontActive = new(Theme.FontName, 10.5F, FontStyle.Bold);

    public bool LogoutRequested { get; private set; }

    public MainForm()
    {
        var user = Session.Current ?? throw new InvalidOperationException();
        Text = "نظام حصر الأصول وتتبع العهد - " + AppSettings.OrganizationName;
        Ui.ApplyRtl(this);
        WindowState = FormWindowState.Maximized;
        MinimumSize = new Size(1150, 700);
        BackColor = Theme.Background;

        // الشريط العلوي
        var header = new Panel { Dock = DockStyle.Top, Height = 58, BackColor = Theme.Surface };
        var title = new Label
        {
            Text = "نظام حصر الأصول وتتبع العهد", Font = Theme.Subtitle, ForeColor = Theme.Primary,
            Dock = DockStyle.Left, Width = 420, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(16, 0, 0, 0)
        };
        var userBox = new FlowLayoutPanel { Dock = DockStyle.Right, AutoSize = true, WrapContents = false, Padding = new Padding(8, 10, 8, 0), FlowDirection = FlowDirection.RightToLeft };
        userBox.Controls.Add(Ui.MakeButton("تسجيل الخروج", Theme.Danger, (_, _) => Logout()));
        userBox.Controls.Add(Ui.MakeButton("تغيير كلمة المرور", Theme.Neutral, (_, _) => { using var d = new ChangePasswordDialog(); d.ShowDialog(this); }));
        userBox.Controls.Add(Ui.MakeLabel($"👤 {user.DisplayName}  ({Labels.Of(Labels.Roles, user.Role.ToString())})", Theme.Bold));
        header.Controls.Add(userBox);
        header.Controls.Add(title);

        // القائمة الجانبية
        var sidebar = new Panel { Dock = DockStyle.Left, Width = 240, BackColor = Theme.Sidebar };
        _menu = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true, Padding = new Padding(0, 6, 0, 0) };
        sidebar.Controls.Add(_menu);
        sidebar.Controls.Add(new Label
        {
            Text = AppSettings.OrganizationName, ForeColor = Color.FromArgb(150, 165, 185), Font = Theme.Small,
            Dock = DockStyle.Bottom, Height = 44, TextAlign = ContentAlignment.MiddleCenter
        });
        sidebar.Controls.Add(new Label
        {
            Text = "حصر الأصول", Font = new Font(Theme.FontName, 13F, FontStyle.Bold), ForeColor = Color.White,
            Dock = DockStyle.Top, Height = 64, TextAlign = ContentAlignment.MiddleCenter
        });

        _content = new Panel { Dock = DockStyle.Fill };
        Controls.Add(_content);
        Controls.Add(sidebar);
        Controls.Add(header);

        BuildMenu();
        KeyPreview = true; // F5 = تحديث الصفحة الحالية
        KeyDown += (_, e) =>
        {
            if (e.KeyCode != Keys.F5 || _content.Controls.Count == 0 || _content.Controls[0] is not IPage page) return;
            Ui.Try(page.RefreshData);
            UpdateAlertCount();
        };
        _alertTimer.Tick += (_, _) => UpdateAlertCount();
        _alertTimer.Start();
    }

    /// <summary>القائمة حسب الصلاحية (تُفحص الصلاحية أيضاً داخل كل عملية في طبقة المنطق).</summary>
    private void BuildMenu()
    {
        var role = Session.Current!.Role;
        if (role == UserRole.Employee)
        {
            AddMenu("🧾", "أصولي", () => new MyAssetsPage());
        }
        else
        {
            AddMenu("🏠", "الشاشة الرئيسية", () => new DashboardPage());
            AddMenu("📦", "الأصول", () => new AssetsPage());
            AddMenu("🔁", "التسليم والاستلام", () => new CustodyPage());
            _alertsButton = AddMenu("⏰", "التنبيهات", () => new AlertsPage());
            AddMenu("♻", "التخريد", () => new DisposalPage());
            AddMenu("📋", "الجرد", () => new InventoryPage());
            AddMenu("👥", "الأشخاص", () => new PersonsPage());
            AddMenu("🗂", "الأقسام والمواقع والتصنيفات", () => new MasterDataPage());
            AddMenu("📊", "التقارير", () => new ReportsPage());
            if (Session.Current.PersonId != null) AddMenu("🧾", "أصولي", () => new MyAssetsPage());
            if (role == UserRole.Manager)
            {
                AddMenu("🔐", "المستخدمون", () => new UsersPage());
                AddMenu("📜", "سجل العمليات", () => new AuditPage());
            }
            UpdateAlertCount();
        }
        ((Button)_menu.Controls[0]).PerformClick();
    }

    /// <summary>عدّاد التنبيهات على زر التنبيهات (FR-20).</summary>
    private void UpdateAlertCount()
    {
        if (_alertsButton == null) return;
        try
        {
            int n = AssetDal.AlertCount();
            _alertsButton.Text = n > 0 ? $"⏰   التنبيهات  ({n})" : "⏰   التنبيهات";
            _alertsButton.ForeColor = n > 0 ? Color.FromArgb(255, 196, 92) : Color.White;
        }
        catch (Exception) { /* لا نوقف الواجهة بسبب العدّاد */ }
    }

    private Button AddMenu(string icon, string text, Func<Control> factory)
    {
        var b = new Button
        {
            Text = $"{icon}   {text}", Tag = text, Width = 240, Height = 46, FlatStyle = FlatStyle.Flat, ForeColor = Color.White, BackColor = Theme.Sidebar,
            Font = MenuFont, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(18, 0, 0, 0),
            Margin = Padding.Empty, Cursor = Cursors.Hand
        };
        b.FlatAppearance.BorderSize = 0;
        b.FlatAppearance.MouseOverBackColor = Theme.SidebarHover;
        b.Click += (_, _) => Ui.Try(() => ShowPage(text, factory, b));
        _menu.Controls.Add(b);
        return b;
    }

    private void ShowPage(string key, Func<Control> factory, Button button)
    {
        if (_active != null)
        {
            _active.BackColor = Theme.Sidebar;
            _active.Font = MenuFont;
        }
        _active = button;
        button.BackColor = Theme.SidebarActive;
        button.Font = MenuFontActive;

        bool isNew = !_pages.TryGetValue(key, out var page);
        if (isNew) _pages[key] = page = factory();
        _content.Controls.Clear();
        _content.Controls.Add(page!);
        if (!isNew && page is IPage p) p.RefreshData();
        UpdateAlertCount();
    }

    private void Logout()
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
