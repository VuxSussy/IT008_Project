using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text.Json;

namespace FlashcardsApp;

// Màn Tổng quan: 4 thẻ số, vòng tròn tiến độ, nút Học ngay. Xem docs/04-gui.md mục 1.
// Cột bên phải của mainLayout để trống cho khung Từ của ngày (#15).
public partial class OverviewScreen : UserControl
{
    private int totalCount;
    private int learnedCount;

    public OverviewScreen()
    {
        InitializeComponent();
    }

    // MainWindow tạo màn mới mỗi lần bấm menu, nên mỗi lần mở màn này là đếm lại số
    private void OverviewScreen_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        var today = DateTime.Today;
        var dayName = today.ToString("dddd", new CultureInfo("vi-VN"));
        dateLabel.Text = $"{char.ToUpper(dayName[0])}{dayName[1..]}, {today:dd/MM}";
        ShowNumbers();
    }

    private void ShowNumbers()
    {
        List<Flashcard> cards;
        int folderCount;
        try
        {
            // Tạm đọc file JSON của bản chạy thử. Khi #4 xong đổi 2 dòng này thành:
            // cards = FlashcardStore.GetAll();
            // folderCount = FolderStore.GetAll().Count;
            cards = FlashcardStore.Load(FlashcardStore.DefaultPath);
            folderCount = 1;
        }
        catch (Exception ex) when (ex is IOException or InvalidDataException or UnauthorizedAccessException or JsonException)
        {
            MessageBox.Show(this, "Không đọc được file dữ liệu. Hãy tắt app, mở lại rồi thử lần nữa.\n\n" + ex.Message,
                "Tổng quan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cards = new List<Flashcard>();
            folderCount = 0;
        }

        totalCount = cards.Count;
        learnedCount = cards.Count(card => card.IsLearned);
        totalLabel.Text = totalCount.ToString();
        learnedLabel.Text = learnedCount.ToString();
        mistakeLabel.Text = cards.Count(card => card.LastRating is 1 or 2).ToString();
        folderLabel.Text = folderCount.ToString();
        progressPanel.Invalidate();
    }

    private void studyNowButton_Click(object? sender, EventArgs e)
    {
        var mainWindow = FindForm() as MainWindow;
        var studyScreen = new StudyScreen();
        mainWindow?.ShowScreen(studyScreen);
        // 0 = học tất cả các thư mục
        studyScreen.StartFolder(0);
    }

    // Vòng tròn tiến độ: vẽ hình tròn xám, vẽ phần "đã nhớ" màu xanh bằng FillPie (bắt đầu từ đỉnh, theo chiều kim đồng hồ),
    // rồi vẽ hình tròn trắng nhỏ hơn ở giữa để thành vòng, ghi phần trăm vào giữa. Bên phải là chú thích.
    // Nền trắng bo góc do CardPanel vẽ sẵn trước khi tới đây.
    private void progressPanel_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        var scale = progressPanel.DeviceDpi / 96f;

        var top = progressTitleLabel.Bottom;
        var bottom = progressPanel.Height - progressPanel.Padding.Bottom;
        var size = Math.Min(Math.Min(bottom - top - 16 * scale, (progressPanel.Width - progressPanel.Padding.Horizontal) * 0.45f), 192 * scale);
        if (size < 40) return;
        var ring = new RectangleF(progressPanel.Padding.Left + 14 * scale, top + (bottom - top - size) / 2, size, size);

        using (var grayBrush = new SolidBrush(StudyTheme.Line))
            g.FillEllipse(grayBrush, ring);
        if (learnedCount > 0)
        {
            using var tealBrush = new SolidBrush(StudyTheme.Teal);
            g.FillPie(tealBrush, ring.X, ring.Y, ring.Width, ring.Height, -90, 360f * learnedCount / totalCount);
        }
        // Vòng dày 30 trên đường kính 192
        var hole = RectangleF.Inflate(ring, -size * 30 / 192, -size * 30 / 192);
        using (var holeBrush = new SolidBrush(progressPanel.BackColor))
            g.FillEllipse(holeBrush, hole);

        var percent = totalCount == 0 ? 0 : learnedCount * 100 / totalCount;
        using var percentFont = new Font("Segoe UI", 26F * size / (192 * scale), FontStyle.Bold);
        using var smallFont = new Font("Segoe UI", 10F);
        var centerY = (int)(ring.Top + size / 2);
        TextRenderer.DrawText(g, $"{percent}%", percentFont, new Rectangle((int)hole.X, (int)hole.Y, (int)hole.Width, centerY + (int)(10 * scale) - (int)hole.Y),
            StudyTheme.Ink, TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom | TextFormatFlags.NoPadding);
        TextRenderer.DrawText(g, $"{learnedCount} / {totalCount} từ", smallFont, new Rectangle((int)hole.X, centerY + (int)(12 * scale), (int)hole.Width, (int)(24 * scale)),
            StudyTheme.Slate, TextFormatFlags.HorizontalCenter | TextFormatFlags.Top);

        var legendX = (int)(ring.Right + 50 * scale);
        DrawLegend(g, legendX, centerY - (int)(40 * scale), StudyTheme.Teal, $"Đã nhớ · {learnedCount}", scale);
        DrawLegend(g, legendX, centerY - (int)(10 * scale), StudyTheme.Line, $"Chưa thuộc · {totalCount - learnedCount}", scale);
    }

    // Một dòng chú thích: ô vuông màu 12×12 rồi chữ, căn giữa theo dòng y
    private void DrawLegend(Graphics g, int x, int y, Color color, string text, float scale)
    {
        var box = (int)(12 * scale);
        using var brush = new SolidBrush(color);
        g.FillRectangle(brush, x, y - box / 2, box, box);
        using var font = new Font("Segoe UI", 10.5F);
        TextRenderer.DrawText(g, text, font, new Rectangle(x + box + (int)(10 * scale), y - (int)(12 * scale), (int)(200 * scale), (int)(24 * scale)),
            StudyTheme.Ink, TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
    }
}
