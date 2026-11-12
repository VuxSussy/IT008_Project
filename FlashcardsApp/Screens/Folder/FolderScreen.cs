namespace FlashcardsApp;

public partial class FolderScreen : UserControl
{
    private List<FolderItem> folders = new();
    private List<Flashcard> allCardsInFolder = new();
    private FolderItem? selectedFolder;

    public FolderScreen()
    {
        InitializeComponent();

        this.folderListBox.DrawItem += folderListBox_DrawItem;
        this.folderListBox.SelectedIndexChanged += folderListBox_SelectedIndexChanged;
        this.folderListBox.MouseWheel += (_, _) => BeginInvoke(UpdateFolderActionButtons);

        this.searchTextBox.TextChanged += searchTextBox_TextChanged;
        this.wordGrid.CellContentClick += wordGrid_CellContentClick;
        this.wordGrid.CellPainting += wordGrid_CellPainting;

        this.addWordButton.Click += addWordButton_Click;
        this.newFolderButton.Click += newFolderButton_Click;
        this.renameFolderButton.Click += renameFolderButton_Click;
        this.deleteFolderButton.Click += deleteFolderButton_Click;
        this.studyFolderButton.Click += studyFolderButton_Click;
        this.importButton.Click += importButton_Click;
        this.leftPanel.Resize += (_, _) => UpdateFolderLayout();

        LoadFolders();
    }

    public void LoadFolders()
    {
        // Khi merge nhánh Database sẽ gọi FolderStore.GetAll();
        // Hiện tại khởi tạo mẫu theo đúng concept hình 2-folders.png:
        folders = new List<FolderItem>
        {
            new() { Id = 1, Name = "Chưa phân loại" },
            new() { Id = 2, Name = "Unit 1 – Daily life" },
            new() { Id = 3, Name = "Unit 2 – Work" },
            new() { Id = 4, Name = "Từ IELTS" }
        };

        UpdateAllFolderCardCounts();

        folderListBox.DataSource = null;
        folderListBox.DataSource = folders;

        if (folders.Count > 1)
            folderListBox.SelectedIndex = 1; // Chọn Unit 1 - Daily life như hình mẫu
        else if (folders.Count > 0)
            folderListBox.SelectedIndex = 0;

        UpdateFolderLayout();
    }

    private void UpdateFolderLayout()
    {
        int count = folders.Count;
        int itemHeight = folderListBox.ItemHeight;
        int contentHeight = count * itemHeight;

        // Vị trí tối đa cho phép trước khi đụng noteLabel ở đáy cột
        int maxBottom = noteLabel.Top - 16 - newFolderButton.Height - 12;
        int availableHeight = Math.Max(itemHeight, maxBottom - folderListBox.Top);

        // Chiều cao ListBox ôm khít số lượng thư mục (không vượt quá vùng cho phép)
        folderListBox.Height = Math.Min(contentHeight, availableHeight);

        // Đặt nút "+ Thư mục mới" nằm ngay sát dưới thư mục cuối cùng (cách 12px)
        newFolderButton.Top = folderListBox.Bottom + 12;
    }

    private void UpdateAllFolderCardCounts()
    {
        try
        {
            var all = FlashcardStore.Load(FlashcardStore.DefaultPath);
            foreach (var f in folders)
            {
                f.CardCount = all.Count(c => c.FolderId == f.Id || (f.Id == 1 && c.FolderId == 0));
            }
        }
        catch
        {
            foreach (var f in folders) f.CardCount = 0;
        }
    }

    private void folderListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        selectedFolder = folderListBox.SelectedItem as FolderItem;
        if (selectedFolder is null) return;

        folderTitleLabel.Text = selectedFolder.Name;
        UpdateFolderActionButtons();
        LoadCardsForFolder(selectedFolder.Id);
    }

    private void UpdateFolderActionButtons()
    {
        if (folderListBox.SelectedIndex < 0)
        {
            renameFolderButton.Visible = false;
            deleteFolderButton.Visible = false;
            return;
        }

        var selected = folderListBox.SelectedItem as FolderItem;
        if (selected == null || selected.Id == 1) // Chưa phân loại không có nút sửa/xóa
        {
            renameFolderButton.Visible = false;
            deleteFolderButton.Visible = false;
            return;
        }

        var rect = folderListBox.GetItemRectangle(folderListBox.SelectedIndex);
        int btnY = folderListBox.Top + rect.Top + (rect.Height - 24) / 2;
        int rightMargin = folderListBox.Left + rect.Width - 36; // Trước vị trí số lượng từ

        deleteFolderButton.Location = new Point(rightMargin - 22, btnY);
        renameFolderButton.Location = new Point(rightMargin - 46, btnY);

        renameFolderButton.Visible = true;
        deleteFolderButton.Visible = true;
        renameFolderButton.BringToFront();
        deleteFolderButton.BringToFront();
    }

    private void folderListBox_DrawItem(object? sender, DrawItemEventArgs e)
    {
        if (e.Index < 0 || e.Index >= folders.Count || e.Graphics is null) return;

        var item = folders[e.Index];
        bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

        // Vẽ nền tổng thể của vùng item
        using var canvasBrush = new SolidBrush(Color.FromArgb(247, 249, 250));
        e.Graphics.FillRectangle(canvasBrush, e.Bounds);

        var cardBounds = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 4, e.Bounds.Width - 4, e.Bounds.Height - 8);

        if (isSelected)
        {
            // Thư mục được chọn: Card trắng bo góc có viền xanh Teal #0F766E
            using var whiteBrush = new SolidBrush(Color.White);
            using var tealPen = new Pen(Color.FromArgb(15, 118, 110), 1.5f);
            using var path = StudyTheme.Round(cardBounds, 8);
            e.Graphics.FillPath(whiteBrush, path);
            e.Graphics.DrawPath(tealPen, path);
        }

        // Tên thư mục
        string displayName = item.Id == 1 ? $"🔒  {item.Name}" : item.Name;
        using var font = new Font("Segoe UI", 10F, isSelected ? FontStyle.Bold : FontStyle.Regular);
        Color textColor = isSelected ? Color.FromArgb(15, 23, 42) : Color.FromArgb(51, 65, 85);

        var textRect = new Rectangle(cardBounds.Left + 12, cardBounds.Top, cardBounds.Width - 85, cardBounds.Height);
        TextRenderer.DrawText(e.Graphics, displayName, font, textRect, textColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        // Số lượng từ ở mép phải
        using var countFont = new Font("Segoe UI", 9.5F, isSelected ? FontStyle.Bold : FontStyle.Regular);
        Color countColor = isSelected ? Color.FromArgb(15, 118, 110) : Color.FromArgb(100, 116, 139);
        var countRect = new Rectangle(cardBounds.Right - 40, cardBounds.Top, 32, cardBounds.Height);
        TextRenderer.DrawText(e.Graphics, item.CardCount.ToString(), countFont, countRect, countColor,
            TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
    }

    private void LoadCardsForFolder(int folderId)
    {
        try
        {
            var all = FlashcardStore.Load(FlashcardStore.DefaultPath);
            allCardsInFolder = all.Where(c => c.FolderId == folderId || (folderId == 1 && c.FolderId == 0)).ToList();
        }
        catch
        {
            allCardsInFolder = new List<Flashcard>();
        }

        if (selectedFolder != null)
        {
            selectedFolder.CardCount = allCardsInFolder.Count;
        }

        UpdateStatistics();
        FilterAndBindGrid();
    }

    private void FilterAndBindGrid()
    {
        var keyword = searchTextBox.Text.Trim().ToLowerInvariant();
        var filtered = allCardsInFolder.Where(c =>
            string.IsNullOrEmpty(keyword) ||
            c.Word.ToLowerInvariant().Contains(keyword) ||
            c.Meaning.ToLowerInvariant().Contains(keyword)
        ).ToList();

        wordGrid.Rows.Clear();
        foreach (var c in filtered)
        {
            string ratingText = c.LastRating switch
            {
                1 => "Quên",
                2 => "Khó",
                3 => "Nhớ",
                4 => "Dễ",
                _ => "Chưa học"
            };

            int rowIndex = wordGrid.Rows.Add(c.Word, c.Meaning, c.Pronunciation, ratingText, "✏", "🗑");
            wordGrid.Rows[rowIndex].Tag = c;
        }

        countLabel.Text = $"Hiện {filtered.Count} / {allCardsInFolder.Count} từ";
    }

    private void wordGrid_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Graphics is null) return;

        // Vẽ cột Mức nhớ dạng Pill badge bo góc
        if (e.ColumnIndex == colRating.Index && e.Value != null)
        {
            e.PaintBackground(e.ClipBounds, true);
            string text = e.Value.ToString() ?? "";

            Color bg = Color.FromArgb(241, 245, 249);
            Color fg = Color.FromArgb(71, 85, 105);

            switch (text)
            {
                case "Nhớ":
                    bg = Color.FromArgb(220, 252, 231);
                    fg = Color.FromArgb(22, 101, 52);
                    break;
                case "Khó":
                    bg = Color.FromArgb(254, 243, 199);
                    fg = Color.FromArgb(180, 83, 9);
                    break;
                case "Dễ":
                    bg = Color.FromArgb(204, 251, 241);
                    fg = Color.FromArgb(15, 118, 110);
                    break;
                case "Quên":
                    bg = Color.FromArgb(254, 226, 226);
                    fg = Color.FromArgb(185, 28, 28);
                    break;
            }

            int pillWidth = 68;
            int pillHeight = 24;
            int pillX = e.CellBounds.X + (e.CellBounds.Width - pillWidth) / 2;
            int pillY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
            var pillRect = new Rectangle(pillX, pillY, pillWidth, pillHeight);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(bg);
            using var path = StudyTheme.Round(pillRect, 12);
            e.Graphics.FillPath(brush, path);

            using var font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            TextRenderer.DrawText(e.Graphics, text, font, pillRect, fg,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            e.Handled = true;
        }
    }

    private void searchTextBox_TextChanged(object? sender, EventArgs e)
    {
        FilterAndBindGrid();
    }

    private void UpdateStatistics()
    {
        int total = allCardsInFolder.Count;
        int learned = allCardsInFolder.Count(c => c.LastRating >= 3);
        int mistakes = allCardsInFolder.Count(c => c.LastRating is 1 or 2);

        folderInfoLabel.Text = $"{total} từ · đã nhớ {learned} · đang trong sổ lỗi {mistakes}";
    }

    private void addWordButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new AddCardDialog(allCardsInFolder);
        if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Card is not null)
        {
            dialog.Card.FolderId = selectedFolder?.Id ?? 1;

            var all = FlashcardStore.Load(FlashcardStore.DefaultPath);
            all.Add(dialog.Card);
            FlashcardStore.Save(FlashcardStore.DefaultPath, all);

            UpdateAllFolderCardCounts();
            folderListBox.Invalidate();
            LoadCardsForFolder(selectedFolder?.Id ?? 1);
        }
    }

    private void wordGrid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var card = wordGrid.Rows[e.RowIndex].Tag as Flashcard;
        if (card is null) return;

        // Bấm nút Sửa
        if (e.ColumnIndex == coledit.Index)
        {
            using var dialog = new AddCardDialog(allCardsInFolder);
            if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Card is not null)
            {
                card.Word = dialog.Card.Word;
                card.Meaning = dialog.Card.Meaning;
                card.Pronunciation = dialog.Card.Pronunciation;
                card.Example = dialog.Card.Example;
                card.ExampleTranslation = dialog.Card.ExampleTranslation;
                card.MemoryNote = dialog.Card.MemoryNote;

                var all = FlashcardStore.Load(FlashcardStore.DefaultPath);
                FlashcardStore.Save(FlashcardStore.DefaultPath, all);
                LoadCardsForFolder(selectedFolder?.Id ?? 1);
            }
        }
        // Bấm nút Xóa
        else if (e.ColumnIndex == coldelete.Index)
        {
            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa từ \"{card.Word}\"?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                allCardsInFolder.Remove(card);
                var all = FlashcardStore.Load(FlashcardStore.DefaultPath);
                all.RemoveAll(c => c.Word == card.Word && c.Meaning == card.Meaning);
                FlashcardStore.Save(FlashcardStore.DefaultPath, all);

                UpdateAllFolderCardCounts();
                folderListBox.Invalidate();
                LoadCardsForFolder(selectedFolder?.Id ?? 1);
            }
        }
    }

    private void newFolderButton_Click(object? sender, EventArgs e)
    {
        using var prompt = new Form
        {
            Width = 360,
            Height = 170,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = "Thư mục mới",
            StartPosition = FormStartPosition.CenterParent,
            MaximizeBox = false,
            MinimizeBox = false,
            BackColor = Color.White
        };

        var label = new Label { Left = 20, Top = 16, Text = "Tên thư mục:", AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        var textBox = new TextBox { Left = 20, Top = 40, Width = 300, Font = new Font("Segoe UI", 10F) };
        var okBtn = new Button { Text = "Tạo", Left = 150, Width = 80, Top = 80, Height = 30, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(15, 118, 110), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
        var cancelBtn = new Button { Text = "Hủy", Left = 240, Width = 80, Top = 80, Height = 30, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };

        prompt.Controls.AddRange(new Control[] { label, textBox, okBtn, cancelBtn });
        prompt.AcceptButton = okBtn;
        prompt.CancelButton = cancelBtn;

        if (prompt.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(textBox.Text))
        {
            string name = textBox.Text.Trim();
            if (folders.Any(f => string.Equals(f.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Thư mục này đã tồn tại!", "Trùng tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nextId = (folders.Count > 0 ? folders.Max(f => f.Id) : 0) + 1;
            var newFolder = new FolderItem { Id = nextId, Name = name, CardCount = 0 };
            folders.Add(newFolder);

            folderListBox.DataSource = null;
            folderListBox.DataSource = folders;
            folderListBox.SelectedItem = newFolder;
            UpdateFolderLayout();
        }
    }

    private void renameFolderButton_Click(object? sender, EventArgs e)
    {
        if (selectedFolder is null || selectedFolder.Id == 1) return;

        using var prompt = new Form
        {
            Width = 360,
            Height = 170,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = "Đổi tên thư mục",
            StartPosition = FormStartPosition.CenterParent,
            MaximizeBox = false,
            MinimizeBox = false,
            BackColor = Color.White
        };

        var label = new Label { Left = 20, Top = 16, Text = "Tên mới:", AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        var textBox = new TextBox { Left = 20, Top = 40, Width = 300, Font = new Font("Segoe UI", 10F), Text = selectedFolder.Name };
        var okBtn = new Button { Text = "Lưu", Left = 150, Width = 80, Top = 80, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(15, 118, 110), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
        var cancelBtn = new Button { Text = "Hủy", Left = 240, Width = 80, Top = 80, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };

        prompt.Controls.AddRange(new Control[] { label, textBox, okBtn, cancelBtn });
        prompt.AcceptButton = okBtn;
        prompt.CancelButton = cancelBtn;

        if (prompt.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(textBox.Text))
        {
            selectedFolder.Name = textBox.Text.Trim();
            folderTitleLabel.Text = selectedFolder.Name;
            folderListBox.Invalidate();
        }
    }

    private void deleteFolderButton_Click(object? sender, EventArgs e)
    {
        if (selectedFolder is null || selectedFolder.Id == 1) return;

        var confirm = MessageBox.Show(
            $"Bạn có chắc muốn xóa thư mục \"{selectedFolder.Name}\"?\n\nCác từ trong thư mục sẽ được chuyển về \"Chưa phân loại\".",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            try
            {
                var all = FlashcardStore.Load(FlashcardStore.DefaultPath);
                foreach (var c in all.Where(c => c.FolderId == selectedFolder.Id))
                {
                    c.FolderId = 1; // Chuyển về Chưa phân loại
                }
                FlashcardStore.Save(FlashcardStore.DefaultPath, all);
            }
            catch { }

            folders.Remove(selectedFolder);
            UpdateAllFolderCardCounts();

            folderListBox.DataSource = null;
            folderListBox.DataSource = folders;
            folderListBox.SelectedIndex = 0;
            UpdateFolderLayout();
        }
    }

    private void studyFolderButton_Click(object? sender, EventArgs e)
    {
        if (selectedFolder is null || allCardsInFolder.Count == 0)
        {
            MessageBox.Show("Thư mục này chưa có từ vựng để học. Hãy thêm từ trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var main = FindForm() as MainWindow;
        var study = new StudyScreen();
        main?.ShowScreen(study);
        study.StartFolder(selectedFolder.Id);
    }

    private void importButton_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("Chức năng Nhập nhiều từ (Sáng tạo #15) sẽ được bổ sung sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

}
