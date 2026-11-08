using AssetTracking.BLL;

namespace AssetTracking.Forms;

/// <summary>
/// استيراد الأصول من Excel (UC-05): اختيار الملف ← مطابقة الأعمدة ← معاينة ← حفظ الأسطر الصحيحة فقط.
/// </summary>
public sealed class ImportDialog : Form
{
    private readonly TextBox _file;
    private readonly Dictionary<string, ComboBox> _map = new();
    private readonly DataGridView _grid = Ui.MakeGrid();
    private readonly Label _summary;
    private readonly Button _save, _errors;
    private DataTable? _raw;
    private List<ImportRow>? _rows;

    public ImportDialog()
    {
        Text = "استيراد الأصول من ملف Excel";
        Ui.ApplyRtl(this);
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(1060, 720);
        MinimizeBox = false;
        BackColor = Theme.Background;

        // 1) اختيار الملف
        var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(12, 10, 12, 4) };
        top.Controls.Add(Ui.MakeLabel("١. الملف:", Theme.Bold));
        _file = Ui.MakeTextBox(430);
        _file.ReadOnly = true;
        top.Controls.Add(_file);
        top.Controls.Add(Ui.MakeButton("اختيار ملف", Theme.Primary, (_, _) => Ui.Try(PickFile)));
        top.Controls.Add(Ui.MakeButton("تنزيل القالب", Theme.Neutral, (_, _) => Ui.Try(SaveTemplate)));

        // 2) مطابقة الأعمدة
        var mapBox = new GroupBox { Text = "٢. مطابقة أعمدة الملف مع حقول الأصل (* إلزامي)", Dock = DockStyle.Top, Height = 190, Padding = new Padding(10) };
        var mapGrid = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4 };
        for (int i = 0; i < 2; i++)
        {
            mapGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            mapGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        }
        foreach (var f in ImportService.Fields)
        {
            var combo = Ui.MakeCombo(260);
            combo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _map[f.Key] = combo;
            mapGrid.Controls.Add(new Label { Text = f.Title + (f.Required ? " *" : ""), AutoSize = true, Margin = new Padding(4, 9, 4, 4) });
            mapGrid.Controls.Add(combo);
        }
        mapBox.Controls.Add(mapGrid);

        // 3) المعاينة
        var previewBar = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(12, 6, 12, 4) };
        previewBar.Controls.Add(Ui.MakeButton("٣. معاينة", Theme.Info, (_, _) => Ui.Try(Preview)));
        _summary = Ui.MakeLabel("", Theme.Bold);
        previewBar.Controls.Add(_summary);
        var gridHost = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12, 0, 12, 0) };
        gridHost.Controls.Add(_grid);
        _grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && _grid.Rows[e.RowIndex].DataBoundItem is DataRowView r && !(bool)r["Valid"])
                e.CellStyle!.ForeColor = Theme.Danger;
        };

        // 4) الحفظ
        var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 58, Padding = new Padding(12, 10, 12, 6) };
        _save = Ui.MakeButton("٤. حفظ الأسطر الصحيحة", Theme.Success, (_, _) => Ui.Try(SaveRows));
        _errors = Ui.MakeButton("🖨 تقرير أخطاء الاستيراد", Theme.Neutral, (_, _) => Ui.Try(PrintErrors));
        var close = Ui.MakeButton("إغلاق", Theme.Primary, (_, _) => Close());
        _save.Enabled = _errors.Enabled = false;
        bottom.Controls.AddRange(new Control[] { _save, _errors, close });
        CancelButton = close;

        Controls.Add(gridHost);
        Controls.Add(previewBar);
        Controls.Add(mapBox);
        Controls.Add(top);
        Controls.Add(bottom);
    }

    private void SaveTemplate()
    {
        using var dlg = new SaveFileDialog { Filter = "ملف Excel|*.xlsx", FileName = "قالب_استيراد_الأصول.xlsx" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        ImportService.CreateTemplate(dlg.FileName);
        Ui.Info("تم حفظ القالب. املأه ثم اختره للاستيراد.");
    }

    private void PickFile()
    {
        using var dlg = new OpenFileDialog { Filter = "ملف Excel|*.xlsx" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        _raw = ImportService.ReadExcel(dlg.FileName);
        _file.Text = dlg.FileName;

        var columns = _raw.Columns.Cast<DataColumn>().Skip(1).Select(c => c.ColumnName).ToList();
        foreach (var f in ImportService.Fields)
        {
            var combo = _map[f.Key];
            combo.Items.Clear();
            combo.Items.Add("— لا يوجد —");
            combo.Items.AddRange(columns.Cast<object>().ToArray());
            combo.SelectedItem = (object?)ImportService.GuessColumn(_raw, f) ?? "— لا يوجد —";
        }
        _rows = null;
        _grid.DataSource = null;
        _summary.Text = $"عدد الأسطر في الملف: {_raw.Rows.Count}";
        _save.Enabled = _errors.Enabled = false;
    }

    private void Preview()
    {
        if (_raw == null) throw new AppException("اختر ملف Excel أولاً.");
        var map = _map.ToDictionary(kv => kv.Key, kv => kv.Value.SelectedIndex > 0 ? (string?)kv.Value.SelectedItem : null);
        _rows = ImportService.Validate(_raw, map);
        Ui.BindGrid(_grid, ImportService.PreviewTable(_rows));
        int ok = _rows.Count(r => r.IsValid);
        _summary.Text = $"صحيح: {ok}   |   مرفوض: {_rows.Count - ok}";
        _save.Enabled = ok > 0;
        _errors.Enabled = ok < _rows.Count;
    }

    private void SaveRows()
    {
        if (_rows == null) return;
        int ok = _rows.Count(r => r.IsValid);
        if (!Ui.Confirm($"سيتم حفظ {ok} أصل، وتجاهل {_rows.Count - ok} سطر مرفوض. متابعة؟")) return;
        int saved = ImportService.Save(_rows, _file.Text);
        Ui.Info($"تم استيراد {saved} أصل بنجاح.");
        _save.Enabled = false;
        DialogResult = DialogResult.OK;
    }

    private void PrintErrors()
    {
        if (_rows == null) return;
        ReportPrinter.Preview(new ReportResult("تقرير أخطاء الاستيراد",
            new[] { new ReportSection("", ImportService.PreviewTable(_rows, errorsOnly: true)) },
            "الملف: " + Path.GetFileName(_file.Text), Array.Empty<string>()), this);
    }
}
