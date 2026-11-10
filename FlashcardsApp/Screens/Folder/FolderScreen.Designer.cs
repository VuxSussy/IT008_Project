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
        DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
        leftPanel = new Panel();
        deleteFolderButton = new Button();
        renameFolderButton = new Button();
        newFolderButton = new Button();
        folderListBox = new ListBox();
        noteLabel = new Label();
        labelFolder = new Label();
        rightPanel = new Panel();
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
        leftPanel.SuspendLayout();
        rightPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)wordGrid).BeginInit();
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
        leftPanel.Padding = new Padding(12);
        leftPanel.Size = new Size(260, 640);
        leftPanel.TabIndex = 0;
        // 
        // deleteFolderButton
        // 
        deleteFolderButton.Location = new Point(130, 489);
        deleteFolderButton.Name = "deleteFolderButton";
        deleteFolderButton.Size = new Size(75, 23);
        deleteFolderButton.TabIndex = 6;
        deleteFolderButton.Text = "Xóa";
        deleteFolderButton.UseVisualStyleBackColor = true;
        // 
        // renameFolderButton
        // 
        renameFolderButton.Location = new Point(49, 489);
        renameFolderButton.Name = "renameFolderButton";
        renameFolderButton.Size = new Size(75, 23);
        renameFolderButton.TabIndex = 5;
        renameFolderButton.Text = "Đổi tên";
        renameFolderButton.UseVisualStyleBackColor = true;
        // 
        // newFolderButton
        // 
        newFolderButton.Cursor = Cursors.Hand;
        newFolderButton.Dock = DockStyle.Top;
        newFolderButton.Location = new Point(12, 400);
        newFolderButton.Name = "newFolderButton";
        newFolderButton.Size = new Size(236, 36);
        newFolderButton.TabIndex = 3;
        newFolderButton.Text = "+ Thư mục mới";
        newFolderButton.UseVisualStyleBackColor = true;
        // 
        // folderListBox
        // 
        folderListBox.BackColor = Color.FromArgb(247, 249, 250);
        folderListBox.BorderStyle = BorderStyle.None;
        folderListBox.Dock = DockStyle.Top;
        folderListBox.DrawMode = DrawMode.OwnerDrawFixed;
        folderListBox.Font = new Font("Segoe UI", 10F);
        folderListBox.FormattingEnabled = true;
        folderListBox.Location = new Point(12, 32);
        folderListBox.Name = "folderListBox";
        folderListBox.Size = new Size(236, 368);
        folderListBox.TabIndex = 2;
        // 
        // noteLabel
        // 
        noteLabel.AllowDrop = true;
        noteLabel.AutoEllipsis = true;
        noteLabel.Dock = DockStyle.Bottom;
        noteLabel.Font = new Font("Segoe UI", 8F);
        noteLabel.ForeColor = Color.Gray;
        noteLabel.Location = new Point(12, 598);
        noteLabel.Name = "noteLabel";
        noteLabel.Size = new Size(236, 30);
        noteLabel.TabIndex = 4;
        noteLabel.Text = "Xóa thư mục: các từ tự chuyển về chưa phân loại.";
        // 
        // labelFolder
        // 
        labelFolder.AutoSize = true;
        labelFolder.Dock = DockStyle.Top;
        labelFolder.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        labelFolder.ForeColor = SystemColors.ControlDarkDark;
        labelFolder.Location = new Point(12, 12);
        labelFolder.Name = "labelFolder";
        labelFolder.Size = new Size(79, 20);
        labelFolder.TabIndex = 1;
        labelFolder.Text = "THƯ MỤC";
        // 
        // rightPanel
        // 
        rightPanel.BackColor = Color.FromArgb(247, 249, 250);
        rightPanel.Controls.Add(wordGrid);
        rightPanel.Controls.Add(searchTextBox);
        rightPanel.Controls.Add(addWordButton);
        rightPanel.Controls.Add(importButton);
        rightPanel.Controls.Add(folderInfoLabel);
        rightPanel.Controls.Add(folderTitleLabel);
        rightPanel.Dock = DockStyle.Fill;
        rightPanel.Location = new Point(0, 0);
        rightPanel.Name = "rightPanel";
        rightPanel.Padding = new Padding(16);
        rightPanel.Size = new Size(900, 640);
        rightPanel.TabIndex = 1;
        // 
        // wordGrid
        // 
        wordGrid.AllowUserToAddRows = false;
        wordGrid.AllowUserToDeleteRows = false;
        wordGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        wordGrid.BackgroundColor = Color.White;
        wordGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        wordGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 248);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(75, 85, 85);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        wordGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        wordGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        wordGrid.Columns.AddRange(new DataGridViewColumn[] { colWord, colMean, colPronunciation, colRating, coledit, coldelete });
        wordGrid.EnableHeadersVisualStyles = false;
        wordGrid.GridColor = Color.FromArgb(235, 238, 238);
        wordGrid.Location = new Point(283, 136);
        wordGrid.Name = "wordGrid";
        wordGrid.ReadOnly = true;
        wordGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        wordGrid.RowHeadersVisible = false;
        dataGridViewCellStyle6.BackColor = Color.White;
        wordGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
        wordGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        wordGrid.Size = new Size(598, 437);
        wordGrid.TabIndex = 5;
        // 
        // colWord
        // 
        colWord.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
        dataGridViewCellStyle2.SelectionForeColor = Color.Black;
        colWord.DefaultCellStyle = dataGridViewCellStyle2;
        colWord.HeaderText = "Từ";
        colWord.Name = "colWord";
        colWord.ReadOnly = true;
        // 
        // colMean
        // 
        colMean.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle3.SelectionBackColor = Color.LightGray;
        dataGridViewCellStyle3.SelectionForeColor = Color.Black;
        colMean.DefaultCellStyle = dataGridViewCellStyle3;
        colMean.HeaderText = "Nghĩa";
        colMean.Name = "colMean";
        colMean.ReadOnly = true;
        // 
        // colPronunciation
        // 
        colPronunciation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle4.SelectionBackColor = Color.LightGray;
        dataGridViewCellStyle4.SelectionForeColor = Color.Black;
        colPronunciation.DefaultCellStyle = dataGridViewCellStyle4;
        colPronunciation.HeaderText = "Phiên âm";
        colPronunciation.Name = "colPronunciation";
        colPronunciation.ReadOnly = true;
        // 
        // colRating
        // 
        colRating.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle5.SelectionBackColor = Color.LightGray;
        dataGridViewCellStyle5.SelectionForeColor = Color.Black;
        colRating.DefaultCellStyle = dataGridViewCellStyle5;
        colRating.HeaderText = "Mức nhớ";
        colRating.Name = "colRating";
        colRating.ReadOnly = true;
        // 
        // coledit
        // 
        coledit.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        coledit.FillWeight = 50F;
        coledit.HeaderText = "Sửa";
        coledit.Name = "coledit";
        coledit.ReadOnly = true;
        coledit.Resizable = DataGridViewTriState.True;
        coledit.SortMode = DataGridViewColumnSortMode.Automatic;
        // 
        // coldelete
        // 
        coldelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        coldelete.FillWeight = 50F;
        coldelete.HeaderText = "Xóa";
        coldelete.Name = "coldelete";
        coldelete.ReadOnly = true;
        // 
        // searchTextBox
        // 
        searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        searchTextBox.Cursor = Cursors.IBeam;
        searchTextBox.Font = new Font("Segoe UI", 10F);
        searchTextBox.Location = new Point(283, 83);
        searchTextBox.Multiline = true;
        searchTextBox.Name = "searchTextBox";
        searchTextBox.PlaceholderText = "Tìm theo từ hoặc nghĩa...";
        searchTextBox.Size = new Size(598, 32);
        searchTextBox.TabIndex = 4;
        // 
        // addWordButton
        // 
        addWordButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        addWordButton.BackColor = Color.FromArgb(15, 118, 110);
        addWordButton.Cursor = Cursors.Hand;
        addWordButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        addWordButton.ForeColor = Color.White;
        addWordButton.Location = new Point(776, 25);
        addWordButton.Name = "addWordButton";
        addWordButton.Size = new Size(105, 36);
        addWordButton.TabIndex = 3;
        addWordButton.Text = "+ Thêm từ";
        addWordButton.UseVisualStyleBackColor = false;
        // 
        // importButton
        // 
        importButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        importButton.Cursor = Cursors.Hand;
        importButton.Location = new Point(637, 29);
        importButton.Name = "importButton";
        importButton.Size = new Size(133, 29);
        importButton.TabIndex = 2;
        importButton.Text = "Nhập nhiều từ";
        importButton.UseVisualStyleBackColor = true;
        // 
        // folderInfoLabel
        // 
        folderInfoLabel.AutoSize = true;
        folderInfoLabel.Font = new Font("Segoe UI", 9.5F);
        folderInfoLabel.ForeColor = Color.Gray;
        folderInfoLabel.Location = new Point(283, 46);
        folderInfoLabel.Name = "folderInfoLabel";
        folderInfoLabel.Size = new Size(194, 17);
        folderInfoLabel.TabIndex = 1;
        folderInfoLabel.Text = "\"0 từ · đã nhớ 0 · trong sổ lỗi 0\"";
        // 
        // folderTitleLabel
        // 
        folderTitleLabel.AutoSize = true;
        folderTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        folderTitleLabel.Location = new Point(283, 16);
        folderTitleLabel.Name = "folderTitleLabel";
        folderTitleLabel.Size = new Size(257, 30);
        folderTitleLabel.TabIndex = 0;
        folderTitleLabel.Text = "Tên thư mục đang chọn";
        // 
        // FolderScreen
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(leftPanel);
        Controls.Add(rightPanel);
        Name = "FolderScreen";
        Size = new Size(900, 640);
        leftPanel.ResumeLayout(false);
        leftPanel.PerformLayout();
        rightPanel.ResumeLayout(false);
        rightPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)wordGrid).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Label placeholderLabel;
    private Panel leftPanel;
    private Panel rightPanel;
    private Label labelFolder;
    private ListBox folderListBox;
    private Button newFolderButton;
    private Label noteLabel;
    private Label folderTitleLabel;
    private Label folderInfoLabel;
    private Button addWordButton;
    private Button importButton;
    private TextBox searchTextBox;
    private DataGridView wordGrid;
    private DataGridViewTextBoxColumn colWord;
    private DataGridViewTextBoxColumn colMean;
    private DataGridViewTextBoxColumn colPronunciation;
    private DataGridViewTextBoxColumn colRating;
    private DataGridViewButtonColumn coledit;
    private DataGridViewButtonColumn coldelete;
    private Button deleteFolderButton;
    private Button renameFolderButton;
}
