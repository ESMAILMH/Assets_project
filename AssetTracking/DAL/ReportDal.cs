namespace AssetTracking.DAL;

/// <summary>استعلامات التقارير التي لا تخص شاشة واحدة.</summary>
public static class ReportDal
{
    /// <summary>القيمة الدفترية لكل أصل (التكلفة، الإهلاك المتراكم، القيمة الحالية).</summary>
    public static DataTable BookValues(int? categoryId, int? departmentId) => Db.Query(@"
        SELECT v.AssetId AS Id, v.SerialNo AS [الرقم التسلسلي], v.Name AS [الأصل], cat.Name AS [التصنيف], d.Name AS [القسم],
               v.InServiceDate AS [بدء الاستخدام], v.LifeYears AS [العمر (سنة)], v.Cost AS [التكلفة],
               v.SalvageValue AS [الخردة], v.AccumulatedDepreciation AS [الإهلاك المتراكم], v.BookValue AS [القيمة الدفترية]
        FROM dbo.vw_AssetValuation v
        JOIN dbo.AssetCategory cat ON cat.CategoryId = v.CategoryId
        LEFT JOIN dbo.Location l ON l.LocationId = v.LocationId
        LEFT JOIN dbo.Department d ON d.DepartmentId = l.DepartmentId
        WHERE v.Status IN (N'Available', N'InCustody')
          AND (@cat IS NULL OR v.CategoryId = @cat) AND (@dep IS NULL OR l.DepartmentId = @dep)
        ORDER BY cat.Name, v.SerialNo", Db.P("@cat", categoryId), Db.P("@dep", departmentId));

    /// <summary>الأصول المنتهية أو التي ينتهي عمرها خلال عدد أشهر محدد.</summary>
    public static DataTable EndOfLife(int withinMonths) => Db.Query(@"
        SELECT v.AssetId AS Id, v.SerialNo AS [الرقم التسلسلي], v.Name AS [الأصل], cat.Name AS [التصنيف],
               p.FullName AS [صاحب العهدة], v.InServiceDate AS [بدء الاستخدام], v.LifeYears AS [العمر (سنة)],
               CAST(v.RemainingMonths AS INT) AS [المتبقي (شهر)], v.BookValue AS [القيمة الدفترية],
               CASE WHEN v.RemainingMonths = 0 THEN N'انتهى عمره' ELSE N'قريب من الانتهاء' END AS [الوضع]
        FROM dbo.vw_AssetValuation v
        JOIN dbo.AssetCategory cat ON cat.CategoryId = v.CategoryId
        LEFT JOIN dbo.AssetCustody c ON c.AssetId = v.AssetId AND c.ReturnDate IS NULL
        LEFT JOIN dbo.Person p ON p.PersonId = c.PersonId
        WHERE v.Status IN (N'Available', N'InCustody') AND v.RemainingMonths <= @m
        ORDER BY v.RemainingMonths, v.SerialNo", Db.P("@m", withinMonths));

    /// <summary>توزيع الأصول حسب القسم والموقع.</summary>
    public static DataTable ByLocation(int? departmentId, int? locationId) => Db.Query($@"
        SELECT a.AssetId AS Id, ISNULL(d.Name, N'بدون قسم') AS Dept, ISNULL(l.Name, N'بدون موقع') AS Loc,
               a.SerialNo AS [الرقم التسلسلي], a.Name AS [الأصل], cat.Name AS [التصنيف],
               {Labels.Sql(Labels.SqlAssetStatus, "a.Status")} AS [الحالة], p.FullName AS [صاحب العهدة]
        FROM dbo.Asset a
        JOIN dbo.AssetCategory cat ON cat.CategoryId = a.CategoryId
        LEFT JOIN dbo.Location l ON l.LocationId = a.LocationId
        LEFT JOIN dbo.Department d ON d.DepartmentId = l.DepartmentId
        LEFT JOIN dbo.AssetCustody c ON c.AssetId = a.AssetId AND c.ReturnDate IS NULL
        LEFT JOIN dbo.Person p ON p.PersonId = c.PersonId
        WHERE a.Status IN (N'Available', N'InCustody')
          AND (@dep IS NULL OR l.DepartmentId = @dep) AND (@loc IS NULL OR a.LocationId = @loc)
        ORDER BY Dept, Loc, a.SerialNo", Db.P("@dep", departmentId), Db.P("@loc", locationId));

    /// <summary>ملخص الأصول مجمّعة حسب التصنيف أو القسم: الأعداد حسب الحالة والتكلفة والقيمة الدفترية.</summary>
    public static DataTable Summary(bool byDepartment)
    {
        string group = byDepartment ? "ISNULL(d.Name, N'بدون قسم')" : "cat.Name";
        string title = byDepartment ? "القسم" : "التصنيف";
        return Db.Query($@"
            SELECT {group} AS [{title}],
                   COUNT(*) AS [عدد الأصول],
                   SUM(CASE WHEN v.Status = N'Available' THEN 1 ELSE 0 END) AS [متاح],
                   SUM(CASE WHEN v.Status = N'InCustody' THEN 1 ELSE 0 END) AS [في عهدة],
                   SUM(CASE WHEN v.RemainingMonths = 0 THEN 1 ELSE 0 END) AS [انتهى عمره],
                   SUM(v.Cost) AS [إجمالي التكلفة],
                   SUM(v.BookValue) AS [إجمالي القيمة الدفترية]
            FROM dbo.vw_AssetValuation v
            JOIN dbo.AssetCategory cat ON cat.CategoryId = v.CategoryId
            LEFT JOIN dbo.Location l ON l.LocationId = v.LocationId
            LEFT JOIN dbo.Department d ON d.DepartmentId = l.DepartmentId
            WHERE v.Status IN (N'Available', N'InCustody')
            GROUP BY {group}
            ORDER BY {group}");
    }

    /// <summary>أرقام التقرير الإحصائي العام.</summary>
    public static DataRow GeneralStats() => Db.Row(@"
        SELECT
          (SELECT COUNT(*) FROM dbo.Asset) AS AllAssets,
          (SELECT COUNT(*) FROM dbo.Asset WHERE Status = N'Available') AS Available,
          (SELECT COUNT(*) FROM dbo.Asset WHERE Status = N'InCustody') AS InCustody,
          (SELECT COUNT(*) FROM dbo.Asset WHERE Status = N'Disposed') AS Disposed,
          (SELECT COUNT(*) FROM dbo.Asset WHERE Status = N'Archived') AS Archived,
          (SELECT COUNT(*) FROM dbo.vw_EndOfLifeAlerts WHERE AlertType = N'Expired') AS Expired,
          (SELECT COUNT(*) FROM dbo.vw_EndOfLifeAlerts WHERE AlertType = N'LastYear') AS LastYear,
          (SELECT COUNT(*) FROM dbo.Disposal WHERE Status = N'Proposed') AS PendingDisposals,
          (SELECT COUNT(*) FROM dbo.Person WHERE IsActive = 1) AS Persons,
          (SELECT COUNT(DISTINCT PersonId) FROM dbo.AssetCustody WHERE ReturnDate IS NULL) AS Holders,
          (SELECT COUNT(*) FROM dbo.InventorySession WHERE Status = N'Open') AS OpenSessions,
          (SELECT ISNULL(SUM(Cost), 0) FROM dbo.vw_AssetValuation WHERE Status IN (N'Available', N'InCustody')) AS Cost,
          (SELECT ISNULL(SUM(AccumulatedDepreciation), 0) FROM dbo.vw_AssetValuation WHERE Status IN (N'Available', N'InCustody')) AS Depreciation,
          (SELECT ISNULL(SUM(BookValue), 0) FROM dbo.vw_AssetValuation WHERE Status IN (N'Available', N'InCustody')) AS BookValue,
          (SELECT ISNULL(SUM(Cost), 0) FROM dbo.MaintenanceRecord WHERE YEAR(MaintenanceDate) = YEAR(GETDATE())) AS MaintenanceThisYear")!;
}

/// <summary>قوائم المرشحات في شاشة التقارير.</summary>
public static class ReportLists
{
    public static DataTable Assets() =>
        Db.Query("SELECT AssetId AS Id, SerialNo + N' - ' + Name AS Name FROM dbo.Asset ORDER BY SerialNo");

    public static DataTable Sessions() => Db.Query(@"
        SELECT SessionId AS Id, CONCAT(N'جلسة ', SessionId, N' — ', CONVERT(NVARCHAR(10), SessionDate, 111)) AS Name
        FROM dbo.InventorySession ORDER BY SessionId DESC");

    /// <summary>آخر عمليات التسليم/الاستلام لاختيار محضر.</summary>
    public static DataTable CustodyOperations() => Db.Query(@"
        SELECT TOP (300) c.CustodyId AS Id,
               CONCAT(c.CustodyId, N' — ', a.SerialNo, N' — ', p.FullName, N' — ', CONVERT(NVARCHAR(10), c.HandoverDate, 111)) AS Name
        FROM dbo.AssetCustody c JOIN dbo.Asset a ON a.AssetId = c.AssetId JOIN dbo.Person p ON p.PersonId = c.PersonId
        ORDER BY c.CustodyId DESC");

    public static DataTable Users() => Db.Query(@"
        SELECT u.UserId AS Id, ISNULL(p.FullName, u.Username) AS Name
        FROM dbo.[User] u LEFT JOIN dbo.Person p ON p.PersonId = u.PersonId ORDER BY Name");
}
