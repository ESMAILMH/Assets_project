using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>فتح جلسة جرد لقسم أو موقع.</summary>
public partial class NewInventoryDialog : DialogBase
{
    public int SessionId { get; private set; }

    public NewInventoryDialog()
    {
        InitializeComponent();
        lblHint.Text = "اترك الحقلين على \"الكل\" لجرد كل الأصول.";
        lblHint.ForeColor = Theme.MutedText;
        Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— كل الأقسام —");
        Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(), "— كل المواقع —");
        cmbDepartment.SelectedIndexChanged += (_, _) =>
            Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(Ui.SelectedId(cmbDepartment)), "— كل المواقع —");
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        SessionId = InventoryService.Open(Ui.SelectedId(cmbDepartment), Ui.SelectedId(cmbLocation));
        return true;
    });
}
