using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Hình tròn xanh có chữ cái đầu của tên đăng nhập, dùng ở màn Tổng quan và ô tài khoản cuối menu.
// Gán Text là tên đầy đủ ("lan"), control tự lấy chữ đầu và viết hoa.
public class AvatarBox : Control
{
    public AvatarBox()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        BackColor = StudyTheme.Teal;
        ForeColor = Color.White;
        Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        Size = new Size(46, 46);
    }

    protected override void OnTextChanged(EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(Parent?.BackColor ?? Color.White);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var diameter = Math.Min(Width, Height) - 1;
        using var brush = new SolidBrush(BackColor);
        g.FillEllipse(brush, (Width - diameter) / 2f, (Height - diameter) / 2f, diameter, diameter);

        var letter = Text.Length > 0 ? Text.Substring(0, 1).ToUpper() : "";
        TextRenderer.DrawText(g, letter, Font, ClientRectangle, ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
    }
}
