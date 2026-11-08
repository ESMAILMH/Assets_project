using AssetTracking.DAL;

namespace AssetTracking.BLL;

/// <summary>البيانات الأساسية: الأقسام والمواقع والأشخاص والتصنيفات. لا حذف نهائي، بل تعطيل.</summary>
public static class MasterDataService
{
    private static string Required(string? value, string field) =>
        string.IsNullOrWhiteSpace(value) ? throw new AppException($"الرجاء إدخال {field}.") : value.Trim();

    private static string? Optional(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    public static void SaveDepartment(int? id, string name, bool active)
    {
        Session.Demand(Session.CanManage);
        int savedId = MasterDataDal.SaveDepartment(id, Required(name, "اسم القسم"), active);
        AuditDal.Log(id is null ? "AddDepartment" : "EditDepartment", "Department", savedId, name);
    }

    public static void SaveLocation(int? id, string name, int? departmentId, bool active)
    {
        Session.Demand(Session.CanManage);
        if (departmentId is null) throw new AppException("الرجاء اختيار القسم.");
        int savedId = MasterDataDal.SaveLocation(id, Required(name, "اسم الموقع"), departmentId.Value, active);
        AuditDal.Log(id is null ? "AddLocation" : "EditLocation", "Location", savedId, name);
    }

    public static void SavePerson(int? id, string fullName, string? employeeNo, int? departmentId, string? phone, bool active)
    {
        Session.Demand(Session.CanManage);
        if (departmentId is null) throw new AppException("الرجاء اختيار القسم.");
        if (id is not null && !active && MasterDataDal.OpenCustodies(id.Value) > 0)
            throw new AppException("لا يمكن تعطيل شخص ما زالت في عهدته أصول. استلم الأصول منه أولاً.");
        int savedId = MasterDataDal.SavePerson(id, Required(fullName, "الاسم"), Optional(employeeNo), departmentId.Value,
            Optional(phone), active);
        AuditDal.Log(id is null ? "AddPerson" : "EditPerson", "Person", savedId, fullName);
    }

    public static void SaveCategory(int? id, string name, int lifeYears)
    {
        Session.Demand(Session.CanManage);
        if (lifeYears <= 0) throw new AppException("العمر الافتراضي يجب أن يكون أكبر من صفر.");
        int savedId = MasterDataDal.SaveCategory(id, Required(name, "اسم التصنيف"), lifeYears);
        AuditDal.Log(id is null ? "AddCategory" : "EditCategory", "AssetCategory", savedId, name);
    }
}
