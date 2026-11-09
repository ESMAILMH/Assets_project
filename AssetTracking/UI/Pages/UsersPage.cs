using AssetTracking.BLL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>المستخدمون والصلاحيات (للمدير فقط).</summary>
public partial class UsersPage : PageBase
{
    public UsersPage()
    {
        InitializeComponent();
        InitPage(grid, lblCount);
        InitRowActions(btnEdit, btnEdit, btnReset);
        grid.CellFormatting += (_, e) =>
        {
            if (e.RowIndex >= 0 && grid.Rows[e.RowIndex].DataBoundItem is DataRowView r && !(bool)r["IsActive"])
                e.CellStyle!.ForeColor = Theme.MutedText;
        };
    }

    public override void RefreshData() => Bind(UserService.GetAll());

    private void btnAdd_Click(object? sender, EventArgs e) => Ui.Try(() => OpenDialog(new UserDialog(null)));
    private void btnEdit_Click(object? sender, EventArgs e) =>
        Ui.Try(() => { if (RequireSelection() is { } r) OpenDialog(new UserDialog((int)r["Id"])); });

    private void btnReset_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (RequireSelection() is not { } r) return;
        using var d = new ResetPasswordDialog((int)r["Id"], (string)r["اسم المستخدم"]);
        d.ShowDialog(FindForm());
    });
}
