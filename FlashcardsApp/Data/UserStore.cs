namespace FlashcardsApp;

// Đọc, ghi bảng Users: đăng nhập, đăng ký, xem và đặt lại mật khẩu cho User, điểm trình độ.
// Mọi câu SQL về tài khoản nằm ở đây. Xem docs/03-database.md.
// Các chỗ ghi "TODO (#số)" là phần còn phải viết. Trong Visual Studio mở View → Task List để thấy hết.
public static class UserStore
{
    // Đúng tên và mật khẩu thì gán Session.CurrentUser rồi trả về User; sai thì trả về null.
    // Ai gọi: LoginDialog, nút Đăng nhập.
    public static User? Login(string username, string password)
    {
        // TODO (#36): SELECT Id, Username, Role, Rating, CreatedAt FROM Users
        //     WHERE Username = @username AND PasswordHash = @hash
        // với @hash = HashPassword(username, password). Có dòng thì tạo User, gán Session.CurrentUser = user, trả về user.
        return null;
    }

    // true nếu đã có tài khoản tên này. SQL Server so chữ không phân biệt hoa thường, nên "Lan" trùng "lan".
    // Ai gọi: LoginDialog khi đăng ký.
    public static bool UsernameExists(string username)
    {
        // TODO (#36): SELECT COUNT(*) FROM Users WHERE Username = @username, lớn hơn 0 thì trả về true
        return false;
    }

    // Tạo tài khoản quyền User và một thư mục "Chưa phân loại" (IsDefault = 1) cho người đó.
    // Ai gọi: LoginDialog, nút Đăng ký (sau khi đã kiểm tra ô nhập).
    public static void Register(string username, string password)
    {
        // TODO (#36): INSERT INTO Users (Username, PasswordHash, Role) VALUES (@username, @hash, 'User');
        // lấy Id vừa tạo bằng SCOPE_IDENTITY(), rồi INSERT INTO Folders (Name, OwnerId, IsDefault) VALUES (N'Chưa phân loại', @id, 1)
    }

    // Mọi tài khoản User kèm số liệu học, cho tab Quản trị · Người dùng.
    public static List<UserSummary> GetAllUsers()
    {
        var users = new List<UserSummary>();

        // TODO (#44): đọc các dòng Role = 'User', kèm số từ đã nhớ (CardProgress, LastRating >= 3),
        // chuỗi ngày (ActivityStore.GetStreakRanking), kỷ lục đua từ (MAX của RushResults) và điểm thử thách hôm nay

        return users;
    }

    // Đặt mật khẩu về 123456. Ai gọi: AdminUserPanel, nút Đặt lại mật khẩu (sau khi hỏi lại).
    public static void ResetPassword(int userId)
    {
        // TODO (#44): đọc Username của userId, rồi UPDATE Users SET PasswordHash = @hash WHERE Id = @userId
        // với @hash = HashPassword(username, "123456")
    }

    // Cộng, trừ điểm trình độ sau mỗi từ trong Thử thách hằng ngày. Tùy chọn.
    public static void UpdateRating(string word, bool correct)
    {
        // TODO (#46): chỉ làm khi Session.CurrentUser là User. Công thức ở #46:
        //     độ khó = Math.Min(800 + 40 * word.Length, 1600)
        //     khả năng đúng = 1 / (1 + 10^((độ khó - điểm) / 400))
        //     điểm mới = điểm + 16 * (kết quả - khả năng đúng), làm tròn
        // rồi UPDATE Users SET Rating = @rating và gán lại Session.CurrentUser.Rating
    }

    // Mã hóa mật khẩu: SHA-256 của "tên viết thường:mật khẩu", ra chuỗi chữ hoa và số.
    // Phải khớp với HASHBYTES('SHA2_256', 'lan:123456') trong dữ liệu mẫu của #4.
    private static string HashPassword(string username, string password)
    {
        // TODO (#36): thêm "using System.Security.Cryptography;" và "using System.Text;" ở đầu file, rồi
        //     var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(username.ToLower() + ":" + password));
        //     return Convert.ToHexString(bytes);
        return "";
    }
}
