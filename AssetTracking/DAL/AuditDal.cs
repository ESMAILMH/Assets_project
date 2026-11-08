namespace AssetTracking.DAL;

/// <summary>سجل العمليات (AuditLog).</summary>
public static class AuditDal
{
    public static void Log(string action, string entity, int? entityId, string? details,
                           SqlConnection? c = null, SqlTransaction? t = null)
    {
        if (Session.Current == null) return;
        const string sql = @"INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
                             VALUES (@u, @a, @e, @id, @d)";
        var ps = new[] { Db.P("@u", Session.UserId), Db.P("@a", action), Db.P("@e", entity), Db.P("@id", entityId),
                         Db.P("@d", details is { Length: > 500 } ? details[..500] : details) };
        if (c != null) Db.Execute(c, t, sql, ps);
        else Db.Execute(sql, ps);
    }

    public static DataTable Search(int? userId, DateTime from, DateTime to) => Db.Query($@"
        SELECT l.LogId AS Id, l.CreatedAt AS [الوقت], ISNULL(p.FullName, u.Username) AS [المستخدم],
               l.Action AS [العملية], l.EntityName AS [الكيان], l.EntityId AS [المعرّف], l.Details AS [التفاصيل]
        FROM dbo.AuditLog l
        JOIN dbo.[User] u ON u.UserId = l.UserId
        LEFT JOIN dbo.Person p ON p.PersonId = u.PersonId
        WHERE l.CreatedAt >= @from AND l.CreatedAt < DATEADD(DAY, 1, @to) AND (@u IS NULL OR l.UserId = @u)
        ORDER BY l.LogId DESC",
        Db.P("@from", from.Date), Db.P("@to", to.Date), Db.P("@u", userId));

    public static DataTable Recent(int top) => Db.Query(@"
        SELECT TOP (@top) l.LogId AS Id, l.CreatedAt AS [الوقت], ISNULL(p.FullName, u.Username) AS [المستخدم],
               l.Action AS [العملية], l.Details AS [التفاصيل]
        FROM dbo.AuditLog l JOIN dbo.[User] u ON u.UserId = l.UserId LEFT JOIN dbo.Person p ON p.PersonId = u.PersonId
        ORDER BY l.LogId DESC", Db.P("@top", top));
}
