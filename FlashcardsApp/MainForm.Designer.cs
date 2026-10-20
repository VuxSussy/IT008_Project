namespace FlashcardsApp;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        root = new TableLayoutPanel();
        sidebar = new TableLayoutPanel();
        brand = new TableLayoutPanel();
        brandLabel = new Label();
        taglineLabel = new Label();
        overviewButton = new Button();
        libraryButton = new Button();
        reviewButton = new Button();
        mistakesButton = new Button();
        statisticsButton = new Button();
        settingsButton = new Button();
        savedLabel = new Label();
        mainHost = new Panel();
        reviewLayout = new TableLayoutPanel();
        reviewHeader = new TableLayoutPanel();
        titleLabel = new Label();
        subtitleLabel = new Label();
        finishButton = new Button();
        progressRow = new TableLayoutPanel();
        counterLabel = new Label();
        progressTrack = new Panel();
        remainingLabel = new Label();
        previousButton = new Button();
        nextButton = new Button();
        cardSurface = new Panel();
        cardLayout = new TableLayoutPanel();
        cardToolbar = new TableLayoutPanel();
        categoryLabel = new Label();
        speakButton = new Button();
        wordLabel = new Label();
        pronunciationLabel = new Label();
        divider = new Panel();
        meaningLabel = new Label();
        exampleLabel = new Label();
        translationLabel = new Label();
        flipButton = new Button();
        ratingPromptLabel = new Label();
        ratings = new TableLayoutPanel();
        againButton = new Button();
        hardButton = new Button();
        goodButton = new Button();
        easyButton = new Button();
        shortcutLabel = new Label();
        catalogLayout = new TableLayoutPanel();
        catalogTitle = new Label();
        catalogSubtitle = new Label();
        summaryStrip = new TableLayoutPanel();
        totalMetric = new Label();
        learnedMetric = new Label();
        practiceMetric = new Label();
        cardsGrid = new DataGridView();
        catalogActions = new TableLayoutPanel();
        addButton = new Button();
        startReviewButton = new Button();
        rightSidebar = new TableLayoutPanel();
        mistakeSurface = new Panel();
        mistakeLayout = new TableLayoutPanel();
        mistakeTitle = new Label();
        mistakeSubtitle = new Label();
        mistakeTag = new Label();
        wrongLabel = new Label();
        correctLabel = new Label();
        mistakeNote = new Label();
        retryButton = new Button();
        sessionLayout = new TableLayoutPanel();
        sessionTitle = new Label();
        reviewedRow = new TableLayoutPanel();
        reviewedRowCaption = new Label();
        reviewedRowValue = new Label();
        rememberedRow = new TableLayoutPanel();
        rememberedRowCaption = new Label();
        rememberedRowValue = new Label();
        practiceRow = new TableLayoutPanel();
        practiceRowCaption = new Label();
        practiceRowValue = new Label();
        scheduleNote = new Label();
        root.SuspendLayout();
        sidebar.SuspendLayout();
        brand.SuspendLayout();
        mainHost.SuspendLayout();
        reviewLayout.SuspendLayout();
        reviewHeader.SuspendLayout();
        progressRow.SuspendLayout();
        cardSurface.SuspendLayout();
        cardLayout.SuspendLayout();
        cardToolbar.SuspendLayout();
        ratings.SuspendLayout();
        catalogLayout.SuspendLayout();
        summaryStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cardsGrid).BeginInit();
        catalogActions.SuspendLayout();
        rightSidebar.SuspendLayout();
        mistakeSurface.SuspendLayout();
        mistakeLayout.SuspendLayout();
        sessionLayout.SuspendLayout();
        reviewedRow.SuspendLayout();
        rememberedRow.SuspendLayout();
        practiceRow.SuspendLayout();
        SuspendLayout();
        // 
        // root
        // 
        root.BackColor = Color.FromArgb(250, 251, 252);
        root.ColumnCount = 3;
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 232F));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 316F));
        root.Controls.Add(sidebar, 0, 0);
        root.Controls.Add(mainHost, 1, 0);
        root.Controls.Add(rightSidebar, 2, 0);
        root.Dock = DockStyle.Fill;
        root.Location = new Point(0, 0);
        root.Margin = new Padding(0);
        root.Name = "root";
        root.RowCount = 1;
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        root.Size = new Size(1919, 1253);
        root.TabIndex = 1;
        // 
        // sidebar
        // 
        sidebar.BackColor = Color.White;
        sidebar.ColumnCount = 1;
        sidebar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        sidebar.Controls.Add(brand, 0, 0);
        sidebar.Controls.Add(overviewButton, 0, 1);
        sidebar.Controls.Add(libraryButton, 0, 2);
        sidebar.Controls.Add(reviewButton, 0, 3);
        sidebar.Controls.Add(mistakesButton, 0, 4);
        sidebar.Controls.Add(statisticsButton, 0, 5);
        sidebar.Controls.Add(settingsButton, 0, 7);
        sidebar.Controls.Add(savedLabel, 0, 8);
        sidebar.Dock = DockStyle.Fill;
        sidebar.Location = new Point(0, 0);
        sidebar.Margin = new Padding(0);
        sidebar.Name = "sidebar";
        sidebar.Padding = new Padding(10, 12, 10, 12);
        sidebar.RowCount = 9;
        sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
        sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        sidebar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        sidebar.Size = new Size(232, 1253);
        sidebar.TabIndex = 2;
        // 
        // brand
        // 
        brand.ColumnCount = 1;
        brand.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        brand.Controls.Add(brandLabel, 0, 0);
        brand.Controls.Add(taglineLabel, 0, 1);
        brand.Dock = DockStyle.Fill;
        brand.Location = new Point(10, 12);
        brand.Margin = new Padding(0);
        brand.Name = "brand";
        brand.Padding = new Padding(14, 8, 0, 0);
        brand.RowCount = 2;
        brand.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        brand.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        brand.Size = new Size(212, 92);
        brand.TabIndex = 3;
        // 
        // brandLabel
        // 
        brandLabel.AutoEllipsis = true;
        brandLabel.Dock = DockStyle.Fill;
        brandLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        brandLabel.ForeColor = Color.FromArgb(15, 23, 42);
        brandLabel.Location = new Point(14, 8);
        brandLabel.Margin = new Padding(0);
        brandLabel.Name = "brandLabel";
        brandLabel.Size = new Size(198, 42);
        brandLabel.TabIndex = 4;
        brandLabel.Text = "FLASHCARDS";
        brandLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // taglineLabel
        // 
        taglineLabel.AutoEllipsis = true;
        taglineLabel.Dock = DockStyle.Fill;
        taglineLabel.Font = new Font("Segoe UI", 9F);
        taglineLabel.ForeColor = Color.FromArgb(93, 105, 125);
        taglineLabel.Location = new Point(14, 50);
        taglineLabel.Margin = new Padding(0);
        taglineLabel.Name = "taglineLabel";
        taglineLabel.Size = new Size(198, 42);
        taglineLabel.TabIndex = 5;
        taglineLabel.Text = "Học từng chút, nhớ thật lâu.";
        taglineLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // overviewButton
        // 
        overviewButton.BackColor = Color.White;
        overviewButton.Cursor = Cursors.Hand;
        overviewButton.Dock = DockStyle.Fill;
        overviewButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        overviewButton.FlatAppearance.BorderSize = 0;
        overviewButton.FlatStyle = FlatStyle.Flat;
        overviewButton.Font = new Font("Segoe UI", 12F);
        overviewButton.Location = new Point(10, 107);
        overviewButton.Margin = new Padding(0, 3, 0, 3);
        overviewButton.Name = "overviewButton";
        overviewButton.Size = new Size(212, 52);
        overviewButton.TabIndex = 6;
        overviewButton.Tag = "overview";
        overviewButton.Text = "Tổng quan";
        overviewButton.TextAlign = ContentAlignment.MiddleLeft;
        overviewButton.UseVisualStyleBackColor = false;
        overviewButton.Click += Navigation_Click;
        // 
        // libraryButton
        // 
        libraryButton.BackColor = Color.White;
        libraryButton.Cursor = Cursors.Hand;
        libraryButton.Dock = DockStyle.Fill;
        libraryButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        libraryButton.FlatAppearance.BorderSize = 0;
        libraryButton.FlatStyle = FlatStyle.Flat;
        libraryButton.Font = new Font("Segoe UI", 12F);
        libraryButton.Location = new Point(10, 165);
        libraryButton.Margin = new Padding(0, 3, 0, 3);
        libraryButton.Name = "libraryButton";
        libraryButton.Size = new Size(212, 52);
        libraryButton.TabIndex = 7;
        libraryButton.Tag = "library";
        libraryButton.Text = "Bộ thẻ của tôi";
        libraryButton.TextAlign = ContentAlignment.MiddleLeft;
        libraryButton.UseVisualStyleBackColor = false;
        libraryButton.Click += Navigation_Click;
        // 
        // reviewButton
        // 
        reviewButton.BackColor = Color.FromArgb(227, 245, 241);
        reviewButton.Cursor = Cursors.Hand;
        reviewButton.Dock = DockStyle.Fill;
        reviewButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        reviewButton.FlatAppearance.BorderSize = 0;
        reviewButton.FlatStyle = FlatStyle.Flat;
        reviewButton.Font = new Font("Segoe UI", 12F);
        reviewButton.ForeColor = Color.FromArgb(0, 116, 122);
        reviewButton.Location = new Point(10, 223);
        reviewButton.Margin = new Padding(0, 3, 0, 3);
        reviewButton.Name = "reviewButton";
        reviewButton.Size = new Size(212, 52);
        reviewButton.TabIndex = 8;
        reviewButton.Tag = "review";
        reviewButton.Text = "Ôn tập";
        reviewButton.TextAlign = ContentAlignment.MiddleLeft;
        reviewButton.UseVisualStyleBackColor = false;
        reviewButton.Click += Navigation_Click;
        // 
        // mistakesButton
        // 
        mistakesButton.BackColor = Color.White;
        mistakesButton.Cursor = Cursors.Hand;
        mistakesButton.Dock = DockStyle.Fill;
        mistakesButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        mistakesButton.FlatAppearance.BorderSize = 0;
        mistakesButton.FlatStyle = FlatStyle.Flat;
        mistakesButton.Font = new Font("Segoe UI", 12F);
        mistakesButton.Location = new Point(10, 281);
        mistakesButton.Margin = new Padding(0, 3, 0, 3);
        mistakesButton.Name = "mistakesButton";
        mistakesButton.Size = new Size(212, 52);
        mistakesButton.TabIndex = 9;
        mistakesButton.Tag = "mistakes";
        mistakesButton.Text = "Sổ lỗi sai";
        mistakesButton.TextAlign = ContentAlignment.MiddleLeft;
        mistakesButton.UseVisualStyleBackColor = false;
        mistakesButton.Click += Navigation_Click;
        // 
        // statisticsButton
        // 
        statisticsButton.BackColor = Color.White;
        statisticsButton.Cursor = Cursors.Hand;
        statisticsButton.Dock = DockStyle.Fill;
        statisticsButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        statisticsButton.FlatAppearance.BorderSize = 0;
        statisticsButton.FlatStyle = FlatStyle.Flat;
        statisticsButton.Font = new Font("Segoe UI", 12F);
        statisticsButton.Location = new Point(10, 339);
        statisticsButton.Margin = new Padding(0, 3, 0, 3);
        statisticsButton.Name = "statisticsButton";
        statisticsButton.Size = new Size(212, 52);
        statisticsButton.TabIndex = 10;
        statisticsButton.Tag = "statistics";
        statisticsButton.Text = "Thống kê";
        statisticsButton.TextAlign = ContentAlignment.MiddleLeft;
        statisticsButton.UseVisualStyleBackColor = false;
        statisticsButton.Click += Navigation_Click;
        // 
        // settingsButton
        // 
        settingsButton.BackColor = Color.White;
        settingsButton.Cursor = Cursors.Hand;
        settingsButton.Dock = DockStyle.Fill;
        settingsButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        settingsButton.FlatAppearance.BorderSize = 0;
        settingsButton.FlatStyle = FlatStyle.Flat;
        settingsButton.Font = new Font("Segoe UI", 11F);
        settingsButton.Location = new Point(10, 1149);
        settingsButton.Margin = new Padding(0);
        settingsButton.Name = "settingsButton";
        settingsButton.Size = new Size(212, 52);
        settingsButton.TabIndex = 11;
        settingsButton.Text = "Cài đặt";
        settingsButton.TextAlign = ContentAlignment.MiddleLeft;
        settingsButton.UseVisualStyleBackColor = false;
        settingsButton.Click += SettingsButton_Click;
        // 
        // savedLabel
        // 
        savedLabel.AutoEllipsis = true;
        savedLabel.BackColor = Color.White;
        savedLabel.Dock = DockStyle.Fill;
        savedLabel.Font = new Font("Segoe UI", 10F);
        savedLabel.ForeColor = Color.FromArgb(0, 116, 122);
        savedLabel.Location = new Point(10, 1201);
        savedLabel.Margin = new Padding(0);
        savedLabel.Name = "savedLabel";
        savedLabel.Size = new Size(212, 40);
        savedLabel.TabIndex = 12;
        savedLabel.Text = "Lưu trên máy";
        savedLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // mainHost
        // 
        mainHost.Controls.Add(reviewLayout);
        mainHost.Controls.Add(catalogLayout);
        mainHost.Dock = DockStyle.Fill;
        mainHost.Location = new Point(232, 0);
        mainHost.Margin = new Padding(0);
        mainHost.Name = "mainHost";
        mainHost.Size = new Size(1371, 1253);
        mainHost.TabIndex = 13;
        // 
        // reviewLayout
        // 
        reviewLayout.ColumnCount = 1;
        reviewLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        reviewLayout.Controls.Add(reviewHeader, 0, 0);
        reviewLayout.Controls.Add(progressRow, 0, 1);
        reviewLayout.Controls.Add(cardSurface, 0, 2);
        reviewLayout.Controls.Add(ratingPromptLabel, 0, 3);
        reviewLayout.Controls.Add(ratings, 0, 4);
        reviewLayout.Controls.Add(shortcutLabel, 0, 5);
        reviewLayout.Dock = DockStyle.Fill;
        reviewLayout.Location = new Point(0, 0);
        reviewLayout.Margin = new Padding(0);
        reviewLayout.Name = "reviewLayout";
        reviewLayout.Padding = new Padding(26, 18, 20, 14);
        reviewLayout.RowCount = 6;
        reviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
        reviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        reviewLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        reviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        reviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
        reviewLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        reviewLayout.Size = new Size(1371, 1253);
        reviewLayout.TabIndex = 14;
        // 
        // reviewHeader
        // 
        reviewHeader.ColumnCount = 2;
        reviewHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        reviewHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132F));
        reviewHeader.Controls.Add(titleLabel, 0, 0);
        reviewHeader.Controls.Add(subtitleLabel, 0, 1);
        reviewHeader.Controls.Add(finishButton, 1, 0);
        reviewHeader.Dock = DockStyle.Fill;
        reviewHeader.Location = new Point(26, 18);
        reviewHeader.Margin = new Padding(0);
        reviewHeader.Name = "reviewHeader";
        reviewHeader.RowCount = 2;
        reviewHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        reviewHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        reviewHeader.Size = new Size(1325, 76);
        reviewHeader.TabIndex = 15;
        // 
        // titleLabel
        // 
        titleLabel.AutoEllipsis = true;
        titleLabel.Dock = DockStyle.Fill;
        titleLabel.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(15, 23, 42);
        titleLabel.Location = new Point(0, 0);
        titleLabel.Margin = new Padding(0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(1193, 42);
        titleLabel.TabIndex = 16;
        titleLabel.Text = "Ôn tập hôm nay";
        titleLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoEllipsis = true;
        subtitleLabel.Dock = DockStyle.Fill;
        subtitleLabel.Font = new Font("Segoe UI", 12F);
        subtitleLabel.ForeColor = Color.FromArgb(93, 105, 125);
        subtitleLabel.Location = new Point(0, 42);
        subtitleLabel.Margin = new Padding(0);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(1193, 34);
        subtitleLabel.TabIndex = 17;
        subtitleLabel.Text = "Tiếng Anh · Bộ thẻ của tôi";
        subtitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // finishButton
        // 
        finishButton.BackColor = Color.White;
        finishButton.Cursor = Cursors.Hand;
        finishButton.Dock = DockStyle.Fill;
        finishButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        finishButton.FlatStyle = FlatStyle.Flat;
        finishButton.Font = new Font("Segoe UI", 10F);
        finishButton.Location = new Point(1193, 6);
        finishButton.Margin = new Padding(0, 6, 0, 0);
        finishButton.Name = "finishButton";
        finishButton.Size = new Size(132, 36);
        finishButton.TabIndex = 18;
        finishButton.Text = "Kết thúc";
        finishButton.UseVisualStyleBackColor = false;
        finishButton.Click += FinishButton_Click;
        // 
        // progressRow
        // 
        progressRow.ColumnCount = 5;
        progressRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
        progressRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        progressRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
        progressRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
        progressRow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
        progressRow.Controls.Add(counterLabel, 0, 0);
        progressRow.Controls.Add(progressTrack, 1, 0);
        progressRow.Controls.Add(remainingLabel, 2, 0);
        progressRow.Controls.Add(previousButton, 3, 0);
        progressRow.Controls.Add(nextButton, 4, 0);
        progressRow.Dock = DockStyle.Fill;
        progressRow.Location = new Point(26, 94);
        progressRow.Margin = new Padding(0);
        progressRow.Name = "progressRow";
        progressRow.RowCount = 1;
        progressRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        progressRow.Size = new Size(1325, 42);
        progressRow.TabIndex = 19;
        // 
        // counterLabel
        // 
        counterLabel.AutoEllipsis = true;
        counterLabel.Dock = DockStyle.Fill;
        counterLabel.Font = new Font("Segoe UI", 11F);
        counterLabel.ForeColor = Color.FromArgb(15, 23, 42);
        counterLabel.Location = new Point(0, 0);
        counterLabel.Margin = new Padding(0);
        counterLabel.Name = "counterLabel";
        counterLabel.Size = new Size(92, 42);
        counterLabel.TabIndex = 20;
        counterLabel.Text = "Thẻ 1 / 5";
        counterLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // progressTrack
        // 
        progressTrack.Dock = DockStyle.Fill;
        progressTrack.Location = new Point(97, 0);
        progressTrack.Margin = new Padding(5, 0, 12, 0);
        progressTrack.Name = "progressTrack";
        progressTrack.Size = new Size(1056, 42);
        progressTrack.TabIndex = 21;
        // 
        // remainingLabel
        // 
        remainingLabel.AutoEllipsis = true;
        remainingLabel.Dock = DockStyle.Fill;
        remainingLabel.Font = new Font("Segoe UI", 10F);
        remainingLabel.ForeColor = Color.FromArgb(93, 105, 125);
        remainingLabel.Location = new Point(1165, 0);
        remainingLabel.Margin = new Padding(0);
        remainingLabel.Name = "remainingLabel";
        remainingLabel.Size = new Size(96, 42);
        remainingLabel.TabIndex = 22;
        remainingLabel.Text = "Còn 5 thẻ";
        remainingLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // previousButton
        // 
        previousButton.AccessibleName = "Thẻ trước";
        previousButton.BackColor = Color.White;
        previousButton.Cursor = Cursors.Hand;
        previousButton.Dock = DockStyle.Fill;
        previousButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        previousButton.FlatAppearance.BorderSize = 0;
        previousButton.FlatStyle = FlatStyle.Flat;
        previousButton.Font = new Font("Segoe UI", 11F);
        previousButton.Location = new Point(1261, 0);
        previousButton.Margin = new Padding(0);
        previousButton.Name = "previousButton";
        previousButton.Size = new Size(32, 42);
        previousButton.TabIndex = 23;
        previousButton.Text = "‹";
        previousButton.UseVisualStyleBackColor = false;
        previousButton.Click += PreviousButton_Click;
        // 
        // nextButton
        // 
        nextButton.AccessibleName = "Thẻ tiếp";
        nextButton.BackColor = Color.White;
        nextButton.Cursor = Cursors.Hand;
        nextButton.Dock = DockStyle.Fill;
        nextButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        nextButton.FlatAppearance.BorderSize = 0;
        nextButton.FlatStyle = FlatStyle.Flat;
        nextButton.Font = new Font("Segoe UI", 11F);
        nextButton.Location = new Point(1293, 0);
        nextButton.Margin = new Padding(0);
        nextButton.Name = "nextButton";
        nextButton.Size = new Size(32, 42);
        nextButton.TabIndex = 24;
        nextButton.Text = "›";
        nextButton.UseVisualStyleBackColor = false;
        nextButton.Click += NextButton_Click;
        // 
        // cardSurface
        // 
        cardSurface.BackColor = Color.White;
        cardSurface.BorderStyle = BorderStyle.FixedSingle;
        cardSurface.Controls.Add(cardLayout);
        cardSurface.Dock = DockStyle.Fill;
        cardSurface.Location = new Point(26, 144);
        cardSurface.Margin = new Padding(0, 8, 0, 0);
        cardSurface.Name = "cardSurface";
        cardSurface.Padding = new Padding(20, 12, 20, 14);
        cardSurface.Size = new Size(1325, 959);
        cardSurface.TabIndex = 25;
        // 
        // cardLayout
        // 
        cardLayout.ColumnCount = 1;
        cardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        cardLayout.Controls.Add(cardToolbar, 0, 0);
        cardLayout.Controls.Add(wordLabel, 0, 1);
        cardLayout.Controls.Add(pronunciationLabel, 0, 2);
        cardLayout.Controls.Add(divider, 0, 3);
        cardLayout.Controls.Add(meaningLabel, 0, 4);
        cardLayout.Controls.Add(exampleLabel, 0, 5);
        cardLayout.Controls.Add(translationLabel, 0, 6);
        cardLayout.Controls.Add(flipButton, 0, 7);
        cardLayout.Dock = DockStyle.Fill;
        cardLayout.Location = new Point(20, 12);
        cardLayout.Margin = new Padding(0);
        cardLayout.Name = "cardLayout";
        cardLayout.RowCount = 8;
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 31F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 27F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
        cardLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        cardLayout.Size = new Size(1283, 931);
        cardLayout.TabIndex = 26;
        // 
        // cardToolbar
        // 
        cardToolbar.ColumnCount = 3;
        cardToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        cardToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        cardToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
        cardToolbar.Controls.Add(categoryLabel, 0, 0);
        cardToolbar.Controls.Add(speakButton, 2, 0);
        cardToolbar.Dock = DockStyle.Fill;
        cardToolbar.Location = new Point(0, 0);
        cardToolbar.Margin = new Padding(0);
        cardToolbar.Name = "cardToolbar";
        cardToolbar.RowCount = 1;
        cardToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        cardToolbar.Size = new Size(1283, 40);
        cardToolbar.TabIndex = 27;
        // 
        // categoryLabel
        // 
        categoryLabel.AutoEllipsis = true;
        categoryLabel.BackColor = Color.FromArgb(227, 245, 241);
        categoryLabel.Dock = DockStyle.Fill;
        categoryLabel.Font = new Font("Segoe UI", 10F);
        categoryLabel.ForeColor = Color.FromArgb(0, 116, 122);
        categoryLabel.Location = new Point(0, 5);
        categoryLabel.Margin = new Padding(0, 5, 0, 5);
        categoryLabel.Name = "categoryLabel";
        categoryLabel.Size = new Size(110, 30);
        categoryLabel.TabIndex = 28;
        categoryLabel.Text = "CỤM TỪ";
        categoryLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // speakButton
        // 
        speakButton.AccessibleName = "Phát âm từ tiếng Anh";
        speakButton.BackColor = Color.White;
        speakButton.Cursor = Cursors.Hand;
        speakButton.Dock = DockStyle.Fill;
        speakButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        speakButton.FlatStyle = FlatStyle.Flat;
        speakButton.Font = new Font("Segoe UI", 11F);
        speakButton.Location = new Point(1239, 0);
        speakButton.Margin = new Padding(0);
        speakButton.Name = "speakButton";
        speakButton.Size = new Size(44, 40);
        speakButton.TabIndex = 29;
        speakButton.Text = "Loa";
        speakButton.UseVisualStyleBackColor = false;
        speakButton.Click += SpeakButton_Click;
        // 
        // wordLabel
        // 
        wordLabel.AutoEllipsis = true;
        wordLabel.Dock = DockStyle.Fill;
        wordLabel.Font = new Font("Segoe UI", 38F, FontStyle.Bold);
        wordLabel.ForeColor = Color.FromArgb(15, 23, 42);
        wordLabel.Location = new Point(0, 40);
        wordLabel.Margin = new Padding(0);
        wordLabel.Name = "wordLabel";
        wordLabel.Size = new Size(1283, 246);
        wordLabel.TabIndex = 30;
        wordLabel.Text = "make a decision";
        wordLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pronunciationLabel
        // 
        pronunciationLabel.AutoEllipsis = true;
        pronunciationLabel.Dock = DockStyle.Fill;
        pronunciationLabel.Font = new Font("Segoe UI", 17F);
        pronunciationLabel.ForeColor = Color.FromArgb(93, 105, 125);
        pronunciationLabel.Location = new Point(0, 286);
        pronunciationLabel.Margin = new Padding(0);
        pronunciationLabel.Name = "pronunciationLabel";
        pronunciationLabel.Size = new Size(1283, 32);
        pronunciationLabel.TabIndex = 31;
        pronunciationLabel.Text = "/meɪk ə dɪˈsɪʒən/";
        pronunciationLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // divider
        // 
        divider.BackColor = Color.FromArgb(224, 229, 235);
        divider.Dock = DockStyle.Fill;
        divider.Location = new Point(5, 326);
        divider.Margin = new Padding(5, 8, 5, 7);
        divider.Name = "divider";
        divider.Size = new Size(1273, 1);
        divider.TabIndex = 32;
        // 
        // meaningLabel
        // 
        meaningLabel.AutoEllipsis = true;
        meaningLabel.Dock = DockStyle.Fill;
        meaningLabel.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
        meaningLabel.ForeColor = Color.FromArgb(15, 23, 42);
        meaningLabel.Location = new Point(0, 334);
        meaningLabel.Margin = new Padding(0);
        meaningLabel.Name = "meaningLabel";
        meaningLabel.Size = new Size(1283, 190);
        meaningLabel.TabIndex = 33;
        meaningLabel.Text = "đưa ra quyết định";
        meaningLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // exampleLabel
        // 
        exampleLabel.AutoEllipsis = true;
        exampleLabel.Dock = DockStyle.Fill;
        exampleLabel.Font = new Font("Segoe UI", 18F);
        exampleLabel.ForeColor = Color.FromArgb(15, 23, 42);
        exampleLabel.Location = new Point(0, 524);
        exampleLabel.Margin = new Padding(0);
        exampleLabel.Name = "exampleLabel";
        exampleLabel.Size = new Size(1283, 214);
        exampleLabel.TabIndex = 34;
        exampleLabel.Text = "I need to make a decision today.";
        exampleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // translationLabel
        // 
        translationLabel.AutoEllipsis = true;
        translationLabel.Dock = DockStyle.Fill;
        translationLabel.Font = new Font("Segoe UI", 13F);
        translationLabel.ForeColor = Color.FromArgb(93, 105, 125);
        translationLabel.Location = new Point(0, 738);
        translationLabel.Margin = new Padding(0);
        translationLabel.Name = "translationLabel";
        translationLabel.Size = new Size(1283, 143);
        translationLabel.TabIndex = 35;
        translationLabel.Text = "Tôi cần đưa ra quyết định hôm nay.";
        translationLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // flipButton
        // 
        flipButton.BackColor = Color.FromArgb(227, 245, 241);
        flipButton.Cursor = Cursors.Hand;
        flipButton.Dock = DockStyle.Fill;
        flipButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        flipButton.FlatAppearance.BorderSize = 0;
        flipButton.FlatStyle = FlatStyle.Flat;
        flipButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        flipButton.ForeColor = Color.FromArgb(0, 116, 122);
        flipButton.Location = new Point(0, 881);
        flipButton.Margin = new Padding(0);
        flipButton.Name = "flipButton";
        flipButton.Size = new Size(1283, 50);
        flipButton.TabIndex = 36;
        flipButton.Text = "Hiện nghĩa · Space";
        flipButton.UseVisualStyleBackColor = false;
        flipButton.Click += FlipButton_Click;
        // 
        // ratingPromptLabel
        // 
        ratingPromptLabel.AutoEllipsis = true;
        ratingPromptLabel.Dock = DockStyle.Fill;
        ratingPromptLabel.Font = new Font("Segoe UI", 11F);
        ratingPromptLabel.ForeColor = Color.FromArgb(15, 23, 42);
        ratingPromptLabel.Location = new Point(26, 1103);
        ratingPromptLabel.Margin = new Padding(0);
        ratingPromptLabel.Name = "ratingPromptLabel";
        ratingPromptLabel.Size = new Size(1325, 32);
        ratingPromptLabel.TabIndex = 37;
        ratingPromptLabel.Text = "Bạn nhớ từ này ở mức nào?";
        ratingPromptLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ratings
        // 
        ratings.ColumnCount = 4;
        ratings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ratings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ratings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ratings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ratings.Controls.Add(againButton, 0, 0);
        ratings.Controls.Add(hardButton, 1, 0);
        ratings.Controls.Add(goodButton, 2, 0);
        ratings.Controls.Add(easyButton, 3, 0);
        ratings.Dock = DockStyle.Fill;
        ratings.Location = new Point(26, 1135);
        ratings.Margin = new Padding(0);
        ratings.Name = "ratings";
        ratings.RowCount = 1;
        ratings.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        ratings.Size = new Size(1325, 76);
        ratings.TabIndex = 38;
        // 
        // againButton
        // 
        againButton.BackColor = Color.FromArgb(255, 232, 233);
        againButton.Cursor = Cursors.Hand;
        againButton.Dock = DockStyle.Fill;
        againButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        againButton.FlatStyle = FlatStyle.Flat;
        againButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        againButton.ForeColor = Color.FromArgb(145, 27, 35);
        againButton.Location = new Point(0, 0);
        againButton.Margin = new Padding(0, 0, 5, 0);
        againButton.Name = "againButton";
        againButton.Size = new Size(326, 76);
        againButton.TabIndex = 39;
        againButton.Tag = 1;
        againButton.Text = "1  Quên\n1 phút";
        againButton.UseVisualStyleBackColor = false;
        againButton.Click += RatingButton_Click;
        // 
        // hardButton
        // 
        hardButton.BackColor = Color.FromArgb(255, 245, 222);
        hardButton.Cursor = Cursors.Hand;
        hardButton.Dock = DockStyle.Fill;
        hardButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        hardButton.FlatStyle = FlatStyle.Flat;
        hardButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        hardButton.ForeColor = Color.FromArgb(124, 79, 10);
        hardButton.Location = new Point(336, 0);
        hardButton.Margin = new Padding(5, 0, 5, 0);
        hardButton.Name = "hardButton";
        hardButton.Size = new Size(321, 76);
        hardButton.TabIndex = 40;
        hardButton.Tag = 2;
        hardButton.Text = "2  Khó\n10 phút";
        hardButton.UseVisualStyleBackColor = false;
        hardButton.Click += RatingButton_Click;
        // 
        // goodButton
        // 
        goodButton.BackColor = Color.FromArgb(227, 245, 241);
        goodButton.Cursor = Cursors.Hand;
        goodButton.Dock = DockStyle.Fill;
        goodButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        goodButton.FlatStyle = FlatStyle.Flat;
        goodButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        goodButton.ForeColor = Color.FromArgb(0, 116, 122);
        goodButton.Location = new Point(667, 0);
        goodButton.Margin = new Padding(5, 0, 5, 0);
        goodButton.Name = "goodButton";
        goodButton.Size = new Size(321, 76);
        goodButton.TabIndex = 41;
        goodButton.Tag = 3;
        goodButton.Text = "3  Nhớ\n1 ngày";
        goodButton.UseVisualStyleBackColor = false;
        goodButton.Click += RatingButton_Click;
        // 
        // easyButton
        // 
        easyButton.BackColor = Color.FromArgb(227, 246, 244);
        easyButton.Cursor = Cursors.Hand;
        easyButton.Dock = DockStyle.Fill;
        easyButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        easyButton.FlatStyle = FlatStyle.Flat;
        easyButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        easyButton.ForeColor = Color.FromArgb(0, 116, 122);
        easyButton.Location = new Point(998, 0);
        easyButton.Margin = new Padding(5, 0, 0, 0);
        easyButton.Name = "easyButton";
        easyButton.Size = new Size(327, 76);
        easyButton.TabIndex = 42;
        easyButton.Tag = 4;
        easyButton.Text = "4  Dễ\n4 ngày";
        easyButton.UseVisualStyleBackColor = false;
        easyButton.Click += RatingButton_Click;
        // 
        // shortcutLabel
        // 
        shortcutLabel.AutoEllipsis = true;
        shortcutLabel.Dock = DockStyle.Fill;
        shortcutLabel.Font = new Font("Segoe UI", 9F);
        shortcutLabel.ForeColor = Color.FromArgb(93, 105, 125);
        shortcutLabel.Location = new Point(26, 1211);
        shortcutLabel.Margin = new Padding(0);
        shortcutLabel.Name = "shortcutLabel";
        shortcutLabel.Size = new Size(1325, 28);
        shortcutLabel.TabIndex = 43;
        shortcutLabel.Text = "Space để hiện nghĩa  ·  Phím 1–4 để đánh giá";
        shortcutLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // catalogLayout
        // 
        catalogLayout.ColumnCount = 1;
        catalogLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        catalogLayout.Controls.Add(catalogTitle, 0, 0);
        catalogLayout.Controls.Add(catalogSubtitle, 0, 1);
        catalogLayout.Controls.Add(summaryStrip, 0, 2);
        catalogLayout.Controls.Add(cardsGrid, 0, 3);
        catalogLayout.Controls.Add(catalogActions, 0, 4);
        catalogLayout.Dock = DockStyle.Fill;
        catalogLayout.Location = new Point(0, 0);
        catalogLayout.Margin = new Padding(0);
        catalogLayout.Name = "catalogLayout";
        catalogLayout.Padding = new Padding(26, 24, 20, 18);
        catalogLayout.RowCount = 5;
        catalogLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        catalogLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        catalogLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        catalogLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        catalogLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        catalogLayout.Size = new Size(1371, 1253);
        catalogLayout.TabIndex = 44;
        catalogLayout.Visible = false;
        // 
        // catalogTitle
        // 
        catalogTitle.AutoEllipsis = true;
        catalogTitle.Dock = DockStyle.Fill;
        catalogTitle.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
        catalogTitle.ForeColor = Color.FromArgb(15, 23, 42);
        catalogTitle.Location = new Point(26, 24);
        catalogTitle.Margin = new Padding(0);
        catalogTitle.Name = "catalogTitle";
        catalogTitle.Size = new Size(1325, 46);
        catalogTitle.TabIndex = 45;
        catalogTitle.Text = "Bộ thẻ của tôi";
        catalogTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // catalogSubtitle
        // 
        catalogSubtitle.AutoEllipsis = true;
        catalogSubtitle.Dock = DockStyle.Fill;
        catalogSubtitle.Font = new Font("Segoe UI", 11F);
        catalogSubtitle.ForeColor = Color.FromArgb(93, 105, 125);
        catalogSubtitle.Location = new Point(26, 70);
        catalogSubtitle.Margin = new Padding(0);
        catalogSubtitle.Name = "catalogSubtitle";
        catalogSubtitle.Size = new Size(1325, 34);
        catalogSubtitle.TabIndex = 46;
        catalogSubtitle.Text = "Từ vựng của bạn, lưu trên máy.";
        catalogSubtitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // summaryStrip
        // 
        summaryStrip.ColumnCount = 3;
        summaryStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        summaryStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        summaryStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        summaryStrip.Controls.Add(totalMetric, 0, 0);
        summaryStrip.Controls.Add(learnedMetric, 1, 0);
        summaryStrip.Controls.Add(practiceMetric, 2, 0);
        summaryStrip.Dock = DockStyle.Fill;
        summaryStrip.Location = new Point(26, 116);
        summaryStrip.Margin = new Padding(0, 12, 0, 16);
        summaryStrip.Name = "summaryStrip";
        summaryStrip.RowCount = 1;
        summaryStrip.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        summaryStrip.Size = new Size(1325, 72);
        summaryStrip.TabIndex = 47;
        // 
        // totalMetric
        // 
        totalMetric.AutoEllipsis = true;
        totalMetric.BackColor = Color.White;
        totalMetric.Dock = DockStyle.Fill;
        totalMetric.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        totalMetric.ForeColor = Color.FromArgb(15, 23, 42);
        totalMetric.Location = new Point(0, 0);
        totalMetric.Margin = new Padding(0, 0, 8, 0);
        totalMetric.Name = "totalMetric";
        totalMetric.Padding = new Padding(12, 4, 4, 4);
        totalMetric.Size = new Size(429, 72);
        totalMetric.TabIndex = 48;
        totalMetric.Text = "0";
        totalMetric.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // learnedMetric
        // 
        learnedMetric.AutoEllipsis = true;
        learnedMetric.BackColor = Color.White;
        learnedMetric.Dock = DockStyle.Fill;
        learnedMetric.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        learnedMetric.ForeColor = Color.FromArgb(15, 23, 42);
        learnedMetric.Location = new Point(437, 0);
        learnedMetric.Margin = new Padding(0, 0, 8, 0);
        learnedMetric.Name = "learnedMetric";
        learnedMetric.Padding = new Padding(12, 4, 4, 4);
        learnedMetric.Size = new Size(442, 72);
        learnedMetric.TabIndex = 49;
        learnedMetric.Text = "0";
        learnedMetric.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // practiceMetric
        // 
        practiceMetric.AutoEllipsis = true;
        practiceMetric.BackColor = Color.White;
        practiceMetric.Dock = DockStyle.Fill;
        practiceMetric.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        practiceMetric.ForeColor = Color.FromArgb(15, 23, 42);
        practiceMetric.Location = new Point(887, 0);
        practiceMetric.Margin = new Padding(0, 0, 8, 0);
        practiceMetric.Name = "practiceMetric";
        practiceMetric.Padding = new Padding(12, 4, 4, 4);
        practiceMetric.Size = new Size(430, 72);
        practiceMetric.TabIndex = 50;
        practiceMetric.Text = "0";
        practiceMetric.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cardsGrid
        // 
        cardsGrid.AllowUserToAddRows = false;
        cardsGrid.AllowUserToDeleteRows = false;
        cardsGrid.AllowUserToResizeRows = false;
        cardsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        cardsGrid.BackgroundColor = Color.White;
        cardsGrid.BorderStyle = BorderStyle.None;
        cardsGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        cardsGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 251, 252);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(93, 105, 125);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        cardsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        cardsGrid.ColumnHeadersHeight = 42;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle2.Padding = new Padding(8, 0, 4, 0);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(227, 245, 241);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        cardsGrid.DefaultCellStyle = dataGridViewCellStyle2;
        cardsGrid.Dock = DockStyle.Fill;
        cardsGrid.EnableHeadersVisualStyles = false;
        cardsGrid.GridColor = Color.FromArgb(224, 229, 235);
        cardsGrid.Location = new Point(26, 204);
        cardsGrid.Margin = new Padding(0);
        cardsGrid.MultiSelect = false;
        cardsGrid.Name = "cardsGrid";
        cardsGrid.ReadOnly = true;
        cardsGrid.RowHeadersVisible = false;
        cardsGrid.RowHeadersWidth = 82;
        cardsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        cardsGrid.Size = new Size(1325, 979);
        cardsGrid.TabIndex = 51;
        cardsGrid.CellDoubleClick += CardsGrid_CellDoubleClick;
        // 
        // catalogActions
        // 
        catalogActions.ColumnCount = 2;
        catalogActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        catalogActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        catalogActions.Controls.Add(addButton, 0, 0);
        catalogActions.Controls.Add(startReviewButton, 1, 0);
        catalogActions.Dock = DockStyle.Fill;
        catalogActions.Location = new Point(26, 1195);
        catalogActions.Margin = new Padding(0, 12, 0, 0);
        catalogActions.Name = "catalogActions";
        catalogActions.RowCount = 1;
        catalogActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        catalogActions.Size = new Size(1325, 40);
        catalogActions.TabIndex = 52;
        // 
        // addButton
        // 
        addButton.BackColor = Color.FromArgb(0, 116, 122);
        addButton.Cursor = Cursors.Hand;
        addButton.Dock = DockStyle.Fill;
        addButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        addButton.FlatStyle = FlatStyle.Flat;
        addButton.Font = new Font("Segoe UI", 11F);
        addButton.ForeColor = Color.White;
        addButton.Location = new Point(0, 0);
        addButton.Margin = new Padding(0, 0, 8, 0);
        addButton.Name = "addButton";
        addButton.Size = new Size(654, 40);
        addButton.TabIndex = 53;
        addButton.Text = "Thêm thẻ mới";
        addButton.UseVisualStyleBackColor = false;
        addButton.Click += AddButton_Click;
        // 
        // startReviewButton
        // 
        startReviewButton.BackColor = Color.White;
        startReviewButton.Cursor = Cursors.Hand;
        startReviewButton.Dock = DockStyle.Fill;
        startReviewButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        startReviewButton.FlatStyle = FlatStyle.Flat;
        startReviewButton.Font = new Font("Segoe UI", 11F);
        startReviewButton.Location = new Point(662, 0);
        startReviewButton.Margin = new Padding(0);
        startReviewButton.Name = "startReviewButton";
        startReviewButton.Size = new Size(663, 40);
        startReviewButton.TabIndex = 54;
        startReviewButton.Text = "Ôn thẻ đã chọn";
        startReviewButton.UseVisualStyleBackColor = false;
        startReviewButton.Click += StartReviewButton_Click;
        // 
        // rightSidebar
        // 
        rightSidebar.BackColor = Color.White;
        rightSidebar.ColumnCount = 1;
        rightSidebar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rightSidebar.Controls.Add(mistakeSurface, 0, 0);
        rightSidebar.Controls.Add(sessionLayout, 0, 1);
        rightSidebar.Dock = DockStyle.Fill;
        rightSidebar.Location = new Point(1603, 0);
        rightSidebar.Margin = new Padding(0);
        rightSidebar.Name = "rightSidebar";
        rightSidebar.Padding = new Padding(10, 24, 18, 18);
        rightSidebar.RowCount = 2;
        rightSidebar.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
        rightSidebar.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
        rightSidebar.Size = new Size(316, 1253);
        rightSidebar.TabIndex = 55;
        // 
        // mistakeSurface
        // 
        mistakeSurface.BackColor = Color.White;
        mistakeSurface.BorderStyle = BorderStyle.FixedSingle;
        mistakeSurface.Controls.Add(mistakeLayout);
        mistakeSurface.Dock = DockStyle.Fill;
        mistakeSurface.Location = new Point(10, 24);
        mistakeSurface.Margin = new Padding(0, 0, 0, 20);
        mistakeSurface.Name = "mistakeSurface";
        mistakeSurface.Padding = new Padding(14, 12, 14, 14);
        mistakeSurface.Size = new Size(288, 682);
        mistakeSurface.TabIndex = 56;
        // 
        // mistakeLayout
        // 
        mistakeLayout.ColumnCount = 1;
        mistakeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mistakeLayout.Controls.Add(mistakeTitle, 0, 0);
        mistakeLayout.Controls.Add(mistakeSubtitle, 0, 1);
        mistakeLayout.Controls.Add(mistakeTag, 0, 2);
        mistakeLayout.Controls.Add(wrongLabel, 0, 3);
        mistakeLayout.Controls.Add(correctLabel, 0, 4);
        mistakeLayout.Controls.Add(mistakeNote, 0, 5);
        mistakeLayout.Controls.Add(retryButton, 0, 6);
        mistakeLayout.Dock = DockStyle.Fill;
        mistakeLayout.Location = new Point(14, 12);
        mistakeLayout.Margin = new Padding(0);
        mistakeLayout.Name = "mistakeLayout";
        mistakeLayout.RowCount = 7;
        mistakeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        mistakeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        mistakeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        mistakeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        mistakeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        mistakeLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mistakeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        mistakeLayout.Size = new Size(258, 654);
        mistakeLayout.TabIndex = 57;
        // 
        // mistakeTitle
        // 
        mistakeTitle.AutoEllipsis = true;
        mistakeTitle.Dock = DockStyle.Fill;
        mistakeTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
        mistakeTitle.ForeColor = Color.FromArgb(15, 23, 42);
        mistakeTitle.Location = new Point(0, 0);
        mistakeTitle.Margin = new Padding(0);
        mistakeTitle.Name = "mistakeTitle";
        mistakeTitle.Size = new Size(258, 34);
        mistakeTitle.TabIndex = 58;
        mistakeTitle.Text = "Sổ lỗi sai";
        mistakeTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // mistakeSubtitle
        // 
        mistakeSubtitle.AutoEllipsis = true;
        mistakeSubtitle.Dock = DockStyle.Fill;
        mistakeSubtitle.Font = new Font("Segoe UI", 10F);
        mistakeSubtitle.ForeColor = Color.FromArgb(93, 105, 125);
        mistakeSubtitle.Location = new Point(0, 34);
        mistakeSubtitle.Margin = new Padding(0);
        mistakeSubtitle.Name = "mistakeSubtitle";
        mistakeSubtitle.Size = new Size(258, 42);
        mistakeSubtitle.TabIndex = 59;
        mistakeSubtitle.Text = "Ôn lại những thẻ bạn thấy khó.";
        mistakeSubtitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // mistakeTag
        // 
        mistakeTag.AutoEllipsis = true;
        mistakeTag.Dock = DockStyle.Fill;
        mistakeTag.Font = new Font("Segoe UI", 9F);
        mistakeTag.ForeColor = Color.FromArgb(0, 116, 122);
        mistakeTag.Location = new Point(0, 76);
        mistakeTag.Margin = new Padding(0);
        mistakeTag.Name = "mistakeTag";
        mistakeTag.Size = new Size(258, 28);
        mistakeTag.TabIndex = 60;
        mistakeTag.Text = "Cách dùng dễ nhầm";
        mistakeTag.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // wrongLabel
        // 
        wrongLabel.AutoEllipsis = true;
        wrongLabel.BackColor = Color.FromArgb(250, 251, 252);
        wrongLabel.Dock = DockStyle.Fill;
        wrongLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        wrongLabel.ForeColor = Color.FromArgb(93, 105, 125);
        wrongLabel.Location = new Point(0, 104);
        wrongLabel.Margin = new Padding(0, 0, 0, 6);
        wrongLabel.Name = "wrongLabel";
        wrongLabel.Size = new Size(258, 42);
        wrongLabel.TabIndex = 61;
        wrongLabel.Text = "Chưa có lỗi được ghi";
        wrongLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // correctLabel
        // 
        correctLabel.AutoEllipsis = true;
        correctLabel.BackColor = Color.FromArgb(227, 245, 241);
        correctLabel.Dock = DockStyle.Fill;
        correctLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        correctLabel.ForeColor = Color.FromArgb(0, 116, 122);
        correctLabel.Location = new Point(0, 156);
        correctLabel.Margin = new Padding(0, 4, 0, 0);
        correctLabel.Name = "correctLabel";
        correctLabel.Size = new Size(258, 44);
        correctLabel.TabIndex = 62;
        correctLabel.Text = "make a decision";
        correctLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // mistakeNote
        // 
        mistakeNote.AutoEllipsis = true;
        mistakeNote.Dock = DockStyle.Fill;
        mistakeNote.Font = new Font("Segoe UI", 10F);
        mistakeNote.ForeColor = Color.FromArgb(15, 23, 42);
        mistakeNote.Location = new Point(0, 200);
        mistakeNote.Margin = new Padding(0);
        mistakeNote.Name = "mistakeNote";
        mistakeNote.Padding = new Padding(0, 12, 0, 4);
        mistakeNote.Size = new Size(258, 410);
        mistakeNote.TabIndex = 63;
        mistakeNote.Text = "Dùng make với decision.";
        // 
        // retryButton
        // 
        retryButton.BackColor = Color.White;
        retryButton.Cursor = Cursors.Hand;
        retryButton.Dock = DockStyle.Fill;
        retryButton.FlatAppearance.BorderColor = Color.FromArgb(224, 229, 235);
        retryButton.FlatStyle = FlatStyle.Flat;
        retryButton.Font = new Font("Segoe UI", 10F);
        retryButton.ForeColor = Color.FromArgb(0, 116, 122);
        retryButton.Location = new Point(0, 610);
        retryButton.Margin = new Padding(0);
        retryButton.Name = "retryButton";
        retryButton.Size = new Size(258, 44);
        retryButton.TabIndex = 64;
        retryButton.Text = "Luyện lại thẻ này";
        retryButton.UseVisualStyleBackColor = false;
        retryButton.Click += RetryButton_Click;
        // 
        // sessionLayout
        // 
        sessionLayout.ColumnCount = 1;
        sessionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        sessionLayout.Controls.Add(sessionTitle, 0, 0);
        sessionLayout.Controls.Add(reviewedRow, 0, 1);
        sessionLayout.Controls.Add(rememberedRow, 0, 2);
        sessionLayout.Controls.Add(practiceRow, 0, 3);
        sessionLayout.Controls.Add(scheduleNote, 0, 4);
        sessionLayout.Dock = DockStyle.Fill;
        sessionLayout.Location = new Point(10, 726);
        sessionLayout.Margin = new Padding(0);
        sessionLayout.Name = "sessionLayout";
        sessionLayout.Padding = new Padding(12, 0, 12, 0);
        sessionLayout.RowCount = 5;
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        sessionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        sessionLayout.Size = new Size(288, 509);
        sessionLayout.TabIndex = 65;
        // 
        // sessionTitle
        // 
        sessionTitle.AutoEllipsis = true;
        sessionTitle.Dock = DockStyle.Fill;
        sessionTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        sessionTitle.ForeColor = Color.FromArgb(15, 23, 42);
        sessionTitle.Location = new Point(12, 0);
        sessionTitle.Margin = new Padding(0);
        sessionTitle.Name = "sessionTitle";
        sessionTitle.Size = new Size(264, 46);
        sessionTitle.TabIndex = 66;
        sessionTitle.Text = "Phiên học này";
        sessionTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // reviewedRow
        // 
        reviewedRow.ColumnCount = 2;
        reviewedRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        reviewedRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        reviewedRow.Controls.Add(reviewedRowCaption, 0, 0);
        reviewedRow.Controls.Add(reviewedRowValue, 1, 0);
        reviewedRow.Dock = DockStyle.Fill;
        reviewedRow.Location = new Point(12, 46);
        reviewedRow.Margin = new Padding(0);
        reviewedRow.Name = "reviewedRow";
        reviewedRow.RowCount = 1;
        reviewedRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        reviewedRow.Size = new Size(264, 46);
        reviewedRow.TabIndex = 67;
        // 
        // reviewedRowCaption
        // 
        reviewedRowCaption.AutoEllipsis = true;
        reviewedRowCaption.Dock = DockStyle.Fill;
        reviewedRowCaption.Font = new Font("Segoe UI", 12F);
        reviewedRowCaption.ForeColor = Color.FromArgb(93, 105, 125);
        reviewedRowCaption.Location = new Point(0, 0);
        reviewedRowCaption.Margin = new Padding(0);
        reviewedRowCaption.Name = "reviewedRowCaption";
        reviewedRowCaption.Size = new Size(171, 46);
        reviewedRowCaption.TabIndex = 68;
        reviewedRowCaption.Text = "Đã ôn";
        reviewedRowCaption.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // reviewedRowValue
        // 
        reviewedRowValue.AutoEllipsis = true;
        reviewedRowValue.Dock = DockStyle.Fill;
        reviewedRowValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        reviewedRowValue.ForeColor = Color.FromArgb(15, 23, 42);
        reviewedRowValue.Location = new Point(171, 0);
        reviewedRowValue.Margin = new Padding(0);
        reviewedRowValue.Name = "reviewedRowValue";
        reviewedRowValue.Size = new Size(93, 46);
        reviewedRowValue.TabIndex = 69;
        reviewedRowValue.Text = "0 thẻ";
        reviewedRowValue.TextAlign = ContentAlignment.MiddleRight;
        // 
        // rememberedRow
        // 
        rememberedRow.ColumnCount = 2;
        rememberedRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        rememberedRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        rememberedRow.Controls.Add(rememberedRowCaption, 0, 0);
        rememberedRow.Controls.Add(rememberedRowValue, 1, 0);
        rememberedRow.Dock = DockStyle.Fill;
        rememberedRow.Location = new Point(12, 92);
        rememberedRow.Margin = new Padding(0);
        rememberedRow.Name = "rememberedRow";
        rememberedRow.RowCount = 1;
        rememberedRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rememberedRow.Size = new Size(264, 46);
        rememberedRow.TabIndex = 70;
        // 
        // rememberedRowCaption
        // 
        rememberedRowCaption.AutoEllipsis = true;
        rememberedRowCaption.Dock = DockStyle.Fill;
        rememberedRowCaption.Font = new Font("Segoe UI", 12F);
        rememberedRowCaption.ForeColor = Color.FromArgb(93, 105, 125);
        rememberedRowCaption.Location = new Point(0, 0);
        rememberedRowCaption.Margin = new Padding(0);
        rememberedRowCaption.Name = "rememberedRowCaption";
        rememberedRowCaption.Size = new Size(171, 46);
        rememberedRowCaption.TabIndex = 71;
        rememberedRowCaption.Text = "Nhớ tốt";
        rememberedRowCaption.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // rememberedRowValue
        // 
        rememberedRowValue.AutoEllipsis = true;
        rememberedRowValue.Dock = DockStyle.Fill;
        rememberedRowValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        rememberedRowValue.ForeColor = Color.FromArgb(15, 23, 42);
        rememberedRowValue.Location = new Point(171, 0);
        rememberedRowValue.Margin = new Padding(0);
        rememberedRowValue.Name = "rememberedRowValue";
        rememberedRowValue.Size = new Size(93, 46);
        rememberedRowValue.TabIndex = 72;
        rememberedRowValue.Text = "0 thẻ";
        rememberedRowValue.TextAlign = ContentAlignment.MiddleRight;
        // 
        // practiceRow
        // 
        practiceRow.ColumnCount = 2;
        practiceRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        practiceRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        practiceRow.Controls.Add(practiceRowCaption, 0, 0);
        practiceRow.Controls.Add(practiceRowValue, 1, 0);
        practiceRow.Dock = DockStyle.Fill;
        practiceRow.Location = new Point(12, 138);
        practiceRow.Margin = new Padding(0);
        practiceRow.Name = "practiceRow";
        practiceRow.RowCount = 1;
        practiceRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        practiceRow.Size = new Size(264, 46);
        practiceRow.TabIndex = 73;
        // 
        // practiceRowCaption
        // 
        practiceRowCaption.AutoEllipsis = true;
        practiceRowCaption.Dock = DockStyle.Fill;
        practiceRowCaption.Font = new Font("Segoe UI", 12F);
        practiceRowCaption.ForeColor = Color.FromArgb(93, 105, 125);
        practiceRowCaption.Location = new Point(0, 0);
        practiceRowCaption.Margin = new Padding(0);
        practiceRowCaption.Name = "practiceRowCaption";
        practiceRowCaption.Size = new Size(171, 46);
        practiceRowCaption.TabIndex = 74;
        practiceRowCaption.Text = "Cần luyện thêm";
        practiceRowCaption.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // practiceRowValue
        // 
        practiceRowValue.AutoEllipsis = true;
        practiceRowValue.Dock = DockStyle.Fill;
        practiceRowValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        practiceRowValue.ForeColor = Color.FromArgb(15, 23, 42);
        practiceRowValue.Location = new Point(171, 0);
        practiceRowValue.Margin = new Padding(0);
        practiceRowValue.Name = "practiceRowValue";
        practiceRowValue.Size = new Size(93, 46);
        practiceRowValue.TabIndex = 75;
        practiceRowValue.Text = "0 thẻ";
        practiceRowValue.TextAlign = ContentAlignment.MiddleRight;
        // 
        // scheduleNote
        // 
        scheduleNote.AutoEllipsis = true;
        scheduleNote.Dock = DockStyle.Fill;
        scheduleNote.Font = new Font("Segoe UI", 10F);
        scheduleNote.ForeColor = Color.FromArgb(93, 105, 125);
        scheduleNote.Location = new Point(12, 184);
        scheduleNote.Margin = new Padding(0);
        scheduleNote.Name = "scheduleNote";
        scheduleNote.Padding = new Padding(0, 12, 0, 0);
        scheduleNote.Size = new Size(264, 325);
        scheduleNote.TabIndex = 76;
        scheduleNote.Text = "Lần ôn tiếp theo được lưu theo mức đánh giá của bạn.";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(250, 251, 252);
        ClientSize = new Size(1919, 1253);
        Controls.Add(root);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.FromArgb(15, 23, 42);
        KeyPreview = true;
        MinimumSize = new Size(1100, 660);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "English Flashcards";
        Load += MainForm_Load;
        Resize += MainForm_Resize;
        root.ResumeLayout(false);
        sidebar.ResumeLayout(false);
        brand.ResumeLayout(false);
        mainHost.ResumeLayout(false);
        reviewLayout.ResumeLayout(false);
        reviewHeader.ResumeLayout(false);
        progressRow.ResumeLayout(false);
        cardSurface.ResumeLayout(false);
        cardLayout.ResumeLayout(false);
        cardToolbar.ResumeLayout(false);
        ratings.ResumeLayout(false);
        catalogLayout.ResumeLayout(false);
        summaryStrip.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)cardsGrid).EndInit();
        catalogActions.ResumeLayout(false);
        rightSidebar.ResumeLayout(false);
        mistakeSurface.ResumeLayout(false);
        mistakeLayout.ResumeLayout(false);
        sessionLayout.ResumeLayout(false);
        reviewedRow.ResumeLayout(false);
        rememberedRow.ResumeLayout(false);
        practiceRow.ResumeLayout(false);
        ResumeLayout(false);
    }
    private TableLayoutPanel root;
    private TableLayoutPanel sidebar;
    private TableLayoutPanel brand;
    private Label brandLabel;
    private Label taglineLabel;
    private Button overviewButton;
    private Button libraryButton;
    private Button reviewButton;
    private Button mistakesButton;
    private Button statisticsButton;
    private Button settingsButton;
    private Label savedLabel;
    private Panel mainHost;
    private TableLayoutPanel reviewLayout;
    private TableLayoutPanel reviewHeader;
    private Label titleLabel;
    private Label subtitleLabel;
    private Button finishButton;
    private TableLayoutPanel progressRow;
    private Label counterLabel;
    private Panel progressTrack;
    private Label remainingLabel;
    private Button previousButton;
    private Button nextButton;
    private Panel cardSurface;
    private TableLayoutPanel cardLayout;
    private TableLayoutPanel cardToolbar;
    private Label categoryLabel;
    private Button speakButton;
    private Label wordLabel;
    private Label pronunciationLabel;
    private Panel divider;
    private Label meaningLabel;
    private Label exampleLabel;
    private Label translationLabel;
    private Button flipButton;
    private Label ratingPromptLabel;
    private TableLayoutPanel ratings;
    private Button againButton;
    private Button hardButton;
    private Button goodButton;
    private Button easyButton;
    private Label shortcutLabel;
    private TableLayoutPanel catalogLayout;
    private Label catalogTitle;
    private Label catalogSubtitle;
    private TableLayoutPanel summaryStrip;
    private Label totalMetric;
    private Label learnedMetric;
    private Label practiceMetric;
    private DataGridView cardsGrid;
    private TableLayoutPanel catalogActions;
    private Button addButton;
    private Button startReviewButton;
    private TableLayoutPanel rightSidebar;
    private Panel mistakeSurface;
    private TableLayoutPanel mistakeLayout;
    private Label mistakeTitle;
    private Label mistakeSubtitle;
    private Label mistakeTag;
    private Label wrongLabel;
    private Label correctLabel;
    private Label mistakeNote;
    private Button retryButton;
    private TableLayoutPanel sessionLayout;
    private Label sessionTitle;
    private TableLayoutPanel reviewedRow;
    private Label reviewedRowCaption;
    private Label reviewedRowValue;
    private TableLayoutPanel rememberedRow;
    private Label rememberedRowCaption;
    private Label rememberedRowValue;
    private TableLayoutPanel practiceRow;
    private Label practiceRowCaption;
    private Label practiceRowValue;
    private Label scheduleNote;
}
