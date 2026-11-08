using AssetTracking.DAL;

namespace AssetTracking.BLL;

/// <summary>العهد (تسليم/استلام)، الصيانة، والتخريد.</summary>
public static class OperationsService
{
    // ------------------------------------------------------------ العهد
    /// <summary>تسليم أصل لشخص. يرجع رقم العهدة لطباعة المحضر.</summary>
    public static int Handover(int? assetId, int? personId, string condition, DateTime date, string? notes)
    {
        Session.Demand(Session.CanManage);
        if (assetId is null) throw new AppException("الرجاء اختيار الأصل.");
        if (personId is null) throw new AppException("الرجاء اختيار الشخص المستلم.");
        if (date.Date > DateTime.Today) throw new AppException("تاريخ التسليم لا يمكن أن يكون في المستقبل.");
        CustodyDal.Handover(assetId.Value, personId.Value, condition, date, string.IsNullOrWhiteSpace(notes) ? null : notes.Trim());
        return CustodyDal.OpenCustodyId(assetId.Value)!.Value;
    }

    /// <summary>استلام أصل من صاحب العهدة. يرجع رقم العهدة لطباعة المحضر.</summary>
    public static int Receive(int assetId, string condition, DateTime date)
    {
        Session.Demand(Session.CanManage);
        int custodyId = CustodyDal.OpenCustodyId(assetId) ?? throw new AppException("لا توجد عهدة مفتوحة لهذا الأصل.");
        var c = CustodyDal.Get(custodyId)!;
        if (date.Date > DateTime.Today) throw new AppException("تاريخ الاستلام لا يمكن أن يكون في المستقبل.");
        if (date.Date < (DateTime)c["HandoverDate"]) throw new AppException("تاريخ الاستلام لا يمكن أن يسبق تاريخ التسليم.");
        CustodyDal.Receive(assetId, condition, date);
        return custodyId;
    }

    // ------------------------------------------------------------ الصيانة
    /// <summary>إضافة سجل صيانة (id = null) أو تعديله.</summary>
    public static void SaveMaintenance(int? id, int assetId, DateTime date, string type, string? description, string? performedBy, decimal? cost)
    {
        if (id is null)
        {
            AddMaintenance(assetId, date, type, description, performedBy, cost);
            return;
        }
        Session.Demand(Session.CanManage);
        ValidateMaintenance(date, type, cost);
        MaintenanceDal.Update(id.Value, date, type.Trim(), Trim(description), Trim(performedBy), cost);
        AuditDal.Log("EditMaintenance", "Asset", assetId, type);
    }

    private static void ValidateMaintenance(DateTime date, string type, decimal? cost)
    {
        if (string.IsNullOrWhiteSpace(type)) throw new AppException("الرجاء اختيار نوع الصيانة.");
        if (date.Date > DateTime.Today) throw new AppException("تاريخ الصيانة لا يمكن أن يكون في المستقبل.");
        if (cost < 0) throw new AppException("التكلفة لا يمكن أن تكون سالبة.");
    }

    public static void AddMaintenance(int assetId, DateTime date, string type, string? description, string? performedBy, decimal? cost)
    {
        Session.Demand(Session.CanManage);
        ValidateMaintenance(date, type, cost);
        MaintenanceDal.Insert(assetId, date, type.Trim(), Trim(description), Trim(performedBy), cost);
        AuditDal.Log("AddMaintenance", "Asset", assetId, type);
    }

    // ------------------------------------------------------------ التخريد
    public static void ProposeDisposal(int assetId, string reason)
    {
        Session.Demand(Session.CanManage);
        if (string.IsNullOrWhiteSpace(reason)) throw new AppException("الرجاء كتابة سبب التخريد.");
        DisposalDal.Propose(assetId, reason.Trim());
    }

    public static void DecideDisposal(int disposalId, bool approve, string? documentNo)
    {
        Session.Demand(Session.IsManager);
        if (approve && string.IsNullOrWhiteSpace(documentNo)) throw new AppException("الرجاء إدخال رقم محضر التخريد.");
        DisposalDal.Decide(disposalId, approve, Trim(documentNo));
    }

    private static string? Trim(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
}
