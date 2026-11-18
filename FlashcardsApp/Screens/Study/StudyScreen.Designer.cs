namespace FlashcardsApp;

partial class StudyScreen
{
    private System.ComponentModel.IContainer components = null;

    #region Component Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        topPanel = new Panel();
        finishButton = new StudyButton();
        remainingLabel = new Label();
        progressBar = new ProgressBar();
        roundLabel = new Label();
        folderComboBox = new ComboBox();
        studyingLabel = new Label();
        contentLayout = new TableLayoutPanel();
        studyArea = new TableLayoutPanel();
        cardPanel = new CardPanel();
        cardLayout = new TableLayoutPanel();
        categoryLabel = new Label();
        wordRow = new TableLayoutPanel();
        wordLabel = new Label();
        speakButton = new StudyButton();
        pronunciationLabel = new Label();
        answerPanel = new Panel();
        answerLayout = new TableLayoutPanel();
        meaningLabel = new Label();
        exampleLabel = new Label();
        translationLabel = new Label();
        memoryLabel = new Label();
        actionLayout = new TableLayoutPanel();
        flipButton = new StudyButton();
        ratingPromptLabel = new Label();
        ratingLayout = new TableLayoutPanel();
        againButton = new StudyButton();
        hardButton = new StudyButton();
        goodButton = new StudyButton();
        easyButton = new StudyButton();
        shortcutLabel = new Label();
        sideLayout = new TableLayoutPanel();
        sessionPanel = new CardPanel();
        sessionLayout = new TableLayoutPanel();
        sessionTitleLabel = new Label();
        reviewedNameLabel = new Label();
        reviewedValueLabel = new Label();
        rememberedNameLabel = new Label();
        rememberedValueLabel = new Label();
        mistakeNameLabel = new Label();
        mistakeValueLabel = new Label();
        tipPanel = new CardPanel();
        tipLabel = new Label();
        speakToolTip = new ToolTip(components);
        topPanel.SuspendLayout();
        contentLayout.SuspendLayout();
        studyArea.SuspendLayout();
        cardPanel.SuspendLayout();
        cardLayout.SuspendLayout();
        wordRow.SuspendLayout();
        answerPanel.SuspendLayout();
        answerLayout.SuspendLayout();
        actionLayout.SuspendLayout();
        ratingLayout.SuspendLayout();
        sideLayout.SuspendLayout();
        sessionPanel.SuspendLayout();
        sessionLayout.SuspendLayout();
        tipPanel.SuspendLayout();
        SuspendLayout();

        topPanel.BackColor = Color.White;
        topPanel.Controls.Add(finishButton);
        topPanel.Controls.Add(remainingLabel);
        topPanel.Controls.Add(progressBar);
        topPanel.Controls.Add(roundLabel);
        topPanel.Controls.Add(folderComboBox);
        topPanel.Controls.Add(studyingLabel);
        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 74;
        topPanel.Padding = new Padding(28, 10, 28, 10);

        finishButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        finishButton.Location = new Point(776, 14);
        finishButton.Name = "finishButton";
        finishButton.Size = new Size(96, 44);
        finishButton.Text = "Kết thúc";
        finishButton.Click += finishButton_Click;

        remainingLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        remainingLabel.ForeColor = StudyTheme.Slate;
        remainingLabel.Location = new Point(600, 11);
        remainingLabel.Name = "remainingLabel";
        remainingLabel.Size = new Size(158, 20);
        remainingLabel.TextAlign = ContentAlignment.MiddleRight;

        progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        progressBar.Location = new Point(225, 39);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(533, 8);
        progressBar.Style = ProgressBarStyle.Continuous;

        roundLabel.AutoSize = true;
        roundLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        roundLabel.Location = new Point(225, 12);
        roundLabel.Name = "roundLabel";

        folderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        folderComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        folderComboBox.Location = new Point(28, 32);
        folderComboBox.Name = "folderComboBox";
        folderComboBox.Size = new Size(176, 25);

        studyingLabel.AutoSize = true;
        studyingLabel.ForeColor = StudyTheme.Muted;
        studyingLabel.Location = new Point(28, 10);
        studyingLabel.Name = "studyingLabel";
        studyingLabel.Text = "Đang học";

        contentLayout.BackColor = StudyTheme.Canvas;
        contentLayout.ColumnCount = 2;
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
        contentLayout.Controls.Add(studyArea, 0, 0);
        contentLayout.Controls.Add(sideLayout, 1, 0);
        contentLayout.Dock = DockStyle.Fill;
        contentLayout.Padding = new Padding(28, 24, 28, 18);

        studyArea.ColumnCount = 1;
        studyArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        studyArea.Controls.Add(cardPanel, 0, 0);
        studyArea.Controls.Add(actionLayout, 0, 1);
        studyArea.Controls.Add(ratingLayout, 0, 2);
        studyArea.Controls.Add(shortcutLabel, 0, 3);
        studyArea.Dock = DockStyle.Fill;
        studyArea.Margin = new Padding(0, 0, 20, 0);
        studyArea.RowCount = 4;
        studyArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        studyArea.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
        studyArea.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
        studyArea.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));

        cardPanel.BackColor = Color.White;
        cardPanel.Controls.Add(cardLayout);
        cardPanel.Dock = DockStyle.Fill;
        cardPanel.Margin = new Padding(0);
        cardPanel.Padding = new Padding(42, 26, 42, 26);

        cardLayout.ColumnCount = 1;
        cardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        cardLayout.Controls.Add(categoryLabel, 0, 0);
        cardLayout.Controls.Add(wordRow, 0, 1);
        cardLayout.Controls.Add(pronunciationLabel, 0, 2);
        cardLayout.Controls.Add(answerPanel, 0, 3);
        cardLayout.Dock = DockStyle.Fill;
        cardLayout.RowCount = 4;
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        categoryLabel.Anchor = AnchorStyles.None;
        categoryLabel.AutoSize = true;
        categoryLabel.BackColor = StudyTheme.SoftTeal;
        categoryLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        categoryLabel.ForeColor = StudyTheme.DarkTeal;
        categoryLabel.Padding = new Padding(10, 4, 10, 4);
        categoryLabel.Text = "TỪ VỰNG";

        wordRow.ColumnCount = 2;
        wordRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        wordRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        wordRow.Controls.Add(wordLabel, 0, 0);
        wordRow.Controls.Add(speakButton, 1, 0);
        wordRow.Dock = DockStyle.Fill;

        wordLabel.Dock = DockStyle.Fill;
        wordLabel.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
        wordLabel.ForeColor = StudyTheme.Ink;
        wordLabel.Text = "make a decision";
        wordLabel.TextAlign = ContentAlignment.MiddleCenter;

        speakButton.Anchor = AnchorStyles.Left;
        speakButton.CornerRadius = 20;
        speakButton.IconName = "sound";
        speakButton.Location = new Point(3, 25);
        speakButton.Name = "speakButton";
        speakButton.Size = new Size(40, 40);
        speakButton.Text = "";
        speakButton.Click += speakButton_Click;

        pronunciationLabel.Dock = DockStyle.Fill;
        pronunciationLabel.Font = new Font("Segoe UI", 12F);
        pronunciationLabel.ForeColor = StudyTheme.Slate;
        pronunciationLabel.TextAlign = ContentAlignment.MiddleCenter;

        answerPanel.Controls.Add(answerLayout);
        answerPanel.Dock = DockStyle.Fill;
        answerPanel.Padding = new Padding(0, 12, 0, 0);

        answerLayout.ColumnCount = 1;
        answerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        answerLayout.Controls.Add(meaningLabel, 0, 0);
        answerLayout.Controls.Add(exampleLabel, 0, 1);
        answerLayout.Controls.Add(translationLabel, 0, 2);
        answerLayout.Controls.Add(memoryLabel, 0, 3);
        answerLayout.Dock = DockStyle.Fill;
        answerLayout.RowCount = 4;
        answerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        answerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        answerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        answerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        meaningLabel.BorderStyle = BorderStyle.FixedSingle;
        meaningLabel.Dock = DockStyle.Fill;
        meaningLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        meaningLabel.ForeColor = StudyTheme.Teal;
        meaningLabel.TextAlign = ContentAlignment.MiddleCenter;

        exampleLabel.Dock = DockStyle.Fill;
        exampleLabel.Font = new Font("Segoe UI", 11F);
        exampleLabel.ForeColor = StudyTheme.Ink;
        exampleLabel.TextAlign = ContentAlignment.MiddleCenter;

        translationLabel.Dock = DockStyle.Fill;
        translationLabel.Font = new Font("Segoe UI", 10F);
        translationLabel.ForeColor = StudyTheme.Slate;
        translationLabel.TextAlign = ContentAlignment.MiddleCenter;

        memoryLabel.Anchor = AnchorStyles.Top;
        memoryLabel.AutoSize = true;
        memoryLabel.BackColor = StudyTheme.SoftGold;
        memoryLabel.ForeColor = StudyTheme.Gold;
        memoryLabel.Padding = new Padding(10, 5, 10, 5);
        memoryLabel.TextAlign = ContentAlignment.MiddleCenter;

        actionLayout.ColumnCount = 2;
        actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
        actionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        actionLayout.Controls.Add(flipButton, 0, 0);
        actionLayout.Controls.Add(ratingPromptLabel, 1, 0);
        actionLayout.Dock = DockStyle.Fill;
        actionLayout.Padding = new Padding(0, 12, 0, 6);

        flipButton.Dock = DockStyle.Fill;
        flipButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        flipButton.Name = "flipButton";
        flipButton.Text = "Lật thẻ · Space";
        flipButton.Click += flipButton_Click;

        ratingPromptLabel.Dock = DockStyle.Fill;
        ratingPromptLabel.ForeColor = StudyTheme.Slate;
        ratingPromptLabel.TextAlign = ContentAlignment.MiddleCenter;

        ratingLayout.ColumnCount = 4;
        ratingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ratingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ratingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ratingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ratingLayout.Controls.Add(againButton, 0, 0);
        ratingLayout.Controls.Add(hardButton, 1, 0);
        ratingLayout.Controls.Add(goodButton, 2, 0);
        ratingLayout.Controls.Add(easyButton, 3, 0);
        ratingLayout.Dock = DockStyle.Fill;

        ConfigureRatingButton(againButton, "Quên", "vào sổ lỗi", "1", StudyTheme.Warning, 1);
        ConfigureRatingButton(hardButton, "Khó", "vào sổ lỗi", "2", StudyTheme.Gold, 2);
        ConfigureRatingButton(goodButton, "Nhớ", "bỏ khỏi sổ lỗi", "3", StudyTheme.Teal, 3);
        ConfigureRatingButton(easyButton, "Dễ", "bỏ khỏi sổ lỗi", "4", StudyTheme.Blue, 4);

        shortcutLabel.Dock = DockStyle.Fill;
        shortcutLabel.ForeColor = StudyTheme.Muted;
        shortcutLabel.Text = "Phím Space để lật · phím 1–4 để đánh giá";
        shortcutLabel.TextAlign = ContentAlignment.MiddleCenter;

        sideLayout.ColumnCount = 1;
        sideLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        sideLayout.Controls.Add(sessionPanel, 0, 0);
        sideLayout.Controls.Add(tipPanel, 0, 1);
        sideLayout.Dock = DockStyle.Fill;
        sideLayout.RowCount = 3;
        sideLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
        sideLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
        sideLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        sessionPanel.BackColor = Color.White;
        sessionPanel.Controls.Add(sessionLayout);
        sessionPanel.Dock = DockStyle.Fill;
        sessionPanel.Padding = new Padding(18, 14, 18, 14);

        sessionLayout.ColumnCount = 2;
        sessionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        sessionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        sessionLayout.Controls.Add(sessionTitleLabel, 0, 0);
        sessionLayout.SetColumnSpan(sessionTitleLabel, 2);
        sessionLayout.Controls.Add(reviewedNameLabel, 0, 1);
        sessionLayout.Controls.Add(reviewedValueLabel, 1, 1);
        sessionLayout.Controls.Add(rememberedNameLabel, 0, 2);
        sessionLayout.Controls.Add(rememberedValueLabel, 1, 2);
        sessionLayout.Controls.Add(mistakeNameLabel, 0, 3);
        sessionLayout.Controls.Add(mistakeValueLabel, 1, 3);
        sessionLayout.Dock = DockStyle.Fill;
        sessionLayout.RowCount = 4;
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));

        sessionTitleLabel.Dock = DockStyle.Fill;
        sessionTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        sessionTitleLabel.Text = "Phiên học này";
        reviewedNameLabel.Text = "Đã học";
        rememberedNameLabel.Text = "Nhớ tốt";
        mistakeNameLabel.Text = "Vào sổ lỗi";
        reviewedValueLabel.Text = "0 thẻ";
        rememberedValueLabel.Text = "0 thẻ";
        rememberedValueLabel.ForeColor = StudyTheme.Teal;
        mistakeValueLabel.Text = "0 thẻ";
        mistakeValueLabel.ForeColor = StudyTheme.Warning;
        foreach (var label in new[] { reviewedNameLabel, rememberedNameLabel, mistakeNameLabel, reviewedValueLabel, rememberedValueLabel, mistakeValueLabel })
        {
            label.Dock = DockStyle.Fill;
            label.TextAlign = label == reviewedNameLabel || label == rememberedNameLabel || label == mistakeNameLabel
                ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleRight;
            if (label == reviewedValueLabel || label == rememberedValueLabel || label == mistakeValueLabel)
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        tipPanel.BackColor = Color.White;
        tipPanel.Controls.Add(tipLabel);
        tipPanel.Dock = DockStyle.Fill;
        tipPanel.Margin = new Padding(0, 14, 0, 0);
        tipPanel.Padding = new Padding(18);

        tipLabel.Dock = DockStyle.Fill;
        tipLabel.ForeColor = StudyTheme.Slate;
        tipLabel.Text = "Hết vòng, app tự xáo lại. Thẻ đầu vòng mới không trùng thẻ cuối vòng trước.";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = StudyTheme.Canvas;
        Controls.Add(contentLayout);
        Controls.Add(topPanel);
        Name = "StudyScreen";
        Size = new Size(900, 640);
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        contentLayout.ResumeLayout(false);
        studyArea.ResumeLayout(false);
        cardPanel.ResumeLayout(false);
        cardLayout.ResumeLayout(false);
        cardLayout.PerformLayout();
        wordRow.ResumeLayout(false);
        answerPanel.ResumeLayout(false);
        answerLayout.ResumeLayout(false);
        answerLayout.PerformLayout();
        actionLayout.ResumeLayout(false);
        ratingLayout.ResumeLayout(false);
        sideLayout.ResumeLayout(false);
        sessionPanel.ResumeLayout(false);
        sessionLayout.ResumeLayout(false);
        tipPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private void ConfigureRatingButton(StudyButton button, string text, string detail, string key, Color color, int rating)
    {
        button.Dock = DockStyle.Fill;
        button.Margin = new Padding(5, 4, 5, 4);
        button.Text = text;
        button.Detail = detail;
        button.KeyBadge = key;
        button.ForeColor = color;
        button.Tag = rating;
        button.Click += ratingButton_Click;
    }

    #endregion

    private Panel topPanel;
    private StudyButton finishButton;
    private Label remainingLabel;
    private ProgressBar progressBar;
    private Label roundLabel;
    private ComboBox folderComboBox;
    private Label studyingLabel;
    private TableLayoutPanel contentLayout;
    private TableLayoutPanel studyArea;
    private CardPanel cardPanel;
    private TableLayoutPanel cardLayout;
    private Label categoryLabel;
    private TableLayoutPanel wordRow;
    private Label wordLabel;
    private StudyButton speakButton;
    private Label pronunciationLabel;
    private Panel answerPanel;
    private TableLayoutPanel answerLayout;
    private Label meaningLabel;
    private Label exampleLabel;
    private Label translationLabel;
    private Label memoryLabel;
    private TableLayoutPanel actionLayout;
    private StudyButton flipButton;
    private Label ratingPromptLabel;
    private TableLayoutPanel ratingLayout;
    private StudyButton againButton;
    private StudyButton hardButton;
    private StudyButton goodButton;
    private StudyButton easyButton;
    private Label shortcutLabel;
    private TableLayoutPanel sideLayout;
    private CardPanel sessionPanel;
    private TableLayoutPanel sessionLayout;
    private Label sessionTitleLabel;
    private Label reviewedNameLabel;
    private Label reviewedValueLabel;
    private Label rememberedNameLabel;
    private Label rememberedValueLabel;
    private Label mistakeNameLabel;
    private Label mistakeValueLabel;
    private CardPanel tipPanel;
    private Label tipLabel;
    private ToolTip speakToolTip;
}
