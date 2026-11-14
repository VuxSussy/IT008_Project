namespace FlashcardsApp;

// Màn Thử thách hằng ngày. Màn trống từ #35, phần bên trong làm ở #15. Xem docs/04-gui.md.
// Ba phần chung một chỗ, chỉ hiện một phần: startPanel (trước khi làm), phần làm bài, donePanel (làm xong).
public partial class ChallengeScreen : UserControl
{
    // TODO (#15): thêm biến cho lượt làm: cards (10 từ), index (từ đang hỏi), score (số từ đúng),
    // seconds (thời gian đã làm, timeLabel đếm lên)

    public ChallengeScreen()
    {
        InitializeComponent();
    }

    // Gọi khi mở màn: hôm nay đã làm thì mở thẳng donePanel, chưa làm thì hiện startPanel.
    private void ShowToday()
    {
        // TODO (#15): ChallengeStore.GetMyResult(DateTime.Today) khác null thì ShowDone(); không thì hiện startPanel.
        // GetTodayCards() rỗng thì báo "Hôm nay chưa có thử thách".
    }

    // Nút Bắt đầu
    private void StartChallenge()
    {
        // TODO (#15): cards = ChallengeStore.GetTodayCards(); ChallengeStore.Begin(cards.Count);
        // index = 0, score = 0, seconds = 0, bật Timer, hiện từ đầu tiên vào meaningLabel
    }

    // Nút Kiểm tra và phím Enter. Không có nút gợi ý.
    private void CheckCurrent()
    {
        // TODO (#15):
        //   - đúng: score + 1   (chấm bằng TypeAnswerScreen.CheckAnswer(typed, cards[index].Word))
        //   - sai: StudyStore.SaveResult(cards[index].Id, 1, typed) để từ vào sổ lỗi
        //   - ChallengeStore.UpdateScore(score, seconds); sang từ tiếp; hết 10 từ thì ShowDone()
    }

    // donePanel: điểm, thời gian, hạng, 10 từ đánh dấu đúng sai, nút Xem bảng xếp hạng
    private void ShowDone()
    {
        // TODO (#15): hạng lấy từ ChallengeStore.GetRanking(DateTime.Today), dòng có IsMe
    }

    // Nút Xem bảng xếp hạng
    private void OpenLeaderboard()
    {
        var leaderboard = new LeaderboardScreen();
        (FindForm() as MainWindow)?.ShowScreen(leaderboard);
        leaderboard.ShowTab(LeaderboardScreen.TodayTab);
    }
}
