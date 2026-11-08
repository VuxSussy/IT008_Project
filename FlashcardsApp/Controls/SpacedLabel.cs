using System.ComponentModel;

namespace FlashcardsApp;

// Chữ giãn cách từng chữ cái, dùng cho chữ FLASHCARDS và các tiêu đề nhỏ viết hoa.
public class SpacedLabel : Label
{
    [DefaultValue(1.5f)]
    public float LetterSpacing { get; set; } = 1.5f;

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.Clear(BackColor);
        var flags = TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter;
        var x = 0;
        foreach (var letter in Text)
        {
            var size = TextRenderer.MeasureText(e.Graphics, letter.ToString(), Font, Size.Empty, flags);
            TextRenderer.DrawText(e.Graphics, letter.ToString(), Font, new Rectangle(x, 0, size.Width + 2, Height), ForeColor, flags);
            x += size.Width + (int)(LetterSpacing * DeviceDpi / 96f);
        }
    }
}
