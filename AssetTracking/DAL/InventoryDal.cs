namespace AssetTracking.DAL;

/// <summary>الجرد: جلسات الجرد (InventorySession) وبنودها (InventoryLine).</summary>
public static class InventoryDal
{
    /// <summary>الأصول المتوقع وجودها في نطاق الجلسة (قسم أو موقع أو الكل).</summary>
    private const string ExpectedCte = @"
        WITH s AS (SELECT * FROM dbo.InventorySession WHERE SessionId = @sid),
        expected AS (
            SELECT a.AssetId FROM dbo.Asset a
            LEFT JOIN dbo.Location l ON l.LocationId = a.LocationId
            CROSS JOIN s
            WHERE a.Status IN (N'Available', N'InCustody')
              AND (s.LocationId IS NULL OR a.LocationId = s.LocationId)
              AND (s.DepartmentId IS NULL OR l.DepartmentId = s.DepartmentId))";

    public static int Create(int? departmentId, int? locationId) => Convert.ToInt32(Db.Scalar(@"
        INSERT dbo.InventorySession (DepartmentId, LocationId, CreatedBy) OUTPUT INSERTED.SessionId VALUES (@d, @l, @u)",
        Db.P("@d", departmentId), Db.P("@l", locationId), Db.P("@u", Session.UserId)));

    public static DataTable Sessions() => Db.Query(@"
        SELECT s.SessionId AS Id, s.Status, s.SessionId AS [رقم الجلسة], s.SessionDate AS [التاريخ],
               ISNULL(d.Name, N'كل الأقسام') AS [القسم], ISNULL(l.Name, N'كل المواقع') AS [الموقع],
               CASE s.Status WHEN N'Open' THEN N'مفتوحة' ELSE N'مغلقة' END AS [الحالة],
               (SELECT COUNT(*) FROM dbo.InventoryLine x WHERE x.SessionId = s.SessionId AND x.Result = N'Found') AS [موجود],
               (SELECT COUNT(*) FROM dbo.InventoryLine x WHERE x.SessionId = s.SessionId AND x.Result = N'Missing') AS [مفقود],
               (SELECT COUNT(*) FROM dbo.InventoryLine x WHERE x.SessionId = s.SessionId AND x.Result IN (N'Surplus', N'DifferentLocation')) AS [زائد / مكانه مختلف]
        FROM dbo.InventorySession s
        LEFT JOIN dbo.Department d ON d.DepartmentId = s.DepartmentId
        LEFT JOIN dbo.Location l ON l.LocationId = s.LocationId
        ORDER BY s.SessionId DESC");

    public static DataRow? GetSession(int id) => Db.Row(@"
        SELECT s.*, ISNULL(d.Name, N'كل الأقسام') AS DepartmentName, ISNULL(l.Name, N'كل المواقع') AS LocationName
        FROM dbo.InventorySession s
        LEFT JOIN dbo.Department d ON d.DepartmentId = s.DepartmentId
        LEFT JOIN dbo.Location l ON l.LocationId = s.LocationId
        WHERE s.SessionId = @id", Db.P("@id", id));

    /// <summary>الأصول المتوقعة + ما سُجل في الجلسة، مع نتيجة كل أصل.</summary>
    public static DataTable Lines(int sessionId) => Db.Query(ExpectedCte + $@"
        SELECT a.AssetId AS Id, il.Result, a.SerialNo AS [الرقم التسلسلي], a.Name AS [الأصل],
               d.Name AS [القسم المسجل], l.Name AS [الموقع المسجل], p.FullName AS [صاحب العهدة],
               CASE WHEN il.Result IS NULL THEN N'لم يُسجَّل بعد' ELSE {Labels.Sql(Labels.SqlInventoryResult, "il.Result")} END AS [النتيجة]
        FROM (SELECT AssetId FROM expected UNION SELECT AssetId FROM dbo.InventoryLine WHERE SessionId = @sid) x
        JOIN dbo.Asset a ON a.AssetId = x.AssetId
        LEFT JOIN dbo.Location l ON l.LocationId = a.LocationId
        LEFT JOIN dbo.Department d ON d.DepartmentId = l.DepartmentId
        LEFT JOIN dbo.AssetCustody c ON c.AssetId = a.AssetId AND c.ReturnDate IS NULL
        LEFT JOIN dbo.Person p ON p.PersonId = c.PersonId
        LEFT JOIN dbo.InventoryLine il ON il.SessionId = @sid AND il.AssetId = a.AssetId
        ORDER BY CASE WHEN il.Result IS NULL THEN 0 ELSE 1 END, a.SerialNo", Db.P("@sid", sessionId));

    public static bool IsExpected(int sessionId, int assetId) => Db.Int(ExpectedCte + @"
        SELECT COUNT(*) FROM expected WHERE AssetId = @a", Db.P("@sid", sessionId), Db.P("@a", assetId)) > 0;

    public static bool HasLine(int sessionId, int assetId) =>
        Db.Int("SELECT COUNT(*) FROM dbo.InventoryLine WHERE SessionId=@s AND AssetId=@a",
            Db.P("@s", sessionId), Db.P("@a", assetId)) > 0;

    public static void AddLine(int sessionId, int assetId, string result) =>
        Db.Execute("INSERT dbo.InventoryLine (SessionId, AssetId, Result) VALUES (@s, @a, @r)",
            Db.P("@s", sessionId), Db.P("@a", assetId), Db.P("@r", result));

    /// <summary>إغلاق الجلسة: كل أصل متوقع لم يُسجَّل يصبح "مفقود".</summary>
    public static int Close(int sessionId)
    {
        int missing = 0;
        Db.Transaction((c, t) =>
        {
            missing = Db.Execute(c, t, ExpectedCte + @"
                INSERT dbo.InventoryLine (SessionId, AssetId, Result)
                SELECT @sid, e.AssetId, N'Missing' FROM expected e
                WHERE NOT EXISTS (SELECT 1 FROM dbo.InventoryLine x WHERE x.SessionId = @sid AND x.AssetId = e.AssetId)",
                Db.P("@sid", sessionId));
            Db.Execute(c, t, "UPDATE dbo.InventorySession SET Status = N'Closed' WHERE SessionId = @sid", Db.P("@sid", sessionId));
            AuditDal.Log("CloseInventory", "InventorySession", sessionId, $"Missing={missing}", c, t);
        });
        return missing;
    }
}
