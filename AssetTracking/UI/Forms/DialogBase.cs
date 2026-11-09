namespace AssetTracking.Forms;

/// <summary>
/// أساس نوافذ الإدخال: لا يحتوي عناصر (كل نافذة تصمم عناصرها في ملف Designer الخاص بها)،
/// فقط منطق الحفظ المشترك: نفّذ الحفظ، وإذا نجح أغلق النافذة، وإلا اعرض الخطأ وابقَ مفتوحاً.
/// </summary>
public class DialogBase : Form
{
    protected void TrySave(Func<bool> save)
    {
        try
        {
            if (!save()) return;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            Ui.ShowError(ex);
        }
    }

    /// <summary>عند فتح النافذة يوضع المؤشر في أول حقل قابل للكتابة (الأعلى في النافذة).</summary>
    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        Controls.Cast<Control>()
            .Where(c => c is TextBox { ReadOnly: false } or ComboBox or NumericUpDown or DateTimePicker && c.Enabled && c.Visible)
            .OrderBy(c => c.Top)
            .FirstOrDefault()?.Focus();
    }

    /// <summary>تغيير عنوان النافذة وشريط العنوان معاً.</summary>
    protected void SetTitle(Label header, string title) => Text = header.Text = title;
}
