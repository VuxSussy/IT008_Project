namespace FlashcardsApp;

partial class MainWindow
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
        menuPanel = new Panel();
        menuLayout = new TableLayoutPanel();
        brandPanel = new Panel();
        logoPanel = new LogoBox();
        brandLabel = new SpacedLabel();
        taglineLabel = new Label();
        overviewButton = new StudyButton();
        courseButton = new StudyButton();
        folderButton = new StudyButton();
        studyButton = new StudyButton();
        typeButton = new StudyButton();
        mistakeButton = new StudyButton();
        challengeButton = new StudyButton();
        rushButton = new StudyButton();
        leaderboardButton = new StudyButton();
        matchButton = new StudyButton();
        adminButton = new StudyButton();
        learnGroupLabel = new SpacedLabel();
        competeGroupLabel = new SpacedLabel();
        adminGroupLabel = new SpacedLabel();
        userPanel = new Panel();
        avatarBox = new AvatarBox();
        userLabel = new Label();
        logoutButton = new StudyButton();
        menuBorder = new Panel();
        contentPanel = new Panel();
        menuPanel.SuspendLayout();
        menuLayout.SuspendLayout();
        brandPanel.SuspendLayout();
        userPanel.SuspendLayout();
        SuspendLayout();
        //
        // menuPanel
        //
        menuPanel.AutoScroll = true;
        menuPanel.AutoScrollMinSize = new Size(0, 706);
        menuPanel.BackColor = Color.White;
        menuPanel.Controls.Add(menuLayout);
        menuPanel.Dock = DockStyle.Left;
        menuPanel.Location = new Point(0, 0);
        menuPanel.Name = "menuPanel";
        menuPanel.Padding = new Padding(16, 20, 16, 16);
        menuPanel.Size = new Size(239, 800);
        menuPanel.TabIndex = 0;
        //
        // menuLayout
        //
        menuLayout.ColumnCount = 1;
        menuLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        menuLayout.Controls.Add(brandPanel, 0, 0);
        menuLayout.Controls.Add(overviewButton, 0, 1);
        menuLayout.Controls.Add(learnGroupLabel, 0, 2);
        menuLayout.Controls.Add(courseButton, 0, 3);
        menuLayout.Controls.Add(folderButton, 0, 4);
        menuLayout.Controls.Add(studyButton, 0, 5);
        menuLayout.Controls.Add(typeButton, 0, 6);
        menuLayout.Controls.Add(mistakeButton, 0, 7);
        menuLayout.Controls.Add(competeGroupLabel, 0, 8);
        menuLayout.Controls.Add(challengeButton, 0, 9);
        menuLayout.Controls.Add(rushButton, 0, 10);
        menuLayout.Controls.Add(leaderboardButton, 0, 11);
        menuLayout.Controls.Add(matchButton, 0, 12);
        menuLayout.Controls.Add(adminGroupLabel, 0, 13);
        menuLayout.Controls.Add(adminButton, 0, 14);
        menuLayout.Controls.Add(userPanel, 0, 16);
        menuLayout.Dock = DockStyle.Fill;
        menuLayout.Location = new Point(16, 20);
        menuLayout.Margin = new Padding(0);
        menuLayout.Name = "menuLayout";
        menuLayout.RowCount = 17;
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        menuLayout.Size = new Size(207, 764);
        menuLayout.TabIndex = 0;
        //
        // brandPanel
        //
        brandPanel.Controls.Add(logoPanel);
        brandPanel.Controls.Add(brandLabel);
        brandPanel.Controls.Add(taglineLabel);
        brandPanel.Dock = DockStyle.Fill;
        brandPanel.Margin = new Padding(0);
        brandPanel.Name = "brandPanel";
        brandPanel.Size = new Size(207, 72);
        brandPanel.TabIndex = 0;
        //
        // logoPanel
        //
        logoPanel.Location = new Point(8, 0);
        logoPanel.Name = "logoPanel";
        logoPanel.Size = new Size(34, 34);
        logoPanel.TabIndex = 0;
        //
        // brandLabel
        //
        brandLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        brandLabel.ForeColor = Color.FromArgb(15, 23, 42);
        brandLabel.Location = new Point(52, 0);
        brandLabel.Name = "brandLabel";
        brandLabel.Size = new Size(155, 20);
        brandLabel.TabIndex = 1;
        brandLabel.Text = "FLASHCARDS";
        brandLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // taglineLabel
        //
        taglineLabel.Font = new Font("Segoe UI", 8.5F);
        taglineLabel.ForeColor = Color.FromArgb(51, 65, 85);
        taglineLabel.Location = new Point(52, 20);
        taglineLabel.Name = "taglineLabel";
        taglineLabel.Size = new Size(155, 36);
        taglineLabel.TabIndex = 2;
        taglineLabel.Text = "Học từng chút, nhớ thật lâu.";
        //
        // overviewButton
        //
        overviewButton.BorderVisible = false;
        overviewButton.Dock = DockStyle.Fill;
        overviewButton.Font = new Font("Segoe UI", 10.5F);
        overviewButton.ForeColor = Color.FromArgb(51, 65, 85);
        overviewButton.IconName = "home";
        overviewButton.IconSize = 16;
        overviewButton.Margin = new Padding(0, 0, 0, 4);
        overviewButton.Name = "overviewButton";
        overviewButton.Size = new Size(207, 38);
        overviewButton.TabIndex = 2;
        overviewButton.Text = "Tổng quan";
        overviewButton.TextAlign = ContentAlignment.MiddleLeft;
        overviewButton.Click += overviewButton_Click;
        //
        // learnGroupLabel
        //
        learnGroupLabel.Dock = DockStyle.Fill;
        learnGroupLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        learnGroupLabel.ForeColor = Color.FromArgb(93, 105, 125);
        learnGroupLabel.LetterSpacing = 1.2F;
        learnGroupLabel.Margin = new Padding(14, 8, 0, 0);
        learnGroupLabel.Name = "learnGroupLabel";
        learnGroupLabel.Size = new Size(193, 20);
        learnGroupLabel.TabIndex = 3;
        learnGroupLabel.Text = "HỌC";
        learnGroupLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // courseButton
        //
        courseButton.BorderVisible = false;
        courseButton.Dock = DockStyle.Fill;
        courseButton.Font = new Font("Segoe UI", 10.5F);
        courseButton.ForeColor = Color.FromArgb(51, 65, 85);
        courseButton.IconName = "course";
        courseButton.IconSize = 16;
        courseButton.Margin = new Padding(0, 0, 0, 4);
        courseButton.Name = "courseButton";
        courseButton.Size = new Size(207, 38);
        courseButton.TabIndex = 4;
        courseButton.Text = "Khóa học";
        courseButton.TextAlign = ContentAlignment.MiddleLeft;
        courseButton.Click += courseButton_Click;
        //
        // folderButton
        //
        folderButton.BorderVisible = false;
        folderButton.Dock = DockStyle.Fill;
        folderButton.Font = new Font("Segoe UI", 10.5F);
        folderButton.ForeColor = Color.FromArgb(51, 65, 85);
        folderButton.IconName = "folder";
        folderButton.IconSize = 16;
        folderButton.Margin = new Padding(0, 0, 0, 4);
        folderButton.Name = "folderButton";
        folderButton.Size = new Size(207, 38);
        folderButton.TabIndex = 5;
        folderButton.Text = "Thư mục của tôi";
        folderButton.TextAlign = ContentAlignment.MiddleLeft;
        folderButton.Click += folderButton_Click;
        //
        // studyButton
        //
        studyButton.BorderVisible = false;
        studyButton.Dock = DockStyle.Fill;
        studyButton.Font = new Font("Segoe UI", 10.5F);
        studyButton.ForeColor = Color.FromArgb(51, 65, 85);
        studyButton.IconName = "cards";
        studyButton.IconSize = 16;
        studyButton.Margin = new Padding(0, 0, 0, 4);
        studyButton.Name = "studyButton";
        studyButton.Size = new Size(207, 38);
        studyButton.TabIndex = 6;
        studyButton.Text = "Học lật thẻ";
        studyButton.TextAlign = ContentAlignment.MiddleLeft;
        studyButton.Click += studyButton_Click;
        //
        // typeButton
        //
        typeButton.BorderVisible = false;
        typeButton.Dock = DockStyle.Fill;
        typeButton.Font = new Font("Segoe UI", 10.5F);
        typeButton.ForeColor = Color.FromArgb(51, 65, 85);
        typeButton.IconName = "keyboard";
        typeButton.IconSize = 16;
        typeButton.Margin = new Padding(0, 0, 0, 4);
        typeButton.Name = "typeButton";
        typeButton.Size = new Size(207, 38);
        typeButton.TabIndex = 7;
        typeButton.Text = "Gõ đáp án";
        typeButton.TextAlign = ContentAlignment.MiddleLeft;
        typeButton.Click += typeButton_Click;
        //
        // mistakeButton
        //
        mistakeButton.Badge = "7";
        mistakeButton.BorderVisible = false;
        mistakeButton.Dock = DockStyle.Fill;
        mistakeButton.Font = new Font("Segoe UI", 10.5F);
        mistakeButton.ForeColor = Color.FromArgb(51, 65, 85);
        mistakeButton.IconName = "book";
        mistakeButton.IconSize = 16;
        mistakeButton.Margin = new Padding(0, 0, 0, 4);
        mistakeButton.Name = "mistakeButton";
        mistakeButton.Size = new Size(207, 38);
        mistakeButton.TabIndex = 8;
        mistakeButton.Text = "Sổ lỗi";
        mistakeButton.TextAlign = ContentAlignment.MiddleLeft;
        mistakeButton.Click += mistakeButton_Click;
        //
        // competeGroupLabel
        //
        competeGroupLabel.Dock = DockStyle.Fill;
        competeGroupLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        competeGroupLabel.ForeColor = Color.FromArgb(93, 105, 125);
        competeGroupLabel.LetterSpacing = 1.2F;
        competeGroupLabel.Margin = new Padding(14, 8, 0, 0);
        competeGroupLabel.Name = "competeGroupLabel";
        competeGroupLabel.Size = new Size(193, 20);
        competeGroupLabel.TabIndex = 9;
        competeGroupLabel.Text = "THI ĐUA";
        competeGroupLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // challengeButton
        //
        challengeButton.BorderVisible = false;
        challengeButton.Dock = DockStyle.Fill;
        challengeButton.Font = new Font("Segoe UI", 10.5F);
        challengeButton.ForeColor = Color.FromArgb(51, 65, 85);
        challengeButton.IconName = "challenge";
        challengeButton.IconSize = 16;
        challengeButton.Margin = new Padding(0, 0, 0, 4);
        challengeButton.Name = "challengeButton";
        challengeButton.Size = new Size(207, 38);
        challengeButton.TabIndex = 10;
        challengeButton.Text = "Thử thách";
        challengeButton.TextAlign = ContentAlignment.MiddleLeft;
        challengeButton.Click += challengeButton_Click;
        //
        // rushButton
        //
        rushButton.BorderVisible = false;
        rushButton.Dock = DockStyle.Fill;
        rushButton.Font = new Font("Segoe UI", 10.5F);
        rushButton.ForeColor = Color.FromArgb(51, 65, 85);
        rushButton.IconName = "rush";
        rushButton.IconSize = 16;
        rushButton.Margin = new Padding(0, 0, 0, 4);
        rushButton.Name = "rushButton";
        rushButton.Size = new Size(207, 38);
        rushButton.TabIndex = 11;
        rushButton.Text = "Đua từ";
        rushButton.TextAlign = ContentAlignment.MiddleLeft;
        rushButton.Click += rushButton_Click;
        //
        // leaderboardButton
        //
        leaderboardButton.BorderVisible = false;
        leaderboardButton.Dock = DockStyle.Fill;
        leaderboardButton.Font = new Font("Segoe UI", 10.5F);
        leaderboardButton.ForeColor = Color.FromArgb(51, 65, 85);
        leaderboardButton.IconName = "trophy";
        leaderboardButton.IconSize = 16;
        leaderboardButton.Margin = new Padding(0, 0, 0, 4);
        leaderboardButton.Name = "leaderboardButton";
        leaderboardButton.Size = new Size(207, 38);
        leaderboardButton.TabIndex = 12;
        leaderboardButton.Text = "Bảng xếp hạng";
        leaderboardButton.TextAlign = ContentAlignment.MiddleLeft;
        leaderboardButton.Click += leaderboardButton_Click;
        //
        // matchButton
        //
        matchButton.Badge = "TÙY CHỌN";
        matchButton.BadgeColor = Color.FromArgb(55, 48, 163);
        matchButton.BorderVisible = false;
        matchButton.Dock = DockStyle.Fill;
        matchButton.Font = new Font("Segoe UI", 10.5F);
        matchButton.ForeColor = Color.FromArgb(51, 65, 85);
        matchButton.IconName = "match";
        matchButton.IconSize = 16;
        matchButton.Margin = new Padding(0, 0, 0, 4);
        matchButton.Name = "matchButton";
        matchButton.Size = new Size(207, 38);
        matchButton.TabIndex = 13;
        matchButton.Text = "Ghép cặp";
        matchButton.TextAlign = ContentAlignment.MiddleLeft;
        matchButton.Click += matchButton_Click;
        //
        // adminGroupLabel
        //
        adminGroupLabel.Dock = DockStyle.Fill;
        adminGroupLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        adminGroupLabel.ForeColor = Color.FromArgb(93, 105, 125);
        adminGroupLabel.LetterSpacing = 1.2F;
        adminGroupLabel.Margin = new Padding(14, 8, 0, 0);
        adminGroupLabel.Name = "adminGroupLabel";
        adminGroupLabel.Size = new Size(193, 20);
        adminGroupLabel.TabIndex = 14;
        adminGroupLabel.Text = "QUẢN TRỊ";
        adminGroupLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // adminButton
        //
        adminButton.BorderVisible = false;
        adminButton.Dock = DockStyle.Fill;
        adminButton.Font = new Font("Segoe UI", 10.5F);
        adminButton.ForeColor = Color.FromArgb(51, 65, 85);
        adminButton.IconName = "admin";
        adminButton.IconSize = 16;
        adminButton.Margin = new Padding(0, 0, 0, 4);
        adminButton.Name = "adminButton";
        adminButton.Size = new Size(207, 38);
        adminButton.TabIndex = 15;
        adminButton.Text = "Quản trị";
        adminButton.TextAlign = ContentAlignment.MiddleLeft;
        adminButton.Click += adminButton_Click;
        //
        // userPanel
        //
        userPanel.Controls.Add(avatarBox);
        userPanel.Controls.Add(userLabel);
        userPanel.Controls.Add(logoutButton);
        userPanel.Dock = DockStyle.Fill;
        userPanel.Margin = new Padding(0);
        userPanel.Name = "userPanel";
        userPanel.Size = new Size(207, 52);
        userPanel.TabIndex = 17;
        //
        // avatarBox
        //
        avatarBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        avatarBox.Location = new Point(4, 10);
        avatarBox.Name = "avatarBox";
        avatarBox.Size = new Size(32, 32);
        avatarBox.TabIndex = 0;
        avatarBox.Text = "lan";
        //
        // userLabel
        //
        userLabel.Font = new Font("Segoe UI", 9F);
        userLabel.ForeColor = Color.FromArgb(15, 23, 42);
        userLabel.Location = new Point(42, 6);
        userLabel.Name = "userLabel";
        userLabel.Size = new Size(78, 40);
        userLabel.TabIndex = 1;
        userLabel.Text = "lan\nUser";
        userLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // logoutButton
        //
        logoutButton.Font = new Font("Segoe UI", 9F);
        logoutButton.ForeColor = Color.FromArgb(51, 65, 85);
        logoutButton.Location = new Point(122, 11);
        logoutButton.Name = "logoutButton";
        logoutButton.Size = new Size(85, 30);
        logoutButton.TabIndex = 2;
        logoutButton.Text = "Đăng xuất";
        logoutButton.Click += logoutButton_Click;
        //
        // menuBorder
        //
        menuBorder.BackColor = Color.FromArgb(226, 232, 240);
        menuBorder.Dock = DockStyle.Left;
        menuBorder.Location = new Point(239, 0);
        menuBorder.Name = "menuBorder";
        menuBorder.Size = new Size(1, 800);
        menuBorder.TabIndex = 1;
        //
        // contentPanel
        //
        contentPanel.BackColor = Color.FromArgb(247, 249, 250);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(240, 0);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new Size(1040, 800);
        contentPanel.TabIndex = 2;
        //
        // MainWindow
        //
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(247, 249, 250);
        ClientSize = new Size(1280, 800);
        Controls.Add(contentPanel);
        Controls.Add(menuBorder);
        Controls.Add(menuPanel);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.FromArgb(15, 23, 42);
        MinimumSize = new Size(1100, 660);
        Name = "MainWindow";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Flashcards";
        Load += MainWindow_Load;
        menuPanel.ResumeLayout(false);
        menuLayout.ResumeLayout(false);
        brandPanel.ResumeLayout(false);
        userPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel menuPanel;
    private TableLayoutPanel menuLayout;
    private Panel brandPanel;
    private LogoBox logoPanel;
    private SpacedLabel brandLabel;
    private Label taglineLabel;
    private StudyButton overviewButton;
    private StudyButton courseButton;
    private StudyButton folderButton;
    private StudyButton studyButton;
    private StudyButton typeButton;
    private StudyButton mistakeButton;
    private StudyButton challengeButton;
    private StudyButton rushButton;
    private StudyButton leaderboardButton;
    private StudyButton matchButton;
    private StudyButton adminButton;
    private SpacedLabel learnGroupLabel;
    private SpacedLabel competeGroupLabel;
    private SpacedLabel adminGroupLabel;
    private Panel userPanel;
    private AvatarBox avatarBox;
    private Label userLabel;
    private StudyButton logoutButton;
    private Panel menuBorder;
    private Panel contentPanel;
}
