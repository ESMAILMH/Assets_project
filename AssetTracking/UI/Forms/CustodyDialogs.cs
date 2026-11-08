using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>تسليم أصل لشخص (UC-06).</summary>
public sealed class HandoverDialog : BaseDialog
{
    private readonly ComboBox _asset, _person, _condition;
    private readonly DateTimePicker _date;
    private readonly TextBox _notes;
    private readonly CheckBox _print;

    public HandoverDialog(int? assetId = null) : base("تسليم أصل (عهدة شخصية)", 600)
    {
        _asset = AddField("الأصل *", Ui.MakeCombo());
        _person = AddField("المستلم *", Ui.MakeCombo());
        _date = AddField("تاريخ التسليم *", Ui.MakeDate());
        _condition = AddField("حالة الأصل *", Ui.MakeCombo());
        _notes = AddText("ملاحظات", 300, multiline: true);
        _print = AddField("", new CheckBox { Text = "طباعة محضر التسليم بعد الحفظ", Checked = true, AutoSize = true });

        foreach (var c in new[] { _asset, _person })
        {
            c.DropDownStyle = ComboBoxStyle.DropDown;
            c.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            c.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        Ui.BindCombo(_asset, AssetDal.AvailableList(), "— اختر الأصل —");
        Ui.BindCombo(_person, MasterDataDal.PersonList(), "— اختر الشخص —");
        _condition.Items.AddRange(Labels.HandoverConditions);
        _condition.SelectedIndex = 1;
        _date.MaxDate = DateTime.Today;
        if (assetId != null) _asset.SelectedValue = assetId.Value;
        BtnSave.Text = "تسليم";
    }

    protected override bool Save()
    {
        int custodyId = OperationsService.Handover(Ui.SelectedId(_asset), Ui.SelectedId(_person),
            (string)_condition.SelectedItem!, _date.Value, _notes.Text);
        if (_print.Checked) ReportPrinter.Preview(ReportCatalog.CustodyDocument(custodyId), this);
        return true;
    }
}

/// <summary>استلام أصل من صاحب العهدة (UC-07).</summary>
public sealed class ReceiveDialog : BaseDialog
{
    private readonly int _assetId;
    private readonly DateTimePicker _date;
    private readonly ComboBox _condition;
    private readonly CheckBox _print;

    public ReceiveDialog(int assetId) : base("استلام أصل", 540)
    {
        _assetId = assetId;
        int custodyId = CustodyDal.OpenCustodyId(assetId) ?? throw new AppException("لا توجد عهدة مفتوحة لهذا الأصل.");
        var c = CustodyDal.Get(custodyId)!;
        AddInfo("الأصل", $"{c["SerialNo"]} - {c["AssetName"]}");
        AddInfo("صاحب العهدة", (string)c["FullName"]);
        AddInfo("تاريخ التسليم", Ui.Format(c["HandoverDate"]));

        _date = AddField("تاريخ الاستلام *", Ui.MakeDate());
        _condition = AddField("حالة الأصل *", Ui.MakeCombo());
        _print = AddField("", new CheckBox { Text = "طباعة محضر الاستلام بعد الحفظ", Checked = true, AutoSize = true });
        _date.MaxDate = DateTime.Today;
        _date.MinDate = (DateTime)c["HandoverDate"];
        _condition.Items.AddRange(Labels.ReturnConditions);
        _condition.SelectedIndex = 0;
        BtnSave.Text = "استلام";
    }

    protected override bool Save()
    {
        string condition = (string)_condition.SelectedItem!;
        int custodyId = OperationsService.Receive(_assetId, condition, _date.Value);
        if (_print.Checked) ReportPrinter.Preview(ReportCatalog.CustodyDocument(custodyId), this);

        // UC-07 بديل: الأصل تالف ← اقتراح إحالته للتخريد
        if (condition == "تالف" && Ui.Confirm("الأصل تالف. هل تريد اقتراح إحالته للتخريد الآن؟"))
        {
            using var d = new ProposeDisposalDialog(_assetId, "الأصل تالف عند الاستلام");
            d.ShowDialog(this);
        }
        return true;
    }
}
