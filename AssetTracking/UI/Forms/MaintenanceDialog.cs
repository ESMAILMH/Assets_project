using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>تسجيل صيانة جديدة أو تعديل سجل موجود.</summary>
public partial class MaintenanceDialog : DialogBase
{
    private readonly int _assetId;
    private readonly int? _id;

    public MaintenanceDialog(int assetId, string assetTitle, int? maintenanceId = null)
    {
        InitializeComponent();
        _assetId = assetId;
        _id = maintenanceId;
        SetTitle(lblHeader, maintenanceId is null ? "تسجيل صيانة" : "تعديل سجل صيانة");
        lblAssetValue.Text = assetTitle;
        cmbType.Items.AddRange(Labels.MaintenanceTypes);   // يمكن الاختيار أو كتابة نوع آخر
        cmbType.SelectedIndex = 0;
        dtpDate.Value = DateTime.Today;
        dtpDate.MaxDate = DateTime.Today;
        numCost.Enabled = false;
        chkHasCost.CheckedChanged += (_, _) => numCost.Enabled = chkHasCost.Checked;

        if (maintenanceId is null) return;
        var r = MaintenanceDal.Get(maintenanceId.Value) ?? throw new AppException("سجل الصيانة غير موجود.");
        dtpDate.Value = (DateTime)r["MaintenanceDate"];
        cmbType.Text = (string)r["Type"];
        txtDescription.Text = r["Description"] as string;
        txtPerformedBy.Text = r["PerformedBy"] as string;
        if (r["Cost"] is decimal cost)
        {
            chkHasCost.Checked = true;
            numCost.Value = cost;
        }
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        OperationsService.SaveMaintenance(_id, _assetId, dtpDate.Value, cmbType.Text, txtDescription.Text, txtPerformedBy.Text,
            chkHasCost.Checked ? numCost.Value : null);
        return true;
    });
}
