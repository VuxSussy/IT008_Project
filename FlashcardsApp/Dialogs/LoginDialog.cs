namespace FlashcardsApp;

// Hộp đăng nhập và đăng ký, mở trước MainWindow. Hộp trống từ #35, phần bên trong làm ở #36. Xem docs/04-gui.md.
// Kéo vào Designer: LogoBox, titleLabel, usernameTextBox (MaxLength 20), passwordTextBox (che chữ, MaxLength 50),
// confirmPasswordTextBox (chỉ hiện khi đăng ký), errorLabel nền cam nhạt, loginButton (AcceptButton), modeLinkLabel, exitButton.
public partial class LoginDialog : Form
{
    // true khi đang ở chế độ đăng ký; modeLinkLabel đổi qua lại
    private bool isRegisterMode;

    public LoginDialog()
    {
        InitializeComponent();
    }

    // Nút Đăng nhập / Đăng ký
    private void SubmitForm(string username, string password, string confirmPassword)
    {
        // TODO (#36):
        //   Đăng nhập: UserStore.Login(username, password) khác null thì DialogResult = DialogResult.OK;
        //              null thì errorLabel "Sai tên đăng nhập hoặc mật khẩu"
        //   Đăng ký: GetRegisterError(...) khác null thì hiện vào errorLabel; không thì UserStore.Register rồi Login
        //   Bọc trong try/catch, lỗi kết nối thì báo bằng câu tiếng Việt (docs/02 quy tắc 3)
    }

    // Kiểm tra ô nhập khi đăng ký. Trả về câu báo lỗi, hoặc null nếu hợp lệ.
    private static string? GetRegisterError(string username, string password, string confirmPassword)
    {
        // TODO (#36): mỗi lỗi một câu riêng
        //   - tên dài 3 đến 20 ký tự, chỉ có chữ cái không dấu và số: Regex.IsMatch(username, "^[a-zA-Z0-9]{3,20}$")
        //   - tên chưa có ai dùng: UserStore.UsernameExists(username)
        //   - mật khẩu ít nhất 6 ký tự: "Mật khẩu cần ít nhất 6 ký tự."
        //   - hai ô mật khẩu giống nhau
        return null;
    }

    // modeLinkLabel: "Chưa có tài khoản? Đăng ký" ↔ "Đã có tài khoản? Đăng nhập"
    private void ToggleMode()
    {
        isRegisterMode = !isRegisterMode;

        // TODO (#36): đổi titleLabel ("Đăng nhập" / "Tạo tài khoản"), chữ trên loginButton và modeLinkLabel,
        // hiện hoặc ẩn confirmPasswordTextBox, xóa errorLabel
    }
}
