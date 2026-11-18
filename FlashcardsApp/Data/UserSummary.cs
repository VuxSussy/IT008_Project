namespace FlashcardsApp;

// Một dòng trong bảng người dùng ở tab Quản trị · Người dùng (#44). Chỉ để hiện, không lưu.
public sealed class UserSummary
{
    public int UserId { get; set; }
    public string Username { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public int LearnedCount { get; set; } // số từ đã nhớ
    public int Streak { get; set; }       // chuỗi ngày học hiện tại
    public int BestRush { get; set; }     // kỷ lục đua từ
    public string TodayScore { get; set; } = ""; // "9/10", chưa làm thì để trống
}
