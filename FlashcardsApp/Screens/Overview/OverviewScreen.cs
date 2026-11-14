using System.Globalization;
using System.Text.Json;

namespace FlashcardsApp;

// Màn Tổng quan, kiểu trang chủ chess.com bản điện thoại: một cột rộng 640 ở giữa (feedPanel),
// từ trên xuống là câu chào, dải sự kiện, nút Học ngay, thẻ Thử thách hôm nay, rồi các dòng HomeRow bấm được.
// Xem docs/04-gui.md mục 1. Giao diện kéo thả trong Designer; file này chỉ điền số vào và chuyển màn.
// feedPanel không neo trái phải nên tự nằm giữa khi cửa sổ to nhỏ; rộng 660 để còn chỗ cho thanh cuộn trên màn thấp.
//
// Màn này đã gọi sẵn hàm của các lớp ...Store. Hàm nào chưa viết thì trả về 0 hoặc danh sách rỗng,
// nên dòng đó hiện số 0 hoặc để trống. Viết xong hàm trong Data/ là màn này tự có số, không cần sửa file này.
public partial class OverviewScreen : UserControl
{
    // Bài đang học dở đầu tiên; 0 là chưa có, bấm dòng Học tiếp thì sang màn Khóa học
    private int nextLessonFolderId;

    public OverviewScreen()
    {
        InitializeComponent();
    }

    // MainWindow tạo màn mới mỗi lần bấm menu, nên mỗi lần mở màn này là đọc lại số
    private void OverviewScreen_Load(object? sender, EventArgs e)
    {
        // Trong Designer không có dữ liệu, giữ nguyên số mẫu để xem giao diện
        if (DesignMode) return;

        ShowGreeting();
        try
        {
            ShowNumbers();
            ShowStreak();
            ShowSeason();
            ShowChallenge();
            ShowCourse();
            ShowRush();
            ShowRank();
        }
        // TODO (#4): khi chuyển sang SQL Server thì thêm "or SqlException" vào dòng dưới
        catch (Exception ex) when (ex is IOException or InvalidDataException or UnauthorizedAccessException or JsonException)
        {
            MessageBox.Show(this, "Không đọc được dữ liệu. Hãy tắt app, mở lại rồi thử lần nữa.\n\n" + ex.Message,
                "Tổng quan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // "Chào lan", ngày hôm nay, chữ cái đầu trong hình tròn, điểm trình độ nếu có
    private void ShowGreeting()
    {
        var user = Session.CurrentUser;
        var name = user?.Username ?? "bạn";
        avatarBox.Text = name;
        greetingLabel.Text = "Chào " + name;

        var today = DateTime.Today;
        var dayName = today.ToString("dddd", new CultureInfo("vi-VN")); // "thứ hai"
        dayName = char.ToUpper(dayName[0]) + dayName.Substring(1);      // "Thứ hai"
        dateLabel.Text = $"{dayName}, {today:dd/MM} · hôm nay học gì?";

        // Điểm trình độ là phần tùy chọn (#46): chưa có điểm thì ẩn
        var rating = user?.Rating ?? 0;
        ratingLabel.Visible = rating > 0;
        ratingLabel.Text = rating.ToString();
    }

    // Dòng Tiến độ ghi nhớ, dòng Sổ lỗi và chữ trên nút Học ngay
    private void ShowNumbers()
    {
        // TODO (#4): đổi 2 dòng dưới thành
        //     var cards = FlashcardStore.GetAll();
        //     var folderCount = FolderStore.GetAll().Count;
        var cards = FlashcardStore.Load(FlashcardStore.DefaultPath);
        var folderCount = 1;

        var totalCount = cards.Count;
        var learnedCount = cards.Count(card => card.IsLearned);
        var notLearnedCount = totalCount - learnedCount;
        var percent = totalCount == 0 ? 0 : learnedCount * 100 / totalCount;

        progressRow.Percent = percent;
        progressRow.Value = $"{percent}%";
        progressRow.Detail = $"{learnedCount}/{totalCount} từ đã nhớ · {folderCount} thư mục";

        // TODO (#12): đổi thành StudyStore.GetMistakes().Count
        var mistakeCount = cards.Count(card => card.LastRating == 1 || card.LastRating == 2);
        mistakeRow.Value = $"{mistakeCount} từ";

        studyNowButton.Text = notLearnedCount > 0 ? $"Học ngay · {notLearnedCount} từ chưa thuộc" : "Học ngay";
    }

    // Ngọn lửa và số ngày học liên tiếp; rê chuột vào thì thấy chuỗi dài nhất
    private void ShowStreak()
    {
        var streak = ActivityStore.GetStreak();
        streakLabel.Text = streak.ToString();

        var tip = streak == 0
            ? "Học hôm nay để bắt đầu chuỗi"
            : $"{streak} ngày liên tiếp · dài nhất {ActivityStore.GetBestStreak()}";
        toolTip.SetToolTip(streakLabel, tip);
    }

    // Dải xanh đậm khi có thư mục theo mùa đang diễn ra; không có thì ẩn
    private void ShowSeason()
    {
        var seasons = FolderStore.GetSeasonal();
        seasonBanner.Visible = seasons.Count > 0;
        if (seasons.Count == 0) return;

        // TODO (#43): khi Folder có EndDate (#4) thì ghi đủ "Sự kiện Giáng sinh · còn 17 ngày · 10 từ"
        seasonLabel.Text = "Sự kiện " + seasons[0].Name;
    }

    // Thẻ Thử thách hôm nay: chưa làm thì mời làm, làm rồi thì ghi điểm và hạng
    private void ShowChallenge()
    {
        var today = DateTime.Today;
        var result = ChallengeStore.GetMyResult(today);
        var ranking = ChallengeStore.GetRanking(today);

        if (result != null)
        {
            var me = ranking.FirstOrDefault(row => row.IsMe);
            challengeInfoLabel.Text = $"{result.Score}/{result.Total} · {result.Seconds / 60}:{result.Seconds % 60:00}"
                + (me != null ? $" · hạng {me.Rank}" : "");
            challengeDetailLabel.Text = "Bạn đã làm thử thách hôm nay. Mai có 10 từ mới.";
            challengeButton.Text = "Xem kết quả";
            return;
        }

        var cardCount = ChallengeStore.GetTodayCards().Count;
        if (cardCount == 0)
        {
            challengeInfoLabel.Text = "Hôm nay chưa có thử thách";
            challengeDetailLabel.Text = "Cần ít nhất 5 từ trong khóa học hoặc thư mục theo mùa";
            challengeButton.Enabled = false;
            return;
        }

        challengeInfoLabel.Text = $"{cardCount} từ · {today:dd/MM}";
        challengeDetailLabel.Text = ranking.Count > 0
            ? $"Mỗi người một lượt · {ranking.Count} người đã làm · cao nhất {ranking[0].Score}/{cardCount}"
            : "Mỗi người một lượt · chưa ai làm, bạn làm đầu tiên nhé";
    }

    // Dòng Học tiếp: bài đang mở mà chưa xong, tìm từ khóa đầu tiên
    private void ShowCourse()
    {
        foreach (var course in CourseStore.GetAll())
        {
            var lesson = CourseStore.GetLessons(course.Id).FirstOrDefault(item => item.IsUnlocked && !item.IsDone);
            if (lesson == null) continue;

            nextLessonFolderId = lesson.FolderId;
            courseRow.Text = $"Học tiếp: Bài {lesson.Order} · {lesson.Name}";
            courseRow.Detail = course.Title;
            courseRow.Value = $"{lesson.LearnedCount}/{lesson.WordCount}";
            return;
        }

        nextLessonFolderId = 0;
        courseRow.Text = "Khóa học";
        courseRow.Detail = "Chọn một khóa để bắt đầu";
        courseRow.Value = "";
    }

    private void ShowRush()
    {
        var best = RushStore.GetBest();
        rushRow.Value = best > 0 ? $"Kỷ lục {best}" : "";
    }

    // Hạng của mình trong thử thách hôm nay; chưa làm thì để trống
    private void ShowRank()
    {
        var me = ChallengeStore.GetRanking(DateTime.Today).FirstOrDefault(row => row.IsMe);
        rankRow.Value = me != null ? $"Hạng {me.Rank}" : "";
    }

    // ===== Bấm vào đâu thì sang màn đó =====

    private void OpenScreen(UserControl screen)
    {
        (FindForm() as MainWindow)?.ShowScreen(screen);
    }

    private void studyNowButton_Click(object? sender, EventArgs e)
    {
        var studyScreen = new StudyScreen();
        OpenScreen(studyScreen);
        studyScreen.StartFolder(0); // 0 = học tất cả các thư mục
    }

    private void seasonBanner_Click(object? sender, EventArgs e)
    {
        OpenScreen(new CourseScreen());
    }

    private void challengeButton_Click(object? sender, EventArgs e)
    {
        OpenScreen(new ChallengeScreen());
    }

    private void progressRow_Click(object? sender, EventArgs e)
    {
        OpenScreen(new FolderScreen());
    }

    private void courseRow_Click(object? sender, EventArgs e)
    {
        if (nextLessonFolderId == 0)
        {
            OpenScreen(new CourseScreen());
            return;
        }

        var studyScreen = new StudyScreen();
        OpenScreen(studyScreen);
        studyScreen.StartFolder(nextLessonFolderId);
    }

    private void rushRow_Click(object? sender, EventArgs e)
    {
        OpenScreen(new RushScreen());
    }

    private void mistakeRow_Click(object? sender, EventArgs e)
    {
        OpenScreen(new MistakeScreen());
    }

    private void rankRow_Click(object? sender, EventArgs e)
    {
        var leaderboard = new LeaderboardScreen();
        OpenScreen(leaderboard);
        leaderboard.ShowTab(LeaderboardScreen.TodayTab);
    }
}
