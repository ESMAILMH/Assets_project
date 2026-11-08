namespace AssetTracking.Forms;

/// <summary>نافذة لعرض جدول بيانات (مثل سجل حركات أصل) مع الطباعة.</summary>
public partial class GridDialog : Form
{
    private readonly Func<DataTable> _load;

    public GridDialog(string title, Func<DataTable> load)
    {
        InitializeComponent();
        Ui.StyleGrid(grid);
        Text = title;
        _load = load;
        Load += (_, _) => Ui.Try(() => Ui.BindGrid(grid, _load()));
    }

    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => ReportPrinter.Preview(new ReportResult(Text, new[] { new ReportSection("", (DataTable)grid.DataSource) }), this));

    private void btnClose_Click(object? sender, EventArgs e) => Close();
}
