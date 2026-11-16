namespace FlashcardsApp;

// Chỗ app bắt đầu chạy
internal static class Program
{
    [STAThread]
    static void Main()
    {
        // Bật cài đặt chung của WinForms: chữ nét trên màn độ phân giải cao, font mặc định
        ApplicationConfiguration.Initialize();

        // Lần đầu mở app: tạo file flashcards.db và 30 từ mẫu (#4)
        Database.EnsureCreated();

        // TODO (#36): bỏ dòng gán tạm dưới đây, mở hộp đăng nhập trước; bấm Thoát thì tắt app:
        //     using (var login = new LoginDialog())
        //     {
        //         if (login.ShowDialog() != DialogResult.OK) return;
        //     }
        // Gán tạm tài khoản cho tới khi có LoginDialog. Muốn xem menu QUẢN TRỊ thì đổi thành
        // new User { Id = 1, Username = "admin", Role = "Admin" }
        Session.CurrentUser = new User { Id = 2, Username = "lan", Role = "User" };

        // Mở cửa sổ chính. App chạy tới khi cửa sổ này đóng.
        Application.Run(new MainWindow());
    }
}
