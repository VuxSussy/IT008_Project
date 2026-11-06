namespace FlashcardsApp;

public sealed class AddCardDialog : Form
{
    private readonly IReadOnlyList<Flashcard> existing;
    private readonly TextBox word = new() { MaxLength = 100 };
    private readonly TextBox meaning = new() { MaxLength = 300 };
    private readonly TextBox pronunciation = new() { MaxLength = 150 };
    private readonly TextBox example = new() { MaxLength = 1000 };
    private readonly TextBox translation = new() { MaxLength = 1000 };
    private readonly TextBox note = new() { MaxLength = 300 };
    private readonly Label error = new() { ForeColor = Color.Firebrick, Dock = DockStyle.Fill };
    public Flashcard? Card { get; private set; }

    public AddCardDialog(IReadOnlyList<Flashcard> existing)
    {
        this.existing = existing;
        Text = "Thêm thẻ mới";
        Font = new Font("Segoe UI", 10F);
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(510, 620);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = MinimizeBox = false;
        BackColor = Color.White;
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(24), ColumnCount = 1, RowCount = 14 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        var inputs = new[] { ("Từ / cụm từ tiếng Anh *", word), ("Nghĩa tiếng Việt *", meaning),
            ("Phiên âm", pronunciation), ("Câu ví dụ", example), ("Bản dịch câu ví dụ", translation), ("Ghi chú ghi nhớ", note) };
        for (var i = 0; i < inputs.Length; i++)
        {
            var (caption, input) = inputs[i];
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, i is 3 or 4 ? 66 : 40));
            layout.Controls.Add(new Label { Text = caption, Dock = DockStyle.Fill, TextAlign = ContentAlignment.BottomLeft }, 0, i * 2);
            input.Dock = DockStyle.Fill;
            input.AccessibleName = caption;
            input.Name = new[] { "wordTextBox", "meaningTextBox", "pronunciationTextBox", "exampleTextBox", "translationTextBox", "noteTextBox" }[i];
            input.Margin = new Padding(0, 4, 0, 4);
            if (i is 3 or 4) { input.Multiline = true; input.ScrollBars = ScrollBars.Vertical; }
            layout.Controls.Add(input, 0, i * 2 + 1);
        }
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
        layout.Controls.Add(error, 0, 12);
        var buttons = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
        buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        var cancel = new StudyButton { Text = "Hủy", DialogResult = DialogResult.Cancel, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 8, 0) };
        var save = new StudyButton { Text = "Thêm thẻ", BackColor = StudyTheme.Teal, ForeColor = Color.White, Dock = DockStyle.Fill };
        save.Click += (_, _) => SaveCard();
        buttons.Controls.Add(cancel, 0, 0); buttons.Controls.Add(save, 1, 0);
        layout.Controls.Add(buttons, 0, 13);
        Controls.Add(layout);
        AcceptButton = save;
        CancelButton = cancel;
    }

    private void SaveCard()
    {
        if (string.IsNullOrWhiteSpace(word.Text) || string.IsNullOrWhiteSpace(meaning.Text))
        {
            error.Text = "Vui lòng nhập từ tiếng Anh và nghĩa tiếng Việt.";
            (string.IsNullOrWhiteSpace(word.Text) ? word : meaning).Focus();
            return;
        }
        if (existing.Any(c => string.Equals(c.Word, word.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            error.Text = "Từ này đã có trong bộ thẻ.";
            word.Focus();
            return;
        }
        Card = new Flashcard { Word = word.Text.Trim(), Meaning = meaning.Text.Trim(),
            Pronunciation = pronunciation.Text.Trim(), Example = example.Text.Trim(),
            ExampleTranslation = translation.Text.Trim(), MemoryNote = note.Text.Trim(),
            Category = word.Text.Trim().Contains(' ') ? "CỤM TỪ" : "TỪ VỰNG" };
        DialogResult = DialogResult.OK;
    }
}
