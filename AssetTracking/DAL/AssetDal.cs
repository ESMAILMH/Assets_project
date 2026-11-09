namespace AssetTracking.DAL;

/// <summary>بيانات الأصل كما تُدخل من الشاشة أو من ملف Excel.</summary>
public sealed class AssetInput
{
    public string SerialNo { get; set; } = "";
    public string Name { get; set; } = "";
    public int CategoryId { get; set; }
    public string? Model { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public DateTime InServiceDate { get; set; } = DateTime.Today;
    public decimal Cost { get; set; }
    public int LifeYears { get; set; }
    public decimal SalvageValue { get; set; }
    public int? LocationId { get; set; }
}

/// <summary>جدول الأصول (Asset) وعرض الإهلاك (vw_AssetValuation) والتنبيهات (vw_EndOfLifeAlerts).</summary>
public static class AssetDal
{
    private static readonly string StatusText = Labels.Sql(Labels.SqlAssetStatus, "a.Status");

    private static string BaseSelect => $@"
        SELECT a.AssetId AS Id, a.Status, c.PersonId AS HolderId,
               a.SerialNo AS [الرقم التسلسلي], a.Name AS [الاسم], cat.Name AS [التصنيف],
               d.Name AS [القسم], l.Name AS [الموقع], {StatusText} AS [الحالة], p.FullName AS [صاحب العهدة],
               a.Cost AS [التكلفة], v.BookValue AS [القيمة الدفترية], CAST(v.RemainingMonths AS INT) AS [المتبقي من العمر (شهر)]
        FROM dbo.Asset a
        JOIN dbo.AssetCategory cat ON cat.CategoryId = a.CategoryId
        JOIN dbo.vw_AssetValuation v ON v.AssetId = a.AssetId
        LEFT JOIN dbo.Location l ON l.LocationId = a.LocationId
        LEFT JOIN dbo.Department d ON d.DepartmentId = l.DepartmentId
        LEFT JOIN dbo.AssetCustody c ON c.AssetId = a.AssetId AND c.ReturnDate IS NULL
        LEFT JOIN dbo.Person p ON p.PersonId = c.PersonId";

    /// <summary>
    /// البحث بالرقم التسلسلي أو الاسم أو الموديل أو اسم صاحب العهدة، مع التصفية بالتصنيف والقسم والموقع والحالة والشخص.
    /// الأصول المؤرشفة لا تظهر إلا عند اختيار حالة "مؤرشف".
    /// </summary>
    public static DataTable Search(string? text, int? categoryId, int? departmentId, int? locationId,
                                   string? status, int? holderId = null) => Db.Query(BaseSelect + @"
        WHERE (@s IS NULL OR a.SerialNo LIKE N'%' + @s + N'%' OR a.Name LIKE N'%' + @s + N'%'
               OR a.Model LIKE N'%' + @s + N'%' OR p.FullName LIKE N'%' + @s + N'%')
          AND (@cat IS NULL OR a.CategoryId = @cat)
          AND (@dep IS NULL OR l.DepartmentId = @dep)
          AND (@loc IS NULL OR a.LocationId = @loc)
          AND ((@st IS NULL AND a.Status <> N'Archived') OR a.Status = @st)
          AND (@holder IS NULL OR c.PersonId = @holder)
        ORDER BY a.SerialNo",
        Db.P("@s", text), Db.P("@cat", categoryId), Db.P("@dep", departmentId), Db.P("@loc", locationId),
        Db.P("@st", status), Db.P("@holder", holderId));

    /// <summary>عدد الأصول في كل حالة بنفس شروط البحث (لعرض العدد على أزرار الحالات).</summary>
    public static Dictionary<string, int> CountByStatus(string? text, int? categoryId, int? departmentId, int? locationId) =>
        Db.Query(@"
            SELECT a.Status, COUNT(*) AS N
            FROM dbo.Asset a
            LEFT JOIN dbo.Location l ON l.LocationId = a.LocationId
            LEFT JOIN dbo.AssetCustody c ON c.AssetId = a.AssetId AND c.ReturnDate IS NULL
            LEFT JOIN dbo.Person p ON p.PersonId = c.PersonId
            WHERE (@s IS NULL OR a.SerialNo LIKE N'%' + @s + N'%' OR a.Name LIKE N'%' + @s + N'%'
                   OR a.Model LIKE N'%' + @s + N'%' OR p.FullName LIKE N'%' + @s + N'%')
              AND (@cat IS NULL OR a.CategoryId = @cat)
              AND (@dep IS NULL OR l.DepartmentId = @dep)
              AND (@loc IS NULL OR a.LocationId = @loc)
            GROUP BY a.Status",
            Db.P("@s", text), Db.P("@cat", categoryId), Db.P("@dep", departmentId), Db.P("@loc", locationId))
        .AsEnumerable().ToDictionary(r => (string)r["Status"], r => (int)r["N"]);

    public static DataRow? Get(int id) => Db.Row(@"
        SELECT a.AssetId, a.SerialNo, a.Name, a.CategoryId, a.Model, a.PurchaseDate, a.InServiceDate, a.Cost,
               a.LifeYears, a.SalvageValue, a.LocationId, l.DepartmentId, a.Status, a.CreatedAt,
               v.AccumulatedDepreciation, v.BookValue, v.RemainingMonths, v.MonthsElapsed
        FROM dbo.Asset a
        JOIN dbo.vw_AssetValuation v ON v.AssetId = a.AssetId
        LEFT JOIN dbo.Location l ON l.LocationId = a.LocationId
        WHERE a.AssetId = @id", Db.P("@id", id));

    public static DataRow? GetBySerial(string serial) => Db.Row(@"
        SELECT a.AssetId, a.SerialNo, a.Name, a.Status, a.LocationId, l.DepartmentId
        FROM dbo.Asset a LEFT JOIN dbo.Location l ON l.LocationId = a.LocationId
        WHERE a.SerialNo = @s", Db.P("@s", serial));

    public static byte[]? GetImage(int id) =>
        Db.Scalar("SELECT Image FROM dbo.Asset WHERE AssetId=@id", Db.P("@id", id)) as byte[];

    private static SqlParameter[] Params(AssetInput a, int? id) => new[]
    {
        Db.P("@sn", a.SerialNo), Db.P("@n", a.Name), Db.P("@c", a.CategoryId), Db.P("@m", a.Model),
        Db.P("@pd", a.PurchaseDate?.Date), Db.P("@sd", a.InServiceDate.Date), Db.P("@cost", a.Cost),
        Db.P("@life", a.LifeYears), Db.P("@salv", a.SalvageValue), Db.P("@loc", a.LocationId), Db.P("@id", id)
    };

    public static int Insert(AssetInput a, SqlConnection? c = null, SqlTransaction? t = null)
    {
        const string sql = @"
            INSERT dbo.Asset (SerialNo, Name, CategoryId, Model, PurchaseDate, InServiceDate, Cost, LifeYears, SalvageValue, LocationId)
            OUTPUT INSERTED.AssetId
            VALUES (@sn, @n, @c, @m, @pd, @sd, @cost, @life, @salv, @loc)";
        var v = c != null ? Db.Scalar(c, t, sql, Params(a, null)) : Db.Scalar(sql, Params(a, null));
        return Convert.ToInt32(v);
    }

    public static void Update(int id, AssetInput a) => Db.Execute(@"
        UPDATE dbo.Asset SET SerialNo=@sn, Name=@n, CategoryId=@c, Model=@m, PurchaseDate=@pd, InServiceDate=@sd,
               Cost=@cost, LifeYears=@life, SalvageValue=@salv, LocationId=@loc
        WHERE AssetId=@id", Params(a, id));

    public static void SetImage(int id, byte[]? image) =>
        Db.Execute("UPDATE dbo.Asset SET Image=@img WHERE AssetId=@id", Db.Binary("@img", image), Db.P("@id", id));

    public static void SetStatus(int id, string status) =>
        Db.Execute("UPDATE dbo.Asset SET Status=@s WHERE AssetId=@id", Db.P("@s", status), Db.P("@id", id));

    /// <summary>هل للأصل حركات (عهد، صيانة، تخريد، جرد)؟ عندها يُمنع تعديل رقمه التسلسلي.</summary>
    public static bool HasMovements(int id) => Db.Int(@"
        SELECT CASE WHEN EXISTS (SELECT 1 FROM dbo.AssetCustody WHERE AssetId=@id)
                      OR EXISTS (SELECT 1 FROM dbo.MaintenanceRecord WHERE AssetId=@id)
                      OR EXISTS (SELECT 1 FROM dbo.Disposal WHERE AssetId=@id)
                      OR EXISTS (SELECT 1 FROM dbo.InventoryLine WHERE AssetId=@id) THEN 1 ELSE 0 END",
        Db.P("@id", id)) == 1;

    public static bool SerialExists(string serial, int? exceptId = null) =>
        Db.Int("SELECT COUNT(*) FROM dbo.Asset WHERE SerialNo=@s AND (@id IS NULL OR AssetId<>@id)",
            Db.P("@s", serial), Db.P("@id", exceptId)) > 0;

    public static HashSet<string> AllSerials() =>
        Db.Query("SELECT SerialNo FROM dbo.Asset").AsEnumerable()
          .Select(r => r.Field<string>(0)!).ToHashSet(StringComparer.OrdinalIgnoreCase);

    /// <summary>الأصول المتاحة للتسليم (Id, Name).</summary>
    public static DataTable AvailableList() => Db.Query(@"
        SELECT AssetId AS Id, SerialNo + N' - ' + Name AS Name FROM dbo.Asset
        WHERE Status = N'Available' ORDER BY SerialNo");

    // ------------------------------------------------------------ التنبيهات
    public static DataTable Alerts(string? alertType, int? departmentId, int? categoryId) => Db.Query(@"
        SELECT e.AssetId AS Id, e.Status, e.AlertType,
               e.SerialNo AS [الرقم التسلسلي], e.Name AS [الاسم], cat.Name AS [التصنيف], d.Name AS [القسم],
               e.HolderName AS [صاحب العهدة], e.BookValue AS [القيمة الدفترية],
               CASE WHEN e.RemainingMonths > 0 THEN CONCAT(CAST(e.RemainingMonths AS INT), N' شهر متبقٍ')
                    ELSE CONCAT(v.MonthsElapsed - CAST(v.TotalMonths AS INT), N' شهر منذ انتهائه') END AS [المدة],
               CASE e.AlertType WHEN N'Expired' THEN N'انتهى عمره' ELSE N'في آخر سنة' END AS [التنبيه]
        FROM dbo.vw_EndOfLifeAlerts e
        JOIN dbo.vw_AssetValuation v ON v.AssetId = e.AssetId
        JOIN dbo.AssetCategory cat ON cat.CategoryId = e.CategoryId
        JOIN dbo.Asset a ON a.AssetId = e.AssetId
        LEFT JOIN dbo.Location l ON l.LocationId = a.LocationId
        LEFT JOIN dbo.Department d ON d.DepartmentId = l.DepartmentId
        WHERE (@t IS NULL OR e.AlertType = @t) AND (@dep IS NULL OR l.DepartmentId = @dep)
          AND (@cat IS NULL OR e.CategoryId = @cat)
        ORDER BY e.RemainingMonths, e.SerialNo",
        Db.P("@t", alertType), Db.P("@dep", departmentId), Db.P("@cat", categoryId));

    public static int AlertCount() => Db.Int("SELECT COUNT(*) FROM dbo.vw_EndOfLifeAlerts");

    public static DataRow Stats() => Db.Row(@"
        SELECT
          (SELECT COUNT(*) FROM dbo.Asset WHERE Status <> N'Archived') AS Total,
          (SELECT COUNT(*) FROM dbo.Asset WHERE Status = N'Available') AS Available,
          (SELECT COUNT(*) FROM dbo.Asset WHERE Status = N'InCustody') AS InCustody,
          (SELECT COUNT(*) FROM dbo.Asset WHERE Status = N'Disposed') AS Disposed,
          (SELECT COUNT(*) FROM dbo.vw_EndOfLifeAlerts WHERE AlertType = N'Expired') AS Expired,
          (SELECT COUNT(*) FROM dbo.vw_EndOfLifeAlerts WHERE AlertType = N'LastYear') AS LastYear,
          (SELECT COUNT(*) FROM dbo.Disposal WHERE Status = N'Proposed') AS PendingDisposals,
          (SELECT ISNULL(SUM(BookValue), 0) FROM dbo.vw_AssetValuation WHERE Status IN (N'Available', N'InCustody')) AS BookValue")!;
}
