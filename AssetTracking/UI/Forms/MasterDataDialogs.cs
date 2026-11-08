using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

public sealed class DepartmentDialog : BaseDialog
{
    private readonly int? _id;
    private readonly TextBox _name;
    private readonly CheckBox _active;

    public DepartmentDialog(int? id) : base(id is null ? "إضافة قسم" : "تعديل قسم", 460)
    {
        _id = id;
        _name = AddText("اسم القسم *", 100);
        _active = AddField("", new CheckBox { Text = "فعّال", Checked = true, AutoSize = true });
        if (id is null) return;
        var r = MasterDataDal.Department(id.Value)!;
        _name.Text = (string)r["Name"];
        _active.Checked = (bool)r["IsActive"];
    }

    protected override bool Save()
    {
        MasterDataService.SaveDepartment(_id, _name.Text, _active.Checked);
        return true;
    }
}

public sealed class LocationDialog : BaseDialog
{
    private readonly int? _id;
    private readonly TextBox _name;
    private readonly ComboBox _dept;
    private readonly CheckBox _active;

    public LocationDialog(int? id) : base(id is null ? "إضافة موقع" : "تعديل موقع", 480)
    {
        _id = id;
        _dept = AddField("القسم *", Ui.MakeCombo());
        _name = AddText("اسم الموقع *", 100);
        _active = AddField("", new CheckBox { Text = "فعّال", Checked = true, AutoSize = true });
        Ui.BindCombo(_dept, MasterDataDal.DepartmentList(), "— اختر —");
        if (id is null) return;
        var r = MasterDataDal.Location(id.Value)!;
        _name.Text = (string)r["Name"];
        _dept.SelectedValue = r["DepartmentId"];
        _active.Checked = (bool)r["IsActive"];
    }

    protected override bool Save()
    {
        MasterDataService.SaveLocation(_id, _name.Text, Ui.SelectedId(_dept), _active.Checked);
        return true;
    }
}

public sealed class CategoryDialog : BaseDialog
{
    private readonly int? _id;
    private readonly TextBox _name;
    private readonly NumericUpDown _life;

    public CategoryDialog(int? id) : base(id is null ? "إضافة تصنيف" : "تعديل تصنيف", 460)
    {
        _id = id;
        _name = AddText("اسم التصنيف *", 100);
        _life = AddField("العمر الافتراضي (سنة) *", new NumericUpDown { Minimum = 1, Maximum = 100, Value = 5, Width = 120 });
        if (id is null) return;
        var r = MasterDataDal.Category(id.Value)!;
        _name.Text = (string)r["Name"];
        _life.Value = (int)r["DefaultLifeYears"];
    }

    protected override bool Save()
    {
        MasterDataService.SaveCategory(_id, _name.Text, (int)_life.Value);
        return true;
    }
}

public sealed class PersonDialog : BaseDialog
{
    private readonly int? _id;
    private readonly TextBox _name, _no, _phone;
    private readonly ComboBox _dept;
    private readonly CheckBox _active;

    public PersonDialog(int? id) : base(id is null ? "إضافة شخص" : "تعديل بيانات شخص", 500)
    {
        _id = id;
        _name = AddText("الاسم الكامل *");
        _no = AddText("الرقم الوظيفي", 30);
        _dept = AddField("القسم *", Ui.MakeCombo());
        _phone = AddText("الهاتف", 30);
        _phone.RightToLeft = RightToLeft.No;
        _active = AddField("", new CheckBox { Text = "فعّال", Checked = true, AutoSize = true });
        Ui.BindCombo(_dept, MasterDataDal.DepartmentList(), "— اختر —");
        if (id is null) return;
        var r = MasterDataDal.Person(id.Value)!;
        _name.Text = (string)r["FullName"];
        _no.Text = r["EmployeeNo"] as string;
        _dept.SelectedValue = r["DepartmentId"];
        _phone.Text = r["Phone"] as string;
        _active.Checked = (bool)r["IsActive"];
    }

    protected override bool Save()
    {
        MasterDataService.SavePerson(_id, _name.Text, _no.Text, Ui.SelectedId(_dept), _phone.Text, _active.Checked);
        return true;
    }
}

public sealed class UserDialog : BaseDialog
{
    private readonly int? _id;
    private readonly TextBox _username, _password, _confirm;
    private readonly ComboBox _role, _person;
    private readonly CheckBox _active;

    public UserDialog(int? id) : base(id is null ? "إضافة مستخدم" : "تعديل مستخدم", 500)
    {
        _id = id;
        _username = AddText("اسم المستخدم *", 50);
        _username.RightToLeft = RightToLeft.No;
        _role = AddField("الدور *", Ui.MakeCombo());
        _person = AddField("الشخص المرتبط", Ui.MakeCombo());
        _active = AddField("", new CheckBox { Text = "الحساب فعّال", Checked = true, AutoSize = true });
        Ui.BindCombo(_role, Labels.Roles);
        Ui.BindCombo(_person, MasterDataDal.PersonList(), "— بدون —");

        if (id is null)
        {
            _password = AddText("كلمة المرور *", 100);
            _confirm = AddText("تأكيد كلمة المرور *", 100);
            _password.UseSystemPasswordChar = _confirm.UseSystemPasswordChar = true;
            _role.SelectedValue = nameof(UserRole.Employee);
            return;
        }
        _password = _confirm = new TextBox();
        var r = UserDal.Get(id.Value)!;
        _username.Text = (string)r["Username"];
        _role.SelectedValue = (string)r["Role"];
        _person.SelectedValue = r["PersonId"] is int p ? p : 0;
        _active.Checked = (bool)r["IsActive"];
    }

    protected override bool Save()
    {
        if (_id is null && _password.Text != _confirm.Text) throw new AppException("كلمة المرور وتأكيدها غير متطابقين.");
        UserService.Save(_id, _username.Text, Enum.Parse<UserRole>(Ui.SelectedCode(_role)!), Ui.SelectedId(_person),
            _active.Checked, _id is null ? _password.Text : null);
        return true;
    }
}

public sealed class ResetPasswordDialog : BaseDialog
{
    private readonly int _userId;
    private readonly TextBox _password, _confirm;

    public ResetPasswordDialog(int userId, string username) : base("إعادة تعيين كلمة المرور", 460)
    {
        _userId = userId;
        AddInfo("المستخدم", username);
        _password = AddText("كلمة المرور الجديدة", 100);
        _confirm = AddText("التأكيد", 100);
        _password.UseSystemPasswordChar = _confirm.UseSystemPasswordChar = true;
    }

    protected override bool Save()
    {
        if (_password.Text != _confirm.Text) throw new AppException("كلمة المرور وتأكيدها غير متطابقين.");
        UserService.ResetPassword(_userId, _password.Text);
        Ui.Info("تم تعيين كلمة المرور الجديدة.");
        return true;
    }
}
