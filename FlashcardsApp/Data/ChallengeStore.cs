namespace FlashcardsApp;

// Thử thách hằng ngày: 10 từ chung cho mọi người, mỗi người một lượt (bảng DailyChallenges, ChallengeResults).
public static class ChallengeStore
{
    // 10 từ của hôm nay, mọi người nhận cùng từ, cùng thứ tự. Dưới 5 từ thì trả về danh sách rỗng.
    // Ai gọi: ChallengeScreen, OverviewScreen (challengePanel).
    public static List<Flashcard> GetTodayCards()
    {
        var cards = new List<Flashcard>();

        // TODO (#15):
        //   1. Hôm nay có dòng trong DailyChallenges thì lấy từ của thư mục đó; không có thì lấy từ mọi bài
        //      trong khóa học và thư mục theo mùa đang diễn ra
        //   2. Xếp theo Id, xáo bằng new Random(số của ngày hôm nay, ví dụ 20261214), lấy 10 từ đầu

        return cards;
    }

    // Kết quả của người đang đăng nhập trong ngày date; chưa làm thì null.
    public static ChallengeResult? GetMyResult(DateTime date)
    {
        // TODO (#15)
        return null;
    }

    // Bấm Bắt đầu: tạo dòng điểm 0, để thoát giữa chừng thì vẫn tính là đã làm.
    public static void Begin(int total)
    {
        // TODO (#15): INSERT INTO ChallengeResults (UserId, Day, Score, Total, Seconds) VALUES (@userId, @today, 0, @total, 0)
    }

    // Sau mỗi từ: ghi điểm và thời gian hiện tại.
    public static void UpdateScore(int score, int seconds)
    {
        // TODO (#15): UPDATE dòng của hôm nay, rồi gọi ActivityStore.MarkToday()
    }

    // Bảng xếp hạng một ngày: chỉ tài khoản User; bằng điểm thì ai ít giây hơn đứng trên.
    // Ai gọi: LeaderboardScreen (tab Hôm nay), ChallengeScreen (hạng), AdminChallengePanel.
    public static List<RankRow> GetRanking(DateTime date)
    {
        var rows = new List<RankRow>();

        // TODO (#15): ORDER BY Score DESC, Seconds ASC; Detail ghi thời gian dạng "1:52"

        return rows;
    }

    // Tổng điểm thử thách 7 ngày gần nhất. Ai gọi: LeaderboardScreen (tab 7 ngày).
    public static List<RankRow> GetWeekRanking()
    {
        var rows = new List<RankRow>();

        // TODO (#15)

        return rows;
    }

    // ===== Admin soạn lịch (#42) =====

    // Lịch của days ngày tính từ from. Ngày không có dòng trong DailyChallenges là Tự chọn.
    public static List<ChallengeDay> GetSchedule(DateTime from, int days)
    {
        var schedule = new List<ChallengeDay>();

        // TODO (#42): tạo đủ days dòng, rồi điền FolderId, FolderName cho ngày nào có trong DailyChallenges

        return schedule;
    }

    // folderId là null thì xóa dòng của ngày đó (thành Tự chọn); có số thì thêm hoặc sửa.
    public static void SetFolder(DateTime date, int? folderId)
    {
        // TODO (#42)
    }
}
