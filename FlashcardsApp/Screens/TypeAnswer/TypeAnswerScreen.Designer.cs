namespace FlashcardsApp;

partial class TypeAnswerScreen
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        topPanel = new Panel();
        sourceLabel = new Label();
        progressLabel = new Label();
        scoreLabel = new Label();
        progressBar = new ProgressBar();
        contentLayout = new TableLayoutPanel();
        practicePanel = new CardPanel();
        promptLabel = new SpacedLabel();
        meaningLabel = new Label();
        translationLabel = new Label();
        answerCaptionLabel = new Label();
        answerTextBox = new TextBox();
        checkButton = new StudyButton();
        hintButton = new StudyButton();
        hintLabel = new Label();
        resultPanel = new CardPanel();
        resultTitleLabel = new Label();
        resultDetailLabel = new Label();
        diffPanel = new FlowLayoutPanel();
        nextButton = new StudyButton();
        rulesPanel = new CardPanel();
        rulesTitleLabel = new Label();
        rulesLabel = new Label();
        topPanel.SuspendLayout();
        contentLayout.SuspendLayout();
        practicePanel.SuspendLayout();
        resultPanel.SuspendLayout();
        rulesPanel.SuspendLayout();
        SuspendLayout();
        //
        // topPanel
        //
        topPanel.BackColor = Color.White;
        topPanel.Controls.Add(sourceLabel);
        topPanel.Controls.Add(progressLabel);
        topPanel.Controls.Add(scoreLabel);
        topPanel.Controls.Add(progressBar);
        topPanel.Dock = DockStyle.Top;
        topPanel.Location = new Point(0, 0);
        topPanel.Name = "topPanel";
        topPanel.Padding = new Padding(28, 12, 28, 10);
        topPanel.Size = new Size(1040, 82);
        topPanel.TabIndex = 0;
        //
        // sourceLabel
        //
        sourceLabel.AutoEllipsis = true;
        sourceLabel.Font = new Font("Segoe UI", 10F);
        sourceLabel.ForeColor = StudyTheme.Muted;
        sourceLabel.Location = new Point(28, 10);
        sourceLabel.Name = "sourceLabel";
        sourceLabel.Size = new Size(340, 24);
        sourceLabel.TabIndex = 0;
        sourceLabel.Text = "Đang luyện · Tất cả";
        sourceLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // progressLabel
        //
        progressLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        progressLabel.ForeColor = StudyTheme.Ink;
        progressLabel.Location = new Point(28, 34);
        progressLabel.Name = "progressLabel";
        progressLabel.Size = new Size(260, 25);
        progressLabel.TabIndex = 1;
        progressLabel.Text = "Từ 1/5";
        //
        // scoreLabel
        //
        scoreLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        scoreLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        scoreLabel.ForeColor = StudyTheme.Slate;
        scoreLabel.Location = new Point(782, 34);
        scoreLabel.Name = "scoreLabel";
        scoreLabel.Size = new Size(230, 25);
        scoreLabel.TabIndex = 2;
        scoreLabel.Text = "Đúng 0 · Sai 0";
        scoreLabel.TextAlign = ContentAlignment.TopRight;
        //
        // progressBar
        //
        progressBar.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
        progressBar.Location = new Point(28, 63);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(984, 7);
        progressBar.Style = ProgressBarStyle.Continuous;
        progressBar.TabIndex = 3;
        progressBar.Value = 1;
        //
        // contentLayout
        //
        contentLayout.BackColor = StudyTheme.Canvas;
        contentLayout.ColumnCount = 2;
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));
        contentLayout.Controls.Add(practicePanel, 0, 0);
        contentLayout.Controls.Add(rulesPanel, 1, 0);
        contentLayout.Dock = DockStyle.Fill;
        contentLayout.Location = new Point(0, 82);
        contentLayout.Name = "contentLayout";
        contentLayout.Padding = new Padding(28, 26, 28, 26);
        contentLayout.RowCount = 1;
        contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        contentLayout.Size = new Size(1040, 638);
        contentLayout.TabIndex = 1;
        //
        // practicePanel
        //
        practicePanel.BackColor = Color.White;
        practicePanel.Controls.Add(promptLabel);
        practicePanel.Controls.Add(meaningLabel);
        practicePanel.Controls.Add(translationLabel);
        practicePanel.Controls.Add(answerCaptionLabel);
        practicePanel.Controls.Add(answerTextBox);
        practicePanel.Controls.Add(checkButton);
        practicePanel.Controls.Add(hintButton);
        practicePanel.Controls.Add(hintLabel);
        practicePanel.Controls.Add(resultPanel);
        practicePanel.Controls.Add(diffPanel);
        practicePanel.Controls.Add(nextButton);
        practicePanel.Dock = DockStyle.Fill;
        practicePanel.Location = new Point(28, 26);
        practicePanel.Margin = new Padding(0, 0, 20, 0);
        practicePanel.Name = "practicePanel";
        practicePanel.Padding = new Padding(42, 30, 42, 28);
        practicePanel.Size = new Size(684, 586);
        practicePanel.TabIndex = 0;
        //
        // promptLabel
        //
        promptLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        promptLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        promptLabel.ForeColor = StudyTheme.Teal;
        promptLabel.LetterSpacing = 1.15F;
        promptLabel.Location = new Point(42, 34);
        promptLabel.Name = "promptLabel";
        promptLabel.Size = new Size(600, 22);
        promptLabel.TabIndex = 0;
        promptLabel.Text = "GÕ TỪ TIẾNG ANH CÓ NGHĨA LÀ";
        promptLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // meaningLabel
        //
        meaningLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        meaningLabel.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
        meaningLabel.ForeColor = StudyTheme.Ink;
        meaningLabel.Location = new Point(42, 66);
        meaningLabel.Name = "meaningLabel";
        meaningLabel.Size = new Size(600, 66);
        meaningLabel.TabIndex = 1;
        meaningLabel.Text = "tò mò, ham tìm hiểu";
        meaningLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // translationLabel
        //
        translationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        translationLabel.AutoEllipsis = true;
        translationLabel.Font = new Font("Segoe UI", 10.5F);
        translationLabel.ForeColor = StudyTheme.Slate;
        translationLabel.Location = new Point(62, 132);
        translationLabel.Name = "translationLabel";
        translationLabel.Size = new Size(560, 28);
        translationLabel.TabIndex = 2;
        translationLabel.Text = "Cô ấy tò mò về thế giới.";
        translationLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // answerCaptionLabel
        //
        answerCaptionLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        answerCaptionLabel.ForeColor = StudyTheme.Slate;
        answerCaptionLabel.Location = new Point(58, 182);
        answerCaptionLabel.Name = "answerCaptionLabel";
        answerCaptionLabel.Size = new Size(220, 22);
        answerCaptionLabel.TabIndex = 3;
        answerCaptionLabel.Text = "Đáp án của bạn";
        //
        // answerTextBox
        //
        answerTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        answerTextBox.BorderStyle = BorderStyle.FixedSingle;
        answerTextBox.Font = new Font("Segoe UI", 15F);
        answerTextBox.Location = new Point(58, 208);
        answerTextBox.MaxLength = 100;
        answerTextBox.Name = "answerTextBox";
        answerTextBox.PlaceholderText = "Gõ từ tiếng Anh...";
        answerTextBox.Size = new Size(568, 34);
        answerTextBox.TabIndex = 4;
        answerTextBox.KeyDown += answerTextBox_KeyDown;
        //
        // checkButton
        //
        checkButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        checkButton.BackColor = StudyTheme.Teal;
        checkButton.BorderVisible = false;
        checkButton.CornerRadius = 8;
        checkButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        checkButton.ForeColor = Color.White;
        checkButton.Location = new Point(456, 254);
        checkButton.Name = "checkButton";
        checkButton.Size = new Size(170, 42);
        checkButton.TabIndex = 5;
        checkButton.Text = "Kiểm tra · Enter";
        checkButton.Click += checkButton_Click;
        //
        // hintButton
        //
        hintButton.BackColor = Color.White;
        hintButton.CornerRadius = 8;
        hintButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        hintButton.ForeColor = StudyTheme.Teal;
        hintButton.Location = new Point(58, 254);
        hintButton.Name = "hintButton";
        hintButton.Size = new Size(190, 42);
        hintButton.TabIndex = 6;
        hintButton.Text = "Gợi ý chữ cái đầu";
        hintButton.Click += hintButton_Click;
        //
        // hintLabel
        //
        hintLabel.Font = new Font("Consolas", 12F, FontStyle.Bold);
        hintLabel.ForeColor = StudyTheme.Teal;
        hintLabel.Location = new Point(258, 254);
        hintLabel.Name = "hintLabel";
        hintLabel.Size = new Size(188, 42);
        hintLabel.TabIndex = 7;
        hintLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // resultPanel
        //
        resultPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        resultPanel.BackColor = StudyTheme.SoftTeal;
        resultPanel.BorderVisible = false;
        resultPanel.Controls.Add(resultTitleLabel);
        resultPanel.Controls.Add(resultDetailLabel);
        resultPanel.Location = new Point(58, 318);
        resultPanel.Name = "resultPanel";
        resultPanel.Size = new Size(568, 84);
        resultPanel.TabIndex = 8;
        resultPanel.Visible = false;
        //
        // resultTitleLabel
        //
        resultTitleLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        resultTitleLabel.ForeColor = StudyTheme.Teal;
        resultTitleLabel.Location = new Point(18, 10);
        resultTitleLabel.Name = "resultTitleLabel";
        resultTitleLabel.Size = new Size(520, 28);
        resultTitleLabel.TabIndex = 0;
        resultTitleLabel.Text = "✓ Đúng";
        //
        // resultDetailLabel
        //
        resultDetailLabel.AutoEllipsis = true;
        resultDetailLabel.Font = new Font("Segoe UI", 10F);
        resultDetailLabel.ForeColor = StudyTheme.DarkTeal;
        resultDetailLabel.Location = new Point(18, 41);
        resultDetailLabel.Name = "resultDetailLabel";
        resultDetailLabel.Size = new Size(532, 27);
        resultDetailLabel.TabIndex = 1;
        resultDetailLabel.Text = "curious · từ này đã được ghi nhận là Nhớ.";
        //
        // diffPanel
        //
        diffPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        diffPanel.Location = new Point(58, 412);
        diffPanel.Name = "diffPanel";
        diffPanel.Size = new Size(568, 60);
        diffPanel.TabIndex = 9;
        diffPanel.Visible = false;
        //
        // nextButton
        //
        nextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        nextButton.BackColor = Color.White;
        nextButton.CornerRadius = 8;
        nextButton.Enabled = false;
        nextButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        nextButton.ForeColor = StudyTheme.Teal;
        nextButton.Location = new Point(456, 514);
        nextButton.Name = "nextButton";
        nextButton.Size = new Size(170, 44);
        nextButton.TabIndex = 10;
        nextButton.Text = "Từ tiếp theo";
        nextButton.Click += nextButton_Click;
        //
        // rulesPanel
        //
        rulesPanel.BackColor = Color.White;
        rulesPanel.Controls.Add(rulesTitleLabel);
        rulesPanel.Controls.Add(rulesLabel);
        rulesPanel.Dock = DockStyle.Fill;
        rulesPanel.Location = new Point(732, 26);
        rulesPanel.Margin = new Padding(0);
        rulesPanel.Name = "rulesPanel";
        rulesPanel.Padding = new Padding(22);
        rulesPanel.Size = new Size(280, 586);
        rulesPanel.TabIndex = 1;
        //
        // rulesTitleLabel
        //
        rulesTitleLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        rulesTitleLabel.ForeColor = StudyTheme.Ink;
        rulesTitleLabel.Location = new Point(22, 24);
        rulesTitleLabel.Name = "rulesTitleLabel";
        rulesTitleLabel.Size = new Size(230, 30);
        rulesTitleLabel.TabIndex = 0;
        rulesTitleLabel.Text = "Cách app chấm";
        //
        // rulesLabel
        //
        rulesLabel.Font = new Font("Segoe UI", 10F);
        rulesLabel.ForeColor = StudyTheme.Slate;
        rulesLabel.Location = new Point(22, 72);
        rulesLabel.Name = "rulesLabel";
        rulesLabel.Size = new Size(230, 286);
        rulesLabel.TabIndex = 1;
        rulesLabel.Text = "✓ Không phân biệt chữ hoa, chữ thường\r\n\r\n✓ Tự bỏ khoảng trắng ở đầu và cuối\r\n\r\n✓ Sai chính tả vẫn tính là sai\r\n\r\n✓ Bỏ trống không bị tính sai\r\n\r\n✓ Trả lời đúng sẽ đưa từ ra khỏi sổ lỗi";
        //
        // TypeAnswerScreen
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = StudyTheme.Canvas;
        Controls.Add(contentLayout);
        Controls.Add(topPanel);
        Name = "TypeAnswerScreen";
        Size = new Size(1040, 720);
        topPanel.ResumeLayout(false);
        contentLayout.ResumeLayout(false);
        practicePanel.ResumeLayout(false);
        practicePanel.PerformLayout();
        resultPanel.ResumeLayout(false);
        rulesPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel topPanel;
    private Label sourceLabel;
    private Label progressLabel;
    private Label scoreLabel;
    private ProgressBar progressBar;
    private TableLayoutPanel contentLayout;
    private CardPanel practicePanel;
    private SpacedLabel promptLabel;
    private Label meaningLabel;
    private Label translationLabel;
    private Label answerCaptionLabel;
    private TextBox answerTextBox;
    private StudyButton checkButton;
    private StudyButton hintButton;
    private Label hintLabel;
    private CardPanel resultPanel;
    private Label resultTitleLabel;
    private Label resultDetailLabel;
    private FlowLayoutPanel diffPanel;
    private StudyButton nextButton;
    private CardPanel rulesPanel;
    private Label rulesTitleLabel;
    private Label rulesLabel;
}
