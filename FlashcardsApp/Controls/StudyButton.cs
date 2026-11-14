using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Nút bo góc tự vẽ, dùng cho menu trái và các nút trong màn hình.
// Kéo từ Toolbox vào như Button thường, rồi chỉnh các thuộc tính dưới đây trong cửa sổ Properties.
public class StudyButton : Button
{
    private bool selected;
    private string badge = "";
    private bool hovered; // chuột đang nằm trên nút
    private bool pressed; // chuột đang bấm giữ nút

    // Tên biểu tượng vẽ bên trái chữ, xem danh sách trong Icons.cs. Để trống thì không có biểu tượng.
    [DefaultValue("")]
    public string IconName { get; set; } = "";

    // Cỡ biểu tượng; menu trái dùng cỡ nhỏ hơn 24
    [DefaultValue(24)]
    public int IconSize { get; set; } = 24;

    // Dòng chữ nhỏ thứ hai bên dưới chữ chính. Có dòng này thì chữ được căn giữa và in đậm.
    [DefaultValue("")]
    public string Detail { get; set; } = "";

    // Phím tắt ghi trước chữ chính, ví dụ "1" cho nút Quên. Chỉ hiện khi có Detail.
    [DefaultValue("")]
    public string KeyBadge { get; set; } = "";

    [DefaultValue(true)]
    public bool BorderVisible { get; set; } = true;

    // Bo góc; đặt bằng nửa chiều cao để thành nút tròn
    [DefaultValue(8)]
    public int CornerRadius { get; set; } = 8;

    // Nút đang chọn (ví dụ màn đang mở ở menu trái): nền xanh nhạt, viền xanh, chữ đậm
    [DefaultValue(false)]
    public bool Selected
    {
        get => selected;
        set { selected = value; Invalidate(); }
    }

    // Nhãn nhỏ bên phải nút, ví dụ số từ trong sổ lỗi hoặc chữ "MỚI". Để trống thì không vẽ.
    [DefaultValue("")]
    public string Badge
    {
        get => badge;
        set { badge = value; Invalidate(); }
    }

    [DefaultValue(typeof(Color), "194, 65, 12")]
    public Color BadgeColor { get; set; } = StudyTheme.Warning;

    public StudyButton()
    {
        // Tự vẽ toàn bộ nút, vẽ vào bộ nhớ trước rồi mới hiện để không bị nháy
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        UseVisualStyleBackColor = false;
        BackColor = Color.White;
        ForeColor = StudyTheme.Ink;
        Font = new Font("Segoe UI", 11F);
        Cursor = Cursors.Hand;
    }

    // Mỗi khi chuột vào, ra, bấm, thả thì gọi Invalidate() để vẽ lại nút với màu mới
    protected override void OnMouseEnter(EventArgs e)
    {
        hovered = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        hovered = false;
        pressed = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        pressed = true;
        Invalidate();
        base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        pressed = false;
        Invalidate();
        base.OnMouseUp(e);
    }

    protected override void OnGotFocus(EventArgs e)
    {
        Invalidate();
        base.OnGotFocus(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        Invalidate();
        base.OnLostFocus(e);
    }

    // Vẽ nút theo thứ tự: nền và viền → biểu tượng → chữ → nhãn bên phải → khung khi chọn bằng phím Tab
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Parent?.BackColor ?? BackColor);

        var background = GetBackgroundColor();
        var foreground = GetTextColor();

        DrawBackground(g, background);
        var textBounds = DrawIcon(g, foreground);
        DrawText(g, textBounds, foreground);

        if (Badge.Length > 0)
        {
            DrawBadge(g);
        }

        if (Focused && ShowFocusCues)
        {
            var focusBounds = new Rectangle(Px(5), Px(5), Width - Px(10), Height - Px(10));
            ControlPaint.DrawFocusRectangle(g, focusBounds, foreground, background);
        }
    }

    private Color GetBackgroundColor()
    {
        var color = Selected ? StudyTheme.SoftTeal : BackColor;
        if (hovered && Enabled)
        {
            // Rê chuột vào thì nền tối đi một chút, bấm giữ thì tối hơn nữa
            color = ControlPaint.Dark(color, pressed ? .08f : .025f);
        }
        return color;
    }

    private Color GetTextColor()
    {
        if (!Enabled) return StudyTheme.Muted;
        if (Selected) return StudyTheme.DarkTeal;
        return ForeColor;
    }

    private void DrawBackground(Graphics g, Color background)
    {
        using var path = StudyTheme.RoundedRectangle(new RectangleF(1, 1, Width - 2, Height - 2), Px(CornerRadius));
        using var brush = new SolidBrush(background);
        g.FillPath(brush, path);

        if (BorderVisible)
        {
            var borderColor = Selected ? StudyTheme.Teal : StudyTheme.Line;
            var borderWidth = Selected ? Px(2) : 1;
            using var pen = new Pen(borderColor, borderWidth);
            g.DrawPath(pen, path);
        }
    }

    // Vẽ biểu tượng (nếu có), trả về chỗ còn lại để viết chữ
    private Rectangle DrawIcon(Graphics g, Color color)
    {
        var textBounds = new Rectangle(Px(12), 0, Width - Px(24), Height);
        if (IconName.Length == 0) return textBounds;

        // Biểu tượng cỡ 24 cách lề trái 16, chữ cách biểu tượng 14; biểu tượng nhỏ ở menu thì sát hơn
        var isLargeIcon = IconSize >= 24;
        var iconLeft = isLargeIcon ? 16 : 14;
        var gapAfterIcon = isLargeIcon ? 14 : 12;

        var iconBounds = new Rectangle(Px(iconLeft), (Height - Px(IconSize)) / 2, Px(IconSize), Px(IconSize));
        if (Text.Length == 0)
        {
            // Nút chỉ có biểu tượng thì đặt biểu tượng vào giữa
            iconBounds.X = (Width - Px(IconSize)) / 2;
        }
        Icons.Draw(g, IconName, iconBounds, color);

        textBounds.X = Px(iconLeft + IconSize + gapAfterIcon);
        textBounds.Width = Width - textBounds.X - Px(10);
        return textBounds;
    }

    private void DrawText(Graphics g, Rectangle bounds, Color color)
    {
        if (Detail.Length > 0)
        {
            DrawTwoLineText(g, color);
            return;
        }

        var flags = TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis;
        if (TextAlign == ContentAlignment.MiddleLeft)
            flags |= TextFormatFlags.Left;
        else
            flags |= TextFormatFlags.HorizontalCenter;

        if (Selected)
        {
            using var boldFont = new Font(Font, FontStyle.Bold);
            TextRenderer.DrawText(g, Text, boldFont, bounds, color, flags);
        }
        else
        {
            TextRenderer.DrawText(g, Text, Font, bounds, color, flags);
        }
    }

    // Nút hai dòng như "1   Quên" / "Chưa nhớ": dòng trên in đậm, dòng dưới chữ nhỏ hơn
    private void DrawTwoLineText(Graphics g, Color color)
    {
        var flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix;

        var title = KeyBadge.Length == 0 ? Text : $"{KeyBadge}   {Text}";
        using var boldFont = new Font(Font, FontStyle.Bold);
        var titleBounds = new Rectangle(0, Px(7), Width, Height / 2);
        TextRenderer.DrawText(g, title, boldFont, titleBounds, color, flags);

        using var smallFont = new Font(Font.FontFamily, Math.Max(9, Font.Size - 1));
        var detailBounds = new Rectangle(0, Height / 2, Width, Height / 2 - Px(4));
        TextRenderer.DrawText(g, Detail, smallFont, detailBounds, color, flags);
    }

    // Nhãn bo tròn sát mép phải, nền là BadgeColor nhạt, chữ là BadgeColor
    private void DrawBadge(Graphics g)
    {
        using var font = new Font("Segoe UI", 8F, FontStyle.Bold);
        var textSize = TextRenderer.MeasureText(g, Badge, font, Size.Empty, TextFormatFlags.NoPadding);

        var width = Math.Max(textSize.Width + StudyTheme.Scale(this, 14), StudyTheme.Scale(this, 23));
        var height = StudyTheme.Scale(this, 17);
        var left = Width - width - StudyTheme.Scale(this, 12);
        var top = (Height - height) / 2;
        var bounds = new RectangleF(left, top, width, height);

        using var path = StudyTheme.RoundedRectangle(bounds, height / 2);
        using var fill = new SolidBrush(Color.FromArgb(36, BadgeColor)); // 36/255: rất nhạt
        g.FillPath(fill, path);
        TextRenderer.DrawText(g, Badge, font, Rectangle.Round(bounds), BadgeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding);
    }

    // Số đo theo màn 100%, làm tròn thành số điểm ảnh trên màn đang dùng
    private int Px(float value)
    {
        return (int)Math.Round(StudyTheme.Scale(this, value));
    }
}
