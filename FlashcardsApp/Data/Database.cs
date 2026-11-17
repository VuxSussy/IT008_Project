using Microsoft.Data.SqlClient;

namespace FlashcardsApp;

// Tạo cơ sở dữ liệu Flashcards trên SQL Server Express của máy, 9 bảng và dữ liệu mẫu. Việc của #4.
// Bảng, cột, khóa chính, khóa ngoại: xem docs/03-database.md và ảnh docs/assets/data/data.png.
// Các chỗ ghi "TODO (#4)" là phần còn phải viết. Trong Visual Studio mở View → Task List để thấy hết.
public static class Database
{
    // Mọi lớp ...Store mở kết nối bằng chuỗi này:
    //     using var conn = new SqlConnection(Database.ConnectionString);
    // TODO (#4): trả về chuỗi kết nối tới cơ sở dữ liệu Flashcards trên máy chủ .\SQLEXPRESS,
    // đăng nhập bằng tài khoản Windows. Máy nào đặt tên máy chủ khác thì sửa trên máy mình, đừng commit.
    public static string ConnectionString => "";

    // Program.cs gọi hàm này một lần, trước khi mở hộp đăng nhập.
    public static void EnsureCreated()
    {
        // TODO (#4):
        //   1. Nối vào master (cơ sở dữ liệu có sẵn của SQL Server), xem đã có Flashcards chưa. Có rồi thì thôi.
        //   2. Chưa có thì tạo cơ sở dữ liệu Flashcards.
        //   3. Tạo 9 bảng đúng như docs/03: Users, Courses, Folders, Flashcards, CardProgress, StudyDays,
        //      DailyChallenges, ChallengeResults, RushResults (đủ khóa chính, khóa ngoại, UNIQUE, ON DELETE CASCADE).
        //   4. Thêm dữ liệu mẫu:
        //      - 3 tài khoản admin (Admin), lan, minh (User), mật khẩu đều là 123456, mã hóa giống UserStore.HashPassword
        //      - mỗi tài khoản một thư mục "Chưa phân loại" (IsDefault = 1)
        //      - 1 khóa học có 3 bài (3 thư mục của admin), mỗi bài 10 từ, lấy từ file JSON của bản chạy thử
        //   Câu lệnh SQL viết thẳng trong file này, không tạo file .sql riêng.
        //   Chữ có dấu phải có N đứng trước: N'tò mò'.
        // Viết xong thì thử: xóa Flashcards trong SSMS, bấm F5, app phải tự tạo lại.
    }
}
