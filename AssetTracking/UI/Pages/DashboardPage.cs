using AssetTracking.DAL;

namespace AssetTracking.Pages;

/// <summary>الشاشة الرئيسية: إحصائيات سريعة (بطاقات) وآخر العمليات.</summary>
public partial class DashboardPage : PageBase
{
    public DashboardPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount);
        lblTitle.Text = $"مرحباً، {Session.Current?.DisplayName}";
        Resize += (_, _) => FitCards();
    }

    public override void RefreshData()
    {
        var s = AssetDal.Stats();
        flpCards.SuspendLayout();
        flpCards.Controls.Clear();
        AddCard("إجمالي الأصول", s["Total"].ToString()!, Theme.Primary);
        AddCard("متاحة", s["Available"].ToString()!, Theme.Success);
        AddCard("في عهدة أشخاص", s["InCustody"].ToString()!, Theme.Info);
        AddCard("مُخرَّدة", s["Disposed"].ToString()!, Theme.Neutral);
        AddCard("⚠ انتهى عمرها", s["Expired"].ToString()!, Theme.Danger);
        AddCard("⚠ في آخر سنة من عمرها", s["LastYear"].ToString()!, Theme.Warning);
        AddCard("طلبات تخريد بانتظار المدير", s["PendingDisposals"].ToString()!, Theme.Warning);
        AddCard("القيمة الدفترية الحالية", Ui.Money((decimal)s["BookValue"]), Theme.Success);
        flpCards.ResumeLayout();
        FitCards();
        Bind(AuditDal.Recent(15));
    }

    /// <summary>بطاقة إحصائية (تُنشأ عند التشغيل لأن عددها وقيمها من قاعدة البيانات).</summary>
    private void AddCard(string title, string value, Color color)
    {
        var card = new Panel { Size = new Size(240, 110), BackColor = Theme.Surface, Margin = new Padding(6) };
        card.Controls.Add(new Label { Text = value, Font = Theme.CardValue, ForeColor = color, Dock = DockStyle.Fill, Padding = new Padding(14, 0, 14, 0), TextAlign = ContentAlignment.MiddleLeft });
        card.Controls.Add(new Label { Text = title, ForeColor = Theme.MutedText, Dock = DockStyle.Top, Height = 40, Padding = new Padding(14, 8, 14, 0) });
        card.Controls.Add(new Panel { Dock = DockStyle.Left, Width = 6, BackColor = color });
        flpCards.Controls.Add(card);
    }

    private void FitCards()
    {
        if (flpCards.Controls.Count == 0) return;
        int width = flpCards.ClientSize.Width - 4;
        int perRow = Math.Max(1, Math.Min(4, width / 230));
        foreach (Control c in flpCards.Controls) c.Width = width / perRow - 12;
        flpCards.Height = (int)Math.Ceiling(flpCards.Controls.Count / (double)perRow) * 122 + 8;
    }

    private void btnRefresh_Click(object? sender, EventArgs e) => Ui.Try(RefreshData);
}
