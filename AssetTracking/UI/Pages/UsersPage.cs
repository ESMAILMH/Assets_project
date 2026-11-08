using AssetTracking.BLL;
using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>المستخدمون والصلاحيات (للمدير فقط).</summary>
public sealed class UsersPage : PageBase
{
    public UsersPage() : base("المستخدمون والصلاحيات")
    {
        AddAction("➕ إضافة", Theme.Primary, () => Edit(null));
        AddAction("✏ تعديل", Theme.Info, () => { if (RequireSelection() is { } r) Edit((int)r["Id"]); });
        AddAction("🔑 إعادة تعيين كلمة المرور", Theme.Warning, () =>
        {
            if (RequireSelection() is not { } r) return;
            using var d = new ResetPasswordDialog((int)r["Id"], (string)r["اسم المستخدم"]);
            d.ShowDialog(FindForm());
        });
        Toolbar.Controls.Add(Ui.MakeLabel("مدير: كل الصلاحيات واعتماد التخريد — أمين مخزن: التشغيل اليومي — موظف: يعرض أصوله فقط",
            Theme.Small, Theme.MutedText));
        Grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && Selected is { } r) Ui.Try(() => Edit((int)r["Id"])); };
    }

    public override void RefreshData() => Bind(UserService.GetAll());

    private void Edit(int? id)
    {
        OpenDialog(new UserDialog(id));
    }
}

/// <summary>سجل العمليات: من فعل ماذا ومتى (للمدير فقط).</summary>
public sealed class AuditPage : PageBase
{
    private readonly ComboBox _user;
    private readonly DateTimePicker _from, _to;

    public AuditPage() : base("سجل العمليات")
    {
        _user = AddFilter("المستخدم:", 180);
        _from = AddTool("من:", Ui.MakeDate());
        _to = AddTool("إلى:", Ui.MakeDate());
        _from.Value = DateTime.Today.AddDays(-30);
        _from.ValueChanged += (_, _) => { if (Ready) Ui.Try(RefreshData); };
        _to.ValueChanged += (_, _) => { if (Ready) Ui.Try(RefreshData); };
        AddPrintExport("سجل العمليات", () => $"من {_from.Value:yyyy/MM/dd} إلى {_to.Value:yyyy/MM/dd}");
    }

    public override void RefreshData()
    {
        Session.Demand(Session.IsManager);
        if (_user.DataSource == null) Ui.BindCombo(_user, ReportLists.Users(), "— الكل —");
        Bind(AuditDal.Search(Ui.SelectedId(_user), _from.Value, _to.Value));
    }
}
