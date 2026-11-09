using System.Globalization;
using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>
/// الشاشة الرئيسية: ترحيب، أزرار سريعة، بطاقات إحصائية (كل بطاقة تفتح صفحتها)،
/// آخر العمليات، توزيع الأصول حسب التصنيف، والأصول التي انتهى عمرها.
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
        InitPage(grid, lblCount);
        Ui.StyleGrid(gridUrgent);
        lblTitle.Text = $"مرحباً، {Session.Current?.DisplayName} 👋";
        lblDate.Text = DateTime.Today.ToString("dddd، d MMMM yyyy", new CultureInfo("ar-LY"));
        tblChart.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));  // اسم التصنيف
        tblChart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));   // الشريط
        tblChart.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44));   // العدد
        gridUrgent.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0 && Ui.CurrentRow(gridUrgent) is { } r) Ui.Try(() => OpenDialog(new AssetDialog((int)r["Id"])));
        };
        Resize += (_, _) => FitCards();
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

        Bind(AuditDal.Recent(15));
        LoadChart();
        LoadUrgent();
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

    // ------------------------------------------------------------ الرسم البياني البسيط
    /// <summary>أشرطة أفقية: عدد الأصول القائمة في كل تصنيف.</summary>
    private void LoadChart()
    {
        var data = ReportDal.Summary(byDepartment: false).AsEnumerable()
            .Select(r => (Name: r.Field<string>(0)!, Count: Convert.ToInt32(r["عدد الأصول"])))
            .OrderByDescending(x => x.Count).ToList();
        int max = Math.Max(1, data.Count == 0 ? 1 : data.Max(x => x.Count));

        tblChart.SuspendLayout();
        tblChart.Controls.Clear();
        tblChart.RowStyles.Clear();
        tblChart.RowCount = 0;
        for (int i = 0; i < data.Count; i++)
        {
            var (name, count) = data[i];
            tblChart.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            var host = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 8, 0, 8) };
            var bar = new Panel { Dock = DockStyle.Left, BackColor = ChartColors[i % ChartColors.Length] };
            double ratio = count / (double)max;
            host.Resize += (_, _) => bar.Width = Math.Max(4, (int)(host.ClientSize.Width * ratio));
            host.Controls.Add(bar);
            tblChart.Controls.Add(new Label { Text = name, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, AutoEllipsis = true }, 0, i);
            tblChart.Controls.Add(host, 1, i);
            tblChart.Controls.Add(new Label { Text = count.ToString(), Dock = DockStyle.Fill, Font = Theme.Bold, TextAlign = ContentAlignment.MiddleCenter }, 2, i);
        }
        tblChart.RowCount = data.Count;
        tblChart.ResumeLayout();
        if (data.Count == 0) tblChart.Controls.Add(new Label { Text = "لا توجد أصول بعد", AutoSize = true, ForeColor = Theme.MutedText }, 0, 0);
    }

    // ------------------------------------------------------------ أصول انتهى عمرها
    private void LoadUrgent()
    {
        var t = AssetDal.Alerts("Expired", null, null);
        foreach (var c in new[] { "التصنيف", "القسم", "القيمة الدفترية", "التنبيه" })
            if (t.Columns.Contains(c)) t.Columns.Remove(c);
        Ui.BindGrid(gridUrgent, t);
        lblUrgent.Text = t.Rows.Count == 0 ? "✅  لا توجد أصول انتهى عمرها" : $"⚠  أصول انتهى عمرها ({t.Rows.Count})";
        lblUrgent.ForeColor = t.Rows.Count == 0 ? Theme.Success : Theme.Danger;
    }

    // ------------------------------------------------------------ الأزرار
    private void btnRefresh_Click(object? sender, EventArgs e) => Ui.Try(RefreshData);
    private void btnQuickAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new AssetDialog(null)));
    private void btnQuickHandover_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new HandoverDialog()));
    private void btnQuickReceive_Click(object? sender, EventArgs e) => Navigate?.Invoke("Custody");
    private void btnQuickReports_Click(object? sender, EventArgs e) => Navigate?.Invoke("Reports");
}
