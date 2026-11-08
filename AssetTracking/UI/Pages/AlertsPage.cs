using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>تنبيهات انتهاء العمر (UC-15): أصول في آخر سنة من عمرها وأصول انتهى عمرها.</summary>
public sealed class AlertsPage : PageBase
{
    private readonly ComboBox _type, _department, _category;

    public AlertsPage() : base("تنبيهات انتهاء العمر")
    {
        _type = AddFilter("التنبيه:", 170);
        _department = AddFilter("القسم:");
        _category = AddFilter("التصنيف:");
        Toolbar.Controls.Add(Ui.MakeLabel("الأصل المنتهي يبقى قيد الاستخدام حتى يعتمد المدير تخريده.", Theme.Small, Theme.MutedText));

        AddAction("📄 بطاقة الأصل", Theme.Info, () => { if (RequireSelection() is { } r) OpenDialog(new AssetDialog((int)r["Id"])); });
        if (Session.CanManage)
            AddAction("♻ اقتراح تخريد", Theme.Danger, () => { if (RequireSelection() is { } r) OpenDialog(new ProposeDisposalDialog((int)r["Id"])); });
        AddPrintExport("تنبيهات انتهاء العمر");
        Grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && Grid.Rows[e.RowIndex].DataBoundItem is DataRowView r)
                e.CellStyle!.ForeColor = (string)r["AlertType"] == "Expired" ? Theme.Danger : Theme.Warning;
        };
    }

    public override void RefreshData()
    {
        bool ready = Ready;
        Ready = false;
        if (_type.DataSource == null) Ui.BindCombo(_type, Labels.WithAll(Labels.AlertTypes));
        Rebind(_department, () => Ui.BindCombo(_department, MasterDataDal.DepartmentList(), "— الكل —"));
        Rebind(_category, () => Ui.BindCombo(_category, MasterDataDal.CategoryList(), "— الكل —"));
        Ready = ready;
        Bind(AssetDal.Alerts(Ui.SelectedCode(_type), Ui.SelectedId(_department), Ui.SelectedId(_category)));
    }
}
