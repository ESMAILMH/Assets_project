using AssetTracking.BLL;
using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>الأصول: بحث وتصفية، إضافة وتعديل وأرشفة، تسليم واستلام، صيانة، تخريد، وصورة الأصل.</summary>
public partial class AssetsPage : PageBase
{
    private int? _photoAssetId;

    public AssetsPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount, txtSearch);
        txtSearch.PlaceholderText = "الرقم التسلسلي، الاسم، الموديل، صاحب العهدة...";
        foreach (var c in new[] { cmbCategory, cmbDepartment, cmbLocation, cmbStatus }) c.SelectedIndexChanged += Filter_Changed;
        grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && Selected is { } r) Ui.Try(() => OpenCard((int)r["Id"])); };
        grid.SelectionChanged += (_, _) => ShowPhoto();
        Ui.ColorBy(grid, "Status", "الحالة", Ui.AssetStatusColor);
    }

    public override void RefreshData()
    {
        bool ready = Ready;
        Ready = false;
        Rebind(cmbCategory, () => Ui.BindCombo(cmbCategory, MasterDataDal.CategoryList(), "— الكل —"));
        Rebind(cmbDepartment, () => Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— الكل —"));
        Rebind(cmbLocation, () => Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(Ui.SelectedId(cmbDepartment)), "— الكل —"));
        if (cmbStatus.DataSource == null) Ui.BindCombo(cmbStatus, Labels.WithAll(Labels.AssetStatuses));
        Ready = ready;
        Bind(AssetService.Search(txtSearch.Text, Ui.SelectedId(cmbCategory), Ui.SelectedId(cmbDepartment),
            Ui.SelectedId(cmbLocation), Ui.SelectedCode(cmbStatus)));
        ShowPhoto(reload: true);
    }

    private static string Title(DataRowView r) => $"{r["الرقم التسلسلي"]} - {r["الاسم"]}";

    private void OpenCard(int? id) => OpenDialog(new AssetDialog(id));

    // ------------------------------------------------------------ أزرار العمليات
    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenCard(null));
    private void btnCard_Click(object? sender, EventArgs e) => Ui.Try(() => { if (RequireSelection() is { } r) OpenCard((int)r["Id"]); });

    private void btnHandover_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        var r = Selected;
        if (r != null && (string)r["Status"] != "Available")
        {
            Ui.Info("لا يُسلَّم إلا أصل حالته \"متاح\". إذا كان في عهدة شخص آخر فاستلمه أولاً (BR-05).");
            return;
        }
        OpenDialog(new HandoverDialog(r?["Id"] as int?));
    });

    private void btnReceive_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        if ((string)r["Status"] != "InCustody") { Ui.Info("هذا الأصل ليس في عهدة أحد."); return; }
        OpenDialog(new ReceiveDialog((int)r["Id"]));
    });

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
        else if (Ui.Confirm($"أرشفة الأصل ({r["الرقم التسلسلي"]})؟ لن يظهر في القوائم إلا عند اختيار حالة \"مؤرشف\"."))
        {
            AssetService.Archive(id);
        }
        RefreshData();
    });

    private void btnPrint_Click(object? sender, EventArgs e) => Ui.Try(() => PrintGrid("سجل الأصول"));
    private void btnExcel_Click(object? sender, EventArgs e) => Ui.Try(() => ExportGrid("سجل الأصول"));

    // ------------------------------------------------------------ صورة الأصل المحدد
    private void ShowPhoto(bool reload = false)
    {
        var row = Selected;
        int? id = row?["Id"] as int?;
        if (id == _photoAssetId && !reload) return;
        _photoAssetId = id;

        picPhoto.Image?.Dispose();
        picPhoto.Image = null;
        lblPhotoTitle.Text = row == null ? "اختر أصلاً لعرض صورته" : $"{row["الرقم التسلسلي"]}\n{row["الاسم"]}";
        if (id is int assetId) Ui.Try(() => picPhoto.Image = Ui.ToImage(AssetDal.GetImage(assetId)));
        lblNoPhoto.Visible = picPhoto.Image == null;
    }

    private void picPhoto_DoubleClick(object? sender, EventArgs e)
    {
        if (_photoAssetId is int id) Ui.Try(() => OpenCard(id));
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
        ShowPhoto(reload: true);
    });

    private void btnPhotoRemove_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        if (picPhoto.Image == null) { Ui.Info("لا توجد صورة لهذا الأصل."); return; }
        if (!Ui.Confirm($"حذف صورة الأصل ({r["الرقم التسلسلي"]})؟")) return;
        AssetService.SetImage((int)r["Id"], null);
        ShowPhoto(reload: true);
    });
}
