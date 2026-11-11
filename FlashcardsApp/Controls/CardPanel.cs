using System.ComponentModel;

namespace FlashcardsApp;

// Khung nền trắng bo góc 12, viền xám: dùng cho thẻ số, khung tiến độ.
// Là control riêng nên Designer cũng vẽ được, giống hệt lúc chạy app.
// Sự kiện Paint vẫn chạy sau khi vẽ nền, nên màn hình có thể vẽ thêm lên trên (như vòng tròn tiến độ).
public class CardPanel : Panel
{
    private bool borderVisible = true;

    public CardPanel()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
    }

    // Tắt viền khi khung có nền màu (như khung Từ của ngày)
    [DefaultValue(true)]
    public bool BorderVisible
    {
        get => borderVisible;
        set { borderVisible = value; Invalidate(); }
    }

    protected override void OnPaintBackground(PaintEventArgs e) => NativeStudyPainting.Surface(this, e, borderVisible);
}
