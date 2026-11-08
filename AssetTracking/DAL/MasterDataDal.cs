namespace AssetTracking.DAL;

/// <summary>البيانات الأساسية: الأقسام، المواقع، الأشخاص، تصنيفات الأصول.</summary>
public static class MasterDataDal
{
    private const string ActiveText = "CASE {0} WHEN 1 THEN N'فعّال' ELSE N'معطّل' END";

    // ------------------------------------------------------------ الأقسام
    public static DataTable Departments() => Db.Query($@"
        SELECT d.DepartmentId AS Id, d.IsActive, d.Name AS [القسم],
               (SELECT COUNT(*) FROM dbo.Location l WHERE l.DepartmentId = d.DepartmentId) AS [عدد المواقع],
               (SELECT COUNT(*) FROM dbo.Person p WHERE p.DepartmentId = d.DepartmentId) AS [عدد الأشخاص],
               {string.Format(ActiveText, "d.IsActive")} AS [الحالة]
        FROM dbo.Department d ORDER BY d.Name");

    public static DataTable DepartmentList() =>
        Db.Query("SELECT DepartmentId AS Id, Name FROM dbo.Department WHERE IsActive = 1 ORDER BY Name");

    public static DataRow? Department(int id) => Db.Row("SELECT * FROM dbo.Department WHERE DepartmentId=@id", Db.P("@id", id));

    public static int SaveDepartment(int? id, string name, bool active)
    {
        if (id is null)
            return Convert.ToInt32(Db.Scalar("INSERT dbo.Department (Name, IsActive) OUTPUT INSERTED.DepartmentId VALUES (@n, @a)",
                Db.P("@n", name), Db.P("@a", active)));
        Db.Execute("UPDATE dbo.Department SET Name=@n, IsActive=@a WHERE DepartmentId=@id",
            Db.P("@n", name), Db.P("@a", active), Db.P("@id", id));
        return id.Value;
    }

    // ------------------------------------------------------------ المواقع
    public static DataTable Locations() => Db.Query($@"
        SELECT l.LocationId AS Id, l.DepartmentId, l.IsActive, l.Name AS [الموقع], d.Name AS [القسم],
               (SELECT COUNT(*) FROM dbo.Asset a WHERE a.LocationId = l.LocationId AND a.Status NOT IN (N'Disposed', N'Archived')) AS [عدد الأصول],
               {string.Format(ActiveText, "l.IsActive")} AS [الحالة]
        FROM dbo.Location l JOIN dbo.Department d ON d.DepartmentId = l.DepartmentId
        ORDER BY d.Name, l.Name");

    /// <summary>قائمة المواقع الفعّالة بالشكل «القسم - الموقع»، ويمكن حصرها في قسم.</summary>
    public static DataTable LocationList(int? departmentId = null) => Db.Query(@"
        SELECT l.LocationId AS Id, d.Name + N' - ' + l.Name AS Name, l.Name AS ShortName, l.DepartmentId
        FROM dbo.Location l JOIN dbo.Department d ON d.DepartmentId = l.DepartmentId
        WHERE l.IsActive = 1 AND (@d IS NULL OR l.DepartmentId = @d)
        ORDER BY d.Name, l.Name", Db.P("@d", departmentId));

    public static DataRow? Location(int id) => Db.Row("SELECT * FROM dbo.Location WHERE LocationId=@id", Db.P("@id", id));

    public static int SaveLocation(int? id, string name, int departmentId, bool active)
    {
        var ps = new[] { Db.P("@n", name), Db.P("@d", departmentId), Db.P("@a", active), Db.P("@id", id) };
        if (id is null)
            return Convert.ToInt32(Db.Scalar(
                "INSERT dbo.Location (Name, DepartmentId, IsActive) OUTPUT INSERTED.LocationId VALUES (@n, @d, @a)", ps));
        Db.Execute("UPDATE dbo.Location SET Name=@n, DepartmentId=@d, IsActive=@a WHERE LocationId=@id", ps);
        return id.Value;
    }

    // ------------------------------------------------------------ الأشخاص
    public static DataTable Persons(string? search) => Db.Query($@"
        SELECT p.PersonId AS Id, p.IsActive, p.EmployeeNo AS [الرقم الوظيفي], p.FullName AS [الاسم],
               d.Name AS [القسم], p.Phone AS [الهاتف],
               (SELECT COUNT(*) FROM dbo.AssetCustody c WHERE c.PersonId = p.PersonId AND c.ReturnDate IS NULL) AS [أصول في عهدته],
               {string.Format(ActiveText, "p.IsActive")} AS [الحالة]
        FROM dbo.Person p JOIN dbo.Department d ON d.DepartmentId = p.DepartmentId
        WHERE @s IS NULL OR p.FullName LIKE N'%' + @s + N'%' OR p.EmployeeNo LIKE N'%' + @s + N'%'
              OR d.Name LIKE N'%' + @s + N'%' OR p.Phone LIKE N'%' + @s + N'%'
        ORDER BY p.FullName", Db.P("@s", search));

    public static DataTable PersonList() => Db.Query(@"
        SELECT PersonId AS Id, FullName + ISNULL(N' (' + EmployeeNo + N')', N'') AS Name
        FROM dbo.Person WHERE IsActive = 1 ORDER BY FullName");

    public static DataRow? Person(int id) => Db.Row(@"
        SELECT p.*, d.Name AS DepartmentName FROM dbo.Person p JOIN dbo.Department d ON d.DepartmentId = p.DepartmentId
        WHERE p.PersonId=@id", Db.P("@id", id));

    public static int SavePerson(int? id, string fullName, string? employeeNo, int departmentId, string? phone, bool active)
    {
        var ps = new[] { Db.P("@n", fullName), Db.P("@e", employeeNo), Db.P("@d", departmentId), Db.P("@p", phone),
                         Db.P("@a", active), Db.P("@id", id) };
        if (id is null)
            return Convert.ToInt32(Db.Scalar(@"INSERT dbo.Person (FullName, EmployeeNo, DepartmentId, Phone, IsActive)
                                               OUTPUT INSERTED.PersonId VALUES (@n, @e, @d, @p, @a)", ps));
        Db.Execute("UPDATE dbo.Person SET FullName=@n, EmployeeNo=@e, DepartmentId=@d, Phone=@p, IsActive=@a WHERE PersonId=@id", ps);
        return id.Value;
    }

    public static int OpenCustodies(int personId) =>
        Db.Int("SELECT COUNT(*) FROM dbo.AssetCustody WHERE PersonId=@p AND ReturnDate IS NULL", Db.P("@p", personId));

    // ------------------------------------------------------------ تصنيفات الأصول
    public static DataTable Categories() => Db.Query(@"
        SELECT c.CategoryId AS Id, c.Name AS [التصنيف], c.DefaultLifeYears AS [العمر الافتراضي (سنة)],
               (SELECT COUNT(*) FROM dbo.Asset a WHERE a.CategoryId = c.CategoryId) AS [عدد الأصول]
        FROM dbo.AssetCategory c ORDER BY c.Name");

    public static DataTable CategoryList() =>
        Db.Query("SELECT CategoryId AS Id, Name, DefaultLifeYears FROM dbo.AssetCategory ORDER BY Name");

    public static DataRow? Category(int id) => Db.Row("SELECT * FROM dbo.AssetCategory WHERE CategoryId=@id", Db.P("@id", id));

    public static int SaveCategory(int? id, string name, int lifeYears)
    {
        var ps = new[] { Db.P("@n", name), Db.P("@y", lifeYears), Db.P("@id", id) };
        if (id is null)
            return Convert.ToInt32(Db.Scalar(
                "INSERT dbo.AssetCategory (Name, DefaultLifeYears) OUTPUT INSERTED.CategoryId VALUES (@n, @y)", ps));
        Db.Execute("UPDATE dbo.AssetCategory SET Name=@n, DefaultLifeYears=@y WHERE CategoryId=@id", ps);
        return id.Value;
    }
}
