using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Màu dùng chung cho cả app. Màn nào cần màu thì lấy ở đây, không tự gõ mã màu,
// để các màn trông giống nhau (docs/02-quy-uoc-code.md, quy tắc 8).
internal static class StudyTheme
{
    public static readonly Color Ink = Color.FromArgb(15, 23, 42);         // chữ chính, gần đen
    public static readonly Color Slate = Color.FromArgb(51, 65, 85);       // chữ phụ, xám đậm
    public static readonly Color Muted = Color.FromArgb(93, 105, 125);     // chữ mờ, nút đang tắt
    public static readonly Color Teal = Color.FromArgb(15, 118, 110);      // màu chính: logo, nút chính, phần đã nhớ
    public static readonly Color DarkTeal = Color.FromArgb(17, 78, 74);    // chữ của nút menu đang chọn
    public static readonly Color SoftTeal = Color.FromArgb(227, 245, 241); // nền của nút menu đang chọn
    public static readonly Color Line = Color.FromArgb(224, 229, 235);     // viền, phần chưa thuộc
    public static readonly Color Canvas = Color.FromArgb(247, 249, 250);   // nền xám nhạt phía sau các khung
    public static readonly Color Warning = Color.FromArgb(194, 65, 12);    // cam: số từ trong sổ lỗi
    public static readonly Color Error = Color.Firebrick;                  // đỏ: câu báo lỗi
    public static readonly Color SoftWarning = Color.FromArgb(255, 237, 222); // nền cam nhạt: biểu tượng Sổ lỗi, Đua từ
    public static readonly Color DeepTeal = Color.FromArgb(19, 84, 78);    // nền dải sự kiện theo mùa
    public static readonly Color Gold = Color.FromArgb(183, 121, 31);      // chuỗi ngày học
    public static readonly Color SoftGold = Color.FromArgb(255, 247, 224); // nền của chuỗi ngày học
    public static readonly Color Blue = Color.FromArgb(30, 58, 138);       // bảng xếp hạng, điểm trình độ
    public static readonly Color SoftBlue = Color.FromArgb(227, 233, 251); // nền biểu tượng bảng xếp hạng
    public static readonly Color Divider = Color.FromArgb(238, 242, 243);  // vạch mảnh giữa các dòng trong một khung

    // Đổi số đo trên màn 100% sang màn đang dùng. Ví dụ màn 150% thì Scale(this, 10) = 15.
    // Mọi số đo khi tự vẽ đều đi qua hàm này, để app không bị nhỏ xíu trên laptop màn nét.
    public static float Scale(Control control, float value)
    {
        return value * control.DeviceDpi / 96f;
    }

    // Hình chữ nhật bo 4 góc, dùng để vẽ nền nút, khung, nhãn.
    // Nhớ viết "using var path = ..." để hình được giải phóng sau khi vẽ.
    public static GraphicsPath RoundedRectangle(RectangleF bounds, float radius)
    {
        var path = new GraphicsPath();
        var diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
        if (diameter <= 0)
        {
            path.AddRectangle(bounds);
            return path;
        }

        // Vẽ 4 cung tròn ở 4 góc theo chiều kim đồng hồ, bắt đầu từ góc trên bên trái
        path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();
        return path;
    }
}
