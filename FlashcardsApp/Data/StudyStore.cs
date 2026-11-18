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
    }

    // Các từ có LastRating là 1 hoặc 2 của người đang đăng nhập, từ sai nhiều lần đứng đầu.
    // Ai gọi: MistakeScreen, MainWindow (số trên nút Sổ lỗi), OverviewScreen (dòng Sổ lỗi).
    public static List<Flashcard> GetMistakes()
    {
        var cards = new List<Flashcard>();

        // TODO (#12): giống FlashcardStore.GetAll, thêm WHERE LastRating IN (1, 2) ORDER BY WrongCount DESC

        return cards;
    }
}
