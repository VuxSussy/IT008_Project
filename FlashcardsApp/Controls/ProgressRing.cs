using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Vòng tròn tiến độ: phần đã xong màu xanh, phần còn lại màu xám, phần trăm ở giữa, dòng chữ nhỏ bên dưới.
// Là control riêng nên kéo từ Toolbox vào được, Designer cũng vẽ được, giống hệt lúc chạy app.
// Màn hình chỉ cần gán Value, Maximum, Caption; control tự vẽ lại.
public class ProgressRing : Control
{
    private int value;
    private int maximum = 100;
    private string caption = "";

    // Số phần đã xong, ví dụ số từ đã nhớ
    [DefaultValue(0)]
    public int Value
    {
        get => value;
        set { this.value = value; Invalidate(); }
    }

    // Tổng số phần, ví dụ tổng số từ
    [DefaultValue(100)]
    public int Maximum
    {
        get => maximum;
        set { maximum = value; Invalidate(); }
    }

    // Dòng chữ nhỏ dưới phần trăm, ví dụ "12 / 30 từ"
    [DefaultValue("")]
    public string Caption
    {
        get => caption;
        set { caption = value; Invalidate(); }
    }

    public ProgressRing()
    {
        // Tự vẽ toàn bộ, vẽ vào bộ nhớ trước rồi mới hiện để không bị nháy
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        BackColor = Color.White;
        Size = new Size(192, 192);
    }

    // Bản thiết kế vẽ vòng đường kính 192, dày 30; các số đo dưới đây theo bản đó.
    // Cách vẽ: hình tròn xám → phần đã xong màu xanh (FillPie) → hình tròn nền ở giữa để thành vòng → chữ ở giữa.
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(BackColor);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Vòng to nhất vừa trong control, nằm giữa theo chiều dọc
        var diameter = Math.Min(Width, Height) - 1;
        if (diameter < 40) return; // quá nhỏ thì không vẽ
        var ring = new RectangleF((Width - diameter) / 2f, (Height - diameter) / 2f, diameter, diameter);

        DrawRing(g, ring);
        DrawText(g, ring);
    }

    private void DrawRing(Graphics g, RectangleF ring)
    {
        using (var grayBrush = new SolidBrush(StudyTheme.Line))
        {
            g.FillEllipse(grayBrush, ring);
        }

        if (Value > 0 && Maximum > 0)
        {
            // Bắt đầu từ đỉnh (-90 độ), quét theo chiều kim đồng hồ đúng tỉ lệ đã xong
            var sweepAngle = 360f * Math.Min(Value, Maximum) / Maximum;
            using var tealBrush = new SolidBrush(StudyTheme.Teal);
            g.FillPie(tealBrush, ring.X, ring.Y, ring.Width, ring.Height, -90, sweepAngle);
        }

        using (var holeBrush = new SolidBrush(BackColor))
        {
            g.FillEllipse(holeBrush, GetHoleBounds(ring));
        }
    }

    // Giữa vòng: "40%" chữ to, bên dưới Caption chữ nhỏ
    private void DrawText(Graphics g, RectangleF ring)
    {
        var hole = GetHoleBounds(ring);
        var centerY = (int)(ring.Top + ring.Height / 2);
        var percent = Maximum == 0 ? 0 : Value * 100 / Maximum;

        // Chữ phần trăm to lên nhỏ xuống theo vòng; vòng 192 thì cỡ 26
        var percentFontSize = 26F * ring.Width / StudyTheme.Scale(this, 192);
        using var percentFont = new Font("Segoe UI", percentFontSize, FontStyle.Bold);
        var percentBounds = new Rectangle((int)hole.X, (int)hole.Y, (int)hole.Width, centerY + Px(10) - (int)hole.Y);
        TextRenderer.DrawText(g, $"{percent}%", percentFont, percentBounds, StudyTheme.Ink,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom | TextFormatFlags.NoPadding);

        using var captionFont = new Font("Segoe UI", 10F);
        var captionBounds = new Rectangle((int)hole.X, centerY + Px(12), (int)hole.Width, Px(24));
        TextRenderer.DrawText(g, Caption, captionFont, captionBounds, StudyTheme.Slate,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.Top);
    }

    // Lỗ ở giữa: nhỏ hơn vòng ngoài 30/192 mỗi bên
    private static RectangleF GetHoleBounds(RectangleF ring)
    {
        var thickness = ring.Width * 30 / 192;
        return RectangleF.Inflate(ring, -thickness, -thickness);
    }

    // Số đo theo màn 100% đổi sang số điểm ảnh trên màn đang dùng
    private int Px(float value)
    {
        return (int)StudyTheme.Scale(this, value);
    }
}
