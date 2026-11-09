using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text.Json;

namespace FlashcardsApp;

// Màn Tổng quan và Từ của ngày. Xem docs/04-gui.md mục 1.
public partial class OverviewScreen : UserControl
{
    private int totalCount;
    private int learnedCount;
    private Flashcard? wordOfDay;

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

        ShowWordOfDay(cards);
    }

    // Từ của ngày: chọn trong các từ chưa thuộc (chưa học, Quên, Khó); thuộc hết thì chọn trong tất cả.
    // Lấy theo số thứ tự của ngày trong năm nên cả ngày ra cùng một từ mà không cần lưu gì.
    private void ShowWordOfDay(List<Flashcard> cards)
    {
        var pool = cards.Where(card => card.LastRating < 3).ToList();
        if (pool.Count == 0) pool = cards;
        if (pool.Count == 0)
        {
            wordOfDay = null;
            wordOfDayPanel.Visible = false;
            return;
        }

        wordOfDay = pool[DateTime.Today.DayOfYear % pool.Count];
        wordOfDayPanel.Visible = true;
        wordOfDayLabel.Text = wordOfDay.Word;
        wordOfDayInfoLabel.Text = string.IsNullOrWhiteSpace(wordOfDay.Pronunciation)
            ? wordOfDay.Meaning
            : $"{wordOfDay.Pronunciation} · {wordOfDay.Meaning}";
        wordOfDayExampleLabel.Text = wordOfDay.Example;
        wordOfDayTranslationLabel.Text = wordOfDay.ExampleTranslation;
    }

    private void studyNowButton_Click(object? sender, EventArgs e)
    {
        var mainWindow = FindForm() as MainWindow;
        var studyScreen = new StudyScreen();
        mainWindow?.ShowScreen(studyScreen);
        // 0 = học tất cả các thư mục
        studyScreen.StartFolder(0);
    }

    private void speakWordButton_Click(object? sender, EventArgs e)
    {
        if (wordOfDay is not null) WordSpeaker.Speak(this, wordOfDay.Word);
    }

    // Nền trắng bo góc, viền xám cho 4 thẻ số và khung tiến độ
    private void cardPanel_Paint(object? sender, PaintEventArgs e)
    {
        if (sender is Panel panel) NativeStudyPainting.Surface(panel, e);
    }

    // Khung Từ của ngày: nền xanh nhạt bo góc, không viền
    private void wordOfDayPanel_Paint(object? sender, PaintEventArgs e) => NativeStudyPainting.Surface(wordOfDayPanel, e, border: false);

    // Tiêu đề nhỏ viết hoa ("TIẾN ĐỘ GHI NHỚ", "TỪ CỦA NGÀY"): giãn cách từng chữ cái như hình mẫu
    private void spacedLabel_Paint(object? sender, PaintEventArgs e)
    {
        if (sender is not Label label) return;
        e.Graphics.Clear(label.BackColor);
        var flags = TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix;
        var x = 0;
        foreach (var letter in label.Text)
        {
            var size = TextRenderer.MeasureText(e.Graphics, letter.ToString(), label.Font, Size.Empty, flags);
            TextRenderer.DrawText(e.Graphics, letter.ToString(), label.Font, new Rectangle(x, 0, size.Width + 2, label.Height),
                label.ForeColor, flags | TextFormatFlags.VerticalCenter);
            x += size.Width + (int)(1.2f * label.DeviceDpi / 96f);
        }
    }

    // Câu ví dụ: in đậm từ đang học. Không tìm thấy từ trong câu thì để Label tự vẽ như thường.
    private void wordOfDayExampleLabel_Paint(object? sender, PaintEventArgs e)
    {
        var text = wordOfDayExampleLabel.Text;
        var word = wordOfDay?.Word ?? "appointment";
        var index = text.IndexOf(word, StringComparison.OrdinalIgnoreCase);
        if (index < 0) return;
        e.Graphics.Clear(wordOfDayExampleLabel.BackColor);
        using var bold = new Font(wordOfDayExampleLabel.Font, FontStyle.Bold);
        var flags = TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix;
        var x = 0;
        foreach (var (part, font) in new[] { (text[..index], wordOfDayExampleLabel.Font), (text.Substring(index, word.Length), bold), (text[(index + word.Length)..], wordOfDayExampleLabel.Font) })
        {
            if (part.Length == 0) continue;
            var width = TextRenderer.MeasureText(e.Graphics, part, font, Size.Empty, flags).Width;
            TextRenderer.DrawText(e.Graphics, part, font, new Rectangle(x, 0, width + 2, wordOfDayExampleLabel.Height),
                wordOfDayExampleLabel.ForeColor, flags | TextFormatFlags.VerticalCenter);
            x += width;
        }
    }

    // Ô ghi chú cuối khung Từ của ngày: nền trắng bo góc
    private void wordOfDayNoteLabel_Paint(object? sender, PaintEventArgs e)
    {
        var label = wordOfDayNoteLabel;
        var g = e.Graphics;
        g.Clear(wordOfDayPanel.BackColor);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        using var path = StudyTheme.Round(new RectangleF(0, 0, label.Width - 1, label.Height - 1), 6 * label.DeviceDpi / 96f);
        using var white = new SolidBrush(Color.White);
        g.FillPath(white, path);
        TextRenderer.DrawText(g, label.Text, label.Font, new Rectangle(label.Padding.Left, 0, label.Width - label.Padding.Left, label.Height),
            label.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis);
    }

    private void progressPanel_Resize(object? sender, EventArgs e) => progressPanel.Invalidate();

    // Vòng tròn tiến độ: vẽ hình tròn xám, vẽ phần "đã nhớ" màu xanh bằng FillPie (bắt đầu từ đỉnh, theo chiều kim đồng hồ),
    // rồi vẽ hình tròn trắng nhỏ hơn ở giữa để thành vòng, ghi phần trăm vào giữa. Bên phải là chú thích.
    private void progressPanel_Paint(object? sender, PaintEventArgs e)
    {
        NativeStudyPainting.Surface(progressPanel, e);
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
