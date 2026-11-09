namespace FlashcardsApp;

partial class OverviewScreen
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

    #region Component Designer generated code

    private void InitializeComponent()
    {
        overviewLayout = new TableLayoutPanel();
        headerLayout = new TableLayoutPanel();
        dateLabel = new Label();
        greetingLabel = new Label();
        studyNowButton = new StudyButton();
        statsLayout = new TableLayoutPanel();
        totalPanel = new Panel();
        totalNoteLabel = new Label();
        totalLabel = new Label();
        totalTitleLabel = new Label();
        learnedPanel = new Panel();
        learnedNoteLabel = new Label();
        learnedLabel = new Label();
        learnedTitleLabel = new Label();
        mistakePanel = new Panel();
        mistakeNoteLabel = new Label();
        mistakeValuePanel = new FlowLayoutPanel();
        mistakeLabel = new Label();
        mistakeUnitLabel = new Label();
        mistakeTitleLabel = new Label();
        folderPanel = new Panel();
        folderNoteLabel = new Label();
        folderLabel = new Label();
        folderTitleLabel = new Label();
        mainLayout = new TableLayoutPanel();
        progressPanel = new Panel();
        progressTitleLabel = new Label();
        wordOfDayPanel = new Panel();
        wordOfDayLayout = new TableLayoutPanel();
        wordOfDayTitleLabel = new Label();
        speakWordButton = new StudyButton();
        wordOfDayLabel = new Label();
        wordOfDayInfoLabel = new Label();
        wordOfDayExampleLabel = new Label();
        wordOfDayTranslationLabel = new Label();
        wordOfDayNoteLabel = new Label();
        overviewLayout.SuspendLayout();
        headerLayout.SuspendLayout();
        statsLayout.SuspendLayout();
        totalPanel.SuspendLayout();
        learnedPanel.SuspendLayout();
        mistakePanel.SuspendLayout();
        mistakeValuePanel.SuspendLayout();
        folderPanel.SuspendLayout();
        mainLayout.SuspendLayout();
        progressPanel.SuspendLayout();
        wordOfDayPanel.SuspendLayout();
        wordOfDayLayout.SuspendLayout();
        SuspendLayout();
        //
        // overviewLayout
        //
        overviewLayout.ColumnCount = 1;
        overviewLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        overviewLayout.Controls.Add(headerLayout, 0, 0);
        overviewLayout.Controls.Add(statsLayout, 0, 1);
        overviewLayout.Controls.Add(mainLayout, 0, 2);
        overviewLayout.Dock = DockStyle.Fill;
        overviewLayout.Location = new Point(0, 0);
        overviewLayout.Name = "overviewLayout";
        overviewLayout.Padding = new Padding(40, 28, 40, 32);
        overviewLayout.RowCount = 3;
        overviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
        overviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
        overviewLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        overviewLayout.Size = new Size(1040, 800);
        overviewLayout.TabIndex = 0;
        //
        // headerLayout
        //
        headerLayout.ColumnCount = 2;
        headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
        headerLayout.Controls.Add(dateLabel, 0, 0);
        headerLayout.Controls.Add(greetingLabel, 0, 1);
        headerLayout.Controls.Add(studyNowButton, 1, 0);
        headerLayout.Dock = DockStyle.Fill;
        headerLayout.Margin = new Padding(0);
        headerLayout.Name = "headerLayout";
        headerLayout.RowCount = 2;
        headerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        headerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        headerLayout.Size = new Size(960, 68);
        headerLayout.TabIndex = 0;
        //
        // dateLabel
        //
        dateLabel.Dock = DockStyle.Fill;
        dateLabel.Font = new Font("Segoe UI", 10.5F);
        dateLabel.ForeColor = Color.FromArgb(51, 65, 85);
        dateLabel.Margin = new Padding(0);
        dateLabel.Name = "dateLabel";
        dateLabel.Size = new Size(846, 24);
        dateLabel.TabIndex = 0;
        dateLabel.Text = "Thứ năm, 06/11";
        dateLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // greetingLabel
        //
        greetingLabel.Dock = DockStyle.Fill;
        greetingLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        greetingLabel.ForeColor = Color.FromArgb(15, 23, 42);
        greetingLabel.Margin = new Padding(0);
        greetingLabel.Name = "greetingLabel";
        greetingLabel.AutoEllipsis = true;
        greetingLabel.Size = new Size(846, 44);
        greetingLabel.TabIndex = 1;
        greetingLabel.Text = "Chào bạn, hôm nay học gì?";
        greetingLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // studyNowButton
        //
        studyNowButton.BackColor = Color.FromArgb(15, 118, 110);
        studyNowButton.BorderVisible = false;
        studyNowButton.Dock = DockStyle.Fill;
        studyNowButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        studyNowButton.ForeColor = Color.White;
        studyNowButton.Margin = new Padding(0, 20, 0, 4);
        studyNowButton.Name = "studyNowButton";
        headerLayout.SetRowSpan(studyNowButton, 2);
        studyNowButton.Size = new Size(114, 44);
        studyNowButton.TabIndex = 2;
        studyNowButton.Text = "Học ngay";
        studyNowButton.Click += studyNowButton_Click;
        //
        // statsLayout
        //
        statsLayout.ColumnCount = 4;
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        statsLayout.Controls.Add(totalPanel, 0, 0);
        statsLayout.Controls.Add(learnedPanel, 1, 0);
        statsLayout.Controls.Add(mistakePanel, 2, 0);
        statsLayout.Controls.Add(folderPanel, 3, 0);
        statsLayout.Dock = DockStyle.Fill;
        statsLayout.Margin = new Padding(0, 20, 0, 24);
        statsLayout.Name = "statsLayout";
        statsLayout.RowCount = 1;
        statsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        statsLayout.Size = new Size(960, 126);
        statsLayout.TabIndex = 1;
        //
        // totalPanel
        //
        totalPanel.BackColor = Color.White;
        totalPanel.Controls.Add(totalNoteLabel);
        totalPanel.Controls.Add(totalLabel);
        totalPanel.Controls.Add(totalTitleLabel);
        totalPanel.Dock = DockStyle.Fill;
        totalPanel.Margin = new Padding(0, 0, 12, 0);
        totalPanel.Name = "totalPanel";
        totalPanel.Padding = new Padding(21, 14, 16, 10);
        totalPanel.Size = new Size(228, 126);
        totalPanel.TabIndex = 0;
        totalPanel.Paint += cardPanel_Paint;
        //
        // totalNoteLabel
        //
        totalNoteLabel.Dock = DockStyle.Top;
        totalNoteLabel.Font = new Font("Segoe UI", 9.5F);
        totalNoteLabel.ForeColor = Color.FromArgb(93, 105, 125);
        totalNoteLabel.Margin = new Padding(0);
        totalNoteLabel.Name = "totalNoteLabel";
        totalNoteLabel.Size = new Size(191, 24);
        totalNoteLabel.TabIndex = 2;
        totalNoteLabel.Text = "trong mọi thư mục";
        totalNoteLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // totalLabel
        //
        totalLabel.Dock = DockStyle.Top;
        totalLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        totalLabel.ForeColor = Color.FromArgb(15, 23, 42);
        totalLabel.Margin = new Padding(0);
        totalLabel.Name = "totalLabel";
        totalLabel.Size = new Size(191, 46);
        totalLabel.TabIndex = 1;
        totalLabel.Text = "30";
        totalLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // totalTitleLabel
        //
        totalTitleLabel.Dock = DockStyle.Top;
        totalTitleLabel.Font = new Font("Segoe UI", 10.5F);
        totalTitleLabel.ForeColor = Color.FromArgb(51, 65, 85);
        totalTitleLabel.Margin = new Padding(0);
        totalTitleLabel.Name = "totalTitleLabel";
        totalTitleLabel.Size = new Size(191, 28);
        totalTitleLabel.TabIndex = 0;
        totalTitleLabel.Text = "Tổng số từ";
        totalTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // learnedPanel
        //
        learnedPanel.BackColor = Color.White;
        learnedPanel.Controls.Add(learnedNoteLabel);
        learnedPanel.Controls.Add(learnedLabel);
        learnedPanel.Controls.Add(learnedTitleLabel);
        learnedPanel.Dock = DockStyle.Fill;
        learnedPanel.Margin = new Padding(4, 0, 8, 0);
        learnedPanel.Name = "learnedPanel";
        learnedPanel.Padding = new Padding(21, 14, 16, 10);
        learnedPanel.Size = new Size(228, 126);
        learnedPanel.TabIndex = 1;
        learnedPanel.Paint += cardPanel_Paint;
        //
        // learnedNoteLabel
        //
        learnedNoteLabel.Dock = DockStyle.Top;
        learnedNoteLabel.Font = new Font("Segoe UI", 9.5F);
        learnedNoteLabel.ForeColor = Color.FromArgb(93, 105, 125);
        learnedNoteLabel.Margin = new Padding(0);
        learnedNoteLabel.Name = "learnedNoteLabel";
        learnedNoteLabel.Size = new Size(191, 24);
        learnedNoteLabel.TabIndex = 2;
        learnedNoteLabel.Text = "chọn Nhớ hoặc Dễ";
        learnedNoteLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // learnedLabel
        //
        learnedLabel.Dock = DockStyle.Top;
        learnedLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        learnedLabel.ForeColor = Color.FromArgb(15, 118, 110);
        learnedLabel.Margin = new Padding(0);
        learnedLabel.Name = "learnedLabel";
        learnedLabel.Size = new Size(191, 46);
        learnedLabel.TabIndex = 1;
        learnedLabel.Text = "12";
        learnedLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // learnedTitleLabel
        //
        learnedTitleLabel.Dock = DockStyle.Top;
        learnedTitleLabel.Font = new Font("Segoe UI", 10.5F);
        learnedTitleLabel.ForeColor = Color.FromArgb(51, 65, 85);
        learnedTitleLabel.Margin = new Padding(0);
        learnedTitleLabel.Name = "learnedTitleLabel";
        learnedTitleLabel.Size = new Size(191, 28);
        learnedTitleLabel.TabIndex = 0;
        learnedTitleLabel.Text = "Đã nhớ";
        learnedTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // mistakePanel
        //
        mistakePanel.BackColor = Color.White;
        mistakePanel.Controls.Add(mistakeNoteLabel);
        mistakePanel.Controls.Add(mistakeValuePanel);
        mistakePanel.Controls.Add(mistakeTitleLabel);
        mistakePanel.Dock = DockStyle.Fill;
        mistakePanel.Margin = new Padding(8, 0, 4, 0);
        mistakePanel.Name = "mistakePanel";
        mistakePanel.Padding = new Padding(21, 14, 16, 10);
        mistakePanel.Size = new Size(228, 126);
        mistakePanel.TabIndex = 2;
        mistakePanel.Paint += cardPanel_Paint;
        //
        // mistakeNoteLabel
        //
        mistakeNoteLabel.Dock = DockStyle.Top;
        mistakeNoteLabel.Font = new Font("Segoe UI", 9.5F);
        mistakeNoteLabel.ForeColor = Color.FromArgb(93, 105, 125);
        mistakeNoteLabel.Margin = new Padding(0);
        mistakeNoteLabel.Name = "mistakeNoteLabel";
        mistakeNoteLabel.Size = new Size(191, 24);
        mistakeNoteLabel.TabIndex = 2;
        mistakeNoteLabel.Text = "Quên, Khó hoặc gõ sai";
        mistakeNoteLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // mistakeValuePanel
        //
        mistakeValuePanel.Controls.Add(mistakeLabel);
        mistakeValuePanel.Controls.Add(mistakeUnitLabel);
        mistakeValuePanel.Dock = DockStyle.Top;
        mistakeValuePanel.Margin = new Padding(0);
        mistakeValuePanel.Name = "mistakeValuePanel";
        mistakeValuePanel.Size = new Size(191, 46);
        mistakeValuePanel.TabIndex = 1;
        mistakeValuePanel.WrapContents = false;
        //
        // mistakeLabel
        //
        mistakeLabel.AutoSize = true;
        mistakeLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        mistakeLabel.ForeColor = Color.FromArgb(194, 65, 12);
        mistakeLabel.Margin = new Padding(0, 2, 0, 0);
        mistakeLabel.Name = "mistakeLabel";
        mistakeLabel.Size = new Size(36, 45);
        mistakeLabel.TabIndex = 0;
        mistakeLabel.Text = "7";
        //
        // mistakeUnitLabel
        //
        mistakeUnitLabel.AutoSize = true;
        mistakeUnitLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        mistakeUnitLabel.ForeColor = Color.FromArgb(15, 23, 42);
        mistakeUnitLabel.Margin = new Padding(0, 18, 0, 0);
        mistakeUnitLabel.Name = "mistakeUnitLabel";
        mistakeUnitLabel.Size = new Size(96, 19);
        mistakeUnitLabel.TabIndex = 1;
        mistakeUnitLabel.Text = "từ cần luyện";
        //
        // mistakeTitleLabel
        //
        mistakeTitleLabel.Dock = DockStyle.Top;
        mistakeTitleLabel.Font = new Font("Segoe UI", 10.5F);
        mistakeTitleLabel.ForeColor = Color.FromArgb(51, 65, 85);
        mistakeTitleLabel.Margin = new Padding(0);
        mistakeTitleLabel.Name = "mistakeTitleLabel";
        mistakeTitleLabel.Size = new Size(191, 28);
        mistakeTitleLabel.TabIndex = 0;
        mistakeTitleLabel.Text = "Sổ lỗi";
        mistakeTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // folderPanel
        //
        folderPanel.BackColor = Color.White;
        folderPanel.Controls.Add(folderNoteLabel);
        folderPanel.Controls.Add(folderLabel);
        folderPanel.Controls.Add(folderTitleLabel);
        folderPanel.Dock = DockStyle.Fill;
        folderPanel.Margin = new Padding(12, 0, 0, 0);
        folderPanel.Name = "folderPanel";
        folderPanel.Padding = new Padding(21, 14, 16, 10);
        folderPanel.Size = new Size(228, 126);
        folderPanel.TabIndex = 3;
        folderPanel.Paint += cardPanel_Paint;
        //
        // folderNoteLabel
        //
        folderNoteLabel.Dock = DockStyle.Top;
        folderNoteLabel.Font = new Font("Segoe UI", 9.5F);
        folderNoteLabel.ForeColor = Color.FromArgb(93, 105, 125);
        folderNoteLabel.Margin = new Padding(0);
        folderNoteLabel.Name = "folderNoteLabel";
        folderNoteLabel.Size = new Size(191, 24);
        folderNoteLabel.TabIndex = 2;
        folderNoteLabel.Text = "kể cả Chưa phân loại";
        folderNoteLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // folderLabel
        //
        folderLabel.Dock = DockStyle.Top;
        folderLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        folderLabel.ForeColor = Color.FromArgb(15, 23, 42);
        folderLabel.Margin = new Padding(0);
        folderLabel.Name = "folderLabel";
        folderLabel.Size = new Size(191, 46);
        folderLabel.TabIndex = 1;
        folderLabel.Text = "4";
        folderLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // folderTitleLabel
        //
        folderTitleLabel.Dock = DockStyle.Top;
        folderTitleLabel.Font = new Font("Segoe UI", 10.5F);
        folderTitleLabel.ForeColor = Color.FromArgb(51, 65, 85);
        folderTitleLabel.Margin = new Padding(0);
        folderTitleLabel.Name = "folderTitleLabel";
        folderTitleLabel.Size = new Size(191, 28);
        folderTitleLabel.TabIndex = 0;
        folderTitleLabel.Text = "Thư mục";
        folderTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // mainLayout
        //
        mainLayout.ColumnCount = 2;
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.3F));
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.7F));
        mainLayout.Controls.Add(progressPanel, 0, 0);
        mainLayout.Controls.Add(wordOfDayPanel, 1, 0);
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Margin = new Padding(0);
        mainLayout.Name = "mainLayout";
        mainLayout.RowCount = 1;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.Size = new Size(960, 502);
        mainLayout.TabIndex = 2;
        //
        // progressPanel
        //
        progressPanel.BackColor = Color.White;
        progressPanel.Controls.Add(progressTitleLabel);
        progressPanel.Dock = DockStyle.Fill;
        progressPanel.Margin = new Padding(0, 0, 16, 0);
        progressPanel.Name = "progressPanel";
        progressPanel.Padding = new Padding(25, 24, 25, 18);
        progressPanel.Size = new Size(505, 502);
        progressPanel.TabIndex = 0;
        progressPanel.Paint += progressPanel_Paint;
        progressPanel.Resize += progressPanel_Resize;
        //
        // progressTitleLabel
        //
        progressTitleLabel.Dock = DockStyle.Top;
        progressTitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        progressTitleLabel.ForeColor = Color.FromArgb(15, 118, 110);
        progressTitleLabel.Margin = new Padding(0);
        progressTitleLabel.Name = "progressTitleLabel";
        progressTitleLabel.Paint += spacedLabel_Paint;
        progressTitleLabel.Size = new Size(455, 24);
        progressTitleLabel.TabIndex = 0;
        progressTitleLabel.Text = "TIẾN ĐỘ GHI NHỚ";
        progressTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // wordOfDayPanel
        //
        wordOfDayPanel.BackColor = Color.FromArgb(227, 245, 241);
        wordOfDayPanel.Controls.Add(wordOfDayLayout);
        wordOfDayPanel.Dock = DockStyle.Fill;
        wordOfDayPanel.Margin = new Padding(0);
        wordOfDayPanel.Name = "wordOfDayPanel";
        wordOfDayPanel.Padding = new Padding(24);
        wordOfDayPanel.Size = new Size(439, 502);
        wordOfDayPanel.TabIndex = 1;
        wordOfDayPanel.Paint += wordOfDayPanel_Paint;
        //
        // wordOfDayLayout
        //
        wordOfDayLayout.ColumnCount = 2;
        wordOfDayLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        wordOfDayLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
        wordOfDayLayout.Controls.Add(wordOfDayTitleLabel, 0, 0);
        wordOfDayLayout.Controls.Add(speakWordButton, 1, 0);
        wordOfDayLayout.Controls.Add(wordOfDayLabel, 0, 1);
        wordOfDayLayout.Controls.Add(wordOfDayInfoLabel, 0, 2);
        wordOfDayLayout.Controls.Add(wordOfDayExampleLabel, 0, 3);
        wordOfDayLayout.Controls.Add(wordOfDayTranslationLabel, 0, 4);
        wordOfDayLayout.Controls.Add(wordOfDayNoteLabel, 0, 6);
        wordOfDayLayout.Dock = DockStyle.Fill;
        wordOfDayLayout.Margin = new Padding(0);
        wordOfDayLayout.Name = "wordOfDayLayout";
        wordOfDayLayout.RowCount = 7;
        wordOfDayLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        wordOfDayLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        wordOfDayLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        wordOfDayLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        wordOfDayLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        wordOfDayLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        wordOfDayLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        wordOfDayLayout.Size = new Size(391, 454);
        wordOfDayLayout.TabIndex = 0;
        //
        // wordOfDayTitleLabel
        //
        wordOfDayTitleLabel.Dock = DockStyle.Fill;
        wordOfDayTitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        wordOfDayTitleLabel.ForeColor = Color.FromArgb(15, 118, 110);
        wordOfDayTitleLabel.Margin = new Padding(0);
        wordOfDayTitleLabel.Name = "wordOfDayTitleLabel";
        wordOfDayTitleLabel.Paint += spacedLabel_Paint;
        wordOfDayTitleLabel.Size = new Size(347, 44);
        wordOfDayTitleLabel.TabIndex = 0;
        wordOfDayTitleLabel.Text = "TỪ CỦA NGÀY";
        wordOfDayTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // speakWordButton
        //
        speakWordButton.AccessibleName = "Phát âm từ của ngày";
        speakWordButton.BorderVisible = false;
        speakWordButton.CornerRadius = 22;
        speakWordButton.Dock = DockStyle.Fill;
        speakWordButton.IconName = "sound";
        speakWordButton.IconSize = 18;
        speakWordButton.Margin = new Padding(0);
        speakWordButton.Name = "speakWordButton";
        speakWordButton.Size = new Size(44, 44);
        speakWordButton.TabIndex = 1;
        speakWordButton.Click += speakWordButton_Click;
        //
        // wordOfDayLabel
        //
        wordOfDayLabel.Dock = DockStyle.Fill;
        wordOfDayLabel.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
        wordOfDayLabel.ForeColor = Color.FromArgb(15, 23, 42);
        wordOfDayLabel.Margin = new Padding(0);
        wordOfDayLabel.Name = "wordOfDayLabel";
        wordOfDayLayout.SetColumnSpan(wordOfDayLabel, 2);
        wordOfDayLabel.AutoEllipsis = true;
        wordOfDayLabel.Size = new Size(391, 58);
        wordOfDayLabel.TabIndex = 2;
        wordOfDayLabel.Text = "appointment";
        wordOfDayLabel.TextAlign = ContentAlignment.BottomLeft;
        //
        // wordOfDayInfoLabel
        //
        wordOfDayInfoLabel.Dock = DockStyle.Fill;
        wordOfDayInfoLabel.Font = new Font("Segoe UI", 11F);
        wordOfDayInfoLabel.ForeColor = Color.FromArgb(51, 65, 85);
        wordOfDayInfoLabel.Margin = new Padding(0);
        wordOfDayInfoLabel.Name = "wordOfDayInfoLabel";
        wordOfDayLayout.SetColumnSpan(wordOfDayInfoLabel, 2);
        wordOfDayInfoLabel.AutoEllipsis = true;
        wordOfDayInfoLabel.Size = new Size(391, 44);
        wordOfDayInfoLabel.TabIndex = 3;
        wordOfDayInfoLabel.Text = "/əˈpɔɪntmənt/ · cuộc hẹn";
        wordOfDayInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // wordOfDayExampleLabel
        //
        wordOfDayExampleLabel.Dock = DockStyle.Fill;
        wordOfDayExampleLabel.Font = new Font("Segoe UI", 11F);
        wordOfDayExampleLabel.ForeColor = Color.FromArgb(15, 23, 42);
        wordOfDayExampleLabel.Margin = new Padding(0);
        wordOfDayExampleLabel.Name = "wordOfDayExampleLabel";
        wordOfDayLayout.SetColumnSpan(wordOfDayExampleLabel, 2);
        wordOfDayExampleLabel.AutoEllipsis = true;
        wordOfDayExampleLabel.Paint += wordOfDayExampleLabel_Paint;
        wordOfDayExampleLabel.Size = new Size(391, 26);
        wordOfDayExampleLabel.TabIndex = 4;
        wordOfDayExampleLabel.Text = "I have a doctor's appointment at 9.";
        wordOfDayExampleLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // wordOfDayTranslationLabel
        //
        wordOfDayTranslationLabel.Dock = DockStyle.Fill;
        wordOfDayTranslationLabel.Font = new Font("Segoe UI", 10.5F);
        wordOfDayTranslationLabel.ForeColor = Color.FromArgb(51, 65, 85);
        wordOfDayTranslationLabel.Margin = new Padding(0);
        wordOfDayTranslationLabel.Name = "wordOfDayTranslationLabel";
        wordOfDayLayout.SetColumnSpan(wordOfDayTranslationLabel, 2);
        wordOfDayTranslationLabel.AutoEllipsis = true;
        wordOfDayTranslationLabel.Size = new Size(391, 30);
        wordOfDayTranslationLabel.TabIndex = 5;
        wordOfDayTranslationLabel.Text = "Tôi có hẹn với bác sĩ lúc 9 giờ.";
        wordOfDayTranslationLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // wordOfDayNoteLabel
        //
        wordOfDayNoteLabel.Dock = DockStyle.Fill;
        wordOfDayNoteLabel.Font = new Font("Segoe UI", 9.5F);
        wordOfDayNoteLabel.ForeColor = Color.FromArgb(17, 78, 74);
        wordOfDayNoteLabel.Margin = new Padding(0);
        wordOfDayNoteLabel.Name = "wordOfDayNoteLabel";
        wordOfDayLayout.SetColumnSpan(wordOfDayNoteLabel, 2);
        wordOfDayNoteLabel.AutoEllipsis = true;
        wordOfDayNoteLabel.Padding = new Padding(12, 0, 0, 0);
        wordOfDayNoteLabel.Paint += wordOfDayNoteLabel_Paint;
        wordOfDayNoteLabel.Size = new Size(391, 32);
        wordOfDayNoteLabel.TabIndex = 6;
        wordOfDayNoteLabel.Text = "Chọn trong các từ chưa thuộc · mỗi ngày một từ";
        wordOfDayNoteLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // OverviewScreen
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 249, 250);
        Controls.Add(overviewLayout);
        Font = new Font("Segoe UI", 9F);
        Name = "OverviewScreen";
        Size = new Size(1040, 800);
        Load += OverviewScreen_Load;
        overviewLayout.ResumeLayout(false);
        headerLayout.ResumeLayout(false);
        statsLayout.ResumeLayout(false);
        totalPanel.ResumeLayout(false);
        learnedPanel.ResumeLayout(false);
        mistakePanel.ResumeLayout(false);
        mistakeValuePanel.ResumeLayout(false);
        mistakeValuePanel.PerformLayout();
        folderPanel.ResumeLayout(false);
        mainLayout.ResumeLayout(false);
        progressPanel.ResumeLayout(false);
        wordOfDayPanel.ResumeLayout(false);
        wordOfDayLayout.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel overviewLayout;
    private TableLayoutPanel headerLayout;
    private Label dateLabel;
    private Label greetingLabel;
    private StudyButton studyNowButton;
    private TableLayoutPanel statsLayout;
    private Panel totalPanel;
    private Label totalNoteLabel;
    private Label totalLabel;
    private Label totalTitleLabel;
    private Panel learnedPanel;
    private Label learnedNoteLabel;
    private Label learnedLabel;
    private Label learnedTitleLabel;
    private Panel mistakePanel;
    private Label mistakeNoteLabel;
    private FlowLayoutPanel mistakeValuePanel;
    private Label mistakeLabel;
    private Label mistakeUnitLabel;
    private Label mistakeTitleLabel;
    private Panel folderPanel;
    private Label folderNoteLabel;
    private Label folderLabel;
    private Label folderTitleLabel;
    private TableLayoutPanel mainLayout;
    private Panel progressPanel;
    private Label progressTitleLabel;
    private Panel wordOfDayPanel;
    private TableLayoutPanel wordOfDayLayout;
    private Label wordOfDayTitleLabel;
    private StudyButton speakWordButton;
    private Label wordOfDayLabel;
    private Label wordOfDayInfoLabel;
    private Label wordOfDayExampleLabel;
    private Label wordOfDayTranslationLabel;
    private Label wordOfDayNoteLabel;
}
