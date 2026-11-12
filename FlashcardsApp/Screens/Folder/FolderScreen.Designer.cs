namespace FlashcardsApp;

partial class FolderScreen
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
        leftPanel = new Panel();
        deleteFolderButton = new Button();
        renameFolderButton = new Button();
        newFolderButton = new Button();
        folderListBox = new ListBox();
        noteLabel = new Label();
        labelFolder = new Label();
        rightPanel = new Panel();
        cardPanel = new Panel();
        wordGrid = new DataGridView();
        colWord = new DataGridViewTextBoxColumn();
        colMean = new DataGridViewTextBoxColumn();
        colPronunciation = new DataGridViewTextBoxColumn();
        colRating = new DataGridViewTextBoxColumn();
        coledit = new DataGridViewButtonColumn();
        coldelete = new DataGridViewButtonColumn();
        searchTextBox = new TextBox();
        addWordButton = new Button();
        importButton = new Button();
        folderInfoLabel = new Label();
        folderTitleLabel = new Label();
        bottomPanel = new Panel();
        countLabel = new Label();
        studyFolderButton = new Button();
        leftPanel.SuspendLayout();
        rightPanel.SuspendLayout();
        cardPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)wordGrid).BeginInit();
        bottomPanel.SuspendLayout();
        SuspendLayout();
        // 
        // leftPanel
        // 
        leftPanel.BackColor = Color.FromArgb(247, 249, 250);
        leftPanel.Controls.Add(deleteFolderButton);
        leftPanel.Controls.Add(renameFolderButton);
        leftPanel.Controls.Add(newFolderButton);
        leftPanel.Controls.Add(folderListBox);
        leftPanel.Controls.Add(noteLabel);
        leftPanel.Controls.Add(labelFolder);
        leftPanel.Dock = DockStyle.Left;
        leftPanel.Location = new Point(0, 0);
        leftPanel.Name = "leftPanel";
        leftPanel.Padding = new Padding(16);
        leftPanel.Size = new Size(260, 640);
        leftPanel.TabIndex = 0;
        // 
        // deleteFolderButton
        // 
        deleteFolderButton.BackColor = Color.Transparent;
        deleteFolderButton.Cursor = Cursors.Hand;
        deleteFolderButton.FlatAppearance.BorderSize = 0;
        deleteFolderButton.FlatStyle = FlatStyle.Flat;
        deleteFolderButton.Font = new Font("Segoe UI", 9F);
        deleteFolderButton.ForeColor = Color.FromArgb(220, 38, 38);
        deleteFolderButton.Location = new Point(176, 48);
        deleteFolderButton.Name = "deleteFolderButton";
        deleteFolderButton.Size = new Size(24, 24);
        deleteFolderButton.TabIndex = 6;
        deleteFolderButton.Text = "🗑";
        deleteFolderButton.UseVisualStyleBackColor = false;
        deleteFolderButton.Visible = false;
        // 
        // renameFolderButton
        // 
        renameFolderButton.BackColor = Color.Transparent;
        renameFolderButton.Cursor = Cursors.Hand;
        renameFolderButton.FlatAppearance.BorderSize = 0;
        renameFolderButton.FlatStyle = FlatStyle.Flat;
        renameFolderButton.Font = new Font("Segoe UI", 9F);
        renameFolderButton.ForeColor = Color.FromArgb(71, 85, 105);
        renameFolderButton.Location = new Point(150, 48);
        renameFolderButton.Name = "renameFolderButton";
        renameFolderButton.Size = new Size(24, 24);
        renameFolderButton.TabIndex = 5;
        renameFolderButton.Text = "✏";
        renameFolderButton.UseVisualStyleBackColor = false;
        renameFolderButton.Visible = false;
        // 
        // newFolderButton
        // 
        newFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        newFolderButton.BackColor = Color.White;
        newFolderButton.Cursor = Cursors.Hand;
        newFolderButton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        newFolderButton.FlatStyle = FlatStyle.Flat;
        newFolderButton.Font = new Font("Segoe UI", 9.5F);
        newFolderButton.ForeColor = Color.FromArgb(51, 65, 85);
        newFolderButton.Location = new Point(16, 450);
        newFolderButton.Name = "newFolderButton";
        newFolderButton.Size = new Size(228, 40);
        newFolderButton.TabIndex = 3;
        newFolderButton.Text = "+ Thư mục mới";
        newFolderButton.UseVisualStyleBackColor = false;
        // 
        // folderListBox
        // 
        folderListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        folderListBox.BackColor = Color.FromArgb(247, 249, 250);
        folderListBox.BorderStyle = BorderStyle.None;
        folderListBox.DrawMode = DrawMode.OwnerDrawFixed;
        folderListBox.Font = new Font("Segoe UI", 10F);
        folderListBox.FormattingEnabled = true;
        folderListBox.ItemHeight = 48;
        folderListBox.Location = new Point(16, 44);
        folderListBox.Name = "folderListBox";
        folderListBox.Size = new Size(228, 384);
        folderListBox.TabIndex = 2;
        // 
        // noteLabel
        // 
        noteLabel.Dock = DockStyle.Bottom;
        noteLabel.Font = new Font("Segoe UI", 8F);
        noteLabel.ForeColor = Color.FromArgb(100, 116, 139);
        noteLabel.Location = new Point(16, 576);
        noteLabel.Name = "noteLabel";
        noteLabel.Size = new Size(228, 48);
        noteLabel.TabIndex = 4;
        noteLabel.Text = "Xóa thư mục còn từ: app hỏi rồi chuyển các từ về \"Chưa phân loại\". Không bao giờ mất từ.";
        // 
        // labelFolder
        // 
        labelFolder.AutoSize = true;
        labelFolder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        labelFolder.ForeColor = Color.FromArgb(100, 116, 139);
        labelFolder.Location = new Point(16, 18);
        labelFolder.Name = "labelFolder";
        labelFolder.Size = new Size(62, 15);
        labelFolder.TabIndex = 1;
        labelFolder.Text = "THƯ MỤC";
        // 
        // rightPanel
        // 
        rightPanel.BackColor = Color.FromArgb(247, 249, 250);
        rightPanel.Controls.Add(cardPanel);
        rightPanel.Controls.Add(bottomPanel);
        rightPanel.Dock = DockStyle.Fill;
        rightPanel.Location = new Point(260, 0);
        rightPanel.Name = "rightPanel";
        rightPanel.Padding = new Padding(20, 16, 24, 16);
        rightPanel.Size = new Size(640, 640);
        rightPanel.TabIndex = 1;
        // 
        // cardPanel
        // 
        cardPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cardPanel.BackColor = Color.White;
        cardPanel.Controls.Add(wordGrid);
        cardPanel.Controls.Add(searchTextBox);
        cardPanel.Controls.Add(addWordButton);
        cardPanel.Controls.Add(importButton);
        cardPanel.Controls.Add(folderInfoLabel);
        cardPanel.Controls.Add(folderTitleLabel);
        cardPanel.Location = new Point(20, 16);
        cardPanel.Name = "cardPanel";
        cardPanel.Padding = new Padding(20);
        cardPanel.Size = new Size(596, 542);
        cardPanel.TabIndex = 0;
        // 
        // wordGrid
        // 
        wordGrid.AllowUserToAddRows = false;
        wordGrid.AllowUserToDeleteRows = false;
        wordGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        wordGrid.BackgroundColor = Color.White;
        wordGrid.BorderStyle = BorderStyle.None;
        wordGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        wordGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.White;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(100, 116, 139);
        dataGridViewCellStyle1.SelectionBackColor = Color.White;
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(100, 116, 139);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        wordGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        wordGrid.ColumnHeadersHeight = 38;
        wordGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        wordGrid.Columns.AddRange(new DataGridViewColumn[] { colWord, colMean, colPronunciation, colRating, coledit, coldelete });
        wordGrid.EnableHeadersVisualStyles = false;
        wordGrid.GridColor = Color.FromArgb(241, 245, 249);
        wordGrid.Location = new Point(20, 124);
        wordGrid.Name = "wordGrid";
        wordGrid.ReadOnly = true;
        wordGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        wordGrid.RowHeadersVisible = false;
        dataGridViewCellStyle7.BackColor = Color.White;
        dataGridViewCellStyle7.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle7.ForeColor = Color.FromArgb(30, 41, 59);
        dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(248, 250, 252);
        dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(15, 23, 42);
        wordGrid.RowsDefaultCellStyle = dataGridViewCellStyle7;
        wordGrid.RowTemplate.Height = 44;
        wordGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        wordGrid.Size = new Size(556, 398);
        wordGrid.TabIndex = 6;
        // 
        // colWord
        // 
        colWord.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        colWord.DefaultCellStyle = dataGridViewCellStyle2;
        colWord.FillWeight = 26F;
        colWord.HeaderText = "TỪ";
        colWord.Name = "colWord";
        colWord.ReadOnly = true;
        // 
        // colMean
        // 
        colMean.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colMean.FillWeight = 28F;
        colMean.HeaderText = "NGHĨA";
        colMean.Name = "colMean";
        colMean.ReadOnly = true;
        // 
        // colPronunciation
        // 
        colPronunciation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle3.ForeColor = Color.FromArgb(100, 116, 139);
        colPronunciation.DefaultCellStyle = dataGridViewCellStyle3;
        colPronunciation.FillWeight = 22F;
        colPronunciation.HeaderText = "PHIÊN ÂM";
        colPronunciation.Name = "colPronunciation";
        colPronunciation.ReadOnly = true;
        // 
        // colRating
        // 
        colRating.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
        colRating.DefaultCellStyle = dataGridViewCellStyle4;
        colRating.FillWeight = 16F;
        colRating.HeaderText = "MỨC NHỚ";
        colRating.Name = "colRating";
        colRating.ReadOnly = true;
        // 
        // coledit
        // 
        coledit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle5.ForeColor = Color.FromArgb(71, 85, 105);
        coledit.DefaultCellStyle = dataGridViewCellStyle5;
        coledit.FlatStyle = FlatStyle.Flat;
        coledit.HeaderText = "THAO";
        coledit.MinimumWidth = 50;
        coledit.Name = "coledit";
        coledit.ReadOnly = true;
        coledit.Text = "✏";
        coledit.UseColumnTextForButtonValue = true;
        coledit.Width = 50;
        // 
        // coldelete
        // 
        coldelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle6.ForeColor = Color.FromArgb(220, 38, 38);
        coldelete.DefaultCellStyle = dataGridViewCellStyle6;
        coldelete.FlatStyle = FlatStyle.Flat;
        coldelete.HeaderText = "TÁC";
        coldelete.MinimumWidth = 44;
        coldelete.Name = "coldelete";
        coldelete.ReadOnly = true;
        coldelete.Text = "🗑";
        coldelete.UseColumnTextForButtonValue = true;
        coldelete.Width = 44;
        // 
        // searchTextBox
        // 
        searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        searchTextBox.BorderStyle = BorderStyle.FixedSingle;
        searchTextBox.Font = new Font("Segoe UI", 10F);
        searchTextBox.Location = new Point(20, 84);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.PlaceholderText = "🔍  Tìm theo từ hoặc nghĩa, ví dụ: tò mò";
        searchTextBox.Size = new Size(556, 25);
        searchTextBox.TabIndex = 5;
        // 
        // addWordButton
        // 
        addWordButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        addWordButton.BackColor = Color.FromArgb(15, 118, 110);
        addWordButton.Cursor = Cursors.Hand;
        addWordButton.FlatAppearance.BorderSize = 0;
        addWordButton.FlatStyle = FlatStyle.Flat;
        addWordButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        addWordButton.ForeColor = Color.White;
        addWordButton.Location = new Point(472, 16);
        addWordButton.Name = "addWordButton";
        addWordButton.Size = new Size(104, 36);
        addWordButton.TabIndex = 4;
        addWordButton.Text = "+ Thêm từ";
        addWordButton.UseVisualStyleBackColor = false;
        // 
        // importButton
        // 
        importButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        importButton.BackColor = Color.White;
        importButton.Cursor = Cursors.Hand;
        importButton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        importButton.FlatStyle = FlatStyle.Flat;
        importButton.Font = new Font("Segoe UI", 9.5F);
        importButton.ForeColor = Color.FromArgb(51, 65, 85);
        importButton.Location = new Point(346, 16);
        importButton.Name = "importButton";
        importButton.Size = new Size(118, 36);
        importButton.TabIndex = 3;
        importButton.Text = "Nhập nhiều từ";
        importButton.UseVisualStyleBackColor = false;
        // 
        // folderInfoLabel
        // 
        folderInfoLabel.AutoSize = true;
        folderInfoLabel.Font = new Font("Segoe UI", 9.5F);
        folderInfoLabel.ForeColor = Color.FromArgb(100, 116, 139);
        folderInfoLabel.Location = new Point(22, 52);
        folderInfoLabel.Name = "folderInfoLabel";
        folderInfoLabel.Size = new Size(218, 17);
        folderInfoLabel.TabIndex = 2;
        folderInfoLabel.Text = "0 từ · đã nhớ 0 · đang trong sổ lỗi 0";
        // 
        // folderTitleLabel
        // 
        folderTitleLabel.AutoSize = true;
        folderTitleLabel.Dock = DockStyle.Left;
        folderTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        folderTitleLabel.ForeColor = Color.FromArgb(15, 23, 42);
        folderTitleLabel.Location = new Point(20, 20);
        folderTitleLabel.Name = "folderTitleLabel";
        folderTitleLabel.Size = new Size(156, 32);
        folderTitleLabel.TabIndex = 0;
        folderTitleLabel.Text = "Tên thư mục";
        // 
        // bottomPanel
        // 
        bottomPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        bottomPanel.BackColor = Color.FromArgb(247, 249, 250);
        bottomPanel.Controls.Add(countLabel);
        bottomPanel.Controls.Add(studyFolderButton);
        bottomPanel.Location = new Point(20, 568);
        bottomPanel.Name = "bottomPanel";
        bottomPanel.Size = new Size(596, 52);
        bottomPanel.TabIndex = 1;
        // 
        // countLabel
        // 
        countLabel.AutoSize = true;
        countLabel.Font = new Font("Segoe UI", 9.5F);
        countLabel.ForeColor = Color.FromArgb(100, 116, 139);
        countLabel.Location = new Point(4, 16);
        countLabel.Name = "countLabel";
        countLabel.Size = new Size(81, 17);
        countLabel.TabIndex = 0;
        countLabel.Text = "Hiện 0 / 0 từ";
        // 
        // studyFolderButton
        // 
        studyFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        studyFolderButton.BackColor = Color.FromArgb(15, 118, 110);
        studyFolderButton.Cursor = Cursors.Hand;
        studyFolderButton.FlatAppearance.BorderSize = 0;
        studyFolderButton.FlatStyle = FlatStyle.Flat;
        studyFolderButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        studyFolderButton.ForeColor = Color.White;
        studyFolderButton.Location = new Point(432, 4);
        studyFolderButton.Name = "studyFolderButton";
        studyFolderButton.Size = new Size(164, 42);
        studyFolderButton.TabIndex = 1;
        studyFolderButton.Text = "Học thư mục này";
        studyFolderButton.UseVisualStyleBackColor = false;
        // 
        // FolderScreen
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 249, 250);
        Controls.Add(rightPanel);
        Controls.Add(leftPanel);
        Name = "FolderScreen";
        Size = new Size(900, 640);
        leftPanel.ResumeLayout(false);
        leftPanel.PerformLayout();
        rightPanel.ResumeLayout(false);
        cardPanel.ResumeLayout(false);
        cardPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)wordGrid).EndInit();
        bottomPanel.ResumeLayout(false);
        bottomPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel leftPanel;
    private Panel rightPanel;
    private Panel cardPanel;
    private Panel bottomPanel;
    private Label labelFolder;
    private ListBox folderListBox;
    private Button newFolderButton;
    private Button renameFolderButton;
    private Button deleteFolderButton;
    private Label noteLabel;
    private Label folderTitleLabel;
    private Label folderInfoLabel;
    private Button addWordButton;
    private Button importButton;
    private TextBox searchTextBox;
    private DataGridView wordGrid;
    private Label countLabel;
    private Button studyFolderButton;
    private DataGridViewTextBoxColumn colWord;
    private DataGridViewTextBoxColumn colMean;
    private DataGridViewTextBoxColumn colPronunciation;
    private DataGridViewTextBoxColumn colRating;
    private DataGridViewButtonColumn coledit;
    private DataGridViewButtonColumn coldelete;
}

