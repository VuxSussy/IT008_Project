namespace FlashcardsApp;

// Màn Khóa học. Màn trống từ #35, phần bên trong làm ở #39. Xem docs/04-gui.md.
// Bên trái courseListBox (rộng 260), bên phải courseTitleLabel, courseInfoLabel, lessonPanel.
// Trên cùng để sẵn eventPanel trống cho thư mục theo mùa (#43).
public partial class CourseScreen : UserControl
{
    public CourseScreen()
    {
        InitializeComponent();
    }

    // Đổ CourseStore.GetAll() vào courseListBox, ghi kèm "2/3 bài" (số bài đã xong / tổng). Gọi khi mở màn.
    private void LoadCourses()
    {
        // TODO (#39)
    }

    // Hiện các bài của khóa đang chọn vào lessonPanel. Gọi khi chọn khóa trong courseListBox.
    private void ShowLessons(int courseId)
    {
        // TODO (#39): CourseStore.GetLessons(courseId). Mỗi bài là một CardPanel tạo bằng code:
        //   "Bài 2 · tên bài", "6/10 đã nhớ", thanh tiến độ, nút Học gọi StudyLesson(lesson.FolderId)
        //   Bài khóa: làm mờ, biểu tượng khóa, "Nhớ 8/10 từ bài 1 để mở". Bài xong: dấu ✓, nút Ôn lại
    }

    // Mỗi thư mục theo mùa đang diễn ra là một thẻ trong eventPanel; không có thì ẩn eventPanel.
    private void ShowEvents()
    {
        // TODO (#43): FolderStore.GetSeasonal(), mỗi thẻ ghi tên, "đến 31/12", "6/10 đã nhớ", nút Học
    }

    // Nút Học trong mỗi bài và mỗi thẻ sự kiện
    private void StudyLesson(int folderId)
    {
        var studyScreen = new StudyScreen();
        (FindForm() as MainWindow)?.ShowScreen(studyScreen);
        studyScreen.StartFolder(folderId);
    }
}
