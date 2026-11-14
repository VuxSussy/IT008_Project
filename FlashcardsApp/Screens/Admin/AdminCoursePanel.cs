namespace FlashcardsApp;

// Tab Quản trị · Khóa học. Màn trống từ #35, phần bên trong làm ở #40. Xem docs/04-gui.md.
// Admin soạn từ ở Thư mục của tôi như User, rồi gắn thư mục vào khóa ở đây.
public partial class AdminCoursePanel : UserControl
{
    public AdminCoursePanel()
    {
        InitializeComponent();
    }

    // Bên trái: courseListBox, nút thêm, đổi tên, xóa (xóa thì hỏi lại), descriptionTextBox
    private void LoadCourses()
    {
        // TODO (#40): CourseStore.GetAll() vào courseListBox; chọn khóa nào thì ShowLessons(course.Id)
    }

    // Bên phải: các bài theo thứ tự, mỗi bài có nút lên, xuống, Gỡ; dưới cùng folderComboBox và nút Thêm bài
    private void ShowLessons(int courseId)
    {
        // TODO (#40): CourseStore.GetLessons(courseId) vào lessonPanel.
        //   Nút lên, xuống: CourseStore.MoveLesson(folderId, -1 / 1); Gỡ: CourseStore.RemoveLesson(folderId)
        //   folderComboBox: FolderStore.GetMine() bỏ thư mục đã thuộc khóa nào; Thêm bài: CourseStore.AddLesson(courseId, folderId)
        //   Dòng ghi chú: "Sửa từ trong bài: vào Thư mục của tôi"
    }
}
