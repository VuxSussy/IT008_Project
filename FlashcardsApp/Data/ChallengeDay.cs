namespace FlashcardsApp;

// Một ngày trong lịch thử thách mà Admin soạn ở tab Quản trị · Thử thách (#42).
// FolderId là null nghĩa là "Tự chọn": app tự lấy từ trong các bài và thư mục theo mùa.
public sealed class ChallengeDay
{
    public DateTime Date { get; set; }
    public int? FolderId { get; set; }
    public string FolderName { get; set; } = "Tự chọn";
}
