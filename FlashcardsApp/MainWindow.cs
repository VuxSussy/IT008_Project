using System.Text.Json;

namespace FlashcardsApp;

// Cửa sổ chính: cột menu bên trái và chỗ hiện màn hình con (contentPanel). Xem docs/04-gui.md mục 0.
public partial class MainWindow : Form
{
    // Màn đang hiện trong contentPanel
    private UserControl? currentScreen;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_Load(object? sender, EventArgs e)
    {
        // Cửa sổ không to hơn màn hình máy đang dùng (laptop màn nhỏ)
        var screenArea = Screen.FromControl(this).WorkingArea;
        var width = Math.Min(Width, screenArea.Width - 24);
        var height = Math.Min(Height, screenArea.Height - 24);
        Size = new Size(width, height);
        CenterToScreen();

        ShowUser();
        ShowScreen(new OverviewScreen());
    }

    // Ô tài khoản cuối menu, và nhóm QUẢN TRỊ chỉ hiện với tài khoản Admin
    private void ShowUser()
    {
        var user = Session.CurrentUser;
        if (user == null) return;

        avatarBox.Text = user.Username;
        userLabel.Text = user.Username + "\n" + (user.IsAdmin ? "Admin" : "User");
        adminGroupLabel.Visible = user.IsAdmin;
        adminButton.Visible = user.IsAdmin;
    }

    // Xóa màn cũ, đặt màn mới vào contentPanel. Màn khác muốn chuyển màn thì gọi:
    // (FindForm() as MainWindow)?.ShowScreen(new StudyScreen());
    public void ShowScreen(UserControl screen)
    {
        var oldScreen = currentScreen;
        currentScreen = screen;

        screen.Dock = DockStyle.Fill;
        contentPanel.SuspendLayout(); // tạm dừng sắp xếp để màn không bị nháy khi đổi
        contentPanel.Controls.Clear();
        contentPanel.Controls.Add(screen);
        contentPanel.ResumeLayout();

        // Hủy màn cũ sau khi cú bấm xử lý xong, vì nút "Học ngay" vừa được bấm nằm trong chính màn cũ
        if (oldScreen != null)
        {
            BeginInvoke(oldScreen.Dispose);
        }

        screen.Focus();
        UpdateMenu();
    }

    // Tô nút menu của màn đang mở, cập nhật số từ trên nút Sổ lỗi
    private void UpdateMenu()
    {
        overviewButton.Selected = currentScreen is OverviewScreen;
        courseButton.Selected = currentScreen is CourseScreen;
        folderButton.Selected = currentScreen is FolderScreen;
        studyButton.Selected = currentScreen is StudyScreen;
        typeButton.Selected = currentScreen is TypeAnswerScreen;
        mistakeButton.Selected = currentScreen is MistakeScreen;
        challengeButton.Selected = currentScreen is ChallengeScreen;
        rushButton.Selected = currentScreen is RushScreen;
        leaderboardButton.Selected = currentScreen is LeaderboardScreen;
        matchButton.Selected = currentScreen is MatchScreen;
        adminButton.Selected = currentScreen is AdminScreen;

        var mistakeCount = CountMistakes();
        if (mistakeCount > 0)
            mistakeButton.Badge = mistakeCount.ToString();
        else
            mistakeButton.Badge = "";
    }

    // Đếm số từ trong sổ lỗi (mức nhớ Quên = 1 hoặc Khó = 2) của người đang đăng nhập
    private int CountMistakes()
    {
        try
        {
            // TODO (#12): đổi 2 dòng dưới thành: return StudyStore.GetMistakes().Count;
            var cards = FlashcardStore.Load(FlashcardStore.DefaultPath);
            return cards.Count(card => card.LastRating == 1 || card.LastRating == 2);
        }
        catch (Exception ex) when (ex is IOException or InvalidDataException or UnauthorizedAccessException or JsonException)
        {
            // Chỉ bắt lỗi đọc file; lỗi khác là lỗi code, để app báo ra cho dễ sửa.
            // Không đếm được thì để trống số trên nút Sổ lỗi, màn Sổ lỗi sẽ tự báo lỗi khi mở.
            return 0;
        }
    }

    // Mỗi nút menu tạo một màn mới, nên số liệu trên màn luôn được đọc lại
    private void overviewButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new OverviewScreen());
    }

    private void folderButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new FolderScreen());
    }

    private void studyButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new StudyScreen());
    }

    private void typeButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new TypeAnswerScreen());
    }

    private void mistakeButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new MistakeScreen());
    }

    private void matchButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new MatchScreen());
    }

    private void courseButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new CourseScreen());
    }

    private void challengeButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new ChallengeScreen());
    }

    private void rushButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new RushScreen());
    }

    private void leaderboardButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new LeaderboardScreen());
    }

    private void adminButton_Click(object? sender, EventArgs e)
    {
        ShowScreen(new AdminScreen());
    }

    // Mở lại app từ đầu: Session mất, Program.cs mở lại hộp đăng nhập (#36)
    private void logoutButton_Click(object? sender, EventArgs e)
    {
        Application.Restart();
    }

    // Phím tắt của màn Học: Space để lật thẻ, 1–4 để chọn Quên/Khó/Nhớ/Dễ.
    // Ở màn khác thì không bắt phím, Space và số vẫn gõ vào ô như thường.
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (currentScreen is StudyScreen studyScreen)
        {
            if (keyData == Keys.Space)
            {
                studyScreen.Flip();
                return true; // true = đã xử lý phím này, không chuyển tiếp cho control khác
            }

            var rating = GetRating(keyData);
            if (rating > 0)
            {
                studyScreen.Rate(rating);
                UpdateMenu(); // số từ trong sổ lỗi có thể đã đổi
                return true;
            }
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    // Phím 1–4 (hàng số hoặc bàn phím số bên phải) thành mức nhớ 1–4; phím khác trả về 0
    private static int GetRating(Keys key)
    {
        switch (key)
        {
            case Keys.D1:
            case Keys.NumPad1:
                return 1;
            case Keys.D2:
            case Keys.NumPad2:
                return 2;
            case Keys.D3:
            case Keys.NumPad3:
                return 3;
            case Keys.D4:
            case Keys.NumPad4:
                return 4;
            default:
                return 0;
        }
    }
}
