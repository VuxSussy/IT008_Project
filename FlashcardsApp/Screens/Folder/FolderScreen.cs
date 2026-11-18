using Microsoft.Data.SqlClient;

namespace FlashcardsApp;

// Màn Thư mục và từ vựng (#6). Xem docs/04-gui.md mục 2.
// Các nút thêm, sửa, xóa thư mục và từ là việc của #11 (cần các hàm của #7).
public partial class FolderScreen : UserControl
{
    private List<Folder> folders = new();
    private Dictionary<int, int> cardCounts = new();   // số từ của mỗi thư mục, theo Id thư mục
    private List<Flashcard> allCardsInFolder = new();
    private Folder? selectedFolder;

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

        if (!DesignMode) LoadFolders();
    }

    public void LoadFolders()
    {
        try
        {
            folders = FolderStore.GetAll();
            UpdateAllFolderCardCounts();
        }
        catch (SqlException ex)
        {
            ShowLoadError(ex);
            folders = new List<Folder>();
        }

        folderListBox.DataSource = null;
        folderListBox.DataSource = folders;
        if (folders.Count > 0) folderListBox.SelectedIndex = 0;

        UpdateFolderLayout();
    }

    // Đổi số đo trên màn 100% sang màn đang dùng, để phần tự vẽ không bị nhỏ trên màn nét
    private int S(float value) => (int)StudyTheme.Scale(this, value);

    private void ShowLoadError(SqlException ex)
    {
        MessageBox.Show(this, "Không đọc được dữ liệu. Hãy tắt app, mở lại rồi thử lần nữa.\n\n" + ex.Message,
            "Thư mục", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void UpdateFolderLayout()
    {
        int count = folders.Count;
        int itemHeight = folderListBox.ItemHeight;
        int contentHeight = count * itemHeight;

        // Vị trí tối đa cho phép trước khi đụng noteLabel ở đáy cột
        int maxBottom = noteLabel.Top - S(16) - newFolderButton.Height - S(12);
        int availableHeight = Math.Max(itemHeight, maxBottom - folderListBox.Top);

        // Chiều cao ListBox ôm khít số lượng thư mục (không vượt quá vùng cho phép)
        folderListBox.Height = Math.Min(contentHeight, availableHeight);

        // Đặt nút "+ Thư mục mới" nằm ngay sát dưới thư mục cuối cùng (cách 12px)
        newFolderButton.Top = folderListBox.Bottom + S(12);
    }

    // Đếm số từ của mọi thư mục bằng một lần đọc, thay vì gọi GetByFolder cho từng thư mục
    private void UpdateAllFolderCardCounts()
    {
        cardCounts = FlashcardStore.GetAll()
            .GroupBy(c => c.FolderId)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    private void folderListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        selectedFolder = folderListBox.SelectedItem as Folder;
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

        var selected = folderListBox.SelectedItem as Folder;
        if (selected == null || selected.IsDefault) // "Chưa phân loại" không có nút sửa/xóa
        {
            renameFolderButton.Visible = false;
            deleteFolderButton.Visible = false;
            return;
        }

        var rect = folderListBox.GetItemRectangle(folderListBox.SelectedIndex);
        int btnY = folderListBox.Top + rect.Top + (rect.Height - S(24)) / 2;
        int rightMargin = folderListBox.Left + rect.Width - S(36); // Trước vị trí số lượng từ

        deleteFolderButton.Location = new Point(rightMargin - S(22), btnY);
        renameFolderButton.Location = new Point(rightMargin - S(46), btnY);

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
        using var canvasBrush = new SolidBrush(StudyTheme.Canvas);
        e.Graphics.FillRectangle(canvasBrush, e.Bounds);

        var cardBounds = new Rectangle(e.Bounds.X + S(2), e.Bounds.Y + S(4), e.Bounds.Width - S(4), e.Bounds.Height - S(8));

        if (isSelected)
        {
            // Thư mục được chọn: Card trắng bo góc có viền xanh Teal #0F766E
            using var whiteBrush = new SolidBrush(Color.White);
            using var tealPen = new Pen(StudyTheme.Teal, StudyTheme.Scale(this, 1.5f));
            using var path = StudyTheme.RoundedRectangle(cardBounds, S(8));
            e.Graphics.FillPath(whiteBrush, path);
            e.Graphics.DrawPath(tealPen, path);
        }

        // Tên thư mục
        string displayName = item.IsDefault ? $"🔒  {item.Name}" : item.Name;
        using var font = new Font("Segoe UI", 10F, isSelected ? FontStyle.Bold : FontStyle.Regular);
        Color textColor = isSelected ? StudyTheme.Ink : StudyTheme.Slate;

        var textRect = new Rectangle(cardBounds.Left + S(12), cardBounds.Top, cardBounds.Width - S(85), cardBounds.Height);
        TextRenderer.DrawText(e.Graphics, displayName, font, textRect, textColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        // Số lượng từ ở mép phải
        using var countFont = new Font("Segoe UI", 9.5F, isSelected ? FontStyle.Bold : FontStyle.Regular);
        Color countColor = isSelected ? StudyTheme.Teal : StudyTheme.Muted;
        var countRect = new Rectangle(cardBounds.Right - S(40), cardBounds.Top, S(32), cardBounds.Height);
        TextRenderer.DrawText(e.Graphics, cardCounts.GetValueOrDefault(item.Id).ToString(), countFont, countRect, countColor,
            TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
    }

    private void LoadCardsForFolder(int folderId)
    {
        try
        {
            allCardsInFolder = FlashcardStore.GetByFolder(folderId);
        }
        catch (SqlException ex)
        {
            ShowLoadError(ex);
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

            // Màu lấy trong StudyTheme (docs/02 quy tắc 8). Quên, Khó là từ đang nằm trong sổ lỗi nên dùng màu cam, vàng
            var (bg, fg) = text switch
            {
                "Quên" => (StudyTheme.SoftWarning, StudyTheme.Warning),
                "Khó" => (StudyTheme.SoftGold, StudyTheme.Gold),
                "Nhớ" => (StudyTheme.SoftTeal, StudyTheme.DarkTeal),
                "Dễ" => (StudyTheme.Teal, Color.White),
                _ => (StudyTheme.Divider, StudyTheme.Slate)          // Chưa học
            };

            int pillWidth = S(68);
            int pillHeight = S(24);
            int pillX = e.CellBounds.X + (e.CellBounds.Width - pillWidth) / 2;
            int pillY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
            var pillRect = new Rectangle(pillX, pillY, pillWidth, pillHeight);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(bg);
            using var path = StudyTheme.RoundedRectangle(pillRect, S(12));
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
        // TODO (#11): mở AddCardDialog, bấm Lưu thì FlashcardStore.Add(dialog.Card) vào thư mục đang chọn,
        // rồi UpdateAllFolderCardCounts(), folderListBox.Invalidate(), LoadCardsForFolder(selectedFolder.Id)
    }

    private void wordGrid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (wordGrid.Rows[e.RowIndex].Tag is not Flashcard card) return;

        if (e.ColumnIndex == editColumn.Index)
        {
            // TODO (#11): mở AddCardDialog ở chế độ Sửa với card, bấm Lưu thì FlashcardStore.Update rồi tải lại bảng
        }
        else if (e.ColumnIndex == deleteColumn.Index)
        {
            // TODO (#11): hỏi "Bạn có chắc muốn xóa từ này?", Yes thì FlashcardStore.Delete(card.Id) rồi tải lại
        }
    }

    private void newFolderButton_Click(object? sender, EventArgs e)
    {
        // TODO (#11): hỏi tên, kiểm tra FolderStore.NameExists, gọi FolderStore.Add rồi LoadFolders()
    }

    private void renameFolderButton_Click(object? sender, EventArgs e)
    {
        if (selectedFolder is null || selectedFolder.IsDefault) return;
        // TODO (#11): hỏi tên mới, kiểm tra FolderStore.NameExists, gọi FolderStore.Rename rồi LoadFolders()
    }

    private void deleteFolderButton_Click(object? sender, EventArgs e)
    {
        if (selectedFolder is null || selectedFolder.IsDefault) return;
        // TODO (#11): hỏi lại (từ trong thư mục sẽ về "Chưa phân loại"), gọi FolderStore.Delete rồi LoadFolders()
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