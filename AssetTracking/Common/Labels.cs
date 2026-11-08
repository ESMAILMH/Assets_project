namespace AssetTracking.Common;

/// <summary>عنصر قائمة منسدلة: قيمة مخزنة في القاعدة + نص عربي.</summary>
public sealed record ListItem(string Value, string Text)
{
    public override string ToString() => Text;
}

/// <summary>النصوص العربية للقيم المخزنة في قاعدة البيانات.</summary>
public static class Labels
{
    public static readonly ListItem[] AssetStatuses =
    {
        new("Available", "متاح"),
        new("InCustody", "في عهدة"),
        new("Disposed", "مُخرَّد"),
        new("Archived", "مؤرشف"),
    };

    public static readonly ListItem[] Roles =
    {
        new("Manager", "مدير"),
        new("StoreKeeper", "أمين مخزن"),
        new("Employee", "موظف"),
    };

    public static readonly ListItem[] DisposalStatuses =
    {
        new("Proposed", "مقترح"),
        new("Approved", "معتمد"),
        new("Rejected", "مرفوض"),
    };

    public static readonly ListItem[] AlertTypes =
    {
        new("LastYear", "في آخر سنة من عمره"),
        new("Expired", "انتهى عمره"),
    };

    /// <summary>حالة الأصل عند التسليم.</summary>
    public static readonly string[] HandoverConditions = { "جديد", "سليم", "يحتاج صيانة" };

    /// <summary>حالة الأصل عند الاستلام (UC-07).</summary>
    public static readonly string[] ReturnConditions = { "سليم", "يحتاج صيانة", "تالف" };

    public static readonly string[] MaintenanceTypes = { "صيانة وقائية", "إصلاح عطل", "استبدال قطعة", "أخرى" };

    public static string Of(IEnumerable<ListItem> items, string? value) =>
        items.FirstOrDefault(i => i.Value == value)?.Text ?? value ?? "";

    public static ListItem[] WithAll(IEnumerable<ListItem> items) =>
        new[] { new ListItem("", "— الكل —") }.Concat(items).ToArray();

    // تعبيرات SQL لعرض القيم بالعربي داخل الاستعلامات
    public const string SqlAssetStatus =
        "CASE {0} WHEN N'Available' THEN N'متاح' WHEN N'InCustody' THEN N'في عهدة' WHEN N'Disposed' THEN N'مُخرَّد' ELSE N'مؤرشف' END";

    public const string SqlRole =
        "CASE {0} WHEN N'Manager' THEN N'مدير' WHEN N'StoreKeeper' THEN N'أمين مخزن' ELSE N'موظف' END";

    public const string SqlDisposalStatus =
        "CASE {0} WHEN N'Proposed' THEN N'مقترح' WHEN N'Approved' THEN N'معتمد' ELSE N'مرفوض' END";

    public const string SqlInventoryResult =
        "CASE {0} WHEN N'Found' THEN N'موجود' WHEN N'Missing' THEN N'مفقود' WHEN N'Surplus' THEN N'زائد' ELSE N'مكانه مختلف' END";

    public static string Sql(string template, string column) => string.Format(template, column);
}
