using AssetTracking.DAL;

namespace AssetTracking.BLL;

/// <summary>الأصول: الإضافة والتعديل والأرشفة والصورة والبحث.</summary>
public static class AssetService
{
    public const int MaxImageBytes = 2 * 1024 * 1024; // نفس القيد في قاعدة البيانات (2 MB)

    /// <summary>الموظف يرى أصوله فقط (BR-13).</summary>
    public static DataTable Search(string? text, int? categoryId, int? departmentId, int? locationId, string? status)
    {
        if (Session.Current?.Role == UserRole.Employee)
            return MyAssets(text);
        return AssetDal.Search(Clean(text), categoryId, departmentId, locationId, status);
    }

    public static DataTable MyAssets(string? text = null)
    {
        int personId = Session.Current?.PersonId ?? throw new AppException("حسابك غير مرتبط بشخص. راجع مدير النظام.");
        return AssetDal.Search(Clean(text), null, null, null, null, personId);
    }

    /// <summary>التحقق من بيانات الأصل (تُستخدم للإدخال اليدوي وللاستيراد). ترجع رسالة الخطأ أو null.</summary>
    public static string? Validate(AssetInput a)
    {
        if (string.IsNullOrWhiteSpace(a.SerialNo)) return "الرقم التسلسلي فارغ";
        if (string.IsNullOrWhiteSpace(a.Name)) return "الاسم فارغ";
        if (a.CategoryId <= 0) return "التصنيف غير محدد";
        if (a.Cost < 0) return "التكلفة لا يمكن أن تكون سالبة";
        if (a.LifeYears <= 0) return "العمر الافتراضي يجب أن يكون أكبر من صفر";
        if (a.SalvageValue < 0 || a.SalvageValue > a.Cost) return "قيمة الخردة يجب أن تكون بين صفر والتكلفة";
        if (a.PurchaseDate > DateTime.Today) return "تاريخ الشراء في المستقبل";
        if (a.PurchaseDate != null && a.InServiceDate < a.PurchaseDate) return "تاريخ بدء الاستخدام يسبق تاريخ الشراء";
        return null;
    }

    public static int Save(int? id, AssetInput a)
    {
        Session.Demand(Session.CanManage);
        a.SerialNo = a.SerialNo.Trim();
        a.Name = a.Name.Trim();
        if (Validate(a) is { } error) throw new AppException(error + ".");
        if (AssetDal.SerialExists(a.SerialNo, id)) throw new AppException("الرقم التسلسلي مستخدم لأصل آخر (BR-01).");

        if (id is null)
        {
            int newId = AssetDal.Insert(a);
            AuditDal.Log("AddAsset", "Asset", newId, a.SerialNo);
            return newId;
        }

        var current = AssetDal.Get(id.Value) ?? throw new AppException("الأصل غير موجود.");
        if ((string)current["Status"] == "Disposed") throw new AppException("لا يمكن تعديل أصل مُخرَّد.");
        if (!string.Equals((string)current["SerialNo"], a.SerialNo, StringComparison.OrdinalIgnoreCase) && AssetDal.HasMovements(id.Value))
            throw new AppException("لا يمكن تعديل الرقم التسلسلي بعد وجود حركات على الأصل.");
        AssetDal.Update(id.Value, a);
        AuditDal.Log("EditAsset", "Asset", id, a.SerialNo);
        return id.Value;
    }

    public static void SetImage(int id, byte[]? image)
    {
        Session.Demand(Session.CanManage);
        if (image is { Length: > MaxImageBytes }) throw new AppException("حجم الصورة يتجاوز 2 ميجابايت.");
        AssetDal.SetImage(id, image);
        AuditDal.Log(image == null ? "RemoveImage" : "SetImage", "Asset", id, null);
    }

    /// <summary>أرشفة الأصل بدل حذفه (لا حذف نهائي).</summary>
    public static void Archive(int id)
    {
        Session.Demand(Session.CanManage);
        var a = AssetDal.Get(id) ?? throw new AppException("الأصل غير موجود.");
        if ((string)a["Status"] != "Available")
            throw new AppException("لا يمكن أرشفة الأصل إلا إذا كانت حالته \"متاح\" (غير مسلّم لأحد وغير مُخرَّد).");
        AssetDal.SetStatus(id, "Archived");
        AuditDal.Log("ArchiveAsset", "Asset", id, (string)a["SerialNo"]);
    }

    public static void Restore(int id)
    {
        Session.Demand(Session.IsManager);
        var a = AssetDal.Get(id) ?? throw new AppException("الأصل غير موجود.");
        if ((string)a["Status"] != "Archived") throw new AppException("الأصل غير مؤرشف.");
        AssetDal.SetStatus(id, "Available");
        AuditDal.Log("RestoreAsset", "Asset", id, (string)a["SerialNo"]);
    }

    private static string? Clean(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
}
