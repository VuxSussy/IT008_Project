namespace FlashcardsApp;

// Màn Sổ lỗi. Xem docs/04-gui.md.
public partial class MistakeScreen : UserControl
{
    public MistakeScreen()
    {
        InitializeComponent();
    }

    // Đổ StudyStore.GetMistakes() vào mistakeGrid theo nút lọc đang chọn. Gọi khi mở màn và khi bấm nút lọc.
    private void LoadMistakes()
    {
        // TODO (#13):
        //   - Tất cả: mọi từ trong sổ
        //   - Gõ sai: từ có LastWrongAnswer
        //   - Quên/Khó: từ không có LastWrongAnswer
        // Ghi số lên từng nút lọc, ví dụ "Tất cả · 7". Cột "Bạn đã gõ" chữ cam.
    }

    // Nút Luyện lại: sang màn Gõ đáp án với các từ trong sổ.
    private void RetryMistakes()
    {
        // TODO (#13):
        //     var typeScreen = new TypeAnswerScreen();
        //     (FindForm() as MainWindow)?.ShowScreen(typeScreen);
        //     typeScreen.Start(StudyStore.GetMistakes());
    }
}
