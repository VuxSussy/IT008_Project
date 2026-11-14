namespace FlashcardsApp;

// Màn Gõ đáp án. Xem docs/04-gui.md.
public partial class TypeAnswerScreen : UserControl
{
    // Các từ đang luyện
    private List<Flashcard> cards = new();

    public TypeAnswerScreen()
    {
        InitializeComponent();
    }

    // Bắt đầu luyện gõ với danh sách từ được đưa vào. Ai gọi: khi mở màn (tất cả từ), nút Luyện lại ở Sổ lỗi.
    public void Start(List<Flashcard> cardsToPractice)
    {
        cards = cardsToPractice;

        // TODO (#10): thêm biến index (từ đang hỏi), xáo cards, hiện từ đầu tiên vào meaningLabel, xóa answerTextBox, cập nhật progressLabel "Từ 1/10 · Đúng 0 · Sai 0"
    }

    // Bỏ khoảng trắng hai đầu, so không phân biệt hoa thường.
    // public static để Thử thách (#15) và Đua từ (#41) chấm giống hệt màn này.
    public static bool CheckAnswer(string typed, string answer)
    {
        // TODO (#10): return string.Equals(typed.Trim(), answer.Trim(), StringComparison.OrdinalIgnoreCase);
        return false;
    }

    // Tô cam phần gõ sai ở giữa: giống từ đầu, giống từ cuối, còn lại là chỗ sai. Hiện trong diffPanel.
    private void ShowDiff(string typed, string answer)
    {
        // TODO (#17)
    }
}
