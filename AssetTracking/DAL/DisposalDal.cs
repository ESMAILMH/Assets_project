namespace AssetTracking.DAL;

/// <summary>التخريد (Disposal): اقتراح من أمين المخزن واعتماد من المدير عبر الإجراءات المخزنة.</summary>
public static class DisposalDal
{
    public static void Propose(int assetId, string reason) =>
        Db.Proc("dbo.sp_ProposeDisposal", Db.P("@AssetId", assetId), Db.P("@Reason", reason), Db.P("@UserId", Session.UserId));

    public static void Decide(int disposalId, bool approve, string? documentNo) =>
        Db.Proc("dbo.sp_ApproveDisposal", Db.P("@DisposalId", disposalId), Db.P("@Approve", approve),
            Db.P("@DocumentNo", documentNo), Db.P("@ManagerId", Session.UserId));

    public static DataTable Search(string? status, DateTime? from, DateTime? to) => Db.Query($@"
        SELECT x.DisposalId AS Id, x.AssetId, x.Status,
               a.SerialNo AS [الرقم التسلسلي], a.Name AS [الأصل], v.BookValue AS [القيمة الدفترية],
               x.ProposedDate AS [تاريخ الاقتراح], x.Reason AS [السبب], ISNULL(pp.FullName, up.Username) AS [اقترحه],
               {Labels.Sql(Labels.SqlDisposalStatus, "x.Status")} AS [الحالة],
               ISNULL(pa.FullName, ua.Username) AS [اعتمده], x.ApprovedDate AS [تاريخ القرار], x.DocumentNo AS [رقم المحضر]
        FROM dbo.Disposal x
        JOIN dbo.Asset a ON a.AssetId = x.AssetId
        JOIN dbo.vw_AssetValuation v ON v.AssetId = x.AssetId
        JOIN dbo.[User] up ON up.UserId = x.ProposedBy LEFT JOIN dbo.Person pp ON pp.PersonId = up.PersonId
        LEFT JOIN dbo.[User] ua ON ua.UserId = x.ApprovedBy LEFT JOIN dbo.Person pa ON pa.PersonId = ua.PersonId
        WHERE (@st IS NULL OR x.Status = @st)
          AND (@from IS NULL OR x.ProposedDate >= @from) AND (@to IS NULL OR x.ProposedDate <= @to)
        ORDER BY x.DisposalId DESC",
        Db.P("@st", status), Db.P("@from", from?.Date), Db.P("@to", to?.Date));
}
