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

    /// <summary>تغيير عنوان النافذة وشريط العنوان معاً.</summary>
    protected void SetTitle(Label header, string title) => Text = header.Text = title;
}
