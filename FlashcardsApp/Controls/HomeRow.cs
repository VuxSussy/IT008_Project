using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Một dòng bấm được trong danh sách ở màn Tổng quan, kiểu trang chủ chess.com bản điện thoại:
// ô biểu tượng bên trái, tiêu đề và dòng nhỏ ở giữa, số bên phải, mũi tên ở mép phải.
// Kéo từ Toolbox vào, chỉnh IconName, Text, Detail, Value trong Properties; bắt sự kiện Click như nút thường.
public class HomeRow : Control
{
    private string iconName = "";
    private string detail = "";
    private string value = "";
    private int percent = -1;
    private bool dividerVisible = true;
    private bool hovered;

    // Tên biểu tượng trong Icons.cs
    [DefaultValue("")]
    public string IconName
    {
        get => iconName;
        set { iconName = value; Invalidate(); }
    }

    [DefaultValue(typeof(Color), "17, 78, 74")]
    public Color IconColor { get; set; } = StudyTheme.DarkTeal;

    [DefaultValue(typeof(Color), "227, 245, 241")]
    public Color IconBackColor { get; set; } = StudyTheme.SoftTeal;

    // Dòng chữ nhỏ dưới tiêu đề, ví dụ "12/30 từ đã nhớ · 4 thư mục"
    [DefaultValue("")]
    public string Detail
    {
        get => detail;
        set { detail = value; Invalidate(); }
    }

    // Số in đậm bên phải, ví dụ "40%", "7 từ", "Hạng 2". Để trống thì chỉ có mũi tên.
    [DefaultValue("")]
    public string Value
    {
        get => value;
        set { this.value = value; Invalidate(); }
    }

    // Từ 0 đến 100 thì vẽ vòng tròn tiến độ nhỏ thay cho biểu tượng; -1 là không vẽ vòng
    [DefaultValue(-1)]
    public int Percent
    {
        get => percent;
        set { percent = Math.Clamp(value, -1, 100); Invalidate(); }
    }

    // Vạch mảnh phía trên dòng. Dòng đầu tiên trong khung thì tắt.
    [DefaultValue(true)]
    public bool DividerVisible
    {
        get => dividerVisible;
        set { dividerVisible = value; Invalidate(); }
    }

    public HomeRow()
    {
        // Tự vẽ toàn bộ, vẽ vào bộ nhớ trước rồi mới hiện để không bị nháy
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        BackColor = Color.White;
        ForeColor = StudyTheme.Ink;
        Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        Cursor = Cursors.Hand;
        Size = new Size(640, 62);
    }

    protected override void OnTextChanged(EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        hovered = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        hovered = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    // Vẽ theo thứ tự: nền → vạch trên → biểu tượng hoặc vòng tròn → mũi tên → số bên phải → tiêu đề và dòng nhỏ
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(hovered ? ControlPaint.Dark(BackColor, .02f) : BackColor);

        if (DividerVisible)
        {
            using var dividerPen = new Pen(StudyTheme.Divider);
            g.DrawLine(dividerPen, 0, 0, Width, 0);
        }

        var boxSize = Px(40);
        var box = new Rectangle(Px(18), (Height - boxSize) / 2, boxSize, boxSize);
        if (Percent >= 0)
            DrawRing(g, box);
        else
            DrawIconBox(g, box);

        var arrowSize = Px(16);
        var arrowLeft = Width - Px(18) - arrowSize;
        Icons.Draw(g, "right", new Rectangle(arrowLeft, (Height - arrowSize) / 2, arrowSize, arrowSize), StudyTheme.Muted);

        var textRight = arrowLeft - Px(10);
        if (Value.Length > 0)
        {
            var valueSize = TextRenderer.MeasureText(g, Value, Font, Size.Empty, TextFormatFlags.NoPadding);
            var valueBounds = new Rectangle(textRight - valueSize.Width, 0, valueSize.Width, Height);
            TextRenderer.DrawText(g, Value, Font, valueBounds, ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right | TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding);
            textRight = valueBounds.Left - Px(16);
        }

        var textLeft = box.Right + Px(14);
        var flags = TextFormatFlags.Left | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis;
        if (Detail.Length == 0)
        {
            TextRenderer.DrawText(g, Text, Font, new Rectangle(textLeft, 0, textRight - textLeft, Height), ForeColor,
                flags | TextFormatFlags.VerticalCenter);
            return;
        }

        TextRenderer.DrawText(g, Text, Font, new Rectangle(textLeft, Height / 2 - Px(22), textRight - textLeft, Px(22)), ForeColor,
            flags | TextFormatFlags.Bottom);
        using var detailFont = new Font("Segoe UI", 9.5F);
        TextRenderer.DrawText(g, Detail, detailFont, new Rectangle(textLeft, Height / 2 + Px(1), textRight - textLeft, Px(20)), StudyTheme.Slate,
            flags | TextFormatFlags.Top);
    }

    private void DrawIconBox(Graphics g, Rectangle box)
    {
        using var path = StudyTheme.RoundedRectangle(box, Px(11));
        using var brush = new SolidBrush(IconBackColor);
        g.FillPath(brush, path);

        var iconSize = Px(20);
        var iconBounds = new Rectangle(box.X + (box.Width - iconSize) / 2, box.Y + (box.Height - iconSize) / 2, iconSize, iconSize);
        Icons.Draw(g, IconName, iconBounds, IconColor);
    }

    // Vòng tròn nhỏ dày 6: phần xám là cả vòng, phần xanh quét theo Percent, bắt đầu từ đỉnh
    private void DrawRing(Graphics g, Rectangle box)
    {
        var thickness = Px(6);
        var ring = Rectangle.Inflate(box, -thickness / 2 - 1, -thickness / 2 - 1);
        using var grayPen = new Pen(StudyTheme.Line, thickness);
        g.DrawEllipse(grayPen, ring);
        if (Percent > 0)
        {
            using var tealPen = new Pen(StudyTheme.Teal, thickness);
            g.DrawArc(tealPen, ring, -90, 360f * Percent / 100);
        }
    }

    // Số đo theo màn 100%, làm tròn thành số điểm ảnh trên màn đang dùng
    private int Px(float value)
    {
        return (int)Math.Round(StudyTheme.Scale(this, value));
    }
}
