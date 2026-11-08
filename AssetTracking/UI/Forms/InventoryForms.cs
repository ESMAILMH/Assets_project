using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>فتح جلسة جرد لقسم أو موقع.</summary>
public sealed class NewInventoryDialog : BaseDialog
{
    private readonly ComboBox _dept, _loc;
    public int SessionId { get; private set; }

    public NewInventoryDialog() : base("فتح جلسة جرد", 500)
    {
        _dept = AddField("القسم", Ui.MakeCombo());
        _loc = AddField("الموقع", Ui.MakeCombo());
        AddInfo("", "اترك الحقلين على \"الكل\" لجرد كل الأصول.");
        Ui.BindCombo(_dept, MasterDataDal.DepartmentList(), "— كل الأقسام —");
        Ui.BindCombo(_loc, MasterDataDal.LocationList(), "— كل المواقع —");
        _dept.SelectedIndexChanged += (_, _) =>
            Ui.BindCombo(_loc, MasterDataDal.LocationList(Ui.SelectedId(_dept)), "— كل المواقع —");
        BtnSave.Text = "فتح الجلسة";
    }

    protected override bool Save()
    {
        SessionId = InventoryService.Open(Ui.SelectedId(_dept), Ui.SelectedId(_loc));
        return true;
    }
}

/// <summary>
/// تنفيذ الجرد (UC-10): النظام يعرض الأصول المتوقعة، والأمين يُدخل الرقم التسلسلي لكل أصل وجده فعلياً،
/// ثم يغلق الجلسة فيظهر الموجود والمفقود والزائد وما مكانه مختلف.
/// </summary>
public sealed class InventorySessionForm : Form
{
    private readonly int _sessionId;
    private readonly DataGridView _grid = Ui.MakeGrid();
    private readonly TextBox _serial;
    private readonly Label _message, _summary, _header;
    private readonly Button _close;

    public InventorySessionForm(int sessionId)
    {
        _sessionId = sessionId;
        Text = "جلسة جرد رقم " + sessionId;
        Ui.ApplyRtl(this);
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(1040, 680);
        BackColor = Theme.Background;

        _header = new Label { Dock = DockStyle.Top, Height = 40, Font = Theme.Subtitle, ForeColor = Theme.Primary, Padding = new Padding(12, 8, 12, 0) };
        var bar = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(12, 4, 12, 4) };
        bar.Controls.Add(Ui.MakeLabel("الرقم التسلسلي للأصل الموجود:", Theme.Bold));
        _serial = Ui.MakeTextBox(220, "اكتب الرقم ثم Enter");
        _serial.RightToLeft = RightToLeft.No;
        _serial.KeyDown += (_, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Register(); } };
        bar.Controls.Add(_serial);
        bar.Controls.Add(Ui.MakeButton("تسجيل", Theme.Primary, (_, _) => Register()));
        _message = Ui.MakeLabel("", Theme.Bold);
        bar.Controls.Add(_message);

        _summary = new Label { Dock = DockStyle.Top, Height = 28, Padding = new Padding(12, 4, 12, 0), ForeColor = Theme.Text };
        var host = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12, 0, 12, 0) };
        host.Controls.Add(_grid);
        _grid.CellFormatting += ColorResult;

        var bottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 58, Padding = new Padding(12, 10, 12, 6) };
        _close = Ui.MakeButton("إغلاق الجلسة وحساب النتيجة", Theme.Danger, (_, _) => Ui.Try(CloseSession));
        bottom.Controls.Add(_close);
        bottom.Controls.Add(Ui.MakeButton("🖨 كشف الجرد", Theme.Neutral, (_, _) => Ui.Try(Print)));
        bottom.Controls.Add(Ui.MakeButton("Excel", Theme.Success, (_, _) =>
            Ui.Try(() => Ui.ExportExcel((DataTable)_grid.DataSource, "جرد_" + _sessionId, this))));
        var exit = Ui.MakeButton("رجوع", Theme.Primary, (_, _) => Close());
        bottom.Controls.Add(exit);
        CancelButton = exit;

        Controls.Add(host);
        Controls.Add(_summary);
        Controls.Add(bar);
        Controls.Add(_header);
        Controls.Add(bottom);
        Load += (_, _) => Ui.Try(Reload);
    }

    private void Reload()
    {
        var s = InventoryDal.GetSession(_sessionId)!;
        bool open = (string)s["Status"] == "Open";
        _header.Text = $"جلسة رقم {_sessionId} — {s["DepartmentName"]} / {s["LocationName"]} — {(open ? "مفتوحة" : "مغلقة")}";
        _serial.Enabled = _close.Enabled = open;
        var t = InventoryDal.Lines(_sessionId);
        Ui.BindGrid(_grid, t);
        int Count(string? r) => t.AsEnumerable().Count(x => x["Result"] as string == r);
        _summary.Text = $"لم يُسجَّل بعد: {Count(null)}   |   موجود: {Count("Found")}   |   مفقود: {Count("Missing")}   |   " +
                        $"زائد: {Count("Surplus")}   |   مكانه مختلف: {Count("DifferentLocation")}";
        if (open) _serial.Focus();
    }

    private void Register()
    {
        try
        {
            _message.Text = InventoryService.Register(_sessionId, _serial.Text);
            _message.ForeColor = _message.Text.StartsWith("✔") ? Theme.Success : Theme.Warning;
            Reload();
        }
        catch (AppException ex)
        {
            _message.Text = ex.Message;
            _message.ForeColor = Theme.Danger;
        }
        catch (Exception ex)
        {
            Ui.ShowError(ex);
        }
        _serial.Clear();
        _serial.Focus();
    }

    private void CloseSession()
    {
        if (!Ui.Confirm("بعد الإغلاق تُسجَّل كل الأصول غير المسجلة كـ \"مفقود\" ولا يمكن التعديل. متابعة؟")) return;
        int missing = InventoryService.Close(_sessionId);
        Reload();
        Ui.Info($"تم إغلاق الجلسة. عدد المفقود: {missing}");
    }

    private void Print() => ReportPrinter.Preview(ReportCatalog.InventoryResult(_sessionId), this);

    private void ColorResult(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || _grid.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;
        e.CellStyle!.ForeColor = (r["Result"] as string) switch
        {
            "Found" => Theme.Success,
            "Missing" => Theme.Danger,
            "Surplus" or "DifferentLocation" => Theme.Warning,
            _ => Theme.Text
        };
    }
}
