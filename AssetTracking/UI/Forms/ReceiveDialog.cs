using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>استلام أصل من صاحب العهدة (UC-07).</summary>
public partial class ReceiveDialog : DialogBase
{
    private readonly int _assetId;

    public ReceiveDialog(int assetId)
    {
        InitializeComponent();
        _assetId = assetId;
        int custodyId = CustodyDal.OpenCustodyId(assetId) ?? throw new AppException("لا توجد عهدة مفتوحة لهذا الأصل.");
        var c = CustodyDal.Get(custodyId)!;
        lblAssetValue.Text = $"{c["SerialNo"]} - {c["AssetName"]}";
        lblHolderValue.Text = (string)c["FullName"];
        lblHandoverValue.Text = Ui.Format(c["HandoverDate"]);
        dtpDate.Value = DateTime.Today;
        dtpDate.MaxDate = DateTime.Today;
        dtpDate.MinDate = (DateTime)c["HandoverDate"];
        cmbCondition.Items.AddRange(Labels.ReturnConditions);
        cmbCondition.SelectedIndex = 0;
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        string condition = (string)cmbCondition.SelectedItem!;
        int custodyId = OperationsService.Receive(_assetId, condition, dtpDate.Value);
        if (chkPrint.Checked) ReportPrinter.Preview(ReportCatalog.CustodyDocument(custodyId), this);

        // UC-07 بديل: الأصل تالف ← اقتراح إحالته للتخريد
        if (condition == "تالف" && Ui.Confirm("الأصل تالف. هل تريد اقتراح إحالته للتخريد الآن؟"))
        {
            using var d = new ProposeDisposalDialog(_assetId, "الأصل تالف عند الاستلام");
            d.ShowDialog(this);
        }
        return true;
    });
}
