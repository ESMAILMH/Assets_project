using AssetTracking.BLL;
using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>الأصول: بحث وتصفية، إضافة وتعديل وأرشفة، تسليم واستلام، صيانة، تخريد، واستيراد من Excel.</summary>
public sealed class AssetsPage : PageBase
{
    private readonly TextBox _search;
    private readonly ComboBox _category, _department, _location, _status;
    private readonly PictureBox _photo = new()
    {
        Dock = DockStyle.Top, Height = 230, SizeMode = PictureBoxSizeMode.Zoom,
        BackColor = Theme.Surface, BorderStyle = BorderStyle.FixedSingle, Cursor = Cursors.Hand
    };
    private readonly Label _photoTitle = new()
    {
        Dock = DockStyle.Top, Height = 52, Font = Theme.Bold, TextAlign = ContentAlignment.MiddleCenter
    };
    private readonly Label _noPhoto = new()
    {
        Dock = DockStyle.Fill, Text = "لا توجد صورة", ForeColor = Theme.MutedText, TextAlign = ContentAlignment.MiddleCenter
    };
    private int? _photoAssetId;

    public AssetsPage() : base("الأصول")
    {
        _search = AddSearchBox("الرقم التسلسلي، الاسم، الموديل، صاحب العهدة...");
        _category = AddFilter("التصنيف:");
        _department = AddFilter("القسم:");
        _location = AddFilter("الموقع:", 170);
        _status = AddFilter("الحالة:", 110);

        AddAction("➕ إضافة", Theme.Primary, () => OpenCard(null));
        AddAction("📥 استيراد Excel", Theme.Success, Import);
        AddAction("📄 بطاقة / تعديل", Theme.Info, () => { if (RequireSelection() is { } r) OpenCard((int)r["Id"]); });
        AddAction("📤 تسليم", Theme.Warning, Handover);
        AddAction("↩ استلام", Theme.Warning, Receive);
        AddAction("🔧 الصيانة", Theme.Neutral, Maintenance);
        AddAction("🕘 الحركات", Theme.Neutral, History);
        AddAction("♻ اقتراح تخريد", Theme.Danger, ProposeDisposal);
        AddAction("🗄 أرشفة / استرجاع", Theme.Neutral, ToggleArchive);
        AddPrintExport("سجل الأصول");
        Grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && Selected is { } r) Ui.Try(() => OpenCard((int)r["Id"])); };
        Ui.ColorBy(Grid, "Status", "الحالة", Ui.AssetStatusColor);
        BuildPhotoPanel();
    }

    // ------------------------------------------------------------ صورة الأصل
    /// <summary>لوحة جانبية تعرض صورة الأصل المحدد، مع أزرار إضافة/تغيير وحذف الصورة.</summary>
    private void BuildPhotoPanel()
    {
        var side = new Panel { Dock = DockStyle.Right, Width = 270, Padding = new Padding(12, 0, 0, 0) };
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(0, 6, 0, 0) };
        buttons.Controls.Add(Ui.MakeButton("🖼 إضافة / تغيير الصورة", Theme.Primary, (_, _) => Ui.Try(ChangePhoto)));
        buttons.Controls.Add(Ui.MakeButton("حذف الصورة", Theme.Neutral, (_, _) => Ui.Try(RemovePhoto)));
        _photo.Controls.Add(_noPhoto);
        _photo.DoubleClick += (_, _) => { if (_photoAssetId is int id) Ui.Try(() => OpenCard(id)); };
        _noPhoto.DoubleClick += (_, _) => { if (_photoAssetId is int id) Ui.Try(() => OpenCard(id)); };

        side.Controls.Add(buttons);
        side.Controls.Add(_photo);
        side.Controls.Add(_photoTitle);
        Controls.Add(side);
        Controls.SetChildIndex(side, 1); // بجانب الجدول وتحت شريط الأدوات

        Grid.SelectionChanged += (_, _) => ShowPhoto();
        ShowPhoto();
    }

    private void ShowPhoto(bool reload = false)
    {
        var row = Selected;
        int? id = row?["Id"] as int?;
        if (id == _photoAssetId && !reload) return;
        _photoAssetId = id;

        _photo.Image?.Dispose();
        _photo.Image = null;
        _photoTitle.Text = row == null ? "اختر أصلاً لعرض صورته" : $"{row["الرقم التسلسلي"]}\n{row["الاسم"]}";
        if (id is int assetId) Ui.Try(() => _photo.Image = Ui.ToImage(AssetDal.GetImage(assetId)));
        _noPhoto.Visible = _photo.Image == null;
    }

    private void ChangePhoto()
    {
        if (RequireSelection() is not { } r) return;
        using var dlg = new OpenFileDialog { Filter = "الصور|*.jpg;*.jpeg;*.png;*.bmp", Title = "اختر صورة الأصل" };
        if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
        var bytes = File.ReadAllBytes(dlg.FileName);
        using (var test = Ui.ToImage(bytes))
            if (test == null) throw new AppException("الملف المختار ليس صورة صالحة.");
        AssetService.SetImage((int)r["Id"], bytes);
        ShowPhoto(reload: true);
    }

    private void RemovePhoto()
    {
        if (RequireSelection() is not { } r) return;
        if (_photo.Image == null) { Ui.Info("لا توجد صورة لهذا الأصل."); return; }
        if (!Ui.Confirm($"حذف صورة الأصل ({r["الرقم التسلسلي"]})؟")) return;
        AssetService.SetImage((int)r["Id"], null);
        ShowPhoto(reload: true);
    }

    public override void RefreshData()
    {
        bool ready = Ready;
        Ready = false;
        Rebind(_category, () => Ui.BindCombo(_category, MasterDataDal.CategoryList(), "— الكل —"));
        Rebind(_department, () => Ui.BindCombo(_department, MasterDataDal.DepartmentList(), "— الكل —"));
        Rebind(_location, () => Ui.BindCombo(_location, MasterDataDal.LocationList(Ui.SelectedId(_department)), "— الكل —"));
        if (_status.DataSource == null) Ui.BindCombo(_status, Labels.WithAll(Labels.AssetStatuses));
        Ready = ready;
        Bind(AssetService.Search(_search.Text, Ui.SelectedId(_category), Ui.SelectedId(_department),
            Ui.SelectedId(_location), Ui.SelectedCode(_status)));
        if (_photoTitle.Parent != null) ShowPhoto(reload: true);
    }

    private string Title(DataRowView r) => $"{r["الرقم التسلسلي"]} - {r["الاسم"]}";

    private void OpenCard(int? id) => OpenDialog(new AssetDialog(id));

    private void Import() => OpenDialog(new ImportDialog());

    private void Handover()
    {
        var r = Selected;
        if (r != null && (string)r["Status"] != "Available")
        {
            Ui.Info("لا يُسلَّم إلا أصل حالته \"متاح\". إذا كان في عهدة شخص آخر فاستلمه أولاً (BR-05).");
            return;
        }
        OpenDialog(new HandoverDialog(r?["Id"] as int?));
    }

    private void Receive()
    {
        if (RequireSelection() is not { } r) return;
        if ((string)r["Status"] != "InCustody") { Ui.Info("هذا الأصل ليس في عهدة أحد."); return; }
        OpenDialog(new ReceiveDialog((int)r["Id"]));
    }

    private void Maintenance()
    {
        if (RequireSelection() is not { } r) return;
        using var d = new MaintenanceListDialog((int)r["Id"], Title(r));
        d.ShowDialog(FindForm());
    }

    private void History()
    {
        if (RequireSelection() is not { } r) return;
        int id = (int)r["Id"];
        using var d = new GridDialog("سجل حركات الأصل: " + Title(r), () => CustodyDal.Search(null, false, null, null, assetId: id));
        d.ShowDialog(FindForm());
    }

    private void ProposeDisposal()
    {
        if (RequireSelection() is not { } r) return;
        OpenDialog(new ProposeDisposalDialog((int)r["Id"]));
    }

    private void ToggleArchive()
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
    }
}
