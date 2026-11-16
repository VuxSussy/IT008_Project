namespace FlashcardsApp;

// Một dòng của bảng xếp hạng. Mọi bảng xếp hạng (thử thách, đua từ, chuỗi ngày) dùng chung lớp này (#38).
public sealed class RankRow
{
    public int Rank { get; set; }
    public string Username { get; set; } = "";
    public int Score { get; set; }
    public string Detail { get; set; } = ""; // ví dụ "1:52" (thời gian làm thử thách)
    public bool IsMe { get; set; }           // dòng của người đang đăng nhập, tô nền xanh nhạt
}
