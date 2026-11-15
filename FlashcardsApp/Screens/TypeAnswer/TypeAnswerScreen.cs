using System.Runtime.InteropServices;

namespace FlashcardsApp;

// Màn Gõ đáp án. Xem docs/04-gui.md.
public partial class TypeAnswerScreen : UserControl
{
    private readonly List<Flashcard> cards = new();
    private int currentIndex;
    private int correctCount;
    private int wrongCount;
    private bool answered;

    public TypeAnswerScreen()
    {
        InitializeComponent();
        Load += TypeAnswerScreen_Load;
    }

    private void TypeAnswerScreen_Load(object? sender, EventArgs e)
    {
        if (cards.Count > 0) return;

        var availableCards = FlashcardStore.GetAll();
        if (availableCards.Count == 0)
        {
            availableCards = FlashcardStore.Load(FlashcardStore.DefaultPath);
        }

        Start(availableCards);
    }

    // Bắt đầu luyện gõ với danh sách từ được đưa vào. Ai gọi: khi mở màn (tất cả từ), nút Luyện lại ở Sổ lỗi.
    public void Start(List<Flashcard> cardsToPractice)
    {
        cards.Clear();
        cards.AddRange(cardsToPractice.Where(card => !string.IsNullOrWhiteSpace(card.Word)
            && !string.IsNullOrWhiteSpace(card.Meaning)));

        if (cards.Count > 1)
        {
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(cards));
        }

        currentIndex = 0;
        correctCount = 0;
        wrongCount = 0;
        ShowCurrentCard();
    }

    // Bỏ khoảng trắng hai đầu, so không phân biệt hoa thường.
    // public static để Thử thách (#15) và Đua từ (#41) chấm giống hệt màn này.
    public static bool CheckAnswer(string typed, string answer)
    {
        return string.Equals(typed.Trim(), answer.Trim(), StringComparison.OrdinalIgnoreCase);
    }

    private void ShowCurrentCard()
    {
        answered = false;
        resultPanel.Visible = false;
        diffPanel.Visible = false;
        answerTextBox.Clear();
        hintLabel.Text = "";

        if (cards.Count == 0)
        {
            sourceLabel.Text = "Đang luyện · Tất cả";
            progressLabel.Text = "Chưa có từ để luyện";
            scoreLabel.Text = "Đúng 0 · Sai 0";
            progressBar.Maximum = 1;
            progressBar.Value = 0;
            meaningLabel.Text = "Hãy thêm từ trước khi bắt đầu luyện.";
            translationLabel.Text = "";
            SetAnswerControls(false);
            nextButton.Enabled = false;
            return;
        }

        var card = cards[currentIndex];
        sourceLabel.Text = "Đang luyện · Tất cả";
        progressLabel.Text = $"Từ {currentIndex + 1}/{cards.Count}";
        scoreLabel.Text = $"Đúng {correctCount} · Sai {wrongCount}";
        progressBar.Maximum = cards.Count;
        progressBar.Value = currentIndex + 1;
        meaningLabel.Text = card.Meaning;
        translationLabel.Text = card.ExampleTranslation;
        nextButton.Text = currentIndex == cards.Count - 1 ? "Xem kết quả" : "Từ tiếp theo";
        nextButton.Enabled = false;
        SetAnswerControls(true);
        answerTextBox.Focus();
    }

    private void CheckCurrentAnswer()
    {
        if (answered || cards.Count == 0) return;

        var typed = answerTextBox.Text.Trim();
        if (typed.Length == 0)
        {
            resultPanel.BackColor = StudyTheme.SoftWarning;
            resultTitleLabel.ForeColor = StudyTheme.Warning;
            resultTitleLabel.Text = "Bạn chưa nhập đáp án";
            resultDetailLabel.ForeColor = StudyTheme.Slate;
            resultDetailLabel.Text = "Hãy gõ từ tiếng Anh rồi thử lại.";
            resultPanel.Visible = true;
            answerTextBox.Focus();
            return;
        }

        var card = cards[currentIndex];
        var isCorrect = CheckAnswer(typed, card.Word);
        answered = true;

        try
        {
            StudyStore.SaveResult(card.Id, isCorrect ? 3 : 1, isCorrect ? null : typed);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this,
                "Không lưu được kết quả học. Hãy thử lại sau.\n\n" + ex.Message,
                "Gõ đáp án", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        if (isCorrect)
        {
            correctCount++;
            resultPanel.BackColor = StudyTheme.SoftTeal;
            resultTitleLabel.ForeColor = StudyTheme.Teal;
            resultTitleLabel.Text = "✓ Đúng";
            resultDetailLabel.ForeColor = StudyTheme.DarkTeal;
            resultDetailLabel.Text = $"{card.Word} · từ này đã được ghi nhận là Nhớ.";
        }
        else
        {
            wrongCount++;
            resultPanel.BackColor = StudyTheme.SoftWarning;
            resultTitleLabel.ForeColor = StudyTheme.Warning;
            resultTitleLabel.Text = "✕ Sai";
            resultDetailLabel.ForeColor = StudyTheme.Warning;
            resultDetailLabel.Text = $"Đáp án đúng: {card.Word} · đã ghi vào sổ lỗi.";
        }

        resultPanel.Visible = true;
        scoreLabel.Text = $"Đúng {correctCount} · Sai {wrongCount}";
        SetAnswerControls(false);
        nextButton.Enabled = true;
        nextButton.Focus();
    }

    private void ShowHint()
    {
        if (cards.Count == 0 || answered) return;

        var answer = cards[currentIndex].Word.Trim();
        hintLabel.Text = string.Join(" ", answer.Select((letter, index) =>
            index == 0 || char.IsWhiteSpace(letter) ? letter.ToString() : "_"));
        answerTextBox.Focus();
    }

    private void ShowNextCard()
    {
        if (!answered) return;

        if (currentIndex < cards.Count - 1)
        {
            currentIndex++;
            ShowCurrentCard();
            return;
        }

        meaningLabel.Text = "Hoàn thành lượt luyện!";
        translationLabel.Text = $"Bạn trả lời đúng {correctCount}/{cards.Count} từ và sai {wrongCount} từ.";
        progressLabel.Text = $"Đã luyện {cards.Count}/{cards.Count}";
        progressBar.Value = cards.Count;
        resultPanel.Visible = false;
        hintLabel.Text = "";
        answerTextBox.Clear();
        SetAnswerControls(false);
        nextButton.Text = "Luyện lại";
        nextButton.Enabled = true;
        answered = false;
    }

    private void SetAnswerControls(bool enabled)
    {
        answerTextBox.Enabled = enabled;
        checkButton.Enabled = enabled;
        hintButton.Enabled = enabled;
    }

    private void checkButton_Click(object? sender, EventArgs e) => CheckCurrentAnswer();

    private void hintButton_Click(object? sender, EventArgs e) => ShowHint();

    private void nextButton_Click(object? sender, EventArgs e)
    {
        if (!answered && cards.Count > 0 && currentIndex == cards.Count - 1
            && nextButton.Text == "Luyện lại")
        {
            Start(cards.ToList());
            return;
        }

        ShowNextCard();
    }

    private void answerTextBox_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;

        e.SuppressKeyPress = true;
        if (answered)
        {
            ShowNextCard();
        }
        else
        {
            CheckCurrentAnswer();
        }
    }

    // Issue #17 sẽ vẽ từng chữ vào khung này khi đáp án sai.
    private void ShowDiff(string typed, string answer)
    {
        diffPanel.Controls.Clear();
        diffPanel.Visible = false;
    }
}
