using System.Drawing.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace AssetTracking.Common;

/// <summary>
/// خط البرنامج Cairo غير موجود في Windows افتراضياً، لذلك يأتي مع البرنامج في مجلد Fonts
/// ويُثبَّت تلقائياً للمستخدم الحالي عند أول تشغيل (لا يحتاج صلاحيات مدير).
/// </summary>
public static class FontSetup
{
    [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
    private static extern int AddFontResource(string fileName);

    public static bool IsInstalled()
    {
        using var fonts = new InstalledFontCollection();
        return fonts.Families.Any(f => f.Name.Equals(Theme.FontName, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>يثبّت الخط إن لم يكن مثبتاً. يرجع true إذا تم التثبيت الآن (يلزم إعادة تشغيل البرنامج ليظهر).</summary>
    public static bool EnsureInstalled()
    {
        if (IsInstalled()) return false;
        string source = Path.Combine(AppContext.BaseDirectory, "Fonts");
        if (!Directory.Exists(source)) return false;

        try
        {
            // مجلد خطوط المستخدم (Windows 10 إصدار 1809 أو أحدث)
            string target = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Microsoft", "Windows", "Fonts");
            Directory.CreateDirectory(target);
            using var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Fonts");

            foreach (string file in Directory.GetFiles(source, "*.ttf"))
            {
                string dest = Path.Combine(target, Path.GetFileName(file));
                if (!File.Exists(dest)) File.Copy(file, dest);
                key.SetValue(Path.GetFileNameWithoutExtension(file).Replace('-', ' ') + " (TrueType)", dest);
                AddFontResource(dest);
            }
            return true;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or System.Security.SecurityException)
        {
            Ui.Warn("تعذر تثبيت خط Cairo تلقائياً. ثبّته يدوياً من مجلد Fonts بجانب البرنامج:\n" +
                    "زر الفأرة الأيمن على الملف ← تثبيت.\n\n" + ex.Message);
            return false;
        }
    }
}
