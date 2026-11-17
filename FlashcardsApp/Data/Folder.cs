namespace FlashcardsApp;

// Một thư mục từ vựng, ứng với một dòng trong bảng Folders.
// Thư mục số 1 là "Chưa phân loại": không đổi tên, không xóa được.
public sealed class Folder
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int OwnerId { get; set; }
    public bool IsDefault { get; set; }
    public int? CourseId { get; set; }
    public int? LessonOrder { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

}
