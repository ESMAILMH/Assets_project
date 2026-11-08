namespace AssetTracking.Common;

/// <summary>خطأ منطقي (تحقق من البيانات) تُعرض رسالته للمستخدم كما هي.</summary>
public sealed class AppException(string message) : Exception(message);
