namespace AssetTracking.Pages;

/// <summary>واجهة مشتركة لكل صفحات النظام.</summary>
public interface IPage
{
    void RefreshData();
}

/// <summary>
/// أساس الصفحات: لا يحتوي عناصر (كل صفحة تصمم عناصرها في ملف Designer الخاص بها)، فقط دوال مساعدة مشتركة:
/// - InitPage: ربط الجدول وعدد السجلات وخانة البحث.
/// - InitChips: أزرار تبويب (حالات) تُلوَّن وتعيد التحميل عند الضغط.
/// - InitRowActions: أزرار تعمل على الصف المحدد: تتفعّل عند التحديد، وتظهر في قائمة الزر الأيمن، وEnter/دبل كليك تنفّذ الأول.
/// - Bind: عرض البيانات مع رسالة "لا توجد بيانات" في وسط الجدول عند الفراغ.
/// </summary>
public class PageBase : UserControl, IPage
{
    private DataGridView? _grid;
    private Label? _count;
    private Label? _empty;
    private bool _loaded;
    private Button[] _chips = Array.Empty<Button>();
    private Button[] _rowButtons = Array.Empty<Button>();

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
        _count!.Text = $"عدد السجلات: {table.Rows.Count}";
        ShowEmpty(table.Rows.Count == 0);
        UpdateRowButtons();
    }

    /// <summary>رسالة في وسط الجدول عندما لا توجد نتائج.</summary>
    private void ShowEmpty(bool empty)
    {
        if (_empty == null)
        {
            _empty = new Label
            {
                Text = "لا توجد بيانات مطابقة 🔍", AutoSize = true, ForeColor = Theme.MutedText,
                Font = new Font(Theme.FontName, 12F), BackColor = Theme.Surface
            };
            _grid!.Controls.Add(_empty);
            _grid.Resize += (_, _) => CenterEmpty();
        }
        _empty.Visible = empty;
        CenterEmpty();
    }

    private void CenterEmpty()
    {
        if (_empty == null || _grid == null) return;
        _empty.Location = new Point((_grid.Width - _empty.Width) / 2, Math.Max(_grid.ColumnHeadersHeight + 20, (_grid.Height - _empty.Height) / 2));
    }

    // ------------------------------------------------------------ أزرار التبويب (الحالات)
    /// <summary>القيمة المختارة من أزرار التبويب (Tag الزر)، أو null لزر "الكل".</summary>
    protected string? Chip { get; private set; }

    protected void InitChips(string? initial, params Button[] chips)
    {
        _chips = chips;
        Chip = initial;
        foreach (var b in chips)
            b.Click += (_, _) =>
            {
                Chip = Ui.NullIfEmpty((string)b.Tag!);
                PaintChips();
                if (Ready) Ui.Try(RefreshData);
            };
        PaintChips();
    }

    /// <summary>اختيار تبويب من الكود (مثل زر "مسح التصفية").</summary>
    protected void SelectChip(string? value)
    {
        Chip = value;
        PaintChips();
    }

    /// <summary>الزر المختار ممتلئ بلون أساسي، والباقي بإطار فقط.</summary>
    private void PaintChips()
    {
        foreach (var b in _chips)
        {
            bool selected = Ui.NullIfEmpty((string)b.Tag!) == Chip;
            b.BackColor = selected ? Theme.Primary : Theme.Surface;
            b.ForeColor = selected ? Color.White : Theme.Primary;
        }
    }

    /// <summary>نص الزر مع العدد، مثل: "متاح (12)".</summary>
    protected static void ChipText(Button chip, string text, int count) => chip.Text = $"{text} ({count})";

    // ------------------------------------------------------------ عمليات الصف المحدد
    /// <summary>
    /// الأزرار التي تحتاج صفاً محدداً: تُعطَّل بدون تحديد، وتظهر في قائمة الزر الأيمن.
    /// openButton (إن وُجد) يُنفَّذ بالضغط على Enter أو دبل كليك على الصف.
    /// </summary>
    protected void InitRowActions(Button? openButton, params Button[] rowButtons)
    {
        _rowButtons = rowButtons;
        var grid = _grid!;
        grid.SelectionChanged += (_, _) => UpdateRowButtons();
        if (openButton != null)
        {
            grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && openButton.Enabled) openButton.PerformClick(); };
            grid.KeyDown += (_, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;
                e.Handled = true;
                if (openButton.Enabled) openButton.PerformClick();
            };
        }
        grid.CellMouseDown += (_, e) =>   // الزر الأيمن يحدد الصف قبل فتح القائمة
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                grid.CurrentCell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        };

        var menu = new ContextMenuStrip { RightToLeft = RightToLeft.Yes, Font = Theme.Base };
        var items = rowButtons.Select(b => (Item: new ToolStripMenuItem(b.Text, null, (_, _) => b.PerformClick()), Button: b)).ToList();
        menu.Items.AddRange(items.Select(x => (ToolStripItem)x.Item).ToArray());
        menu.Opening += (_, e) =>
        {
            if (Selected == null) { e.Cancel = true; return; }
            foreach (var (item, b) in items)
            {
                item.Text = b.Text;
                item.Enabled = b.Enabled;
                item.Visible = b.Visible;
            }
        };
        grid.ContextMenuStrip = menu;
        UpdateRowButtons();
    }

    private void UpdateRowButtons()
    {
        var row = Selected;
        foreach (var b in _rowButtons) b.Enabled = row != null;
        OnRowSelected(row);
    }

    /// <summary>للتفعيل الإضافي حسب بيانات الصف (مثلاً: "استلام" للعهد المفتوحة فقط).</summary>
    protected virtual void OnRowSelected(DataRowView? row) { }

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
