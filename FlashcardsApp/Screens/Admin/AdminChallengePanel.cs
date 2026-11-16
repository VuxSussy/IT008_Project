namespace FlashcardsApp;

// Tab Quản trị · Thử thách: chọn thư mục cho thử thách của 14 ngày tới. Màn trống từ #35, phần bên trong làm ở #42.
// Xem docs/04-gui.md.
public partial class AdminChallengePanel : UserControl
{
    private const int ScheduleDays = 14;

    public AdminChallengePanel()
    {
        InitializeComponent();
    }

    // scheduleGrid: Ngày, Thư mục (DataGridViewComboBoxColumn có "Tự chọn" và các thư mục của Admin), Số từ
    private void LoadSchedule()
    {
        // TODO (#42): ChallengeStore.GetSchedule(DateTime.Today, ScheduleDays), mỗi ngày một dòng.
        // todayInfoLabel: "Hôm nay 3 người đã làm, cao nhất 9/10" từ ChallengeStore.GetRanking(DateTime.Today)
    }

    // Nút Lưu: ghi cả 14 dòng
    private void SaveSchedule()
    {
        // TODO (#42): mỗi dòng gọi ChallengeStore.SetFolder(date, folderId); "Tự chọn" thì folderId là null
    }
}
