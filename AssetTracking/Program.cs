using AssetTracking.BLL;
using AssetTracking.Forms;

namespace AssetTracking;

internal static class Program
{
    /// <summary>
    /// التشغيل: الإعدادات ← التحقق من الاتصال وأول تشغيل (إنشاء المدير) ← الدخول ← النافذة الرئيسية.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => Ui.ShowError(e.Exception);
        AppSettings.Load();

        if (!EnsureReady()) return;

        while (true)
        {
            using (var login = new LoginForm())
                if (login.ShowDialog() != DialogResult.OK) return;

            using var main = new MainForm();
            Application.Run(main);
            if (!main.LogoutRequested) return;
        }
    }

    /// <summary>يتأكد من الاتصال بقاعدة البيانات، وينشئ حساب المدير عند أول تشغيل.</summary>
    private static bool EnsureReady()
    {
        while (true)
        {
            try
            {
                if (!UserService.NeedsFirstRun()) return true;
                using var first = new FirstRunDialog();
                return first.ShowDialog() == DialogResult.OK;
            }
            catch (Exception ex)
            {
                Ui.ShowError(ex);
                using var conn = new ConnectionDialog();
                if (conn.ShowDialog() != DialogResult.OK) return false;
            }
        }
    }
}
