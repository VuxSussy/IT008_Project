using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Viên bo tròn có biểu tượng rồi tới chữ, ví dụ ngọn lửa + "6" (chuỗi ngày học) ở màn Tổng quan.
// Nền là BackColor; biểu tượng vẽ bằng IconColor, chữ bằng ForeColor.
public class ChipLabel : Label
{
    private string iconName = "";

    [DefaultValue("")]
    public string IconName
    {
        get => iconName;
        set { iconName = value; Invalidate(); }
    }

    [DefaultValue(typeof(Color), "183, 121, 31")]
    public Color IconColor { get; set; } = StudyTheme.Gold;

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(Parent?.BackColor ?? Color.White);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var bounds = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = StudyTheme.RoundedRectangle(bounds, Height / 2f);
        using var background = new SolidBrush(BackColor);
        g.FillPath(background, path);

        // Biểu tượng và chữ đứng sát nhau, cả cụm nằm giữa viên
        var flags = TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding | TextFormatFlags.VerticalCenter;
        var textSize = TextRenderer.MeasureText(g, Text, Font, Size.Empty, flags);
        var iconSize = IconName.Length > 0 ? (int)StudyTheme.Scale(this, 16) : 0;
        var gap = IconName.Length > 0 ? (int)StudyTheme.Scale(this, 6) : 0;
        var left = (Width - iconSize - gap - textSize.Width) / 2;

        if (iconSize > 0)
        {
            Icons.Draw(g, IconName, new Rectangle(left, (Height - iconSize) / 2, iconSize, iconSize), IconColor);
        }
        TextRenderer.DrawText(g, Text, Font, new Rectangle(left + iconSize + gap, 0, textSize.Width + 2, Height), ForeColor, flags);
    }
}
