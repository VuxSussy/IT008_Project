using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Ô logo: hình vuông xanh bo góc, biểu tượng thẻ màu trắng ở giữa.
// Là control riêng nên Designer cũng vẽ được, giống hệt lúc chạy app.
public class LogoBox : Control
{
    public LogoBox()
    {
        // Tự vẽ toàn bộ ô, vẽ vào bộ nhớ trước rồi mới hiện để không bị nháy
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        Size = new Size(34, 34);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(Parent?.BackColor ?? Color.White);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Nền vuông xanh bo góc 8
        var bounds = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = StudyTheme.RoundedRectangle(bounds, StudyTheme.Scale(this, 8));
        using var brush = new SolidBrush(StudyTheme.Teal);
        g.FillPath(brush, path);

        // Biểu tượng 18×18 ở chính giữa
        var iconSize = (int)StudyTheme.Scale(this, 18);
        var iconBounds = new Rectangle((Width - iconSize) / 2, (Height - iconSize) / 2, iconSize, iconSize);
        Icons.Draw(g, "cards", iconBounds, Color.White);
    }
}
