using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Khung nền trắng bo góc 12, viền xám: dùng cho thẻ số, khung tiến độ.
// Là control riêng nên Designer cũng vẽ được, giống hệt lúc chạy app.
// Sự kiện Paint vẫn chạy sau khi vẽ nền, nên màn hình có thể vẽ thêm lên trên (như vòng tròn tiến độ).
public class CardPanel : Panel
{
    private bool borderVisible = true;

    public CardPanel()
    {
        // Tự vẽ toàn bộ khung, vẽ vào bộ nhớ trước rồi mới hiện để không bị nháy
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
    }

    // Tắt viền khi khung có nền màu (như khung Từ của ngày)
    [DefaultValue(true)]
    public bool BorderVisible
    {
        get => borderVisible;
        set { borderVisible = value; Invalidate(); }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        var g = e.Graphics;
        // Tô 4 góc ngoài phần bo bằng màu của khung chứa bên ngoài
        g.Clear(Parent?.BackColor ?? StudyTheme.Canvas);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var bounds = new RectangleF(.5f, .5f, Width - 1, Height - 1);
        using var path = StudyTheme.RoundedRectangle(bounds, StudyTheme.Scale(this, 12));
        using var brush = new SolidBrush(BackColor);
        g.FillPath(brush, path);

        if (borderVisible)
        {
            using var pen = new Pen(StudyTheme.Line);
            g.DrawPath(pen, path);
        }
    }
}
