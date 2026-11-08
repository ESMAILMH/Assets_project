namespace AssetTracking.Forms;

/// <summary>نافذة لعرض جدول بيانات (سجل حركة، تسويات...) مع إمكانية الطباعة.</summary>
public class GridDialog : Form
{
    protected readonly DataGridView Grid;
    protected readonly FlowLayoutPanel Buttons;
    private readonly Func<DataTable> _load;
    private readonly string _title;

    public GridDialog(string title, Func<DataTable> load, int width = 1000, int height = 520)
    {
        _title = title;
        _load = load;
        Text = title;
        Ui.ApplyRtl(this);
        StartPosition = FormStartPosition.CenterParent;
        ShowInTaskbar = false;
        MinimizeBox = false;
        ClientSize = new Size(width, height);
        BackColor = Theme.Background;

        Grid = Ui.MakeGrid();
        var host = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12, 12, 12, 0) };
        host.Controls.Add(Grid);

        Buttons = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 56, Padding = new Padding(10, 10, 10, 6) };
        Buttons.Controls.Add(Ui.MakeButton("🖨 طباعة", Theme.Neutral, (_, _) => Ui.Try(Print)));
        var close = Ui.MakeButton("إغلاق", Theme.Primary, (_, _) => Close());
        Buttons.Controls.Add(close);
        CancelButton = close;

        Controls.Add(host);
        Controls.Add(Buttons);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Ui.Try(Reload);
    }

    protected void Reload() => Ui.BindGrid(Grid, _load());

    protected virtual ReportResult BuildReport() =>
        new(_title, new[] { new ReportSection("", (DataTable)Grid.DataSource) });

    private void Print() => ReportPrinter.Preview(BuildReport(), this);
}
