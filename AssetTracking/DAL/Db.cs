namespace AssetTracking.DAL;

/// <summary>
/// الاتصال بقاعدة البيانات عبر ADO.NET.
/// كل الاستعلامات ببارامترات (Parameterized) لمنع حقن SQL.
/// </summary>
public static class Db
{
    public static SqlConnection Open()
    {
        var c = new SqlConnection(AppSettings.ConnectionString);
        c.Open();
        return c;
    }

    public static SqlParameter P(string name, object? value) => new(name, value ?? DBNull.Value);

    /// <summary>بارامتر صورة/بيانات ثنائية (يحدد النوع حتى لو كانت القيمة فارغة).</summary>
    public static SqlParameter Binary(string name, byte[]? value) =>
        new(name, SqlDbType.VarBinary, -1) { Value = (object?)value ?? DBNull.Value };

    private static SqlCommand Cmd(SqlConnection c, SqlTransaction? t, string sql, SqlParameter[] ps,
                                  CommandType type = CommandType.Text)
    {
        var cmd = new SqlCommand(sql, c, t) { CommandType = type, CommandTimeout = 60 };
        cmd.Parameters.AddRange(ps);
        return cmd;
    }

    public static DataTable Query(string sql, params SqlParameter[] ps)
    {
        using var c = Open();
        return Query(c, null, sql, ps);
    }

    public static DataTable Query(SqlConnection c, SqlTransaction? t, string sql, params SqlParameter[] ps)
    {
        using var cmd = Cmd(c, t, sql, ps);
        using var adapter = new SqlDataAdapter(cmd);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public static DataRow? Row(string sql, params SqlParameter[] ps)
    {
        var t = Query(sql, ps);
        return t.Rows.Count > 0 ? t.Rows[0] : null;
    }

    public static int Execute(string sql, params SqlParameter[] ps)
    {
        using var c = Open();
        return Execute(c, null, sql, ps);
    }

    public static int Execute(SqlConnection c, SqlTransaction? t, string sql, params SqlParameter[] ps)
    {
        using var cmd = Cmd(c, t, sql, ps);
        return cmd.ExecuteNonQuery();
    }

    public static object? Scalar(string sql, params SqlParameter[] ps)
    {
        using var c = Open();
        return Scalar(c, null, sql, ps);
    }

    public static object? Scalar(SqlConnection c, SqlTransaction? t, string sql, params SqlParameter[] ps)
    {
        using var cmd = Cmd(c, t, sql, ps);
        var v = cmd.ExecuteScalar();
        return v is DBNull ? null : v;
    }

    public static int Int(string sql, params SqlParameter[] ps) => Convert.ToInt32(Scalar(sql, ps) ?? 0);

    /// <summary>تنفيذ إجراء مخزن (Stored Procedure).</summary>
    public static void Proc(string name, params SqlParameter[] ps)
    {
        using var c = Open();
        using var cmd = Cmd(c, null, name, ps, CommandType.StoredProcedure);
        cmd.ExecuteNonQuery();
    }

    /// <summary>معاملة واحدة: تنجح كل الخطوات أو تُلغى كلها.</summary>
    public static void Transaction(Action<SqlConnection, SqlTransaction> work)
    {
        using var c = Open();
        using var t = c.BeginTransaction();
        try
        {
            work(c, t);
            t.Commit();
        }
        catch
        {
            t.Rollback();
            throw;
        }
    }

    public static bool TestConnection(string connectionString, out string error)
    {
        try
        {
            using var c = new SqlConnection(connectionString);
            c.Open();
            using var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Asset", c);
            cmd.ExecuteScalar();
            error = "";
            return true;
        }
        catch (Exception ex)
        {
            error = ex.Message;
            return false;
        }
    }
}
