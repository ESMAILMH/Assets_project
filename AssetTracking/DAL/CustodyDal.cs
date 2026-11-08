namespace AssetTracking.DAL;

/// <summary>العهد الشخصية (AssetCustody): التسليم والاستلام عبر الإجراءات المخزنة.</summary>
public static class CustodyDal
{
    private const string Select = @"
        SELECT c.CustodyId AS Id, c.AssetId, c.PersonId, a.SerialNo AS [الرقم التسلسلي], a.Name AS [الأصل],
               p.FullName AS [صاحب العهدة], d.Name AS [القسم], c.HandoverDate AS [تاريخ التسليم],
               c.ConditionAtHandover AS [الحالة عند التسليم], c.ReturnDate AS [تاريخ الاستلام],
               c.ConditionAtReturn AS [الحالة عند الاستلام],
               CASE WHEN c.ReturnDate IS NULL THEN N'مفتوحة' ELSE N'مغلقة' END AS [العهدة],
               c.Notes AS [ملاحظات]
        FROM dbo.AssetCustody c
        JOIN dbo.Asset a ON a.AssetId = c.AssetId
        JOIN dbo.Person p ON p.PersonId = c.PersonId
        JOIN dbo.Department d ON d.DepartmentId = p.DepartmentId";

    public static void Handover(int assetId, int personId, string condition, DateTime date, string? notes) =>
        Db.Proc("dbo.sp_HandoverAsset", Db.P("@AssetId", assetId), Db.P("@PersonId", personId),
            Db.P("@Condition", condition), Db.P("@Date", date.Date), Db.P("@Notes", notes), Db.P("@UserId", Session.UserId));

    public static void Receive(int assetId, string condition, DateTime date) =>
        Db.Proc("dbo.sp_ReceiveAsset", Db.P("@AssetId", assetId), Db.P("@Condition", condition),
            Db.P("@Date", date.Date), Db.P("@UserId", Session.UserId));

    public static DataTable Search(string? text, bool openOnly, DateTime? from, DateTime? to,
                                   int? personId = null, int? assetId = null) => Db.Query(Select + @"
        WHERE (@open = 0 OR c.ReturnDate IS NULL)
          AND (@s IS NULL OR a.SerialNo LIKE N'%' + @s + N'%' OR a.Name LIKE N'%' + @s + N'%' OR p.FullName LIKE N'%' + @s + N'%')
          AND (@from IS NULL OR c.HandoverDate >= @from OR c.ReturnDate >= @from)
          AND (@to IS NULL OR c.HandoverDate <= @to)
          AND (@p IS NULL OR c.PersonId = @p)
          AND (@a IS NULL OR c.AssetId = @a)
        ORDER BY c.HandoverDate DESC, c.CustodyId DESC",
        Db.P("@open", openOnly), Db.P("@s", text), Db.P("@from", from?.Date), Db.P("@to", to?.Date),
        Db.P("@p", personId), Db.P("@a", assetId));

    public static DataRow? Get(int custodyId) => Db.Row(@"
        SELECT c.*, a.SerialNo, a.Name AS AssetName, a.Model, p.FullName, p.EmployeeNo, d.Name AS DepartmentName
        FROM dbo.AssetCustody c
        JOIN dbo.Asset a ON a.AssetId = c.AssetId
        JOIN dbo.Person p ON p.PersonId = c.PersonId
        JOIN dbo.Department d ON d.DepartmentId = p.DepartmentId
        WHERE c.CustodyId = @id", Db.P("@id", custodyId));

    public static int? OpenCustodyId(int assetId) =>
        Db.Scalar("SELECT CustodyId FROM dbo.AssetCustody WHERE AssetId=@a AND ReturnDate IS NULL", Db.P("@a", assetId)) as int?;

    public static int? LastCustodyId(int assetId) =>
        Db.Scalar("SELECT MAX(CustodyId) FROM dbo.AssetCustody WHERE AssetId=@a", Db.P("@a", assetId)) as int?;
}
