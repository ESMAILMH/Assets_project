using AssetTracking.BLL;
using AssetTracking.DAL;

namespace AssetTracking.Forms;

/// <summary>بطاقة الأصل: إضافة أو تعديل أصل، مع الصورة الاختيارية وقيمته الدفترية.</summary>
public sealed class AssetDialog : BaseDialog
{
    private readonly int? _id;
    private readonly TextBox _serial, _name, _model;
    private readonly ComboBox _category, _department, _location;
    private readonly DateTimePicker _purchase, _service;
    private readonly NumericUpDown _cost, _salvage, _life;
    private readonly PictureBox _picture;
    private byte[]? _image;
    private bool _imageChanged;
    private bool _loading = true;

    public AssetDialog(int? id, bool readOnly = false) : base(id is null ? "إضافة أصل" : "بطاقة الأصل", 860)
    {
        _id = id;
        Fields.Dock = DockStyle.Fill;
        Fields.AutoSize = false;

        _serial = AddText("الرقم التسلسلي *", 50);
        _serial.RightToLeft = RightToLeft.No;
        _name = AddText("الاسم *");
        _category = AddField("التصنيف *", Ui.MakeCombo());
        _model = AddText("الموديل", 100);
        _department = AddField("القسم", Ui.MakeCombo());
        _location = AddField("الموقع", Ui.MakeCombo());
        _purchase = AddField("تاريخ الشراء", Ui.MakeDate(nullable: true));
        _service = AddField("تاريخ بدء الاستخدام *", Ui.MakeDate());
        _cost = AddField("التكلفة (د.ل) *", Ui.MakeMoney());
        _life = AddField("العمر الافتراضي (سنة) *", new NumericUpDown { Minimum = 1, Maximum = 100, Value = 5, Width = 160 });
        _salvage = AddField("قيمة الخردة (د.ل)", Ui.MakeMoney());

        // الصورة (اختيارية)
        _picture = new PictureBox
        {
            Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle, BackColor = Theme.Background
        };
        var imgButtons = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 44 };
        imgButtons.Controls.Add(Ui.MakeButton("اختيار صورة", Theme.Info, (_, _) => Ui.Try(PickImage)));
        imgButtons.Controls.Add(Ui.MakeButton("حذف الصورة", Theme.Neutral, (_, _) => SetImage(null)));
        var imgPanel = new Panel { Dock = DockStyle.Left, Width = 280, Padding = new Padding(12) };
        imgPanel.Controls.Add(_picture);
        imgPanel.Controls.Add(imgButtons);
        imgPanel.Controls.Add(new Label { Text = "صورة الأصل (اختيارية، حتى 2 ميجابايت)", Dock = DockStyle.Top, Height = 26, ForeColor = Theme.MutedText });
        Controls.Add(imgPanel);
        imgPanel.BringToFront();
        Fields.BringToFront();
        Buttons.SendToBack();

        Ui.BindCombo(_category, MasterDataDal.CategoryList(), "— اختر —");
        Ui.BindCombo(_department, MasterDataDal.DepartmentList(), "— الكل —");
        Ui.BindCombo(_location, MasterDataDal.LocationList(), "— بدون —");
        _purchase.Checked = false;

        // التصنيف يقترح العمر الافتراضي، والقسم يحصر المواقع
        _category.SelectedIndexChanged += (_, _) =>
        {
            if (_loading || _category.SelectedItem is not DataRowView r || r["DefaultLifeYears"] is not int life) return;
            _life.Value = life;
        };
        _department.SelectedIndexChanged += (_, _) =>
        {
            if (_loading) return;
            Ui.BindCombo(_location, MasterDataDal.LocationList(Ui.SelectedId(_department)), "— بدون —");
        };

        if (id != null)
        {
            LoadAsset(id.Value);
            Buttons.Controls.Add(Ui.MakeButton("🖨 طباعة البطاقة", Theme.Neutral,
                (_, _) => Ui.Try(() => ReportPrinter.Preview(ReportCatalog.AssetCard(id.Value), this))));
        }
        _loading = false;

        if (readOnly || !Session.CanManage)
        {
            foreach (Control c in Fields.Controls) c.Enabled = false;
            imgButtons.Visible = false;
            BtnSave.Visible = false;
            BtnCancel.Text = "إغلاق";
        }
    }

    private void LoadAsset(int id)
    {
        var r = AssetDal.Get(id) ?? throw new AppException("الأصل غير موجود.");
        _serial.Text = (string)r["SerialNo"];
        _name.Text = (string)r["Name"];
        _category.SelectedValue = r["CategoryId"];
        _model.Text = r["Model"] as string;
        if (r["DepartmentId"] is int dep)
        {
            _department.SelectedValue = dep;
            Ui.BindCombo(_location, MasterDataDal.LocationList(dep), "— بدون —");
        }
        _location.SelectedValue = r["LocationId"] is int loc ? loc : 0;
        if (r["PurchaseDate"] is DateTime pd) { _purchase.Value = pd; _purchase.Checked = true; }
        _service.Value = (DateTime)r["InServiceDate"];
        _cost.Value = (decimal)r["Cost"];
        _life.Value = (int)r["LifeYears"];
        _salvage.Value = (decimal)r["SalvageValue"];
        SetImage(AssetDal.GetImage(id), changed: false);

        // معلومات محسوبة (لا تُخزَّن): الإهلاك والقيمة الدفترية
        AddInfo("الحالة", Labels.Of(Labels.AssetStatuses, (string)r["Status"]));
        AddInfo("الإهلاك المتراكم", Ui.Money((decimal)r["AccumulatedDepreciation"]));
        AddInfo("القيمة الدفترية", Ui.Money((decimal)r["BookValue"])).ForeColor = Theme.Success;
        AddInfo("المتبقي من العمر", $"{Convert.ToInt32(r["RemainingMonths"])} شهر");
        if (AssetDal.HasMovements(id)) _serial.ReadOnly = true; // FR-11
    }

    private void PickImage()
    {
        using var dlg = new OpenFileDialog { Filter = "الصور|*.jpg;*.jpeg;*.png;*.bmp" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        var bytes = File.ReadAllBytes(dlg.FileName);
        if (bytes.Length > AssetService.MaxImageBytes) throw new AppException("حجم الصورة يتجاوز 2 ميجابايت.");
        SetImage(bytes);
    }

    private void SetImage(byte[]? bytes, bool changed = true)
    {
        _image = bytes;
        _imageChanged |= changed;
        _picture.Image?.Dispose();
        _picture.Image = null;
        if (bytes == null) return;
        _picture.Image = Ui.ToImage(bytes);
        if (_picture.Image == null) Ui.Warn("تعذر عرض الصورة. تأكد أن الملف صورة صالحة.");
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        ClientSize = new Size(ClientSize.Width, Math.Max(ClientSize.Height, 420));
    }

    protected override bool Save()
    {
        var input = new AssetInput
        {
            SerialNo = _serial.Text,
            Name = _name.Text,
            CategoryId = Ui.SelectedId(_category) ?? 0,
            Model = string.IsNullOrWhiteSpace(_model.Text) ? null : _model.Text.Trim(),
            PurchaseDate = _purchase.Checked ? _purchase.Value.Date : null,
            InServiceDate = _service.Value.Date,
            Cost = _cost.Value,
            LifeYears = (int)_life.Value,
            SalvageValue = _salvage.Value,
            LocationId = Ui.SelectedId(_location)
        };
        int id = AssetService.Save(_id, input);
        if (_imageChanged) AssetService.SetImage(id, _image);
        return true;
    }
}
