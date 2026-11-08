namespace AssetTracking.Pages;

/// <summary>قائمة بسيطة مع إضافة وتعديل (الأقسام، المواقع، التصنيفات). لا حذف نهائي: التعطيل من نافذة التعديل.</summary>
public partial class SimpleListPage : PageBase
{
    private readonly string _title = "";
    private readonly Func<DataTable> _load = () => new DataTable();
    private readonly Func<int?, Form> _dialog = _ => new Form();

    /// <summary>للمصمم فقط.</summary>
    public SimpleListPage()
    {
        InitializeComponent();
    }

    public SimpleListPage(string title, Func<DataTable> load, Func<int?, Form> dialog) : this()
    {
        _title = title;
        _load = load;
        _dialog = dialog;
        Dock = DockStyle.Fill;
        Padding = new Padding(8);
        InitPage(grid, lblCount);
        grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) btnEdit_Click(null, EventArgs.Empty); };
    }

    public override void RefreshData() => Bind(_load());

    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(_dialog(null)));
    private void btnEdit_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(_dialog((int)r["Id"])); });
    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid(_title));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid(_title));
}
