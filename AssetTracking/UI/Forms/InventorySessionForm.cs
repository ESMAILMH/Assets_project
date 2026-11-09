using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>
/// تنفيذ الجرد (UC-10): النظام يعرض الأصول المتوقعة، والأمين يُدخل الرقم التسلسلي لكل أصل وجده فعلياً،
/// ثم يغلق الجلسة فيظهر الموجود والمفقود والزائد وما مكانه مختلف.
/// </summary>
public partial class InventorySessionForm : Form
{
    private readonly int _sessionId;

    public InventorySessionForm(int sessionId)
    {
        InitializeComponent();
        Ui.ApplyIcon(this);
        Ui.StyleGrid(grid);
        _sessionId = sessionId;
        Text = "جلسة جرد رقم " + sessionId;
        txtSerial.PlaceholderText = "اكتب الرقم ثم Enter";
        txtSerial.KeyDown += (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            Register();
        };
        grid.CellFormatting += ColorResult;
    }

    private void InventorySessionForm_Load(object? sender, EventArgs e) => Ui.Try(Reload);

    private void Reload()
    {
        var s = InventoryDal.GetSession(_sessionId)!;
        bool open = (string)s["Status"] == "Open";
        lblHeader.Text = $"جلسة رقم {_sessionId} — {s["DepartmentName"]} / {s["LocationName"]} — {(open ? "مفتوحة" : "مغلقة")}";
        txtSerial.Enabled = btnRegister.Enabled = btnCloseSession.Enabled = open;
        var t = InventoryDal.Lines(_sessionId);
        Ui.BindGrid(grid, t);
        int Count(string? r) => t.AsEnumerable().Count(x => x["Result"] as string == r);
        lblSummary.Text = $"لم يُسجَّل بعد: {Count(null)}   |   موجود: {Count("Found")}   |   مفقود: {Count("Missing")}   |   " +
                          $"زائد: {Count("Surplus")}   |   مكانه مختلف: {Count("DifferentLocation")}";
        if (open) txtSerial.Focus();
    }

    private void Register()
    {
        try
        {
            lblMessage.Text = InventoryService.Register(_sessionId, txtSerial.Text);
            lblMessage.ForeColor = lblMessage.Text.StartsWith("✔") ? Theme.Success : Theme.Warning;
            Reload();
        }
        catch (AppException ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = Theme.Danger;
        }
        catch (Exception ex)
        {
            Ui.ShowError(ex);
        }
        txtSerial.Clear();
        txtSerial.Focus();
    }

    private void btnRegister_Click(object? sender, EventArgs e) => Register();

    private void btnCloseSession_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        if (!Ui.Confirm("بعد الإغلاق تُسجَّل كل الأصول غير المسجلة كـ \"مفقود\" ولا يمكن التعديل. متابعة؟")) return;
        int missing = InventoryService.Close(_sessionId);
        Reload();
        Ui.Info($"تم إغلاق الجلسة. عدد المفقود: {missing}");
    });

    private void btnPrint_Click(object? sender, EventArgs e) =>
        Ui.Try(() => ReportPrinter.Preview(ReportCatalog.InventoryResult(_sessionId), this));

    private void btnExcel_Click(object? sender, EventArgs e) =>
        Ui.Try(() => Ui.ExportExcel((DataTable)grid.DataSource, "جرد_" + _sessionId, this));

    private void btnBack_Click(object? sender, EventArgs e) => Close();

    private void ColorResult(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || grid.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;
        e.CellStyle!.ForeColor = (r["Result"] as string) switch
        {
            "Found" => Theme.Success,
            "Missing" => Theme.Danger,
            "Surplus" or "DifferentLocation" => Theme.Warning,
            _ => Theme.Text
        };
    }
}
