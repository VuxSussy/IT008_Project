using Microsoft.Data.SqlClient;

namespace FlashcardsApp;

// Ghi kết quả học vào bảng CardProgress của người đang đăng nhập, lấy sổ lỗi. Xem docs/03-database.md,
// mục "Học xong một thẻ thì ghi gì".
public static class StudyStore
{
    // Ghi kết quả học một thẻ. rating: 1 Quên, 2 Khó, 3 Nhớ, 4 Dễ.
    // typedAnswer là chữ gõ sai; null nếu không gõ hoặc gõ đúng.
    // Ai gọi: StudyScreen.Rate, TypeAnswerScreen, ChallengeScreen.
    public static void SaveResult(int cardId, int rating, string? typedAnswer)
    {
        // TODO (#12): người học là Session.CurrentUser.Id. Trong CardProgress đã có dòng (UserId, CardId) thì UPDATE, chưa có thì INSERT.
        //   - rating 1 hoặc 2: WrongCount + 1
        //   - typedAnswer khác null: LastWrongAnswer = typedAnswer; rating 3, 4 thì LastWrongAnswer = ''
        // Ghi xong gọi ActivityStore.MarkToday()
        using var conn = new SqlConnection(Database.ConnectionString);
        using var cmd = new SqlCommand("""
            IF EXISTS (
                SELECT *
                FROM CardProgress
                WHERE UserId = @useId AND CardId = @cardId
            )
            

        """, conn);

        ActivityStore.MarkToday();
    }

    // Các từ có LastRating là 1 hoặc 2 của người đang đăng nhập, từ sai nhiều lần đứng đầu.
    // Ai gọi: MistakeScreen, MainWindow (số trên nút Sổ lỗi), OverviewScreen (dòng Sổ lỗi).
    public static List<Flashcard> GetMistakes() 
    {
        var cards = new List<Flashcard>();

        // TODO (#12): giống FlashcardStore.GetAll, thêm WHERE LastRating IN (1, 2) ORDER BY WrongCount DESC
        using var conn = new SqlConnection(Database.ConnectionString);
        using var cmd = new SqlCommand("""
            SELECT f.Id, f.FolderId, f.Word, f.Meaning,
                   f.Pronunciation, f.Example, f.ExampleTranslation, f.MemoryNote,
                   ISNULL(p.LastRating, 0), ISNULL(p.WrongCount, 0), ISNULL(p.LastWrongAnswer, '')
            FROM Flashcards f
            JOIN Folders fo ON fo.Id = f.FolderId
            LEFT JOIN CardProgress p ON p.CardId = f.Id AND p.UserId = @userId

            WHERE fo.OwnerId = @userId
               OR fo.CourseId IS NOT NULL
               OR CAST(GETDATE() AS DATE) BETWEEN fo.StartDate AND fo.EndDate
               AND LastRating IN (1, 2)
            ORDER BY WrongCount DESC
            """, conn);
        cmd.Parameters.AddWithValue("@userId", Session.CurrentUser!.Id);
        return FlashcardStore.Read(cmd);
    }
}
