namespace FlashcardsApp;

// Màn Đua từ: gõ đúng nhiều nhất trong 3 phút, 3 mạng. Màn trống từ #35, phần bên trong làm ở #41. Xem docs/04-gui.md.
// Màn này không gọi StudyStore.SaveResult, nên Đua từ không đổi sổ lỗi.
public partial class RushScreen : UserControl
{
    // TODO (#41): thêm biến cho lượt chơi: cards, index, score, lives (3), secondsLeft (180)

    public RushScreen()
    {
        InitializeComponent();
    }

    // Gọi khi mở màn: startPanel ghi "3 phút · 3 mạng" và bestLabel "Kỷ lục của bạn: 19".
    private void ShowStart()
    {
        // TODO (#41): bestLabel.Text = "Kỷ lục của bạn: " + RushStore.GetBest();
        // FlashcardStore.GetAll() dưới 10 từ thì báo "Cần ít nhất 10 từ để chơi" và tắt nút Bắt đầu
    }

    // Nút Bắt đầu và nút Chơi lại
    private void StartGame()
    {
        // TODO (#41): cards = FlashcardStore.GetAll() đã xáo; score = 0, lives = 3, secondsLeft = 180; bật rushTimer
    }

    // Phím Enter. Không có nút Kiểm tra để gõ cho nhanh.
    private void CheckCurrent()
    {
        // TODO (#41): đúng (TypeAnswerScreen.CheckAnswer) thì score + 1 và sang từ khác ngay.
        // Sai hoặc ô trống thì lives - 1, hiện đáp án đúng trong 1 giây rồi sang từ khác. Hết mạng thì EndGame().
        // Dùng hết từ thì xáo lại.
    }

    // rushTimer chạy mỗi giây: đếm ngược, dưới 10 giây chữ chuyển cam, về 0 thì EndGame()
    private void Tick()
    {
        // TODO (#41)
    }

    // endPanel: điểm, "Kỷ lục mới!" nếu vượt kỷ lục cũ, nút Chơi lại, nút Xem bảng xếp hạng
    private void EndGame()
    {
        // TODO (#41): so với RushStore.GetBest() trước khi gọi RushStore.Save(score)
    }

    // Nút Xem bảng xếp hạng
    private void OpenLeaderboard()
    {
        var leaderboard = new LeaderboardScreen();
        (FindForm() as MainWindow)?.ShowScreen(leaderboard);
        leaderboard.ShowTab(LeaderboardScreen.RushTab);
    }
}
