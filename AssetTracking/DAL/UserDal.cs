namespace AssetTracking.DAL;

/// <summary>جدول المستخدمين (User).</summary>
public static class UserDal
{
    public static int Count() => Db.Int("SELECT COUNT(*) FROM dbo.[User]");

    public static DataRow? GetByUsername(string username) => Db.Row(@"
        SELECT u.UserId, u.Username, u.PasswordHash, u.PasswordSalt, u.Role, u.PersonId, u.IsActive, p.FullName
        FROM dbo.[User] u LEFT JOIN dbo.Person p ON p.PersonId = u.PersonId
        WHERE u.Username = @u", Db.P("@u", username));

    public static DataRow? Get(int id) => Db.Row("SELECT * FROM dbo.[User] WHERE UserId = @id", Db.P("@id", id));

    public static DataTable GetAll() => Db.Query($@"
        SELECT u.UserId AS Id, u.Role, u.IsActive, u.Username AS [اسم المستخدم],
               {Labels.Sql(Labels.SqlRole, "u.Role")} AS [الصلاحية],
               p.FullName AS [الشخص المرتبط], d.Name AS [القسم],
               CASE u.IsActive WHEN 1 THEN N'فعّال' ELSE N'معطّل' END AS [الحالة]
        FROM dbo.[User] u
        LEFT JOIN dbo.Person p ON p.PersonId = u.PersonId
        LEFT JOIN dbo.Department d ON d.DepartmentId = p.DepartmentId
        ORDER BY u.Username");

    public static int Insert(string username, byte[] hash, byte[] salt, string role, int? personId, bool active) =>
        Convert.ToInt32(Db.Scalar(@"
            INSERT dbo.[User] (Username, PasswordHash, PasswordSalt, Role, PersonId, IsActive)
            OUTPUT INSERTED.UserId VALUES (@u, @h, @s, @r, @p, @a)",
            Db.P("@u", username), Db.Binary("@h", hash), Db.Binary("@s", salt), Db.P("@r", role),
            Db.P("@p", personId), Db.P("@a", active)));

    public static void Update(int id, string username, string role, int? personId, bool active) =>
        Db.Execute("UPDATE dbo.[User] SET Username=@u, Role=@r, PersonId=@p, IsActive=@a WHERE UserId=@id",
            Db.P("@u", username), Db.P("@r", role), Db.P("@p", personId), Db.P("@a", active), Db.P("@id", id));

    public static void SetPassword(int id, byte[] hash, byte[] salt) =>
        Db.Execute("UPDATE dbo.[User] SET PasswordHash=@h, PasswordSalt=@s WHERE UserId=@id",
            Db.Binary("@h", hash), Db.Binary("@s", salt), Db.P("@id", id));

    public static int ActiveManagersExcept(int id) =>
        Db.Int("SELECT COUNT(*) FROM dbo.[User] WHERE Role=N'Manager' AND IsActive=1 AND UserId<>@id", Db.P("@id", id));
}
