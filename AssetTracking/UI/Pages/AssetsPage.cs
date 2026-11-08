using AssetTracking.BLL;
using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>الأصول: بحث وتصفية، إضافة وتعديل وأرشفة، تسليم واستلام، صيانة، تخريد، واستيراد من Excel.</summary>
public sealed class AssetsPage : PageBase
{
    private readonly TextBox _search;
    private readonly ComboBox _category, _department, _location, _status;

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
