namespace FlashcardsApp;

// Màn Quản trị, chỉ Admin thấy. Màn trống từ #35, khung 4 tab làm ở #40. Xem docs/04-gui.md.
// Mỗi tab là một UserControl riêng trong thư mục này, mỗi người làm một tab nên không đụng file nhau:
//   AdminCoursePanel (#40), AdminSeasonPanel (#43), AdminChallengePanel (#42), AdminUserPanel (#44)
public partial class AdminScreen : UserControl
{
    public AdminScreen()
    {
        InitializeComponent();
    }

    // Bấm nút tab nào thì hiện UserControl của tab đó vào tabContentPanel, giống MainWindow.ShowScreen.
    private void ShowTab(UserControl panel)
    {
        // TODO (#40): kéo 4 nút tab (Khóa học, Theo mùa, Thử thách, Người dùng) và tabContentPanel vào Designer, rồi:
        //     panel.Dock = DockStyle.Fill;
        //     tabContentPanel.Controls.Clear();
        //     tabContentPanel.Controls.Add(panel);
        // Mở màn thì hiện tab Khóa học: ShowTab(new AdminCoursePanel());
    }
}
