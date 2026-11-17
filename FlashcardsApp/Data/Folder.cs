namespace FlashcardsApp;

// Một thư mục từ vựng, ứng với một dòng trong bảng Folders.
// Mỗi người có một thư mục "Chưa phân loại" (IsDefault = 1 trong bảng): không đổi tên, không xóa được.
public sealed class Folder
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
