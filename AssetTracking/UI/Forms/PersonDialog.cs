using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

public partial class PersonDialog : DialogBase
{
    private readonly int? _id;

    public PersonDialog(int? id)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة شخص" : "تعديل بيانات شخص");
        Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— اختر —");
        if (id is null) return;
        var r = MasterDataDal.Person(id.Value)!;
        txtName.Text = (string)r["FullName"];
        txtEmployeeNo.Text = r["EmployeeNo"] as string;
        cmbDepartment.SelectedValue = r["DepartmentId"];
        txtPhone.Text = r["Phone"] as string;
        chkActive.Checked = (bool)r["IsActive"];
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        MasterDataService.SavePerson(_id, txtName.Text, txtEmployeeNo.Text, Ui.SelectedId(cmbDepartment), txtPhone.Text, chkActive.Checked);
        return true;
    });
}
