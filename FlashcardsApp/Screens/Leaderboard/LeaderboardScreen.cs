namespace FlashcardsApp;

// Màn Bảng xếp hạng: 4 tab, mỗi tab một kiểu thi đua. Màn trống từ #35, phần bên trong làm ở #45. Xem docs/04-gui.md.
// Chỉ tính tài khoản User.
public partial class LeaderboardScreen : UserControl
{
    // Tên 4 tab, màn khác dùng khi gọi ShowTab
    public const string TodayTab = "today";
    public const string WeekTab = "week";
    public const string RushTab = "rush";
    public const string StreakTab = "streak";

    public LeaderboardScreen()
    {
        InitializeComponent();
    }

    // Mở đúng một tab. Ai gọi: 4 nút tab, màn Thử thách và Đua từ (nút Xem bảng xếp hạng), dòng Bảng xếp hạng ở Tổng quan.
    public void ShowTab(string tab)
    {
        List<RankRow> rows;
        switch (tab)
        {
            case TodayTab:
                rows = ChallengeStore.GetRanking(DateTime.Today);
                break;
            case WeekTab:
                rows = ChallengeStore.GetWeekRanking();
                break;
            case RushTab:
                rows = RushStore.GetRanking();
                break;
            default:
                rows = ActivityStore.GetStreakRanking();
                break;
        }

        // TODO (#45):
        //   - tô nút tab đang chọn (Selected = true như nút menu)
        //   - đổ 10 dòng đầu của rows vào rankGrid: Hạng, Tên, Điểm, Chi tiết. Hạng 1 đến 3 chữ đậm.
        //     Dòng có IsMe nền StudyTheme.SoftTeal
        //   - người đang đăng nhập ngoài top 10 thì myRankLabel ghi "Bạn đang hạng 14", không thì ẩn
        //   Làm tab Chuỗi ngày trước vì hàm đã có từ #38
    }
}
