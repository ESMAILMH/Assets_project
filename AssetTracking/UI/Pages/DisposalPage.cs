using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>التخريد: طلبات أمين المخزن واعتماد المدير.</summary>
public sealed class DisposalPage : PageBase
{
    private readonly ComboBox _status;

    public DisposalPage() : base("التخريد")
    {
        _status = AddFilter("الحالة:", 130);
        if (Session.IsManager)
            AddAction("✔ اعتماد / رفض", Theme.Primary, Decide);
        AddPrintExport("طلبات التخريد");
        Grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && Session.IsManager) Ui.Try(Decide); };
        Ui.ColorBy(Grid, "Status", "الحالة", s => s switch
        {
            "Proposed" => Theme.Warning, "Approved" => Theme.Danger, _ => Theme.MutedText
        });
    }

    public override void RefreshData()
    {
        if (_status.DataSource == null)
        {
            Ui.BindCombo(_status, Labels.WithAll(Labels.DisposalStatuses));
            _status.SelectedValue = "Proposed";
        }
        Bind(DisposalDal.Search(Ui.SelectedCode(_status), null, null));
    }

    private void Decide()
    {
        if (RequireSelection() is not { } r) return;
        if ((string)r["Status"] != "Proposed") { Ui.Info("تم البت في هذا الطلب مسبقاً."); return; }
        OpenDialog(new DisposalDecisionDialog((int)r["Id"], $"{r["الرقم التسلسلي"]} - {r["الأصل"]}", (string)r["السبب"]));
    }
}
