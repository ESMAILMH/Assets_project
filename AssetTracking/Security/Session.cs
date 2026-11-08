namespace AssetTracking.Security;

/// <summary>أدوار المستخدمين كما في قاعدة البيانات (Role).</summary>
public enum UserRole
{
    Manager,      // مدير: إدارة المستخدمين، اعتماد التخريد، كل التقارير، سجل العمليات
    StoreKeeper,  // أمين مخزن: المشغّل اليومي للنظام
    Employee      // موظف: يعرض أصوله فقط
}

public sealed class AppUser
{
    public int UserId { get; init; }
    public string Username { get; init; } = "";
    public string DisplayName { get; init; } = "";
    public UserRole Role { get; init; }
    public int? PersonId { get; init; }
}

/// <summary>المستخدم الحالي وصلاحياته (تُفحص عند كل شاشة وكل عملية).</summary>
public static class Session
{
    public static AppUser? Current { get; set; }

    public static int UserId => Current?.UserId ?? throw new AppException("لا يوجد مستخدم مسجل.");

    public static bool IsManager => Current?.Role == UserRole.Manager;

    /// <summary>المدير وأمين المخزن.</summary>
    public static bool CanManage => Current?.Role is UserRole.Manager or UserRole.StoreKeeper;

    public static void Demand(bool allowed)
    {
        if (!allowed) throw new AppException("ليست لديك صلاحية لتنفيذ هذه العملية.");
    }
}
