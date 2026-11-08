namespace AssetTracking.DAL;

/// <summary>سجل الصيانة (MaintenanceRecord) — اختياري ولا يغيّر حالة الأصل.</summary>
public static class MaintenanceDal
{
    public static void Insert(int assetId, DateTime date, string type, string? description, string? performedBy, decimal? cost) =>
        Db.Execute(@"INSERT dbo.MaintenanceRecord (AssetId, MaintenanceDate, Type, Description, PerformedBy, Cost, CreatedBy)
                     VALUES (@a, @d, @t, @desc, @by, @c, @u)",
            Db.P("@a", assetId), Db.P("@d", date.Date), Db.P("@t", type), Db.P("@desc", description),
            Db.P("@by", performedBy), Db.P("@c", cost), Db.P("@u", Session.UserId));

    public static DataTable Search(int? assetId, DateTime? from, DateTime? to) => Db.Query(@"
        SELECT m.MaintenanceId AS Id, a.SerialNo AS [الرقم التسلسلي], a.Name AS [الأصل], m.MaintenanceDate AS [التاريخ],
               m.Type AS [النوع], m.Description AS [الوصف], m.PerformedBy AS [الجهة المنفذة], m.Cost AS [التكلفة]
        FROM dbo.MaintenanceRecord m JOIN dbo.Asset a ON a.AssetId = m.AssetId
        WHERE (@a IS NULL OR m.AssetId = @a) AND (@from IS NULL OR m.MaintenanceDate >= @from)
          AND (@to IS NULL OR m.MaintenanceDate <= @to)
        ORDER BY m.MaintenanceDate DESC, m.MaintenanceId DESC",
        Db.P("@a", assetId), Db.P("@from", from?.Date), Db.P("@to", to?.Date));
}
