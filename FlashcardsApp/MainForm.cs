using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace FlashcardsApp;

public partial class MainForm : Form
{
    private readonly string dataPath;
    private readonly bool designerPreview;
    private List<Flashcard> cards = new();
    private List<Flashcard> reviewDeck = new();
    private readonly Dictionary<Flashcard, int> sessionRatings = new();
    private int currentIndex;
    private bool answerVisible;
    private bool dataLoaded;
    private bool autoReveal;
    private bool shortcutsEnabled = true;
    private string currentPage = "review";
    private Flashcard? notebookCard;
    private object? speech;
    private bool wordFitQueued;
    private List<Flashcard> listedCards = new();

    public MainForm() : this(FlashcardStore.DefaultPath) { }

    internal MainForm(string dataPath)
    {
        this.dataPath = dataPath;
        designerPreview = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        SuspendLayout();
        InitializeComponent();
        // Layout measurements are authored at 96 DPI, regardless of the Designer's monitor.
        if (!designerPreview) AutoScaleDimensions = new SizeF(96F, 96F);
        ResumeLayout(false);
        if (!designerPreview) InitializeRuntimeStyles();
        wordLabel.SizeChanged += (_, _) => QueueWordFit();
        Shown += (_, _) => QueueWordFit();
        cardsGrid.AccessibleName = "Danh sách từ vựng và tiến độ ôn tập";
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        if (designerPreview || DesignMode) return;
        try
        {
            cards = FlashcardStore.Load(dataPath);
            dataLoaded = true;
        }
        catch (Exception ex) when (IsStorageError(ex))
        {
            MessageBox.Show(this, $"Không đọc được dữ liệu. File cũ được giữ nguyên.\n{dataPath}\n\n{ex.Message}",
                "Không thể mở bộ thẻ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            savedLabel.Text = "Chưa đọc được dữ liệu";
            savedLabel.ForeColor = Color.Firebrick;
        }
        reviewDeck = cards.ToList();
        notebookCard = cards.FirstOrDefault(c => c.LastRating is 1 or 2);
        RenderCard();
        RenderSidebar();
        var area = Screen.FromControl(this).WorkingArea;
        Size = new Size(Math.Min(Width, area.Width - 24), Math.Min(Height, area.Height - 24));
        CenterToScreen();
    }

    private Flashcard? CurrentCard => reviewDeck.Count > 0 ? reviewDeck[currentIndex] : null;

    private void RenderCard()
    {
        var card = CurrentCard;
        var hasCard = card is not null;
        var reviewed = reviewDeck.Count(c => sessionRatings.ContainsKey(c));
        counterLabel.Text = hasCard ? $"Thẻ {currentIndex + 1} / {reviewDeck.Count}" : "Chưa có thẻ";
        remainingLabel.Text = $"Còn {reviewDeck.Count - reviewed} thẻ";
        progressValue = reviewDeck.Count == 0 ? 0 : reviewed * 100 / reviewDeck.Count;
        progressTrack.Invalidate();
        progressTrack.AccessibleDescription = $"Đã ôn {reviewed} trên {reviewDeck.Count} thẻ";
        categoryLabel.Text = string.IsNullOrWhiteSpace(card?.Category) ? "TỪ VỰNG" : card.Category;
        wordLabel.Text = card?.Word ?? "Bắt đầu bộ từ của bạn";
        pronunciationLabel.Text = card?.Pronunciation ?? "";
        meaningLabel.Text = card is null ? "Thêm từ mới trong Bộ thẻ của tôi."
            : answerVisible ? card.Meaning : "Bạn có nhớ nghĩa của từ này?";
        var meaningSize = answerVisible ? 23F : 14F;
        var meaningStyle = answerVisible ? FontStyle.Bold : FontStyle.Regular;
        if (meaningLabel.Font.Size != meaningSize || meaningLabel.Font.Style != meaningStyle)
        {
            var previousFont = meaningLabel.Font;
            meaningLabel.Font = new Font("Segoe UI", meaningSize, meaningStyle);
            previousFont.Dispose();
        }
        meaningLabel.ForeColor = answerVisible ? StudyTheme.Ink : StudyTheme.Muted;
        exampleLabel.Text = answerVisible ? card?.Example ?? "" : "";
        translationLabel.Text = answerVisible ? card?.ExampleTranslation ?? "" : "";
        flipButton.Text = answerVisible ? $"Ghi nhớ: {card?.Word}  ·  Ẩn nghĩa" : "Hiện nghĩa · Space";
        flipButton.AccessibleName = answerVisible ? "Ẩn nghĩa" : "Hiện nghĩa";
        flipButton.Enabled = speakButton.Enabled = hasCard;
        foreach (var button in new[] { againButton, hardButton, goodButton, easyButton })
            button.Enabled = hasCard && answerVisible && dataLoaded;
        ratingPromptLabel.Text = answerVisible ? "Bạn nhớ từ này ở mức nào?" : "Mở đáp án rồi tự đánh giá mức độ ghi nhớ.";
        previousButton.Enabled = nextButton.Enabled = reviewDeck.Count > 1;
        reviewedRowValue.Text = $"{sessionRatings.Count} thẻ";
        rememberedRowValue.Text = $"{sessionRatings.Count(p => p.Value >= 3)} thẻ";
        practiceRowValue.Text = $"{sessionRatings.Count(p => p.Value <= 2)} thẻ";
        QueueWordFit();
        exampleHighlight = card?.Word ?? "";
        exampleLabel.Invalidate();
        RenderNotebook();
    }

    private void QueueWordFit()
    {
        if (designerPreview || wordFitQueued || !IsHandleCreated || IsDisposed) return;
        wordFitQueued = true;
        BeginInvoke(new Action(() =>
        {
            wordFitQueued = false;
            if (!IsDisposed) FitWordLabel();
        }));
    }

    private void FitWordLabel()
    {
        if (wordLabel is null || wordLabel.Width < 50 || wordLabel.Height < 20) return;
        var size = 38F;
        var dpi = wordLabel.DeviceDpi / 96f;
        Font font;
        using var graphics = wordLabel.CreateGraphics();
        while (true)
        {
            font = new Font("Segoe UI", size, FontStyle.Bold);
            var needed = TextRenderer.MeasureText(graphics, wordLabel.Text, font,
                new Size(Math.Max(1, wordLabel.Width - (int)(12 * dpi)), int.MaxValue), TextFormatFlags.WordBreak);
            if ((needed.Height <= wordLabel.Height - (int)(4 * dpi) && needed.Width <= wordLabel.Width) || size <= 14) break;
            font.Dispose();
            size -= 1;
        }
        if (Math.Abs(wordLabel.Font.Size - font.Size) < .1f) { font.Dispose(); return; }
        var previous = wordLabel.Font;
        wordLabel.Font = font;
        previous.Dispose();
    }

    private void MainForm_Resize(object? sender, EventArgs e) => QueueWordFit();

    private void RenderNotebook()
    {
        var card = notebookCard ?? CurrentCard;
        var hasMistake = card?.LastRating is 1 or 2;
        mistakeTag.Text = hasMistake ? "CẦN LUYỆN THÊM" : "CÁCH DÙNG CẦN NHỚ";
        if (!string.IsNullOrWhiteSpace(card?.CommonMistake))
        {
            wrongLabel.Text = card.CommonMistake;
            wrongIcon = "wrong";
            wrongLabel.BackColor = Color.FromArgb(255, 231, 233);
            wrongLabel.ForeColor = Color.FromArgb(145, 27, 35);
        }
        else
        {
            wrongLabel.Text = hasMistake ? (card!.LastRating == 1 ? "Bạn đã chọn: Quên" : "Bạn đã chọn: Khó") : "Chưa có lỗi được ghi";
            wrongIcon = "info";
            wrongLabel.BackColor = StudyTheme.Canvas;
            wrongLabel.ForeColor = StudyTheme.Muted;
        }
        correctLabel.Text = card?.Word ?? "Thêm thẻ để bắt đầu";
        mistakeNote.Text = card is null ? "Các thẻ Quên hoặc Khó sẽ xuất hiện tại đây."
            : !string.IsNullOrWhiteSpace(card.MemoryNote) ? card.MemoryNote : card.Meaning;
        retryButton.Enabled = card is not null;
        wrongLabel.Invalidate();
        correctLabel.Invalidate();
    }

    private void RenderSidebar()
    {
        var mistakes = cards.Count(c => c.LastRating is 1 or 2);
        mistakesButton.Text = mistakes > 0 ? $"Sổ lỗi sai   {mistakes}" : "Sổ lỗi sai";
        foreach (var button in new[] { overviewButton, libraryButton, reviewButton, mistakesButton, statisticsButton })
        {
            var selected = string.Equals(button.Tag?.ToString(), currentPage, StringComparison.Ordinal);
            button.BackColor = selected ? StudyTheme.SoftTeal : Color.White;
            button.ForeColor = selected ? StudyTheme.Teal : StudyTheme.Ink;
            button.Invalidate();
        }
        addButton.Enabled = dataLoaded;
    }

    private void Navigation_Click(object? sender, EventArgs e)
    {
        if (sender is Button button) ShowPage(button.Tag?.ToString() ?? "review");
    }

    private void ShowPage(string page)
    {
        currentPage = page;
        reviewLayout.Visible = page == "review";
        catalogLayout.Visible = page != "review";
        if (page == "review")
        {
            reviewLayout.BringToFront();
            RenderCard();
        }
        else
        {
            catalogLayout.BringToFront();
            RenderCatalog();
        }
        RenderSidebar();
    }

    private void RenderCatalog()
    {
        catalogTitle.Text = currentPage switch
        {
            "overview" => "Tổng quan", "mistakes" => "Sổ lỗi sai", "statistics" => "Thống kê", _ => "Bộ thẻ của tôi"
        };
        catalogSubtitle.Text = currentPage switch
        {
            "overview" => "Mỗi ngày một chút. Tiến bộ từ những lần ôn đều đặn.",
            "mistakes" => "Những thẻ gần nhất bạn chọn Quên hoặc Khó.",
            "statistics" => "Tiến độ thực tế của bộ thẻ đang lưu trên máy.",
            _ => "Nhấp đúp vào một thẻ để ôn. Thêm từ mới bằng nút bên dưới."
        };
        totalMetric.Text = $"{cards.Count}\nTổng số thẻ";
        learnedMetric.Text = $"{cards.Count(c => c.IsLearned)}\nĐã nhớ";
        practiceMetric.Text = $"{cards.Count(c => c.LastRating is 1 or 2)}\nCần luyện thêm";
        listedCards = currentPage == "mistakes" ? cards.Where(c => c.LastRating is 1 or 2).ToList() : cards.ToList();
        cardsGrid.Columns.Clear();
        cardsGrid.Columns.Add("word", "Từ / cụm từ");
        cardsGrid.Columns.Add("meaning", "Nghĩa");
        cardsGrid.Columns.Add("status", "Ghi nhớ");
        if (currentPage == "statistics") cardsGrid.Columns.Add("due", "Lần ôn tiếp");
        cardsGrid.Columns[0].FillWeight = 110;
        cardsGrid.Columns[1].FillWeight = 130;
        cardsGrid.Columns[2].FillWeight = 75;
        foreach (var card in listedCards)
        {
            var values = new List<string> { card.Word, card.Meaning, RatingName(card) };
            if (currentPage == "statistics") values.Add(card.NextReviewAt?.ToLocalTime().ToString("dd/MM HH:mm") ?? "Chưa lên lịch");
            var row = cardsGrid.Rows.Add(values.ToArray());
            cardsGrid.Rows[row].Tag = card;
        }
        if (listedCards.Count == 0)
            catalogSubtitle.Text = currentPage == "mistakes" ? "Chưa có thẻ cần luyện thêm. Tiếp tục ôn để giữ vững kiến thức." : "Bộ thẻ đang trống. Hãy thêm từ đầu tiên.";
        startReviewButton.Enabled = listedCards.Count > 0;
    }

    private static string RatingName(Flashcard card) => card.LastRating switch
    {
        1 => "Quên", 2 => "Khó", 3 => "Nhớ", 4 => "Dễ", _ => card.IsLearned ? "Đã nhớ" : "Chưa ôn"
    };

    private void FlipButton_Click(object? sender, EventArgs e)
    {
        if (CurrentCard is null) return;
        answerVisible = !answerVisible;
        RenderCard();
    }
    private void PreviousButton_Click(object? sender, EventArgs e) => MoveCard(-1);
    private void NextButton_Click(object? sender, EventArgs e) => MoveCard(1);
    private void MoveCard(int direction)
    {
        if (reviewDeck.Count == 0) return;
        currentIndex = (currentIndex + direction + reviewDeck.Count) % reviewDeck.Count;
        answerVisible = autoReveal;
        RenderCard();
    }

    private void RatingButton_Click(object? sender, EventArgs e)
    {
        if (sender is Button { Tag: int rating }) RateCard(rating);
    }

    private void RateCard(int rating)
    {
        var card = CurrentCard;
        if (card is null || !answerVisible || !dataLoaded || rating is < 1 or > 4) return;
        var previous = (card.LastRating, card.IsLearned, card.NextReviewAt);
        card.LastRating = rating;
        card.IsLearned = rating >= 3;
        // shortcut: fixed intervals; replace with an adaptive scheduler when adding spaced repetition.
        card.NextReviewAt = DateTimeOffset.Now + (rating switch
        {
            1 => TimeSpan.FromMinutes(1), 2 => TimeSpan.FromMinutes(10),
            3 => TimeSpan.FromDays(1), _ => TimeSpan.FromDays(4)
        });
        if (!TrySave())
        {
            (card.LastRating, card.IsLearned, card.NextReviewAt) = previous;
            return;
        }
        sessionRatings[card] = rating;
        if (rating <= 2) notebookCard = card;
        else if (notebookCard == card) notebookCard = cards.FirstOrDefault(c => c.LastRating is 1 or 2);
        RenderSidebar();
        if (reviewDeck.All(c => sessionRatings.ContainsKey(c)))
        {
            RenderCard();
            ShowPage("overview");
            catalogSubtitle.Text = $"Hoàn thành phiên ôn: {sessionRatings.Count} thẻ. Chọn một thẻ để tiếp tục luyện tập.";
        }
        else MoveCard(1);
    }

    private void StartSession(List<Flashcard> deck, Flashcard? first = null)
    {
        reviewDeck = deck;
        sessionRatings.Clear();
        currentIndex = first is null ? 0 : Math.Max(0, reviewDeck.IndexOf(first));
        answerVisible = autoReveal;
        ShowPage("review");
    }

    private void StartReviewButton_Click(object? sender, EventArgs e)
    {
        if (listedCards.Count == 0) return;
        var selected = cardsGrid.CurrentRow?.Tag as Flashcard ?? listedCards[0];
        StartSession(listedCards.ToList(), selected);
    }
    private void CardsGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) StartReviewButton_Click(sender, EventArgs.Empty);
    }
    private void RetryButton_Click(object? sender, EventArgs e)
    {
        var card = notebookCard ?? CurrentCard;
        if (card is not null) StartSession(new List<Flashcard> { card });
    }
    private void FinishButton_Click(object? sender, EventArgs e) => ShowPage("overview");

    private void AddButton_Click(object? sender, EventArgs e)
    {
        if (!dataLoaded) return;
        using var dialog = new AddCardDialog(cards);
        while (dialog.ShowDialog(this) == DialogResult.OK)
        {
            var card = dialog.Card!;
            cards.Add(card);
            if (!TrySave()) { cards.Remove(card); continue; }
            RenderCatalog();
            RenderSidebar();
            if (reviewDeck.Count == 0) { reviewDeck = cards.ToList(); currentIndex = 0; }
            RenderCard();
            break;
        }
    }

    private void SettingsButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new Form
        {
            Text = "Cài đặt phiên học", AutoScaleDimensions = new SizeF(96F, 96F),
            AutoScaleMode = AutoScaleMode.Dpi, Font = new Font("Segoe UI", 10F), ClientSize = new Size(520, 294),
            BackColor = Color.White, StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false
        };
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(24), ColumnCount = 1, RowCount = 5 };
        foreach (var height in new[] { 44, 44, 80, 28, 48 }) layout.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
        var reveal = new CheckBox { Text = "Tự hiện nghĩa khi chuyển thẻ", Checked = autoReveal, Dock = DockStyle.Fill };
        var shortcuts = new CheckBox { Text = "Bật phím tắt Space và 1–4", Checked = shortcutsEnabled, Dock = DockStyle.Fill };
        layout.Controls.Add(reveal, 0, 0); layout.Controls.Add(shortcuts, 0, 1);
        layout.Controls.Add(new Label { Text = $"File dữ liệu:\n{dataPath}", Dock = DockStyle.Fill, ForeColor = StudyTheme.Muted }, 0, 2);
        layout.Controls.Add(new Label { Text = "Tùy chọn áp dụng cho lần mở app hiện tại.", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F), ForeColor = StudyTheme.Muted }, 0, 3);
        var apply = new StudyButton { Text = "Áp dụng", BackColor = StudyTheme.Teal, ForeColor = Color.White, Dock = DockStyle.Fill, DialogResult = DialogResult.OK };
        layout.Controls.Add(apply, 0, 4); dialog.Controls.Add(layout); dialog.AcceptButton = apply;
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        autoReveal = reveal.Checked;
        shortcutsEnabled = shortcuts.Checked;
        answerVisible = autoReveal;
        RenderCard();
    }

    private void SpeakButton_Click(object? sender, EventArgs e)
    {
        if (CurrentCard is null) return;
        try
        {
            speech ??= Activator.CreateInstance(Type.GetTypeFromProgID("SAPI.SpVoice")
                ?? throw new InvalidOperationException("Windows chưa có giọng đọc khả dụng."));
            dynamic voice = speech!;
            // Prefer an installed English voice; SAPI works offline.
            foreach (var item in voice.GetVoices())
            {
                if (((string)item.GetDescription()).Contains("English", StringComparison.OrdinalIgnoreCase))
                { voice.Voice = item; break; }
            }
            voice.Speak(CurrentCard.Word, 3);
        }
        catch (Exception ex) when (ex is COMException or InvalidOperationException or System.Reflection.TargetInvocationException or Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
        {
            MessageBox.Show(this, "Không phát được âm thanh. Kiểm tra giọng đọc tiếng Anh trong cài đặt Windows.\n\n" + ex.Message,
                "Phát âm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (shortcutsEnabled && currentPage == "review")
        {
            if (keyData == Keys.Space) { FlipButton_Click(this, EventArgs.Empty); return true; }
            var rating = keyData switch { Keys.D1 or Keys.NumPad1 => 1, Keys.D2 or Keys.NumPad2 => 2, Keys.D3 or Keys.NumPad3 => 3, Keys.D4 or Keys.NumPad4 => 4, _ => 0 };
            if (rating > 0) { RateCard(rating); return true; }
            if (keyData == Keys.Left) { MoveCard(-1); return true; }
            if (keyData == Keys.Right) { MoveCard(1); return true; }
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (speech is not null && Marshal.IsComObject(speech)) Marshal.FinalReleaseComObject(speech);
        base.OnFormClosed(e);
    }

    private bool TrySave()
    {
        if (!dataLoaded) return false;
        try
        {
            FlashcardStore.Save(dataPath, cards);
            savedLabel.Text = "Đã lưu trên máy";
            savedLabel.ForeColor = StudyTheme.Teal;
            return true;
        }
        catch (Exception ex) when (IsStorageError(ex))
        {
            savedLabel.Text = "Chưa lưu thay đổi";
            savedLabel.ForeColor = Color.Firebrick;
            MessageBox.Show(this, $"Không lưu được thay đổi. Vui lòng thử lại.\n\n{ex.Message}",
                "Lỗi lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
    private static bool IsStorageError(Exception ex) =>
        ex is IOException or UnauthorizedAccessException or JsonException or System.Security.SecurityException;
}
