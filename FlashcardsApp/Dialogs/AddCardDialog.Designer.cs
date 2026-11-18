namespace FlashcardsApp;

partial class AddCardDialog
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        fieldsLayout = new TableLayoutPanel();
        wordCaptionLabel = new Label();
        wordTextBox = new TextBox();
        meaningCaptionLabel = new Label();
        meaningTextBox = new TextBox();
        pronunciationCaptionLabel = new Label();
        pronunciationTextBox = new TextBox();
        exampleCaptionLabel = new Label();
        exampleTextBox = new TextBox();
        translationCaptionLabel = new Label();
        translationTextBox = new TextBox();
        memoryNoteCaptionLabel = new Label();
        memoryNoteTextBox = new TextBox();
        errorLabel = new Label();
        buttonsLayout = new TableLayoutPanel();
        cancelButton = new StudyButton();
        saveButton = new StudyButton();
        fieldsLayout.SuspendLayout();
        buttonsLayout.SuspendLayout();
        SuspendLayout();
        // 
        // fieldsLayout
        // 
        fieldsLayout.ColumnCount = 1;
        fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        fieldsLayout.Controls.Add(wordCaptionLabel, 0, 0);
        fieldsLayout.Controls.Add(wordTextBox, 0, 1);
        fieldsLayout.Controls.Add(meaningCaptionLabel, 0, 2);
        fieldsLayout.Controls.Add(meaningTextBox, 0, 3);
        fieldsLayout.Controls.Add(pronunciationCaptionLabel, 0, 4);
        fieldsLayout.Controls.Add(pronunciationTextBox, 0, 5);
        fieldsLayout.Controls.Add(exampleCaptionLabel, 0, 6);
        fieldsLayout.Controls.Add(exampleTextBox, 0, 7);
        fieldsLayout.Controls.Add(translationCaptionLabel, 0, 8);
        fieldsLayout.Controls.Add(translationTextBox, 0, 9);
        fieldsLayout.Controls.Add(memoryNoteCaptionLabel, 0, 10);
        fieldsLayout.Controls.Add(memoryNoteTextBox, 0, 11);
        fieldsLayout.Controls.Add(errorLabel, 0, 12);
        fieldsLayout.Controls.Add(buttonsLayout, 0, 13);
        fieldsLayout.Dock = DockStyle.Fill;
        fieldsLayout.Location = new Point(0, 0);
        fieldsLayout.Name = "fieldsLayout";
        fieldsLayout.Padding = new Padding(24);
        fieldsLayout.RowCount = 14;
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        fieldsLayout.Size = new Size(510, 620);
        fieldsLayout.TabIndex = 0;
        // 
        // wordCaptionLabel
        // 
        wordCaptionLabel.Dock = DockStyle.Fill;
        wordCaptionLabel.Location = new Point(27, 24);
        wordCaptionLabel.Name = "wordCaptionLabel";
        wordCaptionLabel.Size = new Size(456, 26);
        wordCaptionLabel.TabIndex = 0;
        wordCaptionLabel.Text = "Từ / cụm từ tiếng Anh *";
        wordCaptionLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // wordTextBox
        // 
        wordTextBox.AccessibleName = "Từ / cụm từ tiếng Anh";
        wordTextBox.Dock = DockStyle.Fill;
        wordTextBox.Location = new Point(24, 54);
        wordTextBox.Margin = new Padding(0, 4, 0, 4);
        wordTextBox.MaxLength = 200;
        wordTextBox.Name = "wordTextBox";
        wordTextBox.Size = new Size(462, 25);
        wordTextBox.TabIndex = 1;
        // 
        // meaningCaptionLabel
        // 
        meaningCaptionLabel.Dock = DockStyle.Fill;
        meaningCaptionLabel.Location = new Point(27, 90);
        meaningCaptionLabel.Name = "meaningCaptionLabel";
        meaningCaptionLabel.Size = new Size(456, 26);
        meaningCaptionLabel.TabIndex = 2;
        meaningCaptionLabel.Text = "Nghĩa tiếng Việt *";
        meaningCaptionLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // meaningTextBox
        // 
        meaningTextBox.AccessibleName = "Nghĩa tiếng Việt";
        meaningTextBox.Dock = DockStyle.Fill;
        meaningTextBox.Location = new Point(24, 120);
        meaningTextBox.Margin = new Padding(0, 4, 0, 4);
        meaningTextBox.MaxLength = 255;
        meaningTextBox.Name = "meaningTextBox";
        meaningTextBox.Size = new Size(462, 25);
        meaningTextBox.TabIndex = 3;
        // 
        // pronunciationCaptionLabel
        // 
        pronunciationCaptionLabel.Dock = DockStyle.Fill;
        pronunciationCaptionLabel.Location = new Point(27, 156);
        pronunciationCaptionLabel.Name = "pronunciationCaptionLabel";
        pronunciationCaptionLabel.Size = new Size(456, 26);
        pronunciationCaptionLabel.TabIndex = 4;
        pronunciationCaptionLabel.Text = "Phiên âm";
        pronunciationCaptionLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // pronunciationTextBox
        // 
        pronunciationTextBox.AccessibleName = "Phiên âm";
        pronunciationTextBox.Dock = DockStyle.Fill;
        pronunciationTextBox.Location = new Point(24, 186);
        pronunciationTextBox.Margin = new Padding(0, 4, 0, 4);
        pronunciationTextBox.MaxLength = 100;
        pronunciationTextBox.Name = "pronunciationTextBox";
        pronunciationTextBox.Size = new Size(462, 25);
        pronunciationTextBox.TabIndex = 5;
        // 
        // exampleCaptionLabel
        // 
        exampleCaptionLabel.Dock = DockStyle.Fill;
        exampleCaptionLabel.Location = new Point(27, 222);
        exampleCaptionLabel.Name = "exampleCaptionLabel";
        exampleCaptionLabel.Size = new Size(456, 26);
        exampleCaptionLabel.TabIndex = 6;
        exampleCaptionLabel.Text = "Câu ví dụ";
        exampleCaptionLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // exampleTextBox
        // 
        exampleTextBox.AccessibleName = "Câu ví dụ";
        exampleTextBox.Dock = DockStyle.Fill;
        exampleTextBox.Location = new Point(24, 252);
        exampleTextBox.Margin = new Padding(0, 4, 0, 4);
        exampleTextBox.MaxLength = 500;
        exampleTextBox.Multiline = true;
        exampleTextBox.Name = "exampleTextBox";
        exampleTextBox.ScrollBars = ScrollBars.Vertical;
        exampleTextBox.Size = new Size(462, 58);
        exampleTextBox.TabIndex = 7;
        // 
        // translationCaptionLabel
        // 
        translationCaptionLabel.Dock = DockStyle.Fill;
        translationCaptionLabel.Location = new Point(27, 314);
        translationCaptionLabel.Name = "translationCaptionLabel";
        translationCaptionLabel.Size = new Size(456, 26);
        translationCaptionLabel.TabIndex = 8;
        translationCaptionLabel.Text = "Bản dịch câu ví dụ";
        translationCaptionLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // translationTextBox
        // 
        translationTextBox.AccessibleName = "Bản dịch câu ví dụ";
        translationTextBox.Dock = DockStyle.Fill;
        translationTextBox.Location = new Point(24, 344);
        translationTextBox.Margin = new Padding(0, 4, 0, 4);
        translationTextBox.MaxLength = 500;
        translationTextBox.Multiline = true;
        translationTextBox.Name = "translationTextBox";
        translationTextBox.ScrollBars = ScrollBars.Vertical;
        translationTextBox.Size = new Size(462, 58);
        translationTextBox.TabIndex = 9;
        // 
        // memoryNoteCaptionLabel
        // 
        memoryNoteCaptionLabel.Dock = DockStyle.Fill;
        memoryNoteCaptionLabel.Location = new Point(27, 406);
        memoryNoteCaptionLabel.Name = "memoryNoteCaptionLabel";
        memoryNoteCaptionLabel.Size = new Size(456, 26);
        memoryNoteCaptionLabel.TabIndex = 10;
        memoryNoteCaptionLabel.Text = "Ghi chú ghi nhớ";
        memoryNoteCaptionLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // memoryNoteTextBox
        // 
        memoryNoteTextBox.AccessibleName = "Ghi chú ghi nhớ";
        memoryNoteTextBox.Dock = DockStyle.Fill;
        memoryNoteTextBox.Location = new Point(24, 436);
        memoryNoteTextBox.Margin = new Padding(0, 4, 0, 4);
        memoryNoteTextBox.MaxLength = 500;
        memoryNoteTextBox.Name = "memoryNoteTextBox";
        memoryNoteTextBox.Size = new Size(462, 25);
        memoryNoteTextBox.TabIndex = 11;
        // 
        // errorLabel
        // 
        errorLabel.Dock = DockStyle.Fill;
        errorLabel.ForeColor = Color.Firebrick;
        errorLabel.Location = new Point(27, 472);
        errorLabel.Name = "errorLabel";
        errorLabel.Size = new Size(456, 76);
        errorLabel.TabIndex = 12;
        // 
        // buttonsLayout
        // 
        buttonsLayout.ColumnCount = 2;
        buttonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        buttonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        buttonsLayout.Controls.Add(cancelButton, 0, 0);
        buttonsLayout.Controls.Add(saveButton, 1, 0);
        buttonsLayout.Dock = DockStyle.Fill;
        buttonsLayout.Location = new Point(27, 551);
        buttonsLayout.Name = "buttonsLayout";
        buttonsLayout.RowCount = 1;
        buttonsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        buttonsLayout.Size = new Size(456, 42);
        buttonsLayout.TabIndex = 13;
        // 
        // cancelButton
        // 
        cancelButton.BackColor = Color.White;
        cancelButton.DialogResult = DialogResult.Cancel;
        cancelButton.Dock = DockStyle.Fill;
        cancelButton.FlatStyle = FlatStyle.Flat;
        cancelButton.Font = new Font("Segoe UI", 11F);
        cancelButton.ForeColor = Color.FromArgb(15, 23, 42);
        cancelButton.Location = new Point(0, 0);
        cancelButton.Margin = new Padding(0, 0, 8, 0);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(220, 42);
        cancelButton.TabIndex = 0;
        cancelButton.Text = "Hủy";
        cancelButton.UseVisualStyleBackColor = false;
        // 
        // saveButton
        // 
        saveButton.BackColor = Color.FromArgb(15, 118, 110);
        saveButton.Dock = DockStyle.Fill;
        saveButton.FlatStyle = FlatStyle.Flat;
        saveButton.Font = new Font("Segoe UI", 11F);
        saveButton.ForeColor = Color.White;
        saveButton.Location = new Point(231, 3);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(222, 36);
        saveButton.TabIndex = 1;
        saveButton.Text = "Thêm thẻ";
        saveButton.UseVisualStyleBackColor = false;
        saveButton.Click += saveButton_Click;
        // 
        // AddCardDialog
        // 
        AcceptButton = saveButton;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        CancelButton = cancelButton;
        ClientSize = new Size(510, 620);
        Controls.Add(fieldsLayout);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddCardDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Thêm thẻ mới";
        fieldsLayout.ResumeLayout(false);
        fieldsLayout.PerformLayout();
        buttonsLayout.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel fieldsLayout;
    private Label wordCaptionLabel;
    private TextBox wordTextBox;
    private Label meaningCaptionLabel;
    private TextBox meaningTextBox;
    private Label pronunciationCaptionLabel;
    private TextBox pronunciationTextBox;
    private Label exampleCaptionLabel;
    private TextBox exampleTextBox;
    private Label translationCaptionLabel;
    private TextBox translationTextBox;
    private Label memoryNoteCaptionLabel;
    private TextBox memoryNoteTextBox;
    private Label errorLabel;
    private TableLayoutPanel buttonsLayout;
    private StudyButton cancelButton;
    private StudyButton saveButton;
}
