using System.Text.Json;

namespace FlashcardsApp;

// Cửa sổ chính: cột menu bên trái và chỗ hiện màn hình con. Xem docs/04-gui.md mục 0.
public partial class MainWindow : Form
{
    private UserControl? currentScreen;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_Load(object? sender, EventArgs e)
    {
        // Cửa sổ không to hơn màn hình máy đang dùng (laptop màn nhỏ)
        var area = Screen.FromControl(this).WorkingArea;
        Size = new Size(Math.Min(Width, area.Width - 24), Math.Min(Height, area.Height - 24));
        CenterToScreen();
        ShowScreen(new OverviewScreen());
    }

    // Xóa màn cũ, đặt màn mới vào contentPanel. Màn khác muốn chuyển màn thì gọi:
    // (FindForm() as MainWindow)?.ShowScreen(new StudyScreen());
    public void ShowScreen(UserControl screen)
    {
        var oldScreen = currentScreen;
        currentScreen = screen;
        screen.Dock = DockStyle.Fill;
        contentPanel.SuspendLayout();
        contentPanel.Controls.Clear();
        contentPanel.Controls.Add(screen);
        contentPanel.ResumeLayout();
        // Hủy màn cũ sau khi cú bấm xử lý xong: nút "Học ngay" nằm trong chính màn cũ
        if (oldScreen is not null) BeginInvoke(oldScreen.Dispose);
        screen.Focus();
        UpdateMenu();
    }

    private void UpdateMenu()
    {
        overviewButton.Selected = currentScreen is OverviewScreen;
        folderButton.Selected = currentScreen is FolderScreen;
        studyButton.Selected = currentScreen is StudyScreen;
        typeButton.Selected = currentScreen is TypeAnswerScreen;
        mistakeButton.Selected = currentScreen is MistakeScreen;
        matchButton.Selected = currentScreen is MatchScreen;

        var mistakes = CountMistakes();
        mistakeButton.Badge = mistakes > 0 ? mistakes.ToString() : "";

        foreach (var button in new[] { overviewButton, folderButton, studyButton, typeButton, mistakeButton, matchButton })
            button.Invalidate();
    }

    private int CountMistakes()
    {
        try
        {
            // Tạm đọc file JSON của bản chạy thử. Khi #12 xong đổi thành: return StudyStore.GetMistakes().Count;
            var cards = FlashcardStore.Load(FlashcardStore.DefaultPath);
            savedLabel.Text = "Đã lưu vào máy";
            savedLabel.IsError = false;
            return cards.Count(card => card.LastRating is 1 or 2);
        }
        catch (Exception ex) when (ex is IOException or InvalidDataException or UnauthorizedAccessException or JsonException)
        {
            savedLabel.Text = "Chưa đọc được dữ liệu";
            savedLabel.IsError = true;
            return 0;
        }
    }

    private void overviewButton_Click(object? sender, EventArgs e) => ShowScreen(new OverviewScreen());
    private void folderButton_Click(object? sender, EventArgs e) => ShowScreen(new FolderScreen());
    private void studyButton_Click(object? sender, EventArgs e) => ShowScreen(new StudyScreen());
    private void typeButton_Click(object? sender, EventArgs e) => ShowScreen(new TypeAnswerScreen());
    private void mistakeButton_Click(object? sender, EventArgs e) => ShowScreen(new MistakeScreen());
    private void matchButton_Click(object? sender, EventArgs e) => ShowScreen(new MatchScreen());

    // Phím tắt chỉ dùng ở màn Học; ở màn khác Space và số vẫn gõ vào ô như thường
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (currentScreen is StudyScreen studyScreen)
        {
            if (keyData == Keys.Space) { studyScreen.Flip(); return true; }
            var rating = keyData switch
            {
                Keys.D1 or Keys.NumPad1 => 1,
                Keys.D2 or Keys.NumPad2 => 2,
                Keys.D3 or Keys.NumPad3 => 3,
                Keys.D4 or Keys.NumPad4 => 4,
                _ => 0
            };
            if (rating > 0)
            {
                studyScreen.Rate(rating);
                UpdateMenu();
                return true;
            }
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}
