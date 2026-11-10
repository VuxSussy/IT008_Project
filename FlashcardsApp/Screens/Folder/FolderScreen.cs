namespace FlashcardsApp;

public partial class FolderScreen : UserControl
{
    private List<FolderItem> folders = new();
    private List<Flashcard> allCardsInFolder = new();
    private FolderItem? selectedFolder;

    public FolderScreen()
    {
        InitializeComponent();
        this.Load += FolderScreen_Load;
        this.searchTextBox.TextChanged += searchTextBox_TextChanged;
        this.folderListBox.SelectedIndexChanged += folderListBox_SelectedIndexChanged;
        this.wordGrid.CellContentClick += wordGrid_CellContentClick;
        this.newFolderButton.Click += newFolderButton_Click;
    }

    private void FolderScreen_Load(object? sender, EventArgs e)
    {
        LoadFolders();
    }

    public void LoadFolders()
    {
        folders = new List<FolderItem>
        {
            new() { Id = 1, Name = "Chưa phân loại" },
            new() { Id = 2, Name = "Từ vựng hàng ngày" },
            new() { Id = 3, Name = "IELTS Chuyên sâu" }
        };

        folderListBox.DataSource = null;
        folderListBox.DataSource = folders;

        if (folders.Count > 0)
            folderListBox.SelectedIndex = 0;
    }

    private void folderListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        selectedFolder = folderListBox.SelectedItem as FolderItem;
        if (selectedFolder is null) return;

        folderTitleLabel.Text = selectedFolder.Name;
        LoadCardsForFolder(selectedFolder.Id);
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

            int rowIndex = wordGrid.Rows.Add(c.Word, c.Meaning, c.Pronunciation, ratingText);
            wordGrid.Rows[rowIndex].Tag = c;
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

    // Sự kiện nút "+ Thêm từ" (bạn đã liên kết sự kiện button2_Click trong Designer)
    private void button2_Click(object? sender, EventArgs e)
    {
        using var dialog = new AddCardDialog(allCardsInFolder);
        if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Card is not null)
        {
            dialog.Card.FolderId = selectedFolder?.Id ?? 1;
            allCardsInFolder.Add(dialog.Card);

            // Lưu lại vào store
            var all = FlashcardStore.Load(FlashcardStore.DefaultPath);
            all.Add(dialog.Card);
            FlashcardStore.Save(FlashcardStore.DefaultPath, all);

            LoadCardsForFolder(selectedFolder?.Id ?? 1);
        }
    }

    // Xử lý nút Sửa và Xóa trên từng dòng bảng
    private void wordGrid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var card = wordGrid.Rows[e.RowIndex].Tag as Flashcard;
        if (card is null) return;

        // Bấm nút Sửa (coledit)
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
        // Bấm nút Xóa (coldelete)
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
                LoadCardsForFolder(selectedFolder?.Id ?? 1);
            }
        }
    }

    private void newFolderButton_Click(object? sender, EventArgs e)
    {
        // Bạn có thể dùng Form nhỏ hỏi tên thư mục hoặc thêm nhanh:
        // Sau khi hoàn thiện có thể gọi FolderStore.Add
    }
}
