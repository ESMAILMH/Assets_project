namespace AssetTracking.Pages;

/// <summary>واجهة مشتركة لكل صفحات النظام.</summary>
public interface IPage
{
    void RefreshData();
}

/// <summary>
/// أساس الصفحات: لا يحتوي عناصر (كل صفحة تصمم عناصرها في ملف Designer الخاص بها)،
/// فقط دوال مساعدة: ربط الجدول، عدد السجلات، فتح النوافذ، الطباعة والتصدير.
/// كل صفحة تستدعي InitPage(grid, lblCount) بعد InitializeComponent.
/// </summary>
public class PageBase : UserControl, IPage
{
    private DataGridView? _grid;
    private Label? _count;
    private bool _loaded;

    /// <summary>false أثناء تحميل القوائم المنسدلة حتى لا يُعاد التحميل مع كل تغيير.</summary>
    protected bool Ready { get; set; }

    protected void InitPage(DataGridView grid, Label count, TextBox? search = null)
    {
        _grid = grid;
        _count = count;
        Ui.StyleGrid(grid);
        if (search == null) return;
        Ui.OnTextChangedDebounced(search, () => Ui.Try(RefreshData));
        search.KeyDown += (_, e) => { if (e.KeyCode == Keys.Escape) search.Clear(); }; // Esc يمسح البحث
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (_loaded || DesignMode || _grid == null) return;
        _loaded = true;
        Ui.Try(RefreshData);
        Ready = true;
    }

    public virtual void RefreshData() { }

    /// <summary>ربطه بحدث SelectedIndexChanged للقوائم المنسدلة: يحدّث الجدول عند تغيير التصفية.</summary>
    protected void Filter_Changed(object? sender, EventArgs e)
    {
        if (Ready) Ui.Try(RefreshData);
    }

    protected void Bind(DataTable table)
    {
        Ui.BindGrid(_grid!, table);
        _count!.Text = table.Rows.Count == 0 ? "لا توجد بيانات مطابقة" : $"عدد السجلات: {table.Rows.Count}";
    }

    protected DataTable? CurrentTable => _grid?.DataSource as DataTable;

    protected DataRowView? Selected => _grid == null ? null : Ui.CurrentRow(_grid);

    protected DataRowView? RequireSelection()
    {
        var row = Selected;
        if (row == null) Ui.Info("الرجاء تحديد سجل من الجدول أولاً.");
        return row;
    }

    /// <summary>يفتح نافذة، ويحدّث الصفحة إذا تم الحفظ.</summary>
    protected void OpenDialog(Form dialog)
    {
        using (dialog)
            if (dialog.ShowDialog(FindForm()) == DialogResult.OK) RefreshData();
    }

    protected void PrintGrid(string title, string? subtitle = null)
    {
        if (CurrentTable is { } t)
            ReportPrinter.Preview(new ReportResult(title, new[] { new ReportSection("", Sorted(t)) }, subtitle), FindForm());
    }

    protected void ExportGrid(string title)
    {
        if (CurrentTable is { } t) Ui.ExportExcel(Sorted(t), title, FindForm());
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
