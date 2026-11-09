using AssetTracking.BLL;
using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>
/// الأصول: بحث وتصفية، أزرار الحالات بعدد كل حالة، العمليات (تتفعّل حسب حالة الأصل المحدد)،
/// قائمة الزر الأيمن على الجدول، ولوحة تفاصيل الأصل المحدد مع صورته.
/// </summary>
public partial class AssetsPage : PageBase
{
    private string? _status;          // الحالة المختارة من أزرار الحالات (null = الكل)
    private int? _detailsAssetId;
    private Button[] _chips = Array.Empty<Button>();

    public AssetsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الرقم التسلسلي، الاسم، الموديل، صاحب العهدة...";
        foreach (var c in new[] { cmbCategory, cmbDepartment, cmbLocation }) c.SelectedIndexChanged += Filter_Changed;
        _chips = new[] { btnStatusAll, btnStatusAvailable, btnStatusInCustody, btnStatusDisposed, btnStatusArchived };

        grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) btnCard_Click(null, EventArgs.Empty); };
        grid.KeyDown += (_, e) => { if (e.KeyCode == Keys.Enter) { e.Handled = true; btnCard_Click(null, EventArgs.Empty); } };
        grid.SelectionChanged += (_, _) => ShowDetails();
        grid.CellMouseDown += (_, e) =>   // الزر الأيمن يحدد الصف قبل فتح القائمة
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) grid.CurrentCell = grid.Rows[e.RowIndex].Cells[grid.CurrentCell?.ColumnIndex ?? FirstVisibleColumn()];
        };
        grid.ContextMenuStrip = BuildContextMenu();
        Ui.ColorBy(grid, "Status", "الحالة", Ui.AssetStatusColor);
        PaintChips();
    }

    public override void RefreshData()
    {
        bool ready = Ready;
        Ready = false;
        Rebind(cmbCategory, () => Ui.BindCombo(cmbCategory, MasterDataDal.CategoryList(), "— الكل —"));
        Rebind(cmbDepartment, () => Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— الكل —"));
        Rebind(cmbLocation, () => Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(Ui.SelectedId(cmbDepartment)), "— الكل —"));
        Ready = ready;

        string? text = Ui.NullIfEmpty(txtSearch.Text);
        int? cat = Ui.SelectedId(cmbCategory), dep = Ui.SelectedId(cmbDepartment), loc = Ui.SelectedId(cmbLocation);
        Bind(AssetService.Search(text, cat, dep, loc, _status));
        UpdateChipCounts(AssetDal.CountByStatus(text, cat, dep, loc));
        ShowDetails(reload: true);
    }

    private int FirstVisibleColumn() => grid.Columns.Cast<DataGridViewColumn>().First(c => c.Visible).Index;
    private static string Title(DataRowView r) => $"{r["الرقم التسلسلي"]} - {r["الاسم"]}";
    private void OpenCard(int? id) => OpenDialog(new AssetDialog(id));

    // ------------------------------------------------------------ أزرار الحالات
    private void StatusChip_Click(object? sender, EventArgs e)
    {
        if (sender is not Button b) return;
        _status = Ui.NullIfEmpty((string)b.Tag!);
        PaintChips();
        Ui.Try(RefreshData);
    }

    /// <summary>الزر المختار ممتلئ بلون أساسي، والباقي بإطار فقط.</summary>
    private void PaintChips()
    {
        foreach (var b in _chips)
        {
            bool selected = (Ui.NullIfEmpty((string)b.Tag!)) == _status;
            b.BackColor = selected ? Theme.Primary : Theme.Surface;
            b.ForeColor = selected ? Color.White : Theme.Primary;
        }
    }

    /// <summary>عدد الأصول على كل زر. "الكل" لا يشمل المؤرشف (كما في القائمة).</summary>
    private void UpdateChipCounts(Dictionary<string, int> counts)
    {
        int N(string s) => counts.GetValueOrDefault(s);
        btnStatusAll.Text = $"الكل ({counts.Where(kv => kv.Key != "Archived").Sum(kv => kv.Value)})";
        btnStatusAvailable.Text = $"متاح ({N("Available")})";
        btnStatusInCustody.Text = $"في عهدة ({N("InCustody")})";
        btnStatusDisposed.Text = $"مُخرَّد ({N("Disposed")})";
        btnStatusArchived.Text = $"مؤرشف ({N("Archived")})";
    }

    private void btnClearFilters_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        Ready = false;
        txtSearch.Clear();
        cmbCategory.SelectedIndex = cmbDepartment.SelectedIndex = 0;
        Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(), "— الكل —");
        _status = null;
        PaintChips();
        Ready = true;
        RefreshData();
    });

    // ------------------------------------------------------------ لوحة التفاصيل + تفعيل الأزرار
    private void ShowDetails(bool reload = false)
    {
        var row = Selected;
        int? id = row?["Id"] as int?;
        UpdateButtons(row);
        if (id == _detailsAssetId && !reload) return;
        _detailsAssetId = id;

        picPhoto.Image?.Dispose();
        picPhoto.Image = null;
        if (row == null)
        {
            lblDetailsTitle.Text = "اختر أصلاً من الجدول";
            foreach (var l in new[] { lblValSerial, lblValCategory, lblValLocation, lblValStatus, lblValHolder, lblValCost, lblValBook, lblValRemaining })
                l.Text = "—";
            lblNoPhoto.Visible = true;
            return;
        }

        lblDetailsTitle.Text = (string)row["الاسم"];
        lblValSerial.Text = (string)row["الرقم التسلسلي"];
        lblValCategory.Text = Ui.Format(row["التصنيف"]);
        lblValLocation.Text = row["الموقع"] is string loc ? $"{row["القسم"]} / {loc}" : "—";
        lblValStatus.Text = Ui.Format(row["الحالة"]);
        lblValStatus.ForeColor = Ui.AssetStatusColor((string)row["Status"]) ?? Theme.Text;
        lblValHolder.Text = row["صاحب العهدة"] is string h ? h : "—";
        lblValCost.Text = Ui.Money((decimal)row["التكلفة"]);
        lblValBook.Text = Ui.Money((decimal)row["القيمة الدفترية"]);
        int remaining = Convert.ToInt32(row["المتبقي من العمر (شهر)"]);
        lblValRemaining.Text = remaining == 0 ? "انتهى عمره" : $"{remaining} شهر";
        lblValRemaining.ForeColor = remaining == 0 ? Theme.Danger : remaining <= 12 ? Theme.Warning : Theme.Text;

        Ui.Try(() => picPhoto.Image = Ui.ToImage(AssetDal.GetImage(id!.Value)));
        lblNoPhoto.Visible = picPhoto.Image == null;
    }

    /// <summary>كل زر يعمل فقط عندما تسمح حالة الأصل المحدد بالعملية.</summary>
    private void UpdateButtons(DataRowView? row)
    {
        string? status = row?["Status"] as string;
        bool any = row != null;
        btnCard.Enabled = btnMaintenance.Enabled = btnHistory.Enabled = btnPhotoChange.Enabled = btnPhotoRemove.Enabled = any;
        btnHandover.Enabled = row == null || status == "Available";   // بدون تحديد: يفتح نافذة التسليم لاختيار أصل
        btnReceive.Enabled = status == "InCustody";
        btnDispose.Enabled = status == "Available";
        btnArchive.Enabled = status is "Available" or "Archived";
        btnArchive.Text = status == "Archived" ? "♻ استرجاع" : "🗄 أرشفة";
    }

    /// <summary>قائمة الزر الأيمن على الجدول: نفس أزرار العمليات وبنفس حالة التفعيل.</summary>
    private ContextMenuStrip BuildContextMenu()
    {
        var menu = new ContextMenuStrip { RightToLeft = RightToLeft.Yes, Font = Theme.Base };
        var pairs = new List<(ToolStripMenuItem Item, Button Button)>();
        foreach (var b in new[] { btnCard, btnHandover, btnReceive, btnMaintenance, btnHistory, btnDispose, btnArchive })
        {
            var item = new ToolStripMenuItem(b.Text, null, (_, _) => b.PerformClick());
            pairs.Add((item, b));
            menu.Items.Add(item);
            if (b == btnReceive || b == btnHistory) menu.Items.Add(new ToolStripSeparator());
        }
        menu.Opening += (_, e) =>
        {
            if (Selected == null) { e.Cancel = true; return; }
            foreach (var (item, button) in pairs)
            {
                item.Text = button.Text;
                item.Enabled = button.Enabled;
            }
        };
        return menu;
    }

    // ------------------------------------------------------------ أزرار العمليات
    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenCard(null));
    private void btnCard_Click(object? sender, EventArgs e) => Ui.Try(() => { if (RequireSelection() is { } r) OpenCard((int)r["Id"]); });
    private void btnHandover_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new HandoverDialog(Selected?["Id"] as int?)));
    private void btnReceive_Click(object? sender, EventArgs e) => Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new ReceiveDialog((int)r["Id"])); });

    private void btnMaintenance_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        using var d = new MaintenanceListDialog((int)r["Id"], Title(r));
        d.ShowDialog(FindForm());
    });

    private void btnHistory_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        int id = (int)r["Id"];
        using var d = new GridDialog("سجل حركات الأصل: " + Title(r), () => CustodyDal.Search(null, false, null, null, assetId: id));
        d.ShowDialog(FindForm());
    });

    private void btnDispose_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new ProposeDisposalDialog((int)r["Id"])); });

    private void btnArchive_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        int id = (int)r["Id"];
        if ((string)r["Status"] == "Archived")
        {
            if (Ui.Confirm($"استرجاع الأصل ({r["الرقم التسلسلي"]}) من الأرشيف؟")) AssetService.Restore(id);
        }
        else if (Ui.Confirm($"أرشفة الأصل ({r["الرقم التسلسلي"]})؟ يظهر بعدها في تبويب \"مؤرشف\" فقط."))
        {
            AssetService.Archive(id);
        }
        RefreshData();
    });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("سجل الأصول"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("سجل الأصول"));

    // ------------------------------------------------------------ الصورة
    private void picPhoto_DoubleClick(object? sender, EventArgs e)
    {
        if (_detailsAssetId is int id) Ui.Try(() => OpenCard(id));
    }

    private void btnPhotoChange_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        using var dlg = new OpenFileDialog { Filter = "الصور|*.jpg;*.jpeg;*.png;*.bmp", Title = "اختر صورة الأصل" };
        if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
        var bytes = File.ReadAllBytes(dlg.FileName);
        using (var test = Ui.ToImage(bytes))
            if (test == null) throw new AppException("الملف المختار ليس صورة صالحة.");
        AssetService.SetImage((int)r["Id"], bytes);
        ShowDetails(reload: true);
    });

    private void btnPhotoRemove_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        if (picPhoto.Image == null) { Ui.Info("لا توجد صورة لهذا الأصل."); return; }
        if (!Ui.Confirm($"حذف صورة الأصل ({r["الرقم التسلسلي"]})؟")) return;
        AssetService.SetImage((int)r["Id"], null);
        ShowDetails(reload: true);
    });
}
