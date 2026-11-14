namespace FlashcardsApp;

// Kết quả thử thách của một người trong một ngày, ứng với một dòng trong bảng ChallengeResults (#15).
public sealed class ChallengeResult
{
    public DateTime Date { get; set; }
    public int Score { get; set; }   // số từ đúng
    public int Total { get; set; }   // số từ của thử thách, thường là 10
    public int Seconds { get; set; } // thời gian làm
}
