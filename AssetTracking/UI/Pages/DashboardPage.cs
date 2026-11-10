using System.Globalization;
using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>
/// الشاشة الرئيسية (لوحة بسيطة): ترحيب، أزرار سريعة، بطاقات إحصائية (كل بطاقة تفتح صفحتها)،
/// ورسمان بيانيان: توزيع الأصول حسب الحالة وحسب التصنيف.
/// </summary>
public partial class DashboardPage : PageBase
{
    /// <summary>طلب الانتقال إلى صفحة أخرى (تستقبله النافذة الرئيسية باسم الصفحة مثل "Alerts").</summary>
    public event Action<string>? Navigate;

    private static readonly Color[] ChartColors =
    {
        Color.FromArgb(30, 77, 120), Color.FromArgb(25, 135, 84), Color.FromArgb(13, 110, 153),
        Color.FromArgb(214, 137, 16), Color.FromArgb(111, 66, 193), Color.FromArgb(192, 57, 43)
    };

    public DashboardPage()
    {
        InitializeComponent();
        lblTitle.Text = $"مرحباً، {Session.Current?.DisplayName} 👋";
        lblDate.Text = DateTime.Today.ToString("dddd، d MMMM yyyy", new CultureInfo("ar-LY"));
        foreach (var t in new[] { tblStatus, tblChart })
        {
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));  // الاسم
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));   // الشريط
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));   // العدد والنسبة
        }
        Resize += (_, _) => FitCards();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!DesignMode) Ui.Try(RefreshData);
    }

    public override void RefreshData()
    {
        var s = AssetDal.Stats();
        flpCards.SuspendLayout();
        flpCards.Controls.Clear();
        AddCard("📦", "إجمالي الأصول", s["Total"], "كل الأصول المسجلة", Theme.Primary, "Assets");
        AddCard("✅", "متاحة", s["Available"], "جاهزة للتسليم", Theme.Success, "Assets");
        AddCard("👤", "في عهدة أشخاص", s["InCustody"], "مسلّمة حالياً", Theme.Info, "Custody");
        AddCard("💰", "القيمة الدفترية", Ui.Money((decimal)s["BookValue"]), "للأصول القائمة", Color.FromArgb(111, 66, 193), "Reports");
        AddCard("⛔", "انتهى عمرها", s["Expired"], "تحتاج قرار تخريد", Theme.Danger, "Alerts");
        AddCard("⏳", "في آخر سنة", s["LastYear"], "تنتهي خلال 12 شهراً", Theme.Warning, "Alerts");
        AddCard("♻", "طلبات تخريد", s["PendingDisposals"], "بانتظار اعتماد المدير", Theme.Warning, "Disposal");
        AddCard("🗑", "مُخرَّدة", s["Disposed"], "خرجت من الخدمة", Theme.Neutral, "Disposal");
        flpCards.ResumeLayout();
        FitCards();
        LoadStatusChart();
        LoadChart();
    }

    // ------------------------------------------------------------ البطاقات
    /// <summary>بطاقة إحصائية: رمز، عنوان، قيمة، وسطر توضيح. الضغط عليها يفتح الصفحة المرتبطة.</summary>
    private void AddCard(string icon, string title, object value, string hint, Color color, string page)
    {
        var card = new Panel { Size = new Size(240, 112), BackColor = Theme.Surface, Margin = new Padding(6), Cursor = Cursors.Hand };
        card.Controls.Add(new Label { Text = Convert.ToString(value), Font = Theme.CardValue, ForeColor = color, Dock = DockStyle.Fill, Padding = new Padding(14, 0, 4, 0), TextAlign = ContentAlignment.MiddleLeft });
        card.Controls.Add(new Label { Text = hint, Font = Theme.Small, ForeColor = Theme.MutedText, Dock = DockStyle.Bottom, Height = 26, Padding = new Padding(14, 0, 4, 4) });
        card.Controls.Add(new Label { Text = title, Font = Theme.Bold, ForeColor = Theme.Text, Dock = DockStyle.Top, Height = 34, Padding = new Padding(14, 8, 4, 0) });
        card.Controls.Add(new Label { Text = icon, Font = new Font("Segoe UI Emoji", 20F), ForeColor = color, Dock = DockStyle.Right, Width = 56, TextAlign = ContentAlignment.MiddleCenter });
        card.Controls.Add(new Panel { Dock = DockStyle.Left, Width = 6, BackColor = color });

        void Open(object? sender, EventArgs e) => Navigate?.Invoke(page);
        card.Click += Open;
        foreach (Control c in card.Controls) { c.Click += Open; c.Cursor = Cursors.Hand; }
        flpCards.Controls.Add(card);
    }

    /// <summary>4 بطاقات في كل صف عند الإمكان.</summary>
    private void FitCards()
    {
        if (flpCards.Controls.Count == 0) return;
        int width = flpCards.ClientSize.Width - 4;
        int perRow = Math.Max(1, Math.Min(4, width / 230));
        foreach (Control c in flpCards.Controls) c.Width = width / perRow - 12;
        flpCards.Height = (int)Math.Ceiling(flpCards.Controls.Count / (double)perRow) * 124 + 8;
    }

    // ------------------------------------------------------------ الرسوم البيانية البسيطة
    /// <summary>عدد الأصول في كل حالة (متاح، في عهدة، مُخرَّد، مؤرشف) مع نسبتها من الإجمالي.</summary>
    private void LoadStatusChart()
    {
        var counts = AssetDal.CountByStatus(null, null, null, null);
        var data = Labels.AssetStatuses
            .Select(s => (s.Text, counts.GetValueOrDefault(s.Value), StatusColor(s.Value)))
            .ToList();
        FillBars(tblStatus, data, showPercent: true);
    }

    private static Color StatusColor(string status) => status switch
    {
        "Available" => Theme.Success,
        "InCustody" => Theme.Info,
        "Disposed" => Theme.Danger,
        _ => Theme.Neutral
    };

    /// <summary>عدد الأصول القائمة في كل تصنيف.</summary>
    private void LoadChart()
    {
        var data = ReportDal.Summary(byDepartment: false).AsEnumerable()
            .Select(r => (Name: r.Field<string>(0)!, Count: Convert.ToInt32(r["عدد الأصول"])))
            .OrderByDescending(x => x.Count)
            .Select((x, i) => (x.Name, x.Count, ChartColors[i % ChartColors.Length]))
            .ToList();
        FillBars(tblChart, data, showPercent: false);
    }

    /// <summary>يرسم أشرطة أفقية في الجدول: الاسم، الشريط (طوله نسبة إلى الأكبر)، ثم العدد.</summary>
    private static void FillBars(TableLayoutPanel tbl, List<(string Name, int Count, Color Color)> data, bool showPercent)
    {
        int max = Math.Max(1, data.Count == 0 ? 1 : data.Max(x => x.Count));
        int total = data.Sum(x => x.Count);

        tbl.SuspendLayout();
        tbl.Controls.Clear();
        tbl.RowStyles.Clear();
        for (int i = 0; i < data.Count; i++)
        {
            var (name, count, color) = data[i];
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            var host = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 8, 0, 8) };
            var bar = new Panel { Dock = DockStyle.Left, BackColor = color };
            double ratio = count / (double)max;
            host.Resize += (_, _) => bar.Width = count == 0 ? 0 : Math.Max(4, (int)(host.ClientSize.Width * ratio));
            host.Controls.Add(bar);
            string value = showPercent && total > 0 ? $"{count}  ({count * 100 / total}%)" : count.ToString();
            tbl.Controls.Add(new Label { Text = name, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, AutoEllipsis = true }, 0, i);
            tbl.Controls.Add(host, 1, i);
            tbl.Controls.Add(new Label { Text = value, Dock = DockStyle.Fill, Font = Theme.Bold, ForeColor = color, TextAlign = ContentAlignment.MiddleCenter }, 2, i);
        }
        tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));   // صف فارغ يأخذ باقي المساحة حتى لا يتمدد آخر شريط
        tbl.RowCount = data.Count + 1;
        if (data.Count == 0) tbl.Controls.Add(new Label { Text = "لا توجد أصول بعد", AutoSize = true, ForeColor = Theme.MutedText }, 0, 0);
        tbl.ResumeLayout();
    }

    // ------------------------------------------------------------ الأزرار
    private void btnQuickAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new AssetDialog(null)));
    private void btnQuickHandover_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new HandoverDialog()));
    private void btnQuickReceive_Click(object? sender, EventArgs e) => Navigate?.Invoke("Custody");
    private void btnQuickReports_Click(object? sender, EventArgs e) => Navigate?.Invoke("Reports");
}
