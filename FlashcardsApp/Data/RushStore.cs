namespace FlashcardsApp;

// Kết quả Đua từ (bảng RushResults): gõ đúng nhiều nhất trong 3 phút, 3 mạng.
public static class RushStore
{
    // Lưu điểm một lượt chơi. Ai gọi: RushScreen khi hết lượt.
    public static void Save(int score)
    {
        // TODO (#41): INSERT INTO RushResults (UserId, Score, PlayedAt) VALUES (@userId, @score, GETDATE()),
        // rồi gọi ActivityStore.MarkToday()
    }

    // Kỷ lục của người đang đăng nhập; chưa chơi thì 0.
    // Ai gọi: RushScreen (bestLabel), OverviewScreen (dòng Đua từ).
    public static int GetBest()
    {
        // TODO (#41): SELECT ISNULL(MAX(Score), 0) FROM RushResults WHERE UserId = @userId
        return 0;
    }

    // Kỷ lục của mỗi tài khoản User, từ cao xuống thấp. Ai gọi: LeaderboardScreen (tab Đua từ).
    public static List<RankRow> GetRanking()
    {
        var rows = new List<RankRow>();

        // TODO (#41)

        return rows;
    }
}
