using AssetTracking.DAL;

namespace AssetTracking.Pages;

/// <summary>الشاشة الرئيسية: إحصائيات سريعة وعدّاد التنبيهات وآخر العمليات.</summary>
public sealed class DashboardPage : PageBase
{
    private readonly FlowLayoutPanel _cards;

    public DashboardPage() : base("الشاشة الرئيسية")
    {
        TitleLabel.Text = $"مرحباً، {Session.Current?.DisplayName}";
        _cards = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 250, WrapContents = true, Padding = new Padding(0, 4, 0, 4) };
        Controls.Add(_cards);
        Controls.SetChildIndex(_cards, Controls.GetChildIndex(Toolbar));
        Actions.Controls.Add(Ui.MakeLabel("آخر العمليات", Theme.Subtitle));
        Actions.Controls.Add(Ui.MakeButton("تحديث", Theme.Info, (_, _) => Ui.Try(RefreshData)));
        Resize += (_, _) => FitCards();
    }

    public override void RefreshData()
    {
        var s = AssetDal.Stats();
        _cards.SuspendLayout();
        _cards.Controls.Clear();
        AddCard("إجمالي الأصول", s["Total"].ToString()!, Theme.Primary);
        AddCard("متاحة", s["Available"].ToString()!, Theme.Success);
        AddCard("في عهدة أشخاص", s["InCustody"].ToString()!, Theme.Info);
        AddCard("مُخرَّدة", s["Disposed"].ToString()!, Theme.Neutral);
        AddCard("⚠ انتهى عمرها", s["Expired"].ToString()!, Theme.Danger);
        AddCard("⚠ في آخر سنة من عمرها", s["LastYear"].ToString()!, Theme.Warning);
        AddCard("طلبات تخريد بانتظار المدير", s["PendingDisposals"].ToString()!, Theme.Warning);
        AddCard("القيمة الدفترية الحالية", Ui.Money((decimal)s["BookValue"]), Theme.Success);
        _cards.ResumeLayout();
        FitCards();
        if (Session.CanManage) Bind(AuditDal.Recent(15));
    }

    private void AddCard(string title, string value, Color color)
    {
        var card = new Panel { Size = new Size(240, 110), BackColor = Theme.Surface, Margin = new Padding(6) };
        card.Controls.Add(new Label { Text = value, Font = Theme.CardValue, ForeColor = color, Dock = DockStyle.Fill, Padding = new Padding(14, 0, 14, 0), TextAlign = ContentAlignment.MiddleLeft });
        card.Controls.Add(new Label { Text = title, ForeColor = Theme.MutedText, Dock = DockStyle.Top, Height = 34, Padding = new Padding(14, 10, 14, 0) });
        card.Controls.Add(new Panel { Dock = DockStyle.Left, Width = 6, BackColor = color });
        _cards.Controls.Add(card);
    }

    private void FitCards()
    {
        if (_cards.Controls.Count == 0) return;
        int width = _cards.ClientSize.Width - 4;
        int perRow = Math.Max(1, Math.Min(4, width / 230));
        foreach (Control c in _cards.Controls) c.Width = width / perRow - 12;
        _cards.Height = (int)Math.Ceiling(_cards.Controls.Count / (double)perRow) * 122 + 8;
    }
}
