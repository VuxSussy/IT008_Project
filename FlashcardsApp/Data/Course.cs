namespace FlashcardsApp;

// Một khóa học do Admin soạn, ứng với một dòng trong bảng Courses (#39).
public sealed class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
}
