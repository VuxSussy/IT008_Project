using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlashcardsApp;

internal static class StudyTheme
{
    public static readonly Color Ink = Color.FromArgb(15, 23, 42);
    public static readonly Color Muted = Color.FromArgb(93, 105, 125);
    public static readonly Color Teal = Color.FromArgb(0, 116, 122);
    public static readonly Color SoftTeal = Color.FromArgb(227, 245, 241);
    public static readonly Color Line = Color.FromArgb(224, 229, 235);
    public static readonly Color Canvas = Color.FromArgb(250, 251, 252);

    public static GraphicsPath Round(RectangleF bounds, float radius)
    {
        var path = new GraphicsPath();
        var d = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
        if (d <= 0) { path.AddRectangle(bounds); return path; }
        path.AddArc(bounds.Left, bounds.Top, d, d, 180, 90);
        path.AddArc(bounds.Right - d, bounds.Top, d, d, 270, 90);
        path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
        path.AddArc(bounds.Left, bounds.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    public static void Icon(Graphics g, string icon, Rectangle bounds, Color color)
    {
        if (string.IsNullOrEmpty(icon)) return;
        var state = g.Save();
        g.TranslateTransform(bounds.X, bounds.Y);
        g.ScaleTransform(bounds.Width / 24f, bounds.Height / 24f);
        using var pen = new Pen(color, 1.7f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };
        using var brush = new SolidBrush(color);
        switch (icon)
        {
            case "home":
                g.DrawLines(pen, new PointF[] { new(3, 10), new(12, 3), new(21, 10) });
                g.DrawLines(pen, new PointF[] { new(5, 9), new(5, 21), new(10, 21), new(10, 14), new(15, 14), new(15, 21), new(20, 21), new(20, 9) }); break;
            case "cards":
                g.DrawRectangle(pen, 5, 6, 13, 16);
                g.DrawLines(pen, new PointF[] { new(8, 3), new(21, 5), new(21, 19) }); break;
            case "review":
                g.DrawArc(pen, 4, 4, 16, 16, 35, 290);
                g.DrawLines(pen, new PointF[] { new(20, 3), new(20, 9), new(14, 9) }); break;
            case "book":
                g.DrawRectangle(pen, 6, 3, 15, 18);
                for (var y = 7; y < 20; y += 4) g.DrawLine(pen, 3, y, 8, y);
                g.DrawLine(pen, 11, 8, 17, 8); g.DrawLine(pen, 11, 12, 17, 12); break;
            case "stats":
                g.FillRectangle(brush, 4, 14, 4, 8); g.FillRectangle(brush, 10, 4, 4, 18); g.FillRectangle(brush, 16, 9, 4, 13); break;
            case "sound":
                g.DrawPolygon(pen, new PointF[] { new(3, 9), new(7, 9), new(12, 5), new(12, 19), new(7, 15), new(3, 15) });
                g.DrawArc(pen, 10, 7, 8, 10, -60, 120); g.DrawArc(pen, 10, 3, 13, 18, -60, 120); break;
            case "close": g.DrawLine(pen, 6, 6, 18, 18); g.DrawLine(pen, 18, 6, 6, 18); break;
            case "plus": g.DrawLine(pen, 12, 5, 12, 19); g.DrawLine(pen, 5, 12, 19, 12); break;
            case "check":
                g.DrawEllipse(pen, 3, 3, 18, 18); g.DrawLines(pen, new PointF[] { new(7, 12), new(10, 15), new(17, 8) }); break;
            case "wrong":
                g.DrawEllipse(pen, 3, 3, 18, 18); g.DrawLine(pen, 8, 8, 16, 16); g.DrawLine(pen, 16, 8, 8, 16); break;
            case "settings":
                g.DrawEllipse(pen, 5, 5, 14, 14); g.DrawEllipse(pen, 9, 9, 6, 6);
                for (var i = 0; i < 8; i++) { var angle = i * Math.PI / 4; g.DrawLine(pen, 12 + (float)Math.Cos(angle) * 8, 12 + (float)Math.Sin(angle) * 8, 12 + (float)Math.Cos(angle) * 10, 12 + (float)Math.Sin(angle) * 10); } break;
            case "info": g.DrawEllipse(pen, 3, 3, 18, 18); g.DrawLine(pen, 12, 11, 12, 17); g.FillEllipse(brush, 11, 6, 2, 2); break;
            case "left": g.DrawLines(pen, new PointF[] { new(15, 5), new(8, 12), new(15, 19) }); break;
            case "right": g.DrawLines(pen, new PointF[] { new(9, 5), new(16, 12), new(9, 19) }); break;
            case "dot": g.FillEllipse(brush, 5, 5, 14, 14); break;
        }
        g.Restore(state);
    }
}

public class StudyButton : Button
{
    [DefaultValue("")]
    public string IconName { get; set; } = "";
    [DefaultValue("")]
    public string Detail { get; set; } = "";
    [DefaultValue("")]
    public string KeyBadge { get; set; } = "";
    [DefaultValue(false)]
    public bool Selected { get; set; }
    [DefaultValue(true)]
    public bool BorderVisible { get; set; } = true;
    private bool hovered;
    private bool pressed;

    public StudyButton()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        BackColor = Color.White;
        ForeColor = StudyTheme.Ink;
        Cursor = Cursors.Hand;
        UseVisualStyleBackColor = false;
        Font = new Font("Segoe UI", 11F);
    }
    protected override void OnMouseEnter(EventArgs e) { hovered = true; Invalidate(); base.OnMouseEnter(e); }
    protected override void OnMouseLeave(EventArgs e) { hovered = pressed = false; Invalidate(); base.OnMouseLeave(e); }
    protected override void OnMouseDown(MouseEventArgs e) { pressed = true; Invalidate(); base.OnMouseDown(e); }
    protected override void OnMouseUp(MouseEventArgs e) { pressed = false; Invalidate(); base.OnMouseUp(e); }
    protected override void OnGotFocus(EventArgs e) { Invalidate(); base.OnGotFocus(e); }
    protected override void OnLostFocus(EventArgs e) { Invalidate(); base.OnLostFocus(e); }
    protected override void OnPaint(PaintEventArgs e)
    {
        NativeStudyPainting.Button(this, e, IconName, Detail, KeyBadge, Selected, BorderVisible, hovered, pressed);
    }
}

internal static class NativeStudyPainting
{
    public static void Button(Button owner, PaintEventArgs e, string iconName, string detail, string keyBadge, bool selected, bool borderVisible, bool hovered, bool pressed)
    {
        var g = e.Graphics;
        var scale = owner.DeviceDpi / 96f;
        int D(float value) => (int)Math.Round(value * scale);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(owner.Parent?.BackColor ?? owner.BackColor);
        var background = selected ? StudyTheme.SoftTeal : owner.BackColor;
        if (hovered && owner.Enabled) background = ControlPaint.Dark(background, pressed ? .08f : .025f);
        var foreground = owner.Enabled ? (selected ? StudyTheme.Teal : owner.ForeColor) : StudyTheme.Muted;
        using var path = StudyTheme.Round(new RectangleF(1, 1, owner.Width - 2, owner.Height - 2), D(7));
        using var brush = new SolidBrush(background);
        using var pen = new Pen(selected ? StudyTheme.Teal : StudyTheme.Line, selected ? D(2) : 1);
        g.FillPath(brush, path);
        if (borderVisible) g.DrawPath(pen, path);
        if (selected && !borderVisible)
        {
            using var accent = new SolidBrush(StudyTheme.Teal);
            g.FillRectangle(accent, 0, D(8), D(4), owner.Height - D(16));
        }
        var rect = new Rectangle(D(12), 0, owner.Width - D(24), owner.Height);
        if (iconName.Length > 0)
        {
            var iconBounds = new Rectangle(D(16), (owner.Height - D(24)) / 2, D(24), D(24));
            if (owner.Text.Length == 0) iconBounds.X = (owner.Width - D(24)) / 2;
            StudyTheme.Icon(g, iconName, iconBounds, foreground);
            rect.X = D(54); rect.Width = owner.Width - rect.X - D(10);
        }
        var flags = TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis;
        flags |= owner.TextAlign == ContentAlignment.MiddleLeft ? TextFormatFlags.Left : TextFormatFlags.HorizontalCenter;
        if (detail.Length > 0)
        {
            using var bold = new Font(owner.Font, FontStyle.Bold);
            var title = string.IsNullOrEmpty(keyBadge) ? owner.Text : $"{keyBadge}   {owner.Text}";
            TextRenderer.DrawText(g, title, bold, new Rectangle(0, D(7), owner.Width, owner.Height / 2), foreground,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
            using var small = new Font(owner.Font.FontFamily, Math.Max(9, owner.Font.Size - 1));
            TextRenderer.DrawText(g, detail, small, new Rectangle(0, owner.Height / 2, owner.Width, owner.Height / 2 - D(4)), foreground,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
        }
        else TextRenderer.DrawText(g, owner.Text, owner.Font, rect, foreground, flags);
        if (owner.Focused && true)
            ControlPaint.DrawFocusRectangle(g, new Rectangle(D(5), D(5), owner.Width - D(10), owner.Height - D(10)), foreground, background);
        }

    public static void Surface(Panel owner, PaintEventArgs e)
    {
        e.Graphics.Clear(owner.Parent?.BackColor ?? StudyTheme.Canvas);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var path = StudyTheme.Round(new RectangleF(.5f, .5f, owner.Width - 1, owner.Height - 1), 9 * owner.DeviceDpi / 96f);
        using var brush = new SolidBrush(owner.BackColor);
        using var pen = new Pen(StudyTheme.Line);
        e.Graphics.FillPath(brush, path);
        e.Graphics.DrawPath(pen, path);
        }

    public static void Feedback(Label owner, PaintEventArgs e, string iconName)
    {
        var scale = owner.DeviceDpi / 96f;
        e.Graphics.Clear(owner.Parent?.BackColor ?? Color.White);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var path = StudyTheme.Round(new RectangleF(0, 0, owner.Width - 1, owner.Height - 1), 7 * scale);
        using var brush = new SolidBrush(owner.BackColor);
        e.Graphics.FillPath(brush, path);
        StudyTheme.Icon(e.Graphics, iconName, new Rectangle((int)(12 * scale), (owner.Height - (int)(24 * scale)) / 2, (int)(24 * scale), (int)(24 * scale)), owner.ForeColor);
        TextRenderer.DrawText(e.Graphics, owner.Text, owner.Font, new Rectangle((int)(46 * scale), 0, owner.Width - (int)(54 * scale), owner.Height), owner.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis);
        }

    public static void Highlight(Label owner, PaintEventArgs e, string highlight)
    {
        var index = string.IsNullOrEmpty(highlight) ? -1 : owner.Text.IndexOf(highlight, StringComparison.OrdinalIgnoreCase);
        if (index < 0) { return; }
        using var bold = new Font(owner.Font, FontStyle.Bold);
        using var format = (StringFormat)StringFormat.GenericTypographic.Clone();
        format.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
        var prefix = owner.Text[..index];
        var emphasis = owner.Text.Substring(index, highlight.Length);
        var suffix = owner.Text[(index + highlight.Length)..];
        float WidthOf(string value, Font font) => e.Graphics.MeasureString(value, font, int.MaxValue, format).Width;
        var first = WidthOf(prefix, owner.Font);
        var second = WidthOf(emphasis, bold);
        var total = first + second + WidthOf(suffix, owner.Font);
        if (total > owner.Width - 8) { return; }
        e.Graphics.Clear(owner.BackColor);
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        using var normal = new SolidBrush(owner.ForeColor);
        using var teal = new SolidBrush(StudyTheme.Teal);
        var left = (owner.Width - total) / 2;
        var top = (owner.Height - owner.Font.GetHeight(e.Graphics)) / 2;
        e.Graphics.DrawString(prefix, owner.Font, normal, new PointF(left, top), format);
        e.Graphics.DrawString(emphasis, bold, teal, new PointF(left + first, top), format);
        e.Graphics.DrawString(suffix, owner.Font, normal, new PointF(left + first + second, top), format);
        }

    public static void Progress(Control owner, PaintEventArgs e, int value)
    {
        if (owner.Width < 2 || owner.Height < 2) return;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        var height = 10 * owner.DeviceDpi / 96f;
        var bounds = new RectangleF(0, (owner.Height - height) / 2, owner.Width, height);
        using var track = StudyTheme.Round(bounds, height / 2);
        using var empty = new SolidBrush(StudyTheme.Line);
        e.Graphics.FillPath(empty, track);
        if (value > 0)
        {
            bounds.Width = Math.Max(height, owner.Width * value / 100f);
            using var fill = StudyTheme.Round(bounds, height / 2);
            using var teal = new SolidBrush(Color.FromArgb(57, 167, 167));
            e.Graphics.FillPath(teal, fill);
        }
        }
}
