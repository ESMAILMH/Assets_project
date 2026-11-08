namespace AssetTracking.Forms;

/// <summary>
/// نافذة إدخال أساسية: حقول (عنوان + أداة) مرتبة في جدول، وزرّا حفظ وإلغاء.
/// النوافذ الأخرى ترث منها وتضيف حقولها وتكتب منطق الحفظ في Save().
/// </summary>
public class BaseDialog : Form
{
    protected readonly TableLayoutPanel Fields;
    protected readonly FlowLayoutPanel Buttons;
    protected readonly Button BtnSave;
    protected readonly Button BtnCancel;
    protected readonly Label Header;

    public BaseDialog() : this("", 540) { }

    public BaseDialog(string title, int width = 540)
    {
        Text = title;
        Ui.ApplyRtl(this);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        BackColor = Theme.Surface;
        AutoScaleMode = AutoScaleMode.Font;

        Fields = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            ColumnCount = 2,
            Padding = new Padding(18, 16, 18, 8)
        };
        Fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        Fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        Buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 58,
            Padding = new Padding(14, 10, 14, 10),
            BackColor = Theme.Background
        };
        BtnSave = Ui.MakeButton("حفظ", Theme.Primary, (_, _) => DoSave(), 110);
        BtnCancel = Ui.MakeButton("إلغاء", Theme.Neutral, null, 100);
        BtnCancel.DialogResult = DialogResult.Cancel;
        Buttons.Controls.Add(BtnSave);
        Buttons.Controls.Add(BtnCancel);
        CancelButton = BtnCancel;
        AcceptButton = BtnSave; // Enter = حفظ (الحقول متعددة الأسطر تستقبل Enter بنفسها)

        // شريط عنوان ملوّن أعلى النافذة
        Header = new Label
        {
            Text = title, Dock = DockStyle.Top, Height = 44, Font = Theme.Subtitle, ForeColor = Color.White,
            BackColor = Theme.Primary, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(16, 0, 16, 0)
        };

        Controls.Add(Fields);
        Controls.Add(Header);
        Controls.Add(Buttons);
        ClientSize = new Size(width, 200);
    }

    private void DoSave()
    {
        try
        {
            if (!Save()) return;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            Ui.ShowError(ex);
        }
    }

    /// <summary>منطق الحفظ. يرجع false لإبقاء النافذة مفتوحة.</summary>
    protected virtual bool Save() => true;

    protected T AddField<T>(string label, T control) where T : Control
    {
        int row = Fields.RowCount++;
        Fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        var lbl = new Label
        {
            Text = label,
            AutoSize = true,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Theme.Text,
            Font = label.EndsWith('*') ? Theme.Bold : Theme.Base, // الحقول الإلزامية بخط عريض
            Margin = new Padding(4, 8, 4, 4)
        };
        control.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        control.Margin = new Padding(4, 5, 4, 5);
        Fields.Controls.Add(lbl, 0, row);
        Fields.Controls.Add(control, 1, row);
        return control;
    }

    protected TextBox AddText(string label, int maxLength = 150, bool multiline = false)
    {
        var tb = new TextBox { MaxLength = maxLength, Multiline = multiline };
        if (multiline)
        {
            tb.Height = 64;
            tb.ScrollBars = ScrollBars.Vertical;
        }
        return AddField(label, tb);
    }

    protected Label AddInfo(string label, string value)
    {
        var l = new Label { Text = value, AutoSize = true, Font = Theme.Bold, ForeColor = Theme.Primary };
        return AddField(label, l);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        ClientSize = new Size(ClientSize.Width, Header.Height + Fields.PreferredSize.Height + Buttons.Height + 6);
    }
}
