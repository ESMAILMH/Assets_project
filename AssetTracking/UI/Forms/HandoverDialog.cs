using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>تسليم أصل لشخص (UC-06).</summary>
public partial class HandoverDialog : DialogBase
{
    public HandoverDialog(int? assetId = null)
    {
        InitializeComponent();
        foreach (var c in new[] { cmbAsset, cmbPerson })
        {
            c.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            c.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        Ui.BindCombo(cmbAsset, AssetDal.AvailableList(), "— اختر الأصل —");
        Ui.BindCombo(cmbPerson, MasterDataDal.PersonList(), "— اختر الشخص —");
        cmbCondition.Items.AddRange(Labels.HandoverConditions);
        cmbCondition.SelectedIndex = 1;
        dtpDate.Value = DateTime.Today;
        dtpDate.MaxDate = DateTime.Today;
        if (assetId != null) cmbAsset.SelectedValue = assetId.Value;
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        int custodyId = OperationsService.Handover(Ui.SelectedId(cmbAsset), Ui.SelectedId(cmbPerson),
            (string)cmbCondition.SelectedItem!, dtpDate.Value, txtNotes.Text);
        if (chkPrint.Checked) ReportPrinter.Preview(ReportCatalog.CustodyDocument(custodyId), this);
        return true;
    });
}
