using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>التسليم والاستلام: العهد المفتوحة وسجل الحركات، مع طباعة المحاضر.</summary>
public sealed class CustodyPage : PageBase
{
    private readonly TextBox _search;
    private readonly ComboBox _view;
    private readonly DateTimePicker _from, _to;

    public CustodyPage() : base("التسليم والاستلام")
    {
        _search = AddSearchBox("الأصل، الرقم التسلسلي، صاحب العهدة...");
        _view = AddFilter("عرض:", 160);
        _view.Items.AddRange(new object[] { "العهد المفتوحة", "كل الحركات" });
        _view.SelectedIndex = 0;
        _from = AddTool("من:", Ui.MakeDate());
        _to = AddTool("إلى:", Ui.MakeDate());
        _from.Value = DateTime.Today.AddMonths(-6);
        _from.ValueChanged += (_, _) => { if (Ready) Ui.Try(RefreshData); };
        _to.ValueChanged += (_, _) => { if (Ready) Ui.Try(RefreshData); };

        AddAction("📤 تسليم أصل", Theme.Primary, () => OpenDialog(new HandoverDialog()));
        AddAction("↩ استلام", Theme.Success, Receive);
        AddAction("🧾 طباعة المحضر", Theme.Info, Document);
        AddPrintExport("حركات العهد", () => OpenOnly ? "العهد المفتوحة" : $"من {_from.Value:yyyy/MM/dd} إلى {_to.Value:yyyy/MM/dd}");
        Grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) Ui.Try(Document); };
    }

    private bool OpenOnly => _view.SelectedIndex == 0;

    public override void RefreshData()
    {
        _from.Enabled = _to.Enabled = !OpenOnly;
        Bind(OpenOnly
            ? CustodyDal.Search(Ui.NullIfEmpty(_search.Text), true, null, null)
            : CustodyDal.Search(Ui.NullIfEmpty(_search.Text), false, _from.Value, _to.Value));
    }

    private void Receive()
    {
        if (RequireSelection() is not { } r) return;
        if (r["تاريخ الاستلام"] != DBNull.Value) { Ui.Info("هذه العهدة مغلقة (تم الاستلام)."); return; }
        OpenDialog(new ReceiveDialog((int)r["AssetId"]));
    }

    private void Document()
    {
        if (RequireSelection() is not { } r) return;
        ReportPrinter.Preview(ReportCatalog.CustodyDocument((int)r["Id"]), FindForm());
    }
}
