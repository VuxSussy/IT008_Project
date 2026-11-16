using Microsoft.Data.Sqlite;

namespace FlashcardsApp;

// Đọc, ghi bảng Folders. Mọi câu SQL về thư mục nằm ở đây. Xem docs/03-database.md.
public static class FolderStore
{
    // Lấy tất cả thư mục, xếp theo Id (thư mục số 1 "Chưa phân loại" đứng đầu).
    // Ai gọi: màn Thư mục, màn Tổng quan (đếm số thư mục), ô chọn thư mục ở màn Học.
    public static List<Folder> GetAll()
    {
        var folders = new List<Folder>();

        // TODO (#4): đọc bảng Folders, làm giống FlashcardStore.GetAll ở docs/03 mục "Đọc dữ liệu":
        //     using var conn = new SqliteConnection(Database.ConnectionString);
        //     using var cmd = new SqliteCommand("SELECT Id, Name FROM Folders ORDER BY Id", conn);
        //     conn.Open();
        //     using var reader = cmd.ExecuteReader();
        //     while (reader.Read())
        //     {
        //         folders.Add(new Folder { Id = reader.GetInt32(0), Name = reader.GetString(1) });
        //     }

        return folders;
    }

    // Thư mục do người đang đăng nhập tạo, "Chưa phân loại" đứng đầu. Ai gọi: màn Thư mục của tôi, ô chọn thư mục ở tab Quản trị.
    public static List<Folder> GetMine()
    {
        var folders = new List<Folder>();

        // TODO (#4): WHERE OwnerId = @userId ORDER BY IsDefault DESC, Id

        return folders;
    }

    // Tạo thư mục mới của người đang đăng nhập. Ai gọi: màn Thư mục, nút Thư mục mới.
    public static void Add(string name)
    {
        // TODO (#7): INSERT INTO Folders (Name, OwnerId) VALUES (@name, @userId)
    }

    // Đổi tên thư mục. Thư mục "Chưa phân loại" không đổi tên được.
    public static void Rename(int id, string name)
    {
        // TODO (#7): UPDATE Folders SET Name = @name WHERE Id = @id AND IsDefault = 0
    }

    // Chuyển các từ trong thư mục về "Chưa phân loại" của người đó, rồi xóa thư mục.
    public static void Delete(int id)
    {
        // TODO (#7)
    }

    // ===== Thư mục theo mùa (#43) =====

    // Đặt hai ngày cho thư mục; thư mục đang là một bài trong khóa học thì gỡ khỏi khóa.
    public static void SetSeason(int id, DateTime start, DateTime end)
    {
        // TODO (#43): UPDATE Folders SET StartDate = @start, EndDate = @end, CourseId = NULL, LessonOrder = NULL WHERE Id = @id
    }

    // Bỏ hai ngày: User không thấy thư mục này nữa, từ sai vẫn nằm trong sổ lỗi.
    public static void ClearSeason(int id)
    {
        // TODO (#43): UPDATE Folders SET StartDate = NULL, EndDate = NULL WHERE Id = @id
    }

    // Thư mục có hôm nay nằm trong khoảng ngày, tính cả ngày đầu và ngày cuối.
    // Ai gọi: CourseScreen (eventPanel), OverviewScreen (seasonBanner).
    public static List<Folder> GetSeasonal()
    {
        var folders = new List<Folder>();

        // TODO (#43): WHERE StartDate <= CAST(GETDATE() AS DATE) AND EndDate >= CAST(GETDATE() AS DATE)

        return folders;
    }
}
