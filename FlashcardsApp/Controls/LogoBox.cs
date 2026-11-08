using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Ô logo: hình vuông xanh bo góc, biểu tượng thẻ màu trắng.
// Là control riêng nên Designer cũng vẽ được, giống hệt lúc chạy app.
public class LogoBox : Control
{
    public LogoBox()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        Size = new Size(34, 34);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var scale = DeviceDpi / 96f;
        e.Graphics.Clear(Parent?.BackColor ?? Color.White);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var path = StudyTheme.Round(new RectangleF(0, 0, Width - 1, Height - 1), 8 * scale);
        using var brush = new SolidBrush(StudyTheme.Teal);
        e.Graphics.FillPath(brush, path);
        var icon = (int)(18 * scale);
        StudyTheme.Icon(e.Graphics, "cards", new Rectangle((Width - icon) / 2, (Height - icon) / 2, icon, icon), Color.White);
    }
}
