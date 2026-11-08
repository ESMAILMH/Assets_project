using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>الأقسام والمواقع والتصنيفات في تبويبات؛ كل تبويب يحتوي قائمة بسيطة (SimpleListPage).</summary>
public partial class MasterDataPage : UserControl, IPage
{
    private readonly List<SimpleListPage> _lists = new();

    public MasterDataPage()
    {
        InitializeComponent();
        Add(tabDepartments, new SimpleListPage("الأقسام", MasterDataDal.Departments, id => new DepartmentDialog(id)));
        Add(tabLocations, new SimpleListPage("المواقع", MasterDataDal.Locations, id => new LocationDialog(id)));
        Add(tabCategories, new SimpleListPage("تصنيفات الأصول", MasterDataDal.Categories, id => new CategoryDialog(id)));
    }

    private void Add(TabPage tab, SimpleListPage list)
    {
        _lists.Add(list);
        tab.Controls.Add(list);
    }

    public void RefreshData() => _lists.ForEach(l => Ui.Try(l.RefreshData));
}
