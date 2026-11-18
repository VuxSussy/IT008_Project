using System.ComponentModel;

namespace FlashcardsApp;

// Chữ giãn cách từng chữ cái, dùng cho chữ FLASHCARDS và các tiêu đề nhỏ viết hoa.
// Label thường không giãn chữ được, nên ở đây vẽ từng chữ cái một, chữ sau cách chữ trước LetterSpacing.
public class SpacedLabel : Label
{
    [DefaultValue(1.5f)]
    public float LetterSpacing { get; set; } = 1.5f;

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(BackColor);

        var flags = TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter;
        var spacing = (int)StudyTheme.Scale(this, LetterSpacing);
        var x = 0;

        foreach (var letter in Text)
        {
            var text = letter.ToString();
            var size = TextRenderer.MeasureText(g, text, Font, Size.Empty, flags);
            TextRenderer.DrawText(g, text, Font, new Rectangle(x, 0, size.Width + 2, Height), ForeColor, flags);
            x += size.Width + spacing;
        }
    }
}
