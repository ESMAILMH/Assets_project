using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

public partial class CategoryDialog : DialogBase
{
    private readonly int? _id;

    public CategoryDialog(int? id)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة تصنيف" : "تعديل تصنيف");
        if (id is null) return;
        var r = MasterDataDal.Category(id.Value)!;
        txtName.Text = (string)r["Name"];
        numLife.Value = (int)r["DefaultLifeYears"];
    }

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        MasterDataService.SaveCategory(_id, txtName.Text, (int)numLife.Value);
        return true;
    });
}
