using System.Text.RegularExpressions;

namespace FlashcardsApp;

// Hộp đăng nhập và đăng ký, mở trước MainWindow. Hộp trống từ #35, phần bên trong làm ở #36. Xem docs/04-gui.md.
// Kéo vào Designer: LogoBox, titleLabel, usernameTextBox (MaxLength 20), passwordTextBox (che chữ, MaxLength 50),
// confirmPasswordTextBox (chỉ hiện khi đăng ký), errorLabel nền cam nhạt, loginButton (AcceptButton), modeLinkLabel, exitButton.
public partial class LoginDialog : Form
{
    // true khi đang ở chế độ đăng ký; modeLinkLabel đổi qua lại
    private bool isRegisterMode = true;

    public LoginDialog()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        ToggleMode();
    }

    // Nút Đăng nhập / Đăng ký
    private void SubmitForm(string username, string password, string confirmPassword)
    {
        // TODO (#36):
        //   Đăng nhập: UserStore.Login(username, password) khác null thì DialogResult = DialogResult.OK;
        //              null thì errorLabel "Sai tên đăng nhập hoặc mật khẩu"
        //   Đăng ký: GetRegisterError(...) khác null thì hiện vào errorLabel; không thì UserStore.Register rồi Login
        //   Bọc trong try/catch, lỗi kết nối thì báo bằng câu tiếng Việt (docs/02 quy tắc 3)
        User user = null;
        try
        {
            if (confirmPassword == "")
            {
                user = UserStore.Login(username, password);
                if (user != null)
                {
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    errorLabel.Text = "Sai tên đăng nhập hoặc mật khẩu";
                    errorLabel.Show();
                    loginButton.Location = new Point(errorLabel.Left, errorLabel.Top + 30);
                    modeLinkLabel.Location = new Point(loginButton.Left + modeLinkLabel.Width / 4, loginButton.Top + 50);
                }
            }
            else
            {
                string? error = GetRegisterError(username, password, confirmPassword);
                if (error != null)
                {
                    errorLabel.Text = error;
                    errorLabel.Show();
                    loginButton.Location = new Point(errorLabel.Left, errorLabel.Top + 30);
                    modeLinkLabel.Location = new Point(loginButton.Left + modeLinkLabel.Width / 4, loginButton.Top + 50);
                }
                else
                {
                    UserStore.Register(username, password);
                    user = UserStore.Login(username, password);
                    DialogResult = DialogResult.OK;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể đăng ký tài khoản. Vui lòng kiểm tra SQL Server đã chạy chưa và thử lại.\n\nChi tiết: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Kiểm tra ô nhập khi đăng ký. Trả về câu báo lỗi, hoặc null nếu hợp lệ.
    private static string? GetRegisterError(string username, string password, string confirmPassword)
    {
        // TODO (#36): mỗi lỗi một câu riêng
        //   - tên dài 3 đến 20 ký tự, chỉ có chữ cái không dấu và số: Regex.IsMatch(username, "^[a-zA-Z0-9]{3,20}$")
        //   - tên chưa có ai dùng: UserStore.UsernameExists(username)
        //   - mật khẩu ít nhất 6 ký tự: "Mật khẩu cần ít nhất 6 ký tự."
        //   - hai ô mật khẩu giống nhau
        if (username.Length < 3 || username.Length > 20) { return "Tên đăng nhập phải từ 3 đến 20 ký tự!"; }
        if (!Regex.IsMatch(username, "^[a-zA-Z0-9]{3,20}$")) { return "Tên đăng nhập chỉ nhận số và chữ cái!"; }
        if (UserStore.UsernameExists(username)) { return "Tên đăng nhập đã tồn tại!"; }
        if (password.Length < 6) { return "Mật khẩu cần ít nhất 6 kí tự!"; }
        if (password != confirmPassword) { return "Mật khẩu xác nhận chưa khớp!"; }
        return null;
    }

    // modeLinkLabel: "Chưa có tài khoản? Đăng ký" ↔ "Đã có tài khoản? Đăng nhập"
    private void ToggleMode()
    {
        isRegisterMode = !isRegisterMode;

        // TODO (#36): đổi titleLabel ("Đăng nhập" / "Tạo tài khoản"), chữ trên loginButton và modeLinkLabel,
        // hiện hoặc ẩn confirmPasswordTextBox, xóa errorLabel
        if (!isRegisterMode)
        {
            this.Size = new Size(420, 460);
            confirmPasswordLabel.Hide();
            confirmPasswordTextBox.Hide();
            errorLabel.Hide();
            errorLabel.Bounds = new Rectangle(passwordTextBox.Left, passwordTextBox.Top + 35, usernameTextBox.Width, 25);
            titleLabel.Text = "Đăng nhập";
            usernameTextBox.Location = new Point(titleLabel.Left, titleLabel.Top + 75);
            usernameLabel.Location = new Point(usernameTextBox.Left, usernameTextBox.Top - 25);
            passwordTextBox.Location = new Point(usernameTextBox.Left, usernameTextBox.Top + 55);
            passwordLabel.Location = new Point(passwordTextBox.Left, passwordTextBox.Top - 25);
            loginButton.Text = "Đăng nhập";
            loginButton.Location = new Point(passwordTextBox.Left, passwordTextBox.Top + 45);
            modeLinkLabel.Text = "Chưa có tài khoản? Đăng ký";
            modeLinkLabel.LinkArea = new LinkArea(19, 7);
            modeLinkLabel.Location = new Point(loginButton.Left + modeLinkLabel.Width / 4, loginButton.Top + 50);
            exitButton.Location = new Point(this.ClientSize.Width / 2 - exitButton.Width / 2, this.ClientSize.Height - exitButton.Height - 10);

        }
        else
        {
            this.Size = new Size(420, 520);
            confirmPasswordLabel.Show();
            confirmPasswordTextBox.Show();
            errorLabel.Hide();
            errorLabel.Bounds = new Rectangle(confirmPasswordTextBox.Left, confirmPasswordTextBox.Top + 35, usernameTextBox.Width, 25);
            titleLabel.Text = "Tạo tài khoản";
            usernameTextBox.Location = new Point(titleLabel.Left, titleLabel.Top + 75);
            usernameLabel.Location = new Point(usernameTextBox.Left, usernameTextBox.Top - 25);
            passwordTextBox.Location = new Point(usernameTextBox.Left, usernameTextBox.Top + 55);
            passwordLabel.Location = new Point(passwordTextBox.Left, passwordTextBox.Top - 25);
            confirmPasswordTextBox.Location = new Point(passwordTextBox.Left, passwordTextBox.Top + 55);
            confirmPasswordLabel.Location = new Point(confirmPasswordTextBox.Left, confirmPasswordTextBox.Top - 25);
            loginButton.Text = "Đăng ký";
            loginButton.Location = new Point(confirmPasswordTextBox.Left, confirmPasswordTextBox.Top + 45);
            modeLinkLabel.Text = "Đã có tài khoản? Đăng nhập";
            modeLinkLabel.LinkArea = new LinkArea(17, 9);
            modeLinkLabel.Location = new Point(loginButton.Left + modeLinkLabel.Width / 4, loginButton.Top + 50);
            exitButton.Location = new Point(this.ClientSize.Width / 2 - exitButton.Width / 2, this.ClientSize.Height - exitButton.Height - 10);
        }
        passwordTextBox.Clear();
        confirmPasswordTextBox.Clear();
    }

    private void modeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        ToggleMode();
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        SubmitForm(usernameTextBox.Text.ToString(),
                   passwordTextBox.Text.ToString(),
                   confirmPasswordTextBox.Text.ToString());
    }
}
