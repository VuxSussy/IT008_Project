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
        logoPanel = new Panel();
        brandLabel = new Label();
        taglineLabel = new Label();
        overviewButton = new StudyButton();
        folderButton = new StudyButton();
        studyButton = new StudyButton();
        typeButton = new StudyButton();
        mistakeButton = new StudyButton();
        matchButton = new StudyButton();
        savedLabel = new Label();
        menuBorder = new Panel();
        contentPanel = new Panel();
        menuPanel.SuspendLayout();
        menuLayout.SuspendLayout();
        brandPanel.SuspendLayout();
        SuspendLayout();
        //
        // menuPanel
        //
        menuPanel.BackColor = Color.White;
        menuPanel.Controls.Add(menuLayout);
        menuPanel.Dock = DockStyle.Left;
        menuPanel.Location = new Point(0, 0);
        menuPanel.Name = "menuPanel";
        menuPanel.Padding = new Padding(16, 24, 16, 24);
        menuPanel.Size = new Size(239, 800);
        menuPanel.TabIndex = 0;
        //
        // menuLayout
        //
        menuLayout.ColumnCount = 1;
        menuLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        menuLayout.Controls.Add(brandPanel, 0, 0);
        menuLayout.Controls.Add(overviewButton, 0, 1);
        menuLayout.Controls.Add(folderButton, 0, 2);
        menuLayout.Controls.Add(studyButton, 0, 3);
        menuLayout.Controls.Add(typeButton, 0, 4);
        menuLayout.Controls.Add(mistakeButton, 0, 5);
        menuLayout.Controls.Add(matchButton, 0, 6);
        menuLayout.Controls.Add(savedLabel, 0, 8);
        menuLayout.Dock = DockStyle.Fill;
        menuLayout.Location = new Point(16, 24);
        menuLayout.Margin = new Padding(0);
        menuLayout.Name = "menuLayout";
        menuLayout.RowCount = 9;
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        menuLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        menuLayout.Size = new Size(208, 752);
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
        brandPanel.Size = new Size(208, 80);
        brandPanel.TabIndex = 0;
        //
        // logoPanel
        //
        logoPanel.Location = new Point(8, 0);
        logoPanel.Name = "logoPanel";
        logoPanel.Size = new Size(34, 34);
        logoPanel.TabIndex = 0;
        logoPanel.Paint += logoPanel_Paint;
        //
        // brandLabel
        //
        brandLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        brandLabel.ForeColor = Color.FromArgb(15, 23, 42);
        brandLabel.Location = new Point(52, 0);
        brandLabel.Name = "brandLabel";
        brandLabel.Size = new Size(156, 20);
        brandLabel.TabIndex = 1;
        brandLabel.Text = "FLASHCARDS";
        brandLabel.TextAlign = ContentAlignment.MiddleLeft;
        brandLabel.Paint += brandLabel_Paint;
        //
        // taglineLabel
        //
        taglineLabel.Font = new Font("Segoe UI", 8.5F);
        taglineLabel.ForeColor = Color.FromArgb(51, 65, 85);
        taglineLabel.Location = new Point(52, 20);
        taglineLabel.Name = "taglineLabel";
        taglineLabel.Size = new Size(150, 34);
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
        overviewButton.Margin = new Padding(0, 0, 0, 6);
        overviewButton.Name = "overviewButton";
        overviewButton.Size = new Size(208, 41);
        overviewButton.TabIndex = 2;
        overviewButton.Text = "Tổng quan";
        overviewButton.TextAlign = ContentAlignment.MiddleLeft;
        overviewButton.Click += overviewButton_Click;
        //
        // folderButton
        //
        folderButton.BorderVisible = false;
        folderButton.Dock = DockStyle.Fill;
        folderButton.Font = new Font("Segoe UI", 10.5F);
        folderButton.ForeColor = Color.FromArgb(51, 65, 85);
        folderButton.IconName = "folder";
        folderButton.IconSize = 16;
        folderButton.Margin = new Padding(0, 0, 0, 6);
        folderButton.Name = "folderButton";
        folderButton.Size = new Size(208, 41);
        folderButton.TabIndex = 3;
        folderButton.Text = "Thư mục";
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
        studyButton.Margin = new Padding(0, 0, 0, 6);
        studyButton.Name = "studyButton";
        studyButton.Size = new Size(208, 41);
        studyButton.TabIndex = 4;
        studyButton.Text = "Học thẻ";
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
        typeButton.Margin = new Padding(0, 0, 0, 6);
        typeButton.Name = "typeButton";
        typeButton.Size = new Size(208, 41);
        typeButton.TabIndex = 5;
        typeButton.Text = "Gõ đáp án";
        typeButton.TextAlign = ContentAlignment.MiddleLeft;
        typeButton.Click += typeButton_Click;
        //
        // mistakeButton
        //
        mistakeButton.BorderVisible = false;
        mistakeButton.Dock = DockStyle.Fill;
        mistakeButton.Font = new Font("Segoe UI", 10.5F);
        mistakeButton.ForeColor = Color.FromArgb(51, 65, 85);
        mistakeButton.IconName = "book";
        mistakeButton.IconSize = 16;
        mistakeButton.Margin = new Padding(0, 0, 0, 6);
        mistakeButton.Name = "mistakeButton";
        mistakeButton.Size = new Size(208, 41);
        mistakeButton.TabIndex = 6;
        mistakeButton.Text = "Sổ lỗi";
        mistakeButton.TextAlign = ContentAlignment.MiddleLeft;
        mistakeButton.Click += mistakeButton_Click;
        //
        // matchButton
        //
        matchButton.Badge = "MỚI";
        matchButton.BadgeColor = Color.FromArgb(55, 48, 163);
        matchButton.BorderVisible = false;
        matchButton.Dock = DockStyle.Fill;
        matchButton.Font = new Font("Segoe UI", 10.5F);
        matchButton.ForeColor = Color.FromArgb(51, 65, 85);
        matchButton.IconName = "match";
        matchButton.IconSize = 16;
        matchButton.Margin = new Padding(0, 0, 0, 6);
        matchButton.Name = "matchButton";
        matchButton.Size = new Size(208, 41);
        matchButton.TabIndex = 7;
        matchButton.Text = "Ghép cặp";
        matchButton.TextAlign = ContentAlignment.MiddleLeft;
        matchButton.Click += matchButton_Click;
        //
        // savedLabel
        //
        savedLabel.BackColor = Color.FromArgb(241, 245, 249);
        savedLabel.Dock = DockStyle.Fill;
        savedLabel.Font = new Font("Segoe UI", 9F);
        savedLabel.ForeColor = Color.FromArgb(51, 65, 85);
        savedLabel.Margin = new Padding(0);
        savedLabel.Name = "savedLabel";
        savedLabel.Size = new Size(208, 36);
        savedLabel.TabIndex = 8;
        savedLabel.Text = "Đã lưu vào máy";
        savedLabel.TextAlign = ContentAlignment.MiddleLeft;
        savedLabel.Paint += savedLabel_Paint;
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
        ResumeLayout(false);
    }

    #endregion

    private Panel menuPanel;
    private TableLayoutPanel menuLayout;
    private Panel brandPanel;
    private Panel logoPanel;
    private Label brandLabel;
    private Label taglineLabel;
    private StudyButton overviewButton;
    private StudyButton folderButton;
    private StudyButton studyButton;
    private StudyButton typeButton;
    private StudyButton mistakeButton;
    private StudyButton matchButton;
    private Label savedLabel;
    private Panel menuBorder;
    private Panel contentPanel;
}
