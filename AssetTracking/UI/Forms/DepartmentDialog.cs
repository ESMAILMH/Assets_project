using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

public partial class DepartmentDialog : DialogBase
{
    private readonly int? _id;

    public DepartmentDialog(int? id)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة قسم" : "تعديل قسم");
        if (id is null) return;
        var r = MasterDataDal.Department(id.Value)!;
        txtName.Text = (string)r["Name"];
        chkActive.Checked = (bool)r["IsActive"];
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        MasterDataService.SaveDepartment(_id, txtName.Text, chkActive.Checked);
        return true;
    });
}
