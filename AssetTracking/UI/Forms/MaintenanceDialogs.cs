using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>سجل صيانة أصل مع إمكانية إضافة عملية صيانة (UC-08).</summary>
public sealed class MaintenanceListDialog : GridDialog
{
    private readonly int _assetId;
    private readonly string _title;

    public MaintenanceListDialog(int assetId, string assetTitle)
        : base("سجل صيانة الأصل: " + assetTitle, () => MaintenanceDal.Search(assetId, null, null), 900, 460)
    {
        _assetId = assetId;
        _title = assetTitle;
        if (Session.CanManage)
            Buttons.Controls.Add(Ui.MakeButton("➕ تسجيل صيانة", Theme.Primary, (_, _) => Ui.Try(Add)));
    }

    private void Add()
    {
        using var d = new MaintenanceDialog(_assetId, _title);
        if (d.ShowDialog(this) == DialogResult.OK) Reload();
    }
}

public sealed class MaintenanceDialog : BaseDialog
{
    private readonly int _assetId;
    private readonly DateTimePicker _date;
    private readonly ComboBox _type;
    private readonly TextBox _desc, _by;
    private readonly NumericUpDown _cost;
    private readonly CheckBox _hasCost;

    public MaintenanceDialog(int assetId, string assetTitle) : base("تسجيل صيانة", 540)
    {
        _assetId = assetId;
        AddInfo("الأصل", assetTitle);
        _date = AddField("التاريخ *", Ui.MakeDate());
        _type = AddField("النوع *", Ui.MakeCombo());
        _desc = AddText("الوصف", 500, multiline: true);
        _by = AddText("الجهة المنفذة", 100);
        _hasCost = AddField("", new CheckBox { Text = "لها تكلفة", AutoSize = true });
        _cost = AddField("التكلفة (د.ل)", Ui.MakeMoney());
        _cost.Enabled = false;
        _hasCost.CheckedChanged += (_, _) => _cost.Enabled = _hasCost.Checked;
        _type.Items.AddRange(Labels.MaintenanceTypes);
        _type.SelectedIndex = 0;
        _date.MaxDate = DateTime.Today;
    }

    protected override bool Save()
    {
        OperationsService.AddMaintenance(_assetId, _date.Value, (string)_type.SelectedItem!, _desc.Text, _by.Text,
            _hasCost.Checked ? _cost.Value : null);
        return true;
    }
}
