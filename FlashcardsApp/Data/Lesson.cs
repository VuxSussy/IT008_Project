namespace FlashcardsApp;

// Một bài trong khóa học. Mỗi bài là một thư mục của Admin có CourseId và LessonOrder (#39).
public sealed class Lesson
{
    public int FolderId { get; set; }
    public string Name { get; set; } = "";
    public int Order { get; set; }        // bài 1, 2, 3...
    public int WordCount { get; set; }
    public int LearnedCount { get; set; } // số từ người đang đăng nhập đã nhớ
    public bool IsUnlocked { get; set; }  // bài 1 luôn mở; bài sau mở khi bài trước IsDone

    // Xong khi bài không có từ nào, hoặc đã nhớ từ 80% số từ trở lên
    public bool IsDone => WordCount == 0 || LearnedCount * 100 >= WordCount * 80;
}
