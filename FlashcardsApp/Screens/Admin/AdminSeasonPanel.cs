namespace FlashcardsApp;

// Tab Quản trị · Theo mùa. Màn trống từ #35, phần bên trong làm ở #43. Xem docs/04-gui.md.
public partial class AdminSeasonPanel : UserControl
{
    public AdminSeasonPanel()
    {
        InitializeComponent();
    }

    // seasonGrid: Thư mục, Từ ngày, Đến ngày, Trạng thái (Sắp tới / Đang diễn ra / Đã hết)
    private void LoadSeasons()
    {
        // TODO (#43): các thư mục của Admin (FolderStore.GetMine()) có StartDate; Trạng thái tính bằng GetStatus
    }

    // Nút Lưu
    private void SaveSeason(int folderId, DateTime start, DateTime end)
    {
        // TODO (#43): end trước start thì báo "Ngày kết thúc phải sau ngày bắt đầu." và không lưu;
        // còn lại FolderStore.SetSeason(folderId, start, end) rồi LoadSeasons(). Nút Bỏ ngày gọi FolderStore.ClearSeason(folderId)
    }

    // Tính cả ngày đầu và ngày cuối
    private static string GetStatus(DateTime start, DateTime end)
    {
        var today = DateTime.Today;
        if (today < start.Date) return "Sắp tới";
        if (today > end.Date) return "Đã hết";
        return "Đang diễn ra";
    }
}
