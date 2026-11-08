using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Ô xám bo góc, chấm tròn rồi tới chữ: "Đã lưu vào máy". IsError = true thì chấm và chữ màu đỏ.
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
        var scale = DeviceDpi / 96f;
        var g = e.Graphics;
        g.Clear(Parent?.BackColor ?? Color.White);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        using var path = StudyTheme.Round(new RectangleF(0, 0, Width - 1, Height - 1), 8 * scale);
        using var background = new SolidBrush(BackColor);
        g.FillPath(background, path);
        var color = isError ? Color.Firebrick : StudyTheme.Teal;
        using var dot = new SolidBrush(color);
        var dotSize = 7 * scale;
        g.FillEllipse(dot, 13 * scale, (Height - dotSize) / 2, dotSize, dotSize);
        var textLeft = (int)(29 * scale);
        TextRenderer.DrawText(g, Text, Font, new Rectangle(textLeft, 0, Width - textLeft, Height), isError ? Color.Firebrick : ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis);
    }
}
