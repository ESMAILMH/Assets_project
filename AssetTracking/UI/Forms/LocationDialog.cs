using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

public partial class LocationDialog : DialogBase
{
    private readonly int? _id;

    public LocationDialog(int? id)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة موقع" : "تعديل موقع");
        Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— اختر —");
        if (id is null) return;
        var r = MasterDataDal.Location(id.Value)!;
        txtName.Text = (string)r["Name"];
        cmbDepartment.SelectedValue = r["DepartmentId"];
        chkActive.Checked = (bool)r["IsActive"];
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        MasterDataService.SaveLocation(_id, txtName.Text, Ui.SelectedId(cmbDepartment), chkActive.Checked);
        return true;
    });
}
