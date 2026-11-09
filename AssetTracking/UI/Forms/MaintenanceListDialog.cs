using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>سجل صيانة أصل: عرض، تسجيل، وتعديل (UC-08).</summary>
public partial class MaintenanceListDialog : Form
{
    private readonly int _assetId;
    private readonly string _title;

    public MaintenanceListDialog(int assetId, string assetTitle)
    {
        InitializeComponent();
        Ui.ApplyIcon(this);
        Ui.StyleGrid(grid);
        _assetId = assetId;
        _title = assetTitle;
        Text = "سجل صيانة الأصل: " + assetTitle;
        btnAdd.Visible = btnEdit.Visible = Session.CanManage;
        if (Session.CanManage) grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) Ui.Try(EditSelected); };
        Load += (_, _) => Ui.Try(Reload);
    }

    private void Reload() => Ui.BindGrid(grid, MaintenanceDal.Search(_assetId, null, null));

    private void Edit(int? maintenanceId)
    {
        using var d = new MaintenanceDialog(_assetId, _title, maintenanceId);
        if (d.ShowDialog(this) == DialogResult.OK) Reload();
    }

    private void EditSelected()
    {
        if (Ui.CurrentRow(grid) is not { } r) { Ui.Info("حدد سجل الصيانة المراد تعديله."); return; }
        Edit((int)r["Id"]);
    }

    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() => Edit(null));
    private void btnEdit_Click(object? sender, EventArgs e) => Ui.Try(EditSelected);
    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => ReportPrinter.Preview(new ReportResult(Text, new[] { new ReportSection("", (DataTable)grid.DataSource) }), this));
    private void btnClose_Click(object? sender, EventArgs e) => Close();
}
