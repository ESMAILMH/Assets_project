using AssetTracking.BLL;

namespace AssetTracking.Forms;

/// <summary>
/// استيراد الأصول من Excel (UC-05): اختيار الملف ← مطابقة الأعمدة ← معاينة ← حفظ الأسطر الصحيحة فقط.
/// </summary>
public partial class ImportDialog : Form
{
    private readonly Dictionary<string, ComboBox> _map;
    private DataTable? _raw;
    private List<ImportRow>? _rows;

    public ImportDialog()
    {
        InitializeComponent();
        Ui.StyleGrid(grid);
        // كل حقل في الأصل ← القائمة المنسدلة الخاصة به في المصمم
        _map = new()
        {
            ["SerialNo"] = cmbMapSerialNo, ["Name"] = cmbMapName, ["Category"] = cmbMapCategory, ["Model"] = cmbMapModel,
            ["PurchaseDate"] = cmbMapPurchaseDate, ["InServiceDate"] = cmbMapInServiceDate, ["Cost"] = cmbMapCost,
            ["LifeYears"] = cmbMapLifeYears, ["SalvageValue"] = cmbMapSalvageValue, ["Location"] = cmbMapLocation
        };
        btnSave.Enabled = btnErrors.Enabled = false;
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is DataRowView r && !(bool)r["Valid"])
                e.CellStyle!.ForeColor = Theme.Danger;
        };
    }

    private void btnTemplate_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        using var dlg = new SaveFileDialog { Filter = "ملف Excel|*.xlsx", FileName = "قالب_استيراد_الأصول.xlsx" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        ImportService.CreateTemplate(dlg.FileName);
        Ui.Info("تم حفظ القالب. املأه ثم اختره للاستيراد.");
    });

    private void btnPick_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        using var dlg = new OpenFileDialog { Filter = "ملف Excel|*.xlsx" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        _raw = ImportService.ReadExcel(dlg.FileName);
        txtFile.Text = dlg.FileName;

        var columns = _raw.Columns.Cast<DataColumn>().Skip(1).Select(c => (object)c.ColumnName).ToArray();
        foreach (var f in ImportService.Fields)
        {
            var combo = _map[f.Key];
            combo.Items.Clear();
            combo.Items.Add("— لا يوجد —");
            combo.Items.AddRange(columns);
            combo.SelectedItem = (object?)ImportService.GuessColumn(_raw, f) ?? "— لا يوجد —";
        }
        _rows = null;
        grid.DataSource = null;
        lblSummary.Text = $"عدد الأسطر في الملف: {_raw.Rows.Count}";
        btnSave.Enabled = btnErrors.Enabled = false;
    });

    private void btnPreview_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (_raw == null) throw new AppException("اختر ملف Excel أولاً.");
        var map = _map.ToDictionary(kv => kv.Key, kv => kv.Value.SelectedIndex > 0 ? (string?)kv.Value.SelectedItem : null);
        _rows = ImportService.Validate(_raw, map);
        Ui.BindGrid(grid, ImportService.PreviewTable(_rows));
        int ok = _rows.Count(r => r.IsValid);
        lblSummary.Text = $"صحيح: {ok}   |   مرفوض: {_rows.Count - ok}";
        btnSave.Enabled = ok > 0;
        btnErrors.Enabled = ok < _rows.Count;
    });

    private void btnSave_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (_rows == null) return;
        int ok = _rows.Count(r => r.IsValid);
        if (!Ui.Confirm($"سيتم حفظ {ok} أصل، وتجاهل {_rows.Count - ok} سطر مرفوض. متابعة؟")) return;
        int saved = ImportService.Save(_rows, txtFile.Text);
        Ui.Info($"تم استيراد {saved} أصل بنجاح.");
        btnSave.Enabled = false;
        DialogResult = DialogResult.OK;
    });

    private void btnErrors_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (_rows == null) return;
        ReportPrinter.Preview(new ReportResult("تقرير أخطاء الاستيراد",
            new[] { new ReportSection("", ImportService.PreviewTable(_rows, errorsOnly: true)) },
            "الملف: " + Path.GetFileName(txtFile.Text), Array.Empty<string>()), this);
    });

    private void btnClose_Click(object? sender, EventArgs e) => Close();
}
