using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

public partial class UserDialog : DialogBase
{
    private readonly int? _id;

    public UserDialog(int? id)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة مستخدم" : "تعديل مستخدم");
        Ui.BindCombo(cmbRole, Labels.Roles);
        Ui.BindCombo(cmbPerson, MasterDataDal.PersonList(), "— بدون —");

        if (id is null)
        {
            cmbRole.SelectedValue = nameof(UserRole.Employee);
            return;
        }
        // عند التعديل لا تظهر كلمة المرور (تُغيَّر من زر "إعادة تعيين كلمة المرور")
        foreach (var c in new Control[] { txtPassword, txtConfirm, lblPassword, lblConfirm }) c.Visible = false;
        ClientSize = new Size(ClientSize.Width, ClientSize.Height - 80);

        var r = UserDal.Get(id.Value)!;
        txtUsername.Text = (string)r["Username"];
        cmbRole.SelectedValue = (string)r["Role"];
        cmbPerson.SelectedValue = r["PersonId"] is int p ? p : 0;
        chkActive.Checked = (bool)r["IsActive"];
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        if (_id is null && txtPassword.Text != txtConfirm.Text) throw new AppException("كلمة المرور وتأكيدها غير متطابقين.");
        UserService.Save(_id, txtUsername.Text, Enum.Parse<UserRole>(Ui.SelectedCode(cmbRole)!), Ui.SelectedId(cmbPerson),
            chkActive.Checked, _id is null ? txtPassword.Text : null);
        return true;
    });
}
