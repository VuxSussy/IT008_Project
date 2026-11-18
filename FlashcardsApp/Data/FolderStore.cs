using Microsoft.Data.SqlClient;

namespace FlashcardsApp;

// Đọc, ghi bảng Folders. Mọi câu SQL về thư mục nằm ở đây. Xem docs/03-database.md.
public static class FolderStore
{
    private const string SelectSql =
        "SELECT Id, Name, OwnerId, IsDefault, CourseId, LessonOrder, StartDate, EndDate FROM Folders ";

    // Các thư mục người đang đăng nhập được thấy (docs/03, mục "Ai thấy thư mục nào"), "Chưa phân loại" của mình đứng đầu.
    // Admin: mọi thư mục của mình. User: thư mục của mình, bài trong khóa học, thư mục theo mùa đang diễn ra.
    // FlashcardStore.GetAll lọc từ theo đúng điều kiện này, sửa ở đây thì sửa cả bên đó.
    // Ai gọi: màn Thư mục, màn Tổng quan (đếm số thư mục), ô chọn thư mục ở màn Học.
    public static List<Folder> GetAll()
    {
        using var conn = new SqlConnection(Database.ConnectionString);
        // TODO (#39): đổi "CourseId IS NOT NULL" thành chỉ các bài đã mở (CourseStore.GetUnlockedFolderIds)
        using var cmd = new SqlCommand(SelectSql + """
            WHERE OwnerId = @userId
               OR CourseId IS NOT NULL
               OR CAST(GETDATE() AS DATE) BETWEEN StartDate AND EndDate
            ORDER BY IsDefault DESC, Id
            """, conn);
        cmd.Parameters.AddWithValue("@userId", Session.CurrentUser!.Id);
        return Read(cmd);
    }

    // Thư mục do người đang đăng nhập tạo, "Chưa phân loại" đứng đầu. Ai gọi: màn Thư mục của tôi, ô chọn thư mục ở tab Quản trị.
    public static List<Folder> GetMine()
    {
        using var conn = new SqlConnection(Database.ConnectionString);
        using var cmd = new SqlCommand(SelectSql + "WHERE OwnerId = @userId ORDER BY IsDefault DESC, Id", conn);
        cmd.Parameters.AddWithValue("@userId", Session.CurrentUser!.Id);
        return Read(cmd);
    }

    // Chạy câu SELECT (cột theo đúng thứ tự trong SelectSql) và đổi từng dòng thành Folder
    private static List<Folder> Read(SqlCommand cmd)
    {
        var folders = new List<Folder>();
        cmd.Connection.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            folders.Add(new Folder
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                OwnerId = reader.GetInt32(2),
                IsDefault = reader.GetBoolean(3),
                CourseId = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                LessonOrder = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                StartDate = reader.IsDBNull(6) ? null : reader.GetDateTime(6),
                EndDate = reader.IsDBNull(7) ? null : reader.GetDateTime(7)
            });
        }
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