namespace FlashcardsApp;

// Hộp thoại thêm một từ mới. Giao diện kéo thả trong Designer (nhấp đúp AddCardDialog.cs để mở).
// Cách dùng (docs/02-quy-uoc-code.md mục 3):
//     using var dialog = new AddCardDialog(cards);
//     if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Card != null) { ... lưu dialog.Card ... }
// Trong Designer đã đặt sẵn: phím Enter = nút Thêm thẻ (AcceptButton), phím Esc = nút Hủy (CancelButton).
public partial class AddCardDialog : Form
{
    // Các từ đã có, để báo khi thêm trùng
    private readonly IReadOnlyList<Flashcard> existingCards;

    // Từ người dùng vừa nhập. Chỉ có giá trị khi hộp thoại đóng bằng nút Thêm thẻ.
    public Flashcard? Card { get; private set; }

    public AddCardDialog(IReadOnlyList<Flashcard> existingCards)
    {
        InitializeComponent();
        this.existingCards = existingCards;
    }

    private void saveButton_Click(object? sender, EventArgs e)
    {
        var word = wordTextBox.Text.Trim();
        var meaning = meaningTextBox.Text.Trim();

        // Kiểm tra 1: phải có từ và nghĩa
        if (word == "" || meaning == "")
        {
            errorLabel.Text = "Vui lòng nhập từ tiếng Anh và nghĩa tiếng Việt.";
            if (word == "")
                wordTextBox.Focus();
            else
                meaningTextBox.Focus();
            return;
        }

        // Kiểm tra 2: từ chưa có trong bộ thẻ (không phân biệt hoa thường)
        var isDuplicate = existingCards.Any(card => string.Equals(card.Word, word, StringComparison.OrdinalIgnoreCase));
        if (isDuplicate)
        {
            errorLabel.Text = "Từ này đã có trong bộ thẻ.";
            wordTextBox.Focus();
            return;
        }

        Card = new Flashcard
        {
            Word = word,
            Meaning = meaning,
            Pronunciation = pronunciationTextBox.Text.Trim(),
            Example = exampleTextBox.Text.Trim(),
            ExampleTranslation = translationTextBox.Text.Trim(),
            MemoryNote = memoryNoteTextBox.Text.Trim(),
            Category = word.Contains(' ') ? "CỤM TỪ" : "TỪ VỰNG" // có dấu cách là cụm từ
        };

        // Đặt DialogResult thì hộp thoại tự đóng, ShowDialog() trả về OK
        DialogResult = DialogResult.OK;
    }
}
