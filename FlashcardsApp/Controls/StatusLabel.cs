using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Ô xám bo góc, chấm tròn rồi tới chữ, ví dụ "Đã lưu vào máy".
// Đặt IsError = true thì chấm và chữ chuyển sang màu đỏ.
public class StatusLabel : Label
{
    private bool isError;

    [DefaultValue(false)]
    public bool IsError
    {
        get => isError;
        set { isError = value; Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(Parent?.BackColor ?? Color.White);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Nền bo góc 8
        var bounds = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = StudyTheme.RoundedRectangle(bounds, StudyTheme.Scale(this, 8));
        using var background = new SolidBrush(BackColor);
        g.FillPath(background, path);

        // Chấm tròn cách lề trái 13
        var dotColor = isError ? StudyTheme.Error : StudyTheme.Teal;
        var dotSize = StudyTheme.Scale(this, 7);
        using var dotBrush = new SolidBrush(dotColor);
        g.FillEllipse(dotBrush, StudyTheme.Scale(this, 13), (Height - dotSize) / 2, dotSize, dotSize);

        // Chữ bắt đầu cách lề trái 29, dài quá thì hiện "..."
        var textColor = isError ? StudyTheme.Error : ForeColor;
        var textLeft = (int)StudyTheme.Scale(this, 29);
        var textBounds = new Rectangle(textLeft, 0, Width - textLeft, Height);
        TextRenderer.DrawText(g, Text, Font, textBounds, textColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis);
    }
}
