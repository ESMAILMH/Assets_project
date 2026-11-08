using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>سجل صيانة أصل: عرض، تسجيل صيانة جديدة، وتعديل سجل موجود (UC-08).</summary>
public sealed class MaintenanceListDialog : GridDialog
{
    private readonly int _assetId;
    private readonly string _title;

    public MaintenanceListDialog(int assetId, string assetTitle)
        : base("سجل صيانة الأصل: " + assetTitle, () => MaintenanceDal.Search(assetId, null, null), 900, 460)
    {
        _assetId = assetId;
        _title = assetTitle;
        if (!Session.CanManage) return;
        Buttons.Controls.Add(Ui.MakeButton("➕ تسجيل صيانة", Theme.Primary, (_, _) => Ui.Try(() => Edit(null))));
        Buttons.Controls.Add(Ui.MakeButton("✏ تعديل", Theme.Info, (_, _) => Ui.Try(EditSelected)));
        Grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) Ui.Try(EditSelected); };
    }

    private void EditSelected()
    {
        if (Ui.CurrentRow(Grid) is not { } r) { Ui.Info("حدد سجل الصيانة المراد تعديله."); return; }
        Edit((int)r["Id"]);
    }

    private void Edit(int? maintenanceId)
    {
        using var d = new MaintenanceDialog(_assetId, _title, maintenanceId);
        if (d.ShowDialog(this) == DialogResult.OK) Reload();
    }
}

/// <summary>نافذة تسجيل صيانة جديدة أو تعديل سجل موجود.</summary>
public sealed class MaintenanceDialog : BaseDialog
{
    private readonly int _assetId;
    private readonly int? _id;
    private readonly DateTimePicker _date;
    private readonly ComboBox _type;
    private readonly TextBox _desc, _by;
    private readonly NumericUpDown _cost;
    private readonly CheckBox _hasCost;

    public MaintenanceDialog(int assetId, string assetTitle, int? maintenanceId = null)
        : base(maintenanceId is null ? "تسجيل صيانة" : "تعديل سجل صيانة", 540)
    {
        _assetId = assetId;
        _id = maintenanceId;
        AddInfo("الأصل", assetTitle);
        _date = AddField("التاريخ *", Ui.MakeDate());
        _type = AddField("النوع *", Ui.MakeCombo());
        _desc = AddText("الوصف", 500, multiline: true);
        _by = AddText("الجهة المنفذة", 100);
        _hasCost = AddField("", new CheckBox { Text = "لها تكلفة", AutoSize = true });
        _cost = AddField("التكلفة (د.ل)", Ui.MakeMoney());
        _cost.Enabled = false;
        _hasCost.CheckedChanged += (_, _) => _cost.Enabled = _hasCost.Checked;

        // يمكن الاختيار من القائمة أو كتابة نوع آخر
        _type.DropDownStyle = ComboBoxStyle.DropDown;
        _type.Items.AddRange(Labels.MaintenanceTypes);
        _type.SelectedIndex = 0;
        _date.MaxDate = DateTime.Today;

        if (maintenanceId is null) return;
        var r = MaintenanceDal.Get(maintenanceId.Value) ?? throw new AppException("سجل الصيانة غير موجود.");
        _date.Value = (DateTime)r["MaintenanceDate"];
        _type.Text = (string)r["Type"];
        _desc.Text = r["Description"] as string;
        _by.Text = r["PerformedBy"] as string;
        if (r["Cost"] is decimal c)
        {
            _hasCost.Checked = true;
            _cost.Value = c;
        }
    }

    protected override bool Save()
    {
        OperationsService.SaveMaintenance(_id, _assetId, _date.Value, _type.Text, _desc.Text, _by.Text,
            _hasCost.Checked ? _cost.Value : null);
        return true;
    }
}
