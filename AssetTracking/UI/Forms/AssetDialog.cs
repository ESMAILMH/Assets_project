using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>بطاقة الأصل: إضافة أو تعديل أصل، مع الصورة الاختيارية وقيمته الدفترية.</summary>
public partial class AssetDialog : DialogBase
{
    private readonly int? _id;
    private byte[]? _image;
    private bool _imageChanged;
    private bool _loading = true;

    public AssetDialog(int? id, bool readOnly = false)
    {
        InitializeComponent();
        _id = id;
        SetTitle(lblHeader, id is null ? "إضافة أصل" : "بطاقة الأصل");

        Ui.BindCombo(cmbCategory, MasterDataDal.CategoryList(), "— اختر —");
        Ui.BindCombo(cmbDepartment, MasterDataDal.DepartmentList(), "— الكل —");
        Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(), "— بدون —");
        dtpInService.Value = DateTime.Today;
        dtpPurchase.Value = DateTime.Today;
        dtpPurchase.Checked = false;
        btnPrintCard.Visible = id != null;
        foreach (var l in new[] { lblStatusValue, lblDepreciationValue, lblBookValue, lblRemainingValue }) l.Text = "—";

        // التصنيف يقترح العمر الافتراضي، والقسم يحصر المواقع
        cmbCategory.SelectedIndexChanged += (_, _) =>
        {
            if (!_loading && cmbCategory.SelectedItem is DataRowView r && r["DefaultLifeYears"] is int life) numLife.Value = life;
        };
        cmbDepartment.SelectedIndexChanged += (_, _) =>
        {
            if (!_loading) Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(Ui.SelectedId(cmbDepartment)), "— بدون —");
        };

        if (id != null) LoadAsset(id.Value);
        _loading = false;

        if (readOnly || !Session.CanManage)
        {
            foreach (Control c in Controls)
                if (c is TextBox or ComboBox or DateTimePicker or NumericUpDown) c.Enabled = false;
            btnPickImage.Visible = btnRemoveImage.Visible = btnSave.Visible = false;
            btnCancel.Text = "إغلاق";
        }
    }

    private void LoadAsset(int id)
    {
        var r = AssetDal.Get(id) ?? throw new AppException("الأصل غير موجود.");
        txtSerial.Text = (string)r["SerialNo"];
        txtName.Text = (string)r["Name"];
        cmbCategory.SelectedValue = r["CategoryId"];
        txtModel.Text = r["Model"] as string;
        if (r["DepartmentId"] is int dep)
        {
            cmbDepartment.SelectedValue = dep;
            Ui.BindCombo(cmbLocation, MasterDataDal.LocationList(dep), "— بدون —");
        }
        cmbLocation.SelectedValue = r["LocationId"] is int loc ? loc : 0;
        if (r["PurchaseDate"] is DateTime pd) { dtpPurchase.Value = pd; dtpPurchase.Checked = true; }
        dtpInService.Value = (DateTime)r["InServiceDate"];
        numCost.Value = (decimal)r["Cost"];
        numLife.Value = (int)r["LifeYears"];
        numSalvage.Value = (decimal)r["SalvageValue"];
        SetImage(AssetDal.GetImage(id), changed: false);

        // قيم محسوبة (لا تُخزَّن): الإهلاك والقيمة الدفترية
        lblStatusValue.Text = Labels.Of(Labels.AssetStatuses, (string)r["Status"]);
        lblDepreciationValue.Text = Ui.Money((decimal)r["AccumulatedDepreciation"]);
        lblBookValue.Text = Ui.Money((decimal)r["BookValue"]);
        lblBookValue.ForeColor = Theme.Success;
        lblRemainingValue.Text = $"{Convert.ToInt32(r["RemainingMonths"])} شهر";
        if (AssetDal.HasMovements(id)) txtSerial.ReadOnly = true; // FR-11
    }

    private void SetImage(byte[]? bytes, bool changed = true)
    {
        _image = bytes;
        _imageChanged |= changed;
        picImage.Image?.Dispose();
        picImage.Image = Ui.ToImage(bytes);
        if (bytes != null && picImage.Image == null) Ui.Warn("تعذر عرض الصورة. تأكد أن الملف صورة صالحة.");
    }

    private void btnPickImage_Click(object? sender, EventArgs e) => Ui.Try(() =>
    {
        using var dlg = new OpenFileDialog { Filter = "الصور|*.jpg;*.jpeg;*.png;*.bmp" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        var bytes = File.ReadAllBytes(dlg.FileName);
        if (bytes.Length > AssetService.MaxImageBytes) throw new AppException("حجم الصورة يتجاوز 2 ميجابايت.");
        SetImage(bytes);
    });

    private void btnRemoveImage_Click(object? sender, EventArgs e) => SetImage(null);

    private void btnPrintCard_Click(object? sender, EventArgs e) =>
        Ui.Try(() => ReportPrinter.Preview(ReportCatalog.AssetCard(_id!.Value), this));

    private void btnSave_Click(object? sender, EventArgs e) => TrySave(() =>
    {
        var input = new AssetInput
        {
            SerialNo = txtSerial.Text,
            Name = txtName.Text,
            CategoryId = Ui.SelectedId(cmbCategory) ?? 0,
            Model = Ui.NullIfEmpty(txtModel.Text),
            PurchaseDate = dtpPurchase.Checked ? dtpPurchase.Value.Date : null,
            InServiceDate = dtpInService.Value.Date,
            Cost = numCost.Value,
            LifeYears = (int)numLife.Value,
            SalvageValue = numSalvage.Value,
            LocationId = Ui.SelectedId(cmbLocation)
        };
        int id = AssetService.Save(_id, input);
        if (_imageChanged) AssetService.SetImage(id, _image);
        return true;
    });
}
