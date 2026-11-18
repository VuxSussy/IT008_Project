namespace FlashcardsApp;

// Đọc, ghi bảng Courses và các bài (thư mục có CourseId). Xem docs/03-database.md.
public static class CourseStore
{
    // Tất cả khóa học. Ai gọi: CourseScreen, AdminCoursePanel.
    public static List<Course> GetAll()
    {
        var courses = new List<Course>();

        // TODO (#39): SELECT Id, Title, Description FROM Courses ORDER BY Id

        return courses;
    }

    // Các bài của một khóa, theo thứ tự, kèm số từ đã nhớ của người đang đăng nhập.
    // Bài 1 luôn mở, bài sau mở khi bài trước IsDone. Admin thấy mọi bài đều mở.
    // Ai gọi: CourseScreen, OverviewScreen (dòng Học tiếp), AdminCoursePanel.
    public static List<Lesson> GetLessons(int courseId)
    {
        var lessons = new List<Lesson>();

        // TODO (#39): đọc Folders WHERE CourseId = @courseId ORDER BY LessonOrder, đếm từ và từ đã nhớ (code mẫu ở docs/03).
        // Đọc xong thì đi từ bài 1: IsUnlocked = (i == 0) || lessons[i - 1].IsDone || Session.CurrentUser.IsAdmin

        return lessons;
    }

    // Id các thư mục là bài đang mở với người đang đăng nhập.
    // Ai gọi: FlashcardStore.GetAll, FolderStore.GetAll (để bỏ các bài còn khóa).
    public static List<int> GetUnlockedFolderIds()
    {
        var folderIds = new List<int>();

        // TODO (#39): gọi GetAll(), với mỗi khóa gọi GetLessons, lấy FolderId của bài IsUnlocked

        return folderIds;
    }

    // ===== Admin soạn khóa học (#40) =====

    public static void Add(string title, string description)
    {
        // TODO (#40): INSERT INTO Courses (Title, Description) VALUES (@title, @description)
    }

    public static void Update(int id, string title, string description)
    {
        // TODO (#40): UPDATE Courses SET Title = @title, Description = @description WHERE Id = @id
    }

    // Xóa khóa: các bài thành thư mục thường (CourseId về NULL), từ trong bài vẫn còn.
    public static void Delete(int id)
    {
        // TODO (#40): UPDATE Folders SET CourseId = NULL, LessonOrder = NULL WHERE CourseId = @id; rồi DELETE FROM Courses WHERE Id = @id
    }

    // Gắn một thư mục của Admin vào khóa, thành bài cuối. Thư mục đang có ngày theo mùa thì xóa ngày đó.
    public static void AddLesson(int courseId, int folderId)
    {
        // TODO (#40): LessonOrder = (MAX(LessonOrder) của khóa) + 1, StartDate = NULL, EndDate = NULL
    }

    // Gỡ bài khỏi khóa, thư mục vẫn còn. Các bài sau dồn lên một số.
    public static void RemoveLesson(int folderId)
    {
        // TODO (#40)
    }

    // Đổi chỗ bài với bài ngay trên (step = -1) hoặc ngay dưới (step = 1).
    public static void MoveLesson(int folderId, int step)
    {
        // TODO (#40): tìm bài có LessonOrder = LessonOrder hiện tại + step trong cùng khóa, đổi LessonOrder của hai bài
    }
}
