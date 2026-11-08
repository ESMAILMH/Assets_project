using AssetTracking.DAL;
using AssetTracking.Forms;

namespace AssetTracking.Pages;

/// <summary>البيانات الأساسية: الأقسام والمواقع وتصنيفات الأصول (تبويبات).</summary>
public sealed class MasterDataPage : UserControl, IPage
{
    private readonly List<PageBase> _tabs = new();

    public MasterDataPage()
    {
        Ui.ApplyRtl(this);
        Dock = DockStyle.Fill;
        BackColor = Theme.Background;
        Padding = new Padding(20, 14, 20, 14);

        var tabs = new TabControl { Dock = DockStyle.Fill, RightToLeftLayout = true, Padding = new Point(16, 6) };
        AddTab(tabs, new SimpleListPage("الأقسام", MasterDataDal.Departments, id => new DepartmentDialog(id)));
        AddTab(tabs, new SimpleListPage("المواقع", MasterDataDal.Locations, id => new LocationDialog(id)));
        AddTab(tabs, new SimpleListPage("تصنيفات الأصول", MasterDataDal.Categories, id => new CategoryDialog(id)));

        Controls.Add(tabs);
        Controls.Add(new Label
        {
            Text = "البيانات الأساسية", Font = Theme.Title, ForeColor = Theme.Primary,
            Dock = DockStyle.Top, Height = 46, TextAlign = ContentAlignment.MiddleLeft
        });
    }

    private void AddTab(TabControl tabs, PageBase page)
    {
        _tabs.Add(page);
        var tab = new TabPage(page.Text) { BackColor = Theme.Background };
        tab.Controls.Add(page);
        tabs.TabPages.Add(tab);
    }

    public void RefreshData() => _tabs.ForEach(t => t.RefreshData());
}

/// <summary>قائمة بسيطة مع إضافة وتعديل (لا حذف نهائي: التعطيل من نافذة التعديل).</summary>
public sealed class SimpleListPage : PageBase
{
    private readonly Func<DataTable> _load;
    private readonly Func<int?, Form> _dialog;

    public SimpleListPage(string title, Func<DataTable> load, Func<int?, Form> dialog) : base(title)
    {
        Text = title;
        _load = load;
        _dialog = dialog;
        TitleLabel.Visible = false;
        Padding = new Padding(8);
        AddAction("➕ إضافة", Theme.Primary, () => Edit(null));
        AddAction("✏ تعديل", Theme.Info, () => { if (RequireSelection() is { } r) Edit((int)r["Id"]); });
        AddPrintExport(title);
        Grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0 && Selected is { } r) Ui.Try(() => Edit((int)r["Id"])); };
    }

    public override void RefreshData() => Bind(_load());

    private void Edit(int? id)
    {
        OpenDialog(_dialog(id));
    }
}
