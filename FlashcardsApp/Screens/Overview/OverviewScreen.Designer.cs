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
        components = new System.ComponentModel.Container();
        feedPanel = new FlowLayoutPanel();
        headerPanel = new Panel();
        avatarBox = new AvatarBox();
        greetingLabel = new Label();
        dateLabel = new Label();
        streakLabel = new ChipLabel();
        ratingLabel = new ChipLabel();
        seasonBanner = new CardPanel();
        seasonLabel = new Label();
        studyNowButton = new StudyButton();
        challengePanel = new CardPanel();
        challengeTitleLabel = new SpacedLabel();
        challengeInfoLabel = new Label();
        challengeDetailLabel = new Label();
        challengeButton = new StudyButton();
        rowsPanel = new CardPanel();
        progressRow = new HomeRow();
        courseRow = new HomeRow();
        rushRow = new HomeRow();
        mistakeRow = new HomeRow();
        rankRow = new HomeRow();
        toolTip = new ToolTip(components);
        feedPanel.SuspendLayout();
        headerPanel.SuspendLayout();
        seasonBanner.SuspendLayout();
        challengePanel.SuspendLayout();
        rowsPanel.SuspendLayout();
        SuspendLayout();
        //
        // feedPanel
        //
        feedPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        feedPanel.AutoScroll = true;
        feedPanel.Controls.Add(headerPanel);
        feedPanel.Controls.Add(seasonBanner);
        feedPanel.Controls.Add(studyNowButton);
        feedPanel.Controls.Add(challengePanel);
        feedPanel.Controls.Add(rowsPanel);
        feedPanel.FlowDirection = FlowDirection.TopDown;
        feedPanel.Location = new Point(190, 24);
        feedPanel.Margin = new Padding(0);
        feedPanel.Name = "feedPanel";
        feedPanel.Size = new Size(660, 752);
        feedPanel.TabIndex = 0;
        feedPanel.WrapContents = false;
        //
        // headerPanel
        //
        headerPanel.Controls.Add(avatarBox);
        headerPanel.Controls.Add(greetingLabel);
        headerPanel.Controls.Add(dateLabel);
        headerPanel.Controls.Add(streakLabel);
        headerPanel.Controls.Add(ratingLabel);
        headerPanel.Margin = new Padding(0, 0, 0, 14);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new Size(640, 56);
        headerPanel.TabIndex = 0;
        //
        // avatarBox
        //
        avatarBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        avatarBox.Location = new Point(0, 5);
        avatarBox.Name = "avatarBox";
        avatarBox.Size = new Size(46, 46);
        avatarBox.TabIndex = 0;
        avatarBox.Text = "lan";
        //
        // greetingLabel
        //
        greetingLabel.AutoEllipsis = true;
        greetingLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        greetingLabel.ForeColor = Color.FromArgb(15, 23, 42);
        greetingLabel.Location = new Point(58, 2);
        greetingLabel.Name = "greetingLabel";
        greetingLabel.Size = new Size(380, 32);
        greetingLabel.TabIndex = 1;
        greetingLabel.Text = "Chào lan";
        greetingLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // dateLabel
        //
        dateLabel.Font = new Font("Segoe UI", 10F);
        dateLabel.ForeColor = Color.FromArgb(51, 65, 85);
        dateLabel.Location = new Point(58, 33);
        dateLabel.Name = "dateLabel";
        dateLabel.Size = new Size(380, 20);
        dateLabel.TabIndex = 2;
        dateLabel.Text = "Thứ hai, 14/12 · hôm nay học gì?";
        dateLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // streakLabel
        //
        streakLabel.BackColor = Color.FromArgb(255, 247, 224);
        streakLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        streakLabel.ForeColor = Color.FromArgb(183, 121, 31);
        streakLabel.IconName = "flame";
        streakLabel.Location = new Point(456, 12);
        streakLabel.Name = "streakLabel";
        streakLabel.Size = new Size(76, 32);
        streakLabel.TabIndex = 3;
        streakLabel.Text = "6";
        //
        // ratingLabel
        //
        ratingLabel.BackColor = Color.FromArgb(227, 233, 251);
        ratingLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        ratingLabel.ForeColor = Color.FromArgb(30, 58, 138);
        ratingLabel.IconColor = Color.FromArgb(30, 58, 138);
        ratingLabel.IconName = "star";
        ratingLabel.Location = new Point(540, 12);
        ratingLabel.Name = "ratingLabel";
        ratingLabel.Size = new Size(100, 32);
        ratingLabel.TabIndex = 4;
        ratingLabel.Text = "1010";
        //
        // seasonBanner
        //
        seasonBanner.BackColor = Color.FromArgb(19, 84, 78);
        seasonBanner.BorderVisible = false;
        seasonBanner.Controls.Add(seasonLabel);
        seasonBanner.Cursor = Cursors.Hand;
        seasonBanner.Margin = new Padding(0, 0, 0, 14);
        seasonBanner.Name = "seasonBanner";
        seasonBanner.Padding = new Padding(16, 0, 16, 0);
        seasonBanner.Size = new Size(640, 46);
        seasonBanner.TabIndex = 1;
        seasonBanner.Click += seasonBanner_Click;
        //
        // seasonLabel
        //
        seasonLabel.Dock = DockStyle.Fill;
        seasonLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        seasonLabel.ForeColor = Color.White;
        seasonLabel.Name = "seasonLabel";
        seasonLabel.Size = new Size(608, 46);
        seasonLabel.TabIndex = 0;
        seasonLabel.Text = "Sự kiện Giáng sinh · còn 17 ngày · 10 từ";
        seasonLabel.TextAlign = ContentAlignment.MiddleLeft;
        seasonLabel.Click += seasonBanner_Click;
        //
        // studyNowButton
        //
        studyNowButton.BackColor = Color.FromArgb(15, 118, 110);
        studyNowButton.BorderVisible = false;
        studyNowButton.CornerRadius = 14;
        studyNowButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        studyNowButton.ForeColor = Color.White;
        studyNowButton.IconName = "cards";
        studyNowButton.Margin = new Padding(0, 0, 0, 14);
        studyNowButton.Name = "studyNowButton";
        studyNowButton.Size = new Size(640, 60);
        studyNowButton.TabIndex = 2;
        studyNowButton.Text = "Học ngay · 18 từ chưa thuộc";
        studyNowButton.Click += studyNowButton_Click;
        //
        // challengePanel
        //
        challengePanel.BackColor = Color.White;
        challengePanel.Controls.Add(challengeTitleLabel);
        challengePanel.Controls.Add(challengeInfoLabel);
        challengePanel.Controls.Add(challengeDetailLabel);
        challengePanel.Controls.Add(challengeButton);
        challengePanel.Margin = new Padding(0, 0, 0, 14);
        challengePanel.Name = "challengePanel";
        challengePanel.Size = new Size(640, 132);
        challengePanel.TabIndex = 3;
        //
        // challengeTitleLabel
        //
        challengeTitleLabel.BackColor = Color.White;
        challengeTitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        challengeTitleLabel.ForeColor = Color.FromArgb(15, 118, 110);
        challengeTitleLabel.LetterSpacing = 1.2F;
        challengeTitleLabel.Location = new Point(22, 18);
        challengeTitleLabel.Name = "challengeTitleLabel";
        challengeTitleLabel.Size = new Size(300, 20);
        challengeTitleLabel.TabIndex = 0;
        challengeTitleLabel.Text = "THỬ THÁCH HÔM NAY";
        //
        // challengeInfoLabel
        //
        challengeInfoLabel.AutoEllipsis = true;
        challengeInfoLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        challengeInfoLabel.ForeColor = Color.FromArgb(15, 23, 42);
        challengeInfoLabel.Location = new Point(22, 42);
        challengeInfoLabel.Name = "challengeInfoLabel";
        challengeInfoLabel.Size = new Size(420, 34);
        challengeInfoLabel.TabIndex = 1;
        challengeInfoLabel.Text = "10 từ · 14/12";
        challengeInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // challengeDetailLabel
        //
        challengeDetailLabel.AutoEllipsis = true;
        challengeDetailLabel.Font = new Font("Segoe UI", 9.5F);
        challengeDetailLabel.ForeColor = Color.FromArgb(51, 65, 85);
        challengeDetailLabel.Location = new Point(22, 80);
        challengeDetailLabel.Name = "challengeDetailLabel";
        challengeDetailLabel.Size = new Size(420, 22);
        challengeDetailLabel.TabIndex = 2;
        challengeDetailLabel.Text = "Mỗi người một lượt · 3 người đã làm · cao nhất 9/10";
        challengeDetailLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // challengeButton
        //
        challengeButton.BackColor = Color.FromArgb(15, 118, 110);
        challengeButton.BorderVisible = false;
        challengeButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        challengeButton.ForeColor = Color.White;
        challengeButton.Location = new Point(478, 45);
        challengeButton.Name = "challengeButton";
        challengeButton.Size = new Size(140, 42);
        challengeButton.TabIndex = 3;
        challengeButton.Text = "Làm ngay";
        challengeButton.Click += challengeButton_Click;
        //
        // rowsPanel
        //
        rowsPanel.BackColor = Color.White;
        rowsPanel.Controls.Add(rankRow);
        rowsPanel.Controls.Add(mistakeRow);
        rowsPanel.Controls.Add(rushRow);
        rowsPanel.Controls.Add(courseRow);
        rowsPanel.Controls.Add(progressRow);
        rowsPanel.Margin = new Padding(0);
        rowsPanel.Name = "rowsPanel";
        rowsPanel.Padding = new Padding(4, 6, 4, 6);
        rowsPanel.Size = new Size(640, 322);
        rowsPanel.TabIndex = 4;
        //
        // progressRow
        //
        progressRow.Detail = "12/30 từ đã nhớ · 4 thư mục";
        progressRow.DividerVisible = false;
        progressRow.Dock = DockStyle.Top;
        progressRow.Name = "progressRow";
        progressRow.Percent = 40;
        progressRow.Size = new Size(632, 62);
        progressRow.TabIndex = 0;
        progressRow.Text = "Tiến độ ghi nhớ";
        progressRow.Value = "40%";
        progressRow.Click += progressRow_Click;
        //
        // courseRow
        //
        courseRow.Detail = "Tiếng Anh hằng ngày";
        courseRow.Dock = DockStyle.Top;
        courseRow.IconName = "course";
        courseRow.Name = "courseRow";
        courseRow.Size = new Size(632, 62);
        courseRow.TabIndex = 1;
        courseRow.Text = "Học tiếp: Bài 2 · At work";
        courseRow.Value = "6/10";
        courseRow.Click += courseRow_Click;
        //
        // rushRow
        //
        rushRow.Detail = "3 phút · 3 mạng";
        rushRow.Dock = DockStyle.Top;
        rushRow.IconBackColor = Color.FromArgb(255, 237, 222);
        rushRow.IconColor = Color.FromArgb(194, 65, 12);
        rushRow.IconName = "rush";
        rushRow.Name = "rushRow";
        rushRow.Size = new Size(632, 62);
        rushRow.TabIndex = 2;
        rushRow.Text = "Đua từ";
        rushRow.Value = "Kỷ lục 19";
        rushRow.Click += rushRow_Click;
        //
        // mistakeRow
        //
        mistakeRow.Detail = "Gõ sai hoặc chọn Quên, Khó";
        mistakeRow.Dock = DockStyle.Top;
        mistakeRow.IconBackColor = Color.FromArgb(255, 237, 222);
        mistakeRow.IconColor = Color.FromArgb(194, 65, 12);
        mistakeRow.IconName = "book";
        mistakeRow.Name = "mistakeRow";
        mistakeRow.Size = new Size(632, 62);
        mistakeRow.TabIndex = 3;
        mistakeRow.Text = "Sổ lỗi";
        mistakeRow.Value = "7 từ";
        mistakeRow.Click += mistakeRow_Click;
        //
        // rankRow
        //
        rankRow.Detail = "Thử thách hôm nay";
        rankRow.Dock = DockStyle.Top;
        rankRow.IconBackColor = Color.FromArgb(227, 233, 251);
        rankRow.IconColor = Color.FromArgb(30, 58, 138);
        rankRow.IconName = "trophy";
        rankRow.Name = "rankRow";
        rankRow.Size = new Size(632, 62);
        rankRow.TabIndex = 4;
        rankRow.Text = "Bảng xếp hạng";
        rankRow.Value = "Hạng 2";
        rankRow.Click += rankRow_Click;
        //
        // OverviewScreen
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 249, 250);
        Controls.Add(feedPanel);
        Font = new Font("Segoe UI", 9F);
        Name = "OverviewScreen";
        Size = new Size(1040, 800);
        Load += OverviewScreen_Load;
        feedPanel.ResumeLayout(false);
        headerPanel.ResumeLayout(false);
        seasonBanner.ResumeLayout(false);
        challengePanel.ResumeLayout(false);
        rowsPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel feedPanel;
    private Panel headerPanel;
    private AvatarBox avatarBox;
    private Label greetingLabel;
    private Label dateLabel;
    private ChipLabel streakLabel;
    private ChipLabel ratingLabel;
    private CardPanel seasonBanner;
    private Label seasonLabel;
    private StudyButton studyNowButton;
    private CardPanel challengePanel;
    private SpacedLabel challengeTitleLabel;
    private Label challengeInfoLabel;
    private Label challengeDetailLabel;
    private StudyButton challengeButton;
    private CardPanel rowsPanel;
    private HomeRow progressRow;
    private HomeRow courseRow;
    private HomeRow rushRow;
    private HomeRow mistakeRow;
    private HomeRow rankRow;
    private ToolTip toolTip;
}
