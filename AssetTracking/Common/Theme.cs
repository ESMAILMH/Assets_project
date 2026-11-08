namespace AssetTracking.Common;

/// <summary>ألوان وخطوط موحدة لواجهة التطبيق.</summary>
public static class Theme
{
    public static readonly Color Primary = Color.FromArgb(30, 77, 120);
    public static readonly Color PrimaryDark = Color.FromArgb(20, 55, 90);
    public static readonly Color Sidebar = Color.FromArgb(23, 37, 56);
    public static readonly Color SidebarHover = Color.FromArgb(38, 58, 84);
    public static readonly Color SidebarActive = Color.FromArgb(30, 77, 120);
    public static readonly Color Background = Color.FromArgb(243, 245, 248);
    public static readonly Color Surface = Color.White;
    public static readonly Color Border = Color.FromArgb(222, 226, 232);
    public static readonly Color Text = Color.FromArgb(33, 37, 41);
    public static readonly Color MutedText = Color.FromArgb(108, 117, 125);
    public static readonly Color Success = Color.FromArgb(25, 135, 84);
    public static readonly Color Danger = Color.FromArgb(192, 57, 43);
    public static readonly Color Warning = Color.FromArgb(214, 137, 16);
    public static readonly Color Info = Color.FromArgb(13, 110, 153);
    public static readonly Color Neutral = Color.FromArgb(108, 117, 125);
    public static readonly Color GridAlt = Color.FromArgb(248, 250, 252);

    public const string FontName = "Cairo";
    public static readonly Font Base = new(FontName, 10F);
    public static readonly Font Bold = new(FontName, 10F, FontStyle.Bold);
    public static readonly Font Small = new(FontName, 9F);
    public static readonly Font Title = new(FontName, 16F, FontStyle.Bold);
    public static readonly Font Subtitle = new(FontName, 12F, FontStyle.Bold);
    public static readonly Font CardValue = new(FontName, 20F, FontStyle.Bold);
}
