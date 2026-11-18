namespace FlashcardsApp;

// Một tài khoản, ứng với một dòng trong bảng Users (#4). Mật khẩu không nằm ở đây, chỉ UserStore đụng tới.
public sealed class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Role { get; set; } = "User"; // "Admin" hoặc "User"
    public int Rating { get; set; }            // điểm trình độ (#46, tùy chọn); 0 = chưa có
    public DateTime CreatedAt { get; set; }

    public bool IsAdmin => Role == "Admin";
}
