namespace AssetTracking.Pages;

/// <summary>واجهة مشتركة لكل صفحات النظام.</summary>
public interface IPage
{
    void RefreshData();
}

/// <summary>صفحة قياسية: عنوان، شريط بحث وتصفية، أزرار العمليات، جدول، وعدد السجلات.</summary>
public class PageBase : UserControl, IPage
{
    protected readonly Label TitleLabel;
    protected readonly FlowLayoutPanel Toolbar;
    protected readonly FlowLayoutPanel Actions;
    protected readonly DataGridView Grid;
    protected readonly Label CountLabel;
    private bool _loaded;
    protected bool Ready { get; set; }

    public PageBase(string title)
    {
        Ui.ApplyRtl(this);
        Dock = DockStyle.Fill;
        BackColor = Theme.Background;
        Padding = new Padding(20, 14, 20, 10);

        TitleLabel = new Label
        {
            Text = title, Font = Theme.Title, ForeColor = Theme.Primary,
            Dock = DockStyle.Top, Height = 42, TextAlign = ContentAlignment.MiddleLeft
        };
        Toolbar = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, WrapContents = true, Padding = new Padding(0, 2, 0, 2) };
        Actions = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, WrapContents = true, Padding = new Padding(0, 0, 0, 8) };
        Grid = Ui.MakeGrid();
        var gridHost = new Panel { Dock = DockStyle.Fill, Padding = new Padding(1), BackColor = Theme.Border };
        gridHost.Controls.Add(Grid);
        CountLabel = new Label { Dock = DockStyle.Bottom, Height = 28, ForeColor = Theme.MutedText, TextAlign = ContentAlignment.MiddleLeft };

        // ترتيب الإضافة مهم للـ Dock: العنصر الذي يملأ الفراغ أولاً
        Controls.Add(gridHost);
        Controls.Add(CountLabel);
        Controls.Add(Actions);
        Controls.Add(Toolbar);
        Controls.Add(TitleLabel);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (_loaded || DesignMode) return;
        _loaded = true;
        Ui.Try(RefreshData);
        Ready = true;
    }

    public virtual void RefreshData() { }

    protected void Bind(DataTable table)
    {
        Ui.BindGrid(Grid, table);
        CountLabel.Text = table.Rows.Count == 0 ? "لا توجد بيانات مطابقة" : $"عدد السجلات: {table.Rows.Count}";
    }

    /// <summary>يفتح نافذة، ويحدّث الصفحة إذا تم الحفظ.</summary>
    protected void OpenDialog(Form dialog)
    {
        using (dialog)
            if (dialog.ShowDialog(FindForm()) == DialogResult.OK) RefreshData();
    }

    protected DataTable? CurrentTable => Grid.DataSource as DataTable;
    protected DataRowView? Selected => Ui.CurrentRow(Grid);

    protected DataRowView? RequireSelection()
    {
        var row = Selected;
        if (row == null) Ui.Info("الرجاء تحديد سجل من الجدول أولاً.");
        return row;
    }

    protected Button AddAction(string text, Color color, Action action)
    {
        var b = Ui.MakeButton(text, color, (_, _) => Ui.Try(action));
        Actions.Controls.Add(b);
        return b;
    }

    protected T AddTool<T>(string? label, T control) where T : Control
    {
        if (label != null) Toolbar.Controls.Add(Ui.MakeLabel(label));
        Toolbar.Controls.Add(control);
        return control;
    }

    protected TextBox AddSearchBox(string placeholder)
    {
        var tb = Ui.MakeTextBox(240, placeholder);
        Ui.OnTextChangedDebounced(tb, () => Ui.Try(RefreshData));
        tb.KeyDown += (_, e) => { if (e.KeyCode == Keys.Escape) tb.Clear(); }; // Esc يمسح البحث
        return AddTool("بحث:", tb);
    }

    /// <summary>قائمة منسدلة للتصفية: تغيّرها يحدّث الجدول.</summary>
    protected ComboBox AddFilter(string label, int width = 150)
    {
        var c = AddTool(label, Ui.MakeCombo(width));
        c.SelectedIndexChanged += (_, _) => { if (Ready) Ui.Try(RefreshData); };
        return c;
    }

    protected void AddPrintExport(string title, Func<string?>? subtitle = null)
    {
        AddAction("🖨 طباعة", Theme.Neutral, () =>
        {
            if (CurrentTable is { } t)
                ReportPrinter.Preview(new ReportResult(title, new[] { new ReportSection("", Sorted(t)) }, subtitle?.Invoke()), FindForm());
        });
        AddAction("Excel", Theme.Success, () =>
        {
            if (CurrentTable is { } t) Ui.ExportExcel(Sorted(t), title, FindForm());
        });
    }

    private static DataTable Sorted(DataTable t) => t.DefaultView is { Sort.Length: > 0 } v ? v.ToTable() : t;

    /// <summary>إعادة ربط قائمة منسدلة مع الإبقاء على الاختيار السابق.</summary>
    protected static void Rebind(ComboBox combo, Action bind)
    {
        var prev = combo.SelectedValue;
        bind();
        if (prev != null) combo.SelectedValue = prev;
    }
}
