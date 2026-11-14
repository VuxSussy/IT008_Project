namespace FlashcardsApp;

// Tab Quản trị · Người dùng: xem số liệu của từng User, đặt lại mật khẩu. Màn trống từ #35, phần bên trong làm ở #44.
// Xem docs/04-gui.md.
public partial class AdminUserPanel : UserControl
{
    public AdminUserPanel()
    {
        InitializeComponent();
    }

    // userGrid: Tên, Ngày tạo, Đã nhớ, Chuỗi ngày, Kỷ lục đua từ, Thử thách hôm nay
    private void LoadUsers()
    {
        // TODO (#44): userGrid.DataSource = UserStore.GetAllUsers();
    }

    // Nút Đặt lại mật khẩu, với dòng đang chọn trong userGrid
    private void ResetPassword(UserSummary user)
    {
        var answer = MessageBox.Show(this, $"Đặt lại mật khẩu của {user.Username} về 123456?", "Đặt lại mật khẩu",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes) return;

        // TODO (#44): gọi UserStore.ResetPassword(user.UserId) trong try/catch, lỗi thì báo bằng câu tiếng Việt (docs/02 quy tắc 3)
    }
}
