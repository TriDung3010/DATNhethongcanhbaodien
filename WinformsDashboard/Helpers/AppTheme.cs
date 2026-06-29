using System.Drawing;

namespace WinformsDashboard.Helpers
{
    /// <summary>
    /// Bảng màu và hằng số giao diện chủ đề Điện Năng (Electrical Dark Theme)
    /// </summary>
    public static class AppTheme
    {
        // === NỀN ===
        public static Color BgMain       = Color.FromArgb(240, 242, 245);
        public static Color BgSidebar    = Color.FromArgb(255, 255, 255);
        public static Color BgHeader     = Color.FromArgb(255, 255, 255);
        public static Color BgCard       = Color.FromArgb(255, 255, 255);
        public static Color BgCardHover  = Color.FromArgb(240, 242, 245);
        public static Color BgRow1       = Color.FromArgb(255, 255, 255);
        public static Color BgRow2       = Color.FromArgb(248, 249, 250);

        // === TRẠNG THÁI (Traffic Light System) ===
        public static Color ColorSafe    = Color.FromArgb(0, 230, 118);   // #00E676 - An toàn
        public static Color ColorWarning = Color.FromArgb(255, 214, 0);   // #FFD600 - Cảnh báo
        public static Color ColorDanger  = Color.FromArgb(255, 23, 68);   // #FF1744 - Nguy hiểm

        // === ACCENT ===
        public static Color AccentBlue   = Color.FromArgb(0, 176, 255);   // #00B0FF - Xanh điện
        public static Color AccentBlue2  = Color.FromArgb(0, 145, 234);   // #0091EA - Xanh điện tối
        public static Color AccentOrange = Color.FromArgb(255, 111, 0);   // #FF6F00 - Cam điện

        // === CHỮ ===
        public static Color TextPrimary  = Color.FromArgb(33, 37, 41);
        public static Color TextSecond   = Color.FromArgb(108, 117, 125);
        public static Color TextHeader   = Color.FromArgb(33, 37, 41);

        // === FONT ===
        public static Font FontTitle     = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static Font FontSubtitle  = new Font("Segoe UI", 11F, FontStyle.Bold);
        public static Font FontBody      = new Font("Segoe UI", 10F);
        public static Font FontSmall     = new Font("Segoe UI", 9F);
        public static Font FontKPI       = new Font("Segoe UI", 28F, FontStyle.Bold);
        public static Font FontKPIMed    = new Font("Segoe UI", 20F, FontStyle.Bold);
        public static Font FontIcon      = new Font("Segoe UI Emoji", 14F);
        public static Font FontMenu      = new Font("Segoe UI", 10F, FontStyle.Bold);

        // === ICONS (Unicode Emoji) ===
        public static string IconDashboard   = "⚡";
        public static string IconMonitoring  = "📡";
        public static string IconDevice      = "🔌";
        public static string IconAlert       = "🔔";
        public static string IconHistory     = "📜";
        public static string IconReport      = "📊";
        public static string IconUser        = "👤";
        public static string IconSearch      = "🔍";
        public static string IconAdd         = "＋";
        public static string IconEdit        = "✎";
        public static string IconDelete      = "🗑";
        public static string IconExport      = "📤";

        // === KÍCH THƯỚC ===
        public static int SidebarWidth   = 220;
        public static int HeaderHeight   = 60;
        public static int CardHeight     = 120;
        public static int BtnHeight      = 40;
        public static int BorderRadius   = 12;

        // === NGƯỠNG DÒNG RÒ ===
        public static double ThresholdWarning = 15.0; // mA - Bắt đầu cảnh báo
        public static double ThresholdDanger  = 30.0; // mA - Nguy hiểm

        /// <summary>
        /// Trả về màu trạng thái dựa theo giá trị dòng rò
        /// </summary>
        public static Color GetLeakageColor(double leakageMa)
        {
            if (leakageMa >= ThresholdDanger)  return ColorDanger;
            if (leakageMa >= ThresholdWarning) return ColorWarning;
            return ColorSafe;
        }

        /// <summary>
        /// Trả về nhãn trạng thái dựa theo giá trị dòng rò
        /// </summary>
        public static string GetLeakageStatus(double leakageMa)
        {
            if (leakageMa >= ThresholdDanger)  return "⚠ NGUY HIỂM";
            if (leakageMa >= ThresholdWarning) return "⚡ CẢNH BÁO";
            return "✅ AN TOÀN";
        }
    }
}
