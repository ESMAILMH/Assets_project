using AssetTracking.DAL;

namespace AssetTracking.BLL;

/// <summary>الجرد: فتح جلسة، تسجيل الموجود فعلياً بالرقم التسلسلي، ثم الإغلاق ومقارنة النتيجة.</summary>
public static class InventoryService
{
    public static int Open(int? departmentId, int? locationId)
    {
        Session.Demand(Session.CanManage);
        int id = InventoryDal.Create(departmentId, locationId);
        AuditDal.Log("OpenInventory", "InventorySession", id, null);
        return id;
    }

    /// <summary>تسجيل أصل وُجد فعلياً. يرجع رسالة توضح النتيجة.</summary>
    public static string Register(int sessionId, string serial)
    {
        Session.Demand(Session.CanManage);
        var s = InventoryDal.GetSession(sessionId) ?? throw new AppException("جلسة الجرد غير موجودة.");
        if ((string)s["Status"] != "Open") throw new AppException("جلسة الجرد مغلقة.");
        if (string.IsNullOrWhiteSpace(serial)) throw new AppException("أدخل الرقم التسلسلي.");

        var a = AssetDal.GetBySerial(serial.Trim()) ?? throw new AppException($"الرقم ({serial.Trim()}) غير مسجل في النظام.");
        int assetId = (int)a["AssetId"];
        if (InventoryDal.HasLine(sessionId, assetId)) throw new AppException("تم تسجيل هذا الأصل في الجلسة مسبقاً.");

        string result;
        if (InventoryDal.IsExpected(sessionId, assetId)) result = "Found";
        else if ((string)a["Status"] is "Available" or "InCustody" && a["LocationId"] != DBNull.Value) result = "DifferentLocation";
        else result = "Surplus";

        InventoryDal.AddLine(sessionId, assetId, result);
        return result switch
        {
            "Found" => $"✔ موجود: {a["SerialNo"]} - {a["Name"]}",
            "DifferentLocation" => $"⚠ مكانه مختلف: {a["SerialNo"]} مسجل في موقع آخر",
            _ => $"⚠ زائد: {a["SerialNo"]} غير متوقع في هذا النطاق"
        };
    }

    public static int Close(int sessionId)
    {
        Session.Demand(Session.CanManage);
        return InventoryDal.Close(sessionId);
    }
}
