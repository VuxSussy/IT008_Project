using System.Runtime.InteropServices;

namespace FlashcardsApp;

public partial class StudyScreen : UserControl
{
    private readonly List<Flashcard> cards = new();
    private Flashcard? currentCard;
    private bool answerVisible;
    private bool hasEnglishVoice;
    private object? speech;

    public StudyScreen()
    {
        InitializeComponent();
        Load += StudyScreen_Load;
        Resize += (_, _) => FitWordLabel();
    }

    private void StudyScreen_Load(object? sender, EventArgs e)
    {
        LoadCards();
        CheckEnglishVoice();
        ShowCard(cards.FirstOrDefault());
    }

    private void LoadCards()
    {
        cards.AddRange(FlashcardStore.GetAll());

        folderComboBox.Items.Clear();
        folderComboBox.Items.Add("Tất cả");
        folderComboBox.SelectedIndex = 0;
        roundLabel.Text = cards.Count == 0 ? "Chưa có thẻ" : $"Vòng 1 · 1/{cards.Count}";
        remainingLabel.Text = cards.Count == 0 ? "" : $"Còn {Math.Max(0, cards.Count - 1)} thẻ trong vòng";
        progressBar.Maximum = Math.Max(1, cards.Count);
        progressBar.Value = cards.Count == 0 ? 0 : 1;
    }

    private Flashcard? CurrentCard => currentCard;

    private void ShowCard(Flashcard? card)
    {
        currentCard = card;
        answerVisible = false;

        var hasCard = card is not null;
        categoryLabel.Text = string.IsNullOrWhiteSpace(card?.Category) ? "TỪ VỰNG" : card.Category;
        wordLabel.Text = card?.Word ?? "Chưa có từ để học";
        pronunciationLabel.Text = card?.Pronunciation ?? "";
        meaningLabel.Text = card?.Meaning ?? "Hãy thêm từ trước khi bắt đầu học.";
        exampleLabel.Text = card?.Example ?? "";
        translationLabel.Text = card?.ExampleTranslation ?? "";
        memoryLabel.Text = string.IsNullOrWhiteSpace(card?.MemoryNote) ? "" : "Mẹo nhớ: " + card.MemoryNote;

        answerPanel.Visible = false;
        flipButton.Enabled = hasCard;
        flipButton.Text = "Lật thẻ · Space";
        speakButton.Enabled = hasCard;
        SetRatingButtons(false);
        ratingPromptLabel.Text = "Lật thẻ để xem đáp án và tự đánh giá.";
        FitWordLabel();
    }

    // Lật thẻ đang học. MainWindow gọi hàm này khi người dùng nhấn Space.
    public void Flip()
    {
        if (CurrentCard is null || answerVisible) return;

        answerVisible = true;
        answerPanel.Visible = true;
        flipButton.Text = "Đã lật thẻ";
        SetRatingButtons(true);
        ratingPromptLabel.Text = "Bạn nhớ từ này ở mức nào?";
    }

    // Phần lưu kết quả và chuyển thẻ thuộc issue #9.
    public void Rate(int rating)
    {
        if (!answerVisible || rating is < 1 or > 4) return;
    }

    // Phần chọn và học theo thư mục thuộc issue #9.
    public void StartFolder(int folderId)
    {
    }

    private void SetRatingButtons(bool enabled)
    {
        againButton.Enabled = enabled;
        hardButton.Enabled = enabled;
        goodButton.Enabled = enabled;
        easyButton.Enabled = enabled;
    }

    private void flipButton_Click(object? sender, EventArgs e) => Flip();

    private void ratingButton_Click(object? sender, EventArgs e)
    {
        if (sender is StudyButton button && int.TryParse(button.Tag?.ToString(), out var rating))
        {
            Rate(rating);
        }
    }

    private void finishButton_Click(object? sender, EventArgs e)
    {
        (FindForm() as MainWindow)?.ShowScreen(new OverviewScreen());
    }

    private void speakButton_Click(object? sender, EventArgs e)
    {
        if (CurrentCard is null) return;

        if (!hasEnglishVoice)
        {
            var result = MessageBox.Show(this,
                "Máy chưa có giọng đọc tiếng Anh. Mở cài đặt giọng đọc của Windows?",
                "Phát âm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("ms-settings:speech")
                {
                    UseShellExecute = true
                });
            }
            return;
        }

        var word = CurrentCard.Word;
        _ = Task.Run(() => Speak(word));
    }

    private void CheckEnglishVoice()
    {
        try
        {
            speech = Activator.CreateInstance(Type.GetTypeFromProgID("SAPI.SpVoice")
                ?? throw new InvalidOperationException());
            dynamic voice = speech ?? throw new InvalidOperationException();
            foreach (var item in voice.GetVoices())
            {
                if (((string)item.GetDescription()).Contains("English", StringComparison.OrdinalIgnoreCase))
                {
                    voice.Voice = item;
                    hasEnglishVoice = true;
                    break;
                }
            }
        }
        catch (Exception ex) when (IsSpeechError(ex))
        {
            hasEnglishVoice = false;
        }

        speakButton.ForeColor = hasEnglishVoice ? StudyTheme.Teal : StudyTheme.Muted;
        speakToolTip.SetToolTip(speakButton, hasEnglishVoice
            ? "Phát âm từ đang học"
            : "Máy chưa có giọng đọc tiếng Anh");
    }

    private void Speak(string word)
    {
        try
        {
            dynamic voice = speech ?? throw new InvalidOperationException();
            voice.Speak(word, 3);
        }
        catch (Exception ex) when (IsSpeechError(ex))
        {
            if (!IsDisposed && IsHandleCreated)
            {
                BeginInvoke(() => MessageBox.Show(this,
                    "Không phát được âm thanh. Hãy kiểm tra giọng đọc tiếng Anh trong Windows.\n\n" + ex.Message,
                    "Phát âm", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }
    }

    private static bool IsSpeechError(Exception ex)
    {
        return ex is COMException or InvalidOperationException
            or System.Reflection.TargetInvocationException
            or Microsoft.CSharp.RuntimeBinder.RuntimeBinderException;
    }

    private void FitWordLabel()
    {
        if (wordLabel.Width < 50 || wordLabel.Height < 20) return;

        var size = 36F;
        using var graphics = wordLabel.CreateGraphics();
        Font font;
        while (true)
        {
            font = new Font("Segoe UI", size, FontStyle.Bold);
            var needed = TextRenderer.MeasureText(graphics, wordLabel.Text, font,
                new Size(Math.Max(1, wordLabel.Width - 12), int.MaxValue), TextFormatFlags.WordBreak);
            if (needed.Height <= wordLabel.Height - 4 || size <= 14) break;
            font.Dispose();
            size--;
        }

        if (Math.Abs(wordLabel.Font.Size - font.Size) < .1f)
        {
            font.Dispose();
            return;
        }

        var previous = wordLabel.Font;
        wordLabel.Font = font;
        previous.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
            if (speech is not null && Marshal.IsComObject(speech))
            {
                Marshal.FinalReleaseComObject(speech);
            }
        }
        base.Dispose(disposing);
    }
}
