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
    private int? _detailsAssetId;

    public AssetsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الرقم التسلسلي، الاسم، الموديل، صاحب العهدة...";
        foreach (var c in new[] { cmbCategory, cmbDepartment, cmbLocation }) c.SelectedIndexChanged += Filter_Changed;
        InitChips(null, btnStatusAll, btnStatusAvailable, btnStatusInCustody, btnStatusDisposed, btnStatusArchived);
        InitRowActions(btnCard, btnCard, btnHandover, btnReceive, btnMaintenance, btnHistory, btnDispose, btnArchive,
                       btnPhotoChange, btnPhotoRemove);
        grid.SelectionChanged += (_, _) => ShowDetails();
        Ui.ColorBy(grid, "Status", "الحالة", Ui.AssetStatusColor);
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
        Bind(AssetService.Search(text, cat, dep, loc, Chip));
        UpdateChipCounts(AssetDal.CountByStatus(text, cat, dep, loc));
        ShowDetails(reload: true);
    }

    private static string Title(DataRowView r) => $"{r["الرقم التسلسلي"]} - {r["الاسم"]}";
    private void OpenCard(int? id) => OpenDialog(new AssetDialog(id));

    // ------------------------------------------------------------ أزرار الحالات
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
        SelectChip(null);
        Ready = true;
        RefreshData();
    });

    // ------------------------------------------------------------ لوحة التفاصيل + تفعيل الأزرار
    private void ShowDetails(bool reload = false)
    {
        var row = Selected;
        int? id = row?["Id"] as int?;
        if (id == _detailsAssetId && !reload) return;
        _detailsAssetId = id;

        picPhoto.Image?.Dispose();
        picPhoto.Image = null;
        if (row == null)
        {
            lblDetailsTitle.Text = "اختر أصلاً من الجدول";
            lblNoPhoto.Visible = true;
            return;
        }

        lblDetailsTitle.Text = (string)row["الاسم"];

        Ui.Try(() => picPhoto.Image = Ui.ToImage(AssetDal.GetImage(id!.Value)));
        lblNoPhoto.Visible = picPhoto.Image == null;
    }

    /// <summary>كل زر يعمل فقط عندما تسمح حالة الأصل المحدد بالعملية (يُستدعى بعد تفعيل أزرار الصف).</summary>
    protected override void OnRowSelected(DataRowView? row)
    {
        string? status = row?["Status"] as string;
        btnHandover.Enabled = row == null || status == "Available";   // بدون تحديد: يفتح نافذة التسليم لاختيار أصل
        btnReceive.Enabled = status == "InCustody";
        btnDispose.Enabled = status == "Available";
        btnArchive.Enabled = status is "Available" or "Archived";
        btnArchive.Text = status == "Archived" ? "♻ استرجاع" : "🗄 أرشفة";
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
