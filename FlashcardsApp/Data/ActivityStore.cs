namespace FlashcardsApp;

// Ngày nào người dùng có học (bảng StudyDays) và chuỗi ngày học liên tiếp, giống streak của chess.com.
public static class ActivityStore
{
    // Thêm một dòng StudyDays cho hôm nay nếu chưa có.
    // Ai gọi: StudyStore.SaveResult, ChallengeStore.UpdateScore, RushStore.Save.
    public static void MarkToday()
    {
        // TODO (#12): IF NOT EXISTS (SELECT 1 FROM StudyDays WHERE UserId = @userId AND Day = CAST(GETDATE() AS DATE))
        //     INSERT INTO StudyDays (UserId, Day) VALUES (@userId, CAST(GETDATE() AS DATE))
    }

    // Số ngày liên tiếp có học, tính lùi từ hôm nay. Hôm nay chưa học thì đếm từ hôm qua.
    // Ai gọi: OverviewScreen (streakLabel).
    public static int GetStreak()
    {
        // TODO (#38): đọc các ngày học của Session.CurrentUser, xếp mới nhất trước, đếm tới ngày đầu tiên bị hụt
        // (code mẫu ở docs/03)
        return 0;
    }

    // Chuỗi dài nhất từng có. Ai gọi: OverviewScreen (ToolTip của streakLabel).
    public static int GetBestStreak()
    {
        // TODO (#38)
        return 0;
    }

    // Chuỗi hiện tại của mọi tài khoản User, từ cao xuống thấp.
    // Ai gọi: LeaderboardScreen (tab Chuỗi ngày), UserStore.GetAllUsers.
    public static List<RankRow> GetStreakRanking()
    {
        var rows = new List<RankRow>();

        // TODO (#38): mỗi User một RankRow; Score là chuỗi ngày, IsMe = (Id == Session.CurrentUser.Id)

        return rows;
    }
}
