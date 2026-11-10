using System.Drawing.Drawing2D;
using AssetTracking.BLL;
using AssetTracking.DAL;
using AssetTracking.Pages;

namespace AssetTracking.Forms;

/// <summary>
/// النافذة الرئيسية: قائمة جانبية مقسمة إلى مجموعات + شريط علوي باسم الصفحة الحالية + منطقة عرض الصفحة.
/// أزرار القائمة وعناوين المجموعات مصممة في المصمم؛ كل زر يحمل في Tag اسم الصفحة التي يفتحها،
/// ونصه بالشكل "رمز   الاسم". ما لا يسمح به دور المستخدم يُخفى عند التشغيل.
/// </summary>
public partial class MainForm : Form
{
    private static readonly Color ActiveBack = Color.FromArgb(30, 77, 120);
    private static readonly Color ActiveStripe = Color.FromArgb(96, 175, 255);
    private static readonly Color MenuText = Color.FromArgb(203, 213, 225);
    private static readonly Font MenuFont = new(Theme.FontName, 10.5F);
    private static readonly Font MenuFontActive = new(Theme.FontName, 10.5F, FontStyle.Bold);

    private readonly Dictionary<string, Control> _pages = new();
    private readonly Dictionary<Button, (string Icon, string Name)> _items = new();
    private readonly HashSet<Control> _allowed = new();        // ما يسمح به الدور من أزرار وعناوين
    private readonly System.Windows.Forms.Timer _alertTimer = new() { Interval = 5 * 60 * 1000 };
    private Button? _active;
    private int _alerts;

    public bool LogoutRequested { get; private set; }

    public MainForm()
    {
        InitializeComponent();
        Ui.ApplyIcon(this);
        var user = Session.Current ?? throw new InvalidOperationException("لا يوجد مستخدم مسجل.");
        Text = "نظام حصر الأصول وتتبع العهد - " + AppSettings.OrganizationName;
        lblFooter.Text = AppSettings.OrganizationName;

        // بطاقة المستخدم: أول حرف من الاسم داخل دائرة
        lblUserName.Text = user.DisplayName;
        lblUserRole.Text = Labels.Of(Labels.Roles, user.Role.ToString());
        lblAvatar.Text = user.DisplayName.Trim().FirstOrDefault().ToString();
        using (var circle = new GraphicsPath())
        {
            circle.AddEllipse(0, 0, lblAvatar.Width, lblAvatar.Height);
            lblAvatar.Region = new Region(circle);
        }

        foreach (var b in flpMenu.Controls.OfType<Button>())
        {
            var parts = b.Text.Split("   ", 2);
            _items[b] = (parts[0], parts.Length > 1 ? parts[1] : b.Text);
            b.Paint += MenuButton_Paint;
            b.SizeChanged += (_, _) => RoundCorners(b);
            RoundCorners(b);
        }
        ApplyRole(user);

        KeyDown += (_, e) =>   // F5 = تحديث الصفحة الحالية
        {
            if (e.KeyCode != Keys.F5 || pnlContent.Controls.Count == 0 || pnlContent.Controls[0] is not IPage page) return;
            Ui.Try(page.RefreshData);
            UpdateAlertCount();
        };
        _alertTimer.Tick += (_, _) => UpdateAlertCount();
        _alertTimer.Start();
        Shown += (_, _) => _items.Keys.First(b => b.Visible).PerformClick();
    }

    // ------------------------------------------------------------ الصلاحيات
    /// <summary>
    /// يظهر من القائمة ما يسمح به دور المستخدم فقط (والصلاحية تُفحص أيضاً داخل كل عملية في طبقة المنطق).
    /// عنوان المجموعة يُخفى إذا لم يبقَ تحته أي زر ظاهر.
    /// </summary>
    private void ApplyRole(AppUser user)
    {
        bool employee = user.Role == UserRole.Employee, manager = user.Role == UserRole.Manager;
        Label? section = null;
        foreach (Control c in flpMenu.Controls)
        {
            if (c is Label l) { section = l; continue; }
            bool ok = (string)c.Tag! switch
            {
                "MyAssets" => employee || user.PersonId != null,
                "Users" or "Audit" => manager,
                _ => !employee
            };
            if (!ok) continue;
            _allowed.Add(c);
            if (section != null) _allowed.Add(section);
        }
        RenderMenu();
    }

    // ------------------------------------------------------------ شكل القائمة
    /// <summary>القائمة ثابتة: تظهر الأزرار والعناوين المسموح بها فقط.</summary>
    private void RenderMenu()
    {
        foreach (Control c in flpMenu.Controls) c.Visible = _allowed.Contains(c);
    }

    private string ButtonText(Button b)
    {
        var (icon, name) = _items[b];
        return b == btnAlerts && _alerts > 0 ? $"{icon}   {name}  ({_alerts})" : $"{icon}   {name}";
    }

    /// <summary>زوايا دائرية للأزرار.</summary>
    private static void RoundCorners(Button b)
    {
        using var path = new GraphicsPath();
        const int r = 10;
        var rect = new Rectangle(0, 0, b.Width, b.Height);
        path.AddArc(rect.X, rect.Y, r, r, 180, 90);
        path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
        path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
        path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
        path.CloseFigure();
        b.Region = new Region(path);
    }

    /// <summary>شريط ملوّن على جانب الزر النشط.</summary>
    private void MenuButton_Paint(object? sender, PaintEventArgs e)
    {
        if (sender != _active) return;
        using var brush = new SolidBrush(ActiveStripe);
        e.Graphics.FillRectangle(brush, 0, 8, 4, ((Control)sender!).Height - 16); // في الواجهة العربية يظهر على اليمين
    }

    // ------------------------------------------------------------ التنقل بين الصفحات
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
                // بطاقات وأزرار الشاشة الرئيسية تفتح صفحات أخرى
                if (page is DashboardPage dashboard) dashboard.Navigate += OpenPage;
                _pages[key] = page;
            }
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page!);
            if (!isNew && page is IPage p) p.RefreshData();

            var previous = _active;
            _active = button;
            if (previous != null)
            {
                previous.BackColor = Theme.Sidebar;
                previous.ForeColor = MenuText;
                previous.Font = MenuFont;
                previous.Invalidate();
            }
            button.BackColor = ActiveBack;
            button.ForeColor = Color.White;
            button.Font = MenuFontActive;
            lblPageTitle.Text = $"{_items[button].Icon}  {_items[button].Name}";
            UpdateAlertCount();
        });
    }

    /// <summary>فتح صفحة باسمها (كما في Tag الزر)، إذا كان الدور يسمح بها.</summary>
    private void OpenPage(string key) =>
        _items.Keys.FirstOrDefault(b => (string)b.Tag! == key && _allowed.Contains(b))?.PerformClick();

    /// <summary>عدّاد التنبيهات على زر التنبيهات (FR-20).</summary>
    private void UpdateAlertCount()
    {
        if (!_allowed.Contains(btnAlerts)) return;
        try
        {
            _alerts = AssetDal.AlertCount();
            btnAlerts.Text = ButtonText(btnAlerts);
            if (btnAlerts != _active) btnAlerts.ForeColor = _alerts > 0 ? Color.FromArgb(255, 196, 92) : MenuText;
        }
        catch (Exception) { /* لا نوقف الواجهة بسبب العدّاد */ }
    }

    // ------------------------------------------------------------ الشريط العلوي
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
