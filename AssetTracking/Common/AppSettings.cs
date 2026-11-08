using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AssetTracking.Common;

/// <summary>
/// قراءة وحفظ إعدادات التطبيق من الملف appsettings.json (نص الاتصال واسم المؤسسة).
/// </summary>
public static class AppSettings
{
    private const string DefaultConnection =
        "Server=.\\SQLEXPRESS;Database=AssetsDB;Integrated Security=True;TrustServerCertificate=True";

    public static string FilePath => Path.Combine(AppContext.BaseDirectory, "appsettings.json");

    public static string ConnectionString { get; set; } = DefaultConnection;
    public static string OrganizationName { get; set; } = "كلية التقنيات الهندسية – يفرن";
    public static string DepartmentName { get; set; } = "قسم تقنية المعلومات";

    public static void Load()
    {
        if (!File.Exists(FilePath)) return;
        try
        {
            var root = JsonNode.Parse(File.ReadAllText(FilePath));
            ConnectionString = root?["ConnectionStrings"]?["AssetDb"]?.GetValue<string>() ?? DefaultConnection;
            OrganizationName = root?["Organization"]?["Name"]?.GetValue<string>() ?? OrganizationName;
            DepartmentName = root?["Organization"]?["Department"]?.GetValue<string>() ?? DepartmentName;
        }
        catch (Exception ex)
        {
            Ui.Warn("تعذر قراءة ملف الإعدادات، سيتم استخدام القيم الافتراضية.\n" + ex.Message);
        }
    }

    public static void Save()
    {
        var root = new JsonObject
        {
            ["ConnectionStrings"] = new JsonObject { ["AssetDb"] = ConnectionString },
            ["Organization"] = new JsonObject { ["Name"] = OrganizationName, ["Department"] = DepartmentName }
        };
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        File.WriteAllText(FilePath, root.ToJsonString(options));
    }
}
