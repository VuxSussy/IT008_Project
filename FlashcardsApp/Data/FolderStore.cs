using Microsoft.Data.SqlClient;

namespace FlashcardsApp;

// Đọc, ghi bảng Folders. Mọi câu SQL về thư mục nằm ở đây. Xem docs/03-database.md.
public static class FolderStore
{
    private const string SelectSql = """
                                    SELECT f.Id, f.Name, f.OwnerId, f.IsDefault, f.CourseId, f.LessonOrder, f.StartDate, f.EndDate,
                                    ISNULL(p.LastRating, 0), ISNULL(p.WrongCount, 0), ISNULL(p.LastWrongAnswer, '')
                                    FROM Folder f
                                    LEFT JOIN CardProgress p ON p.CardId = f.Id AND p.UserId = @userId

                                    """;
    // Lấy tất cả thư mục, xếp theo Id (thư mục số 1 "Chưa phân loại" đứng đầu).
    // Ai gọi: màn Thư mục, màn Tổng quan (đếm số thư mục), ô chọn thư mục ở màn Học.
    // Lấy tất cả thư mục mà người đang đăng nhập được phép nhìn thấy.
    public static List<Folder> GetAll()
    {
        var folders = new List<Folder>();
        var user = Session.CurrentUser!;

        using var conn = new SqlConnection(Database.ConnectionString);

        // Admin chỉ cần lấy tất cả thư mục do mình tạo.
        // User cần thêm các bài học đã mở và thư mục theo mùa đang diễn ra.
        var unlockedFolderIds = user.IsAdmin
            ? new List<int>()
            : CourseStore.GetUnlockedFolderIds();

        var unlockedConditions = new List<string>();

        for (int i = 0; i < unlockedFolderIds.Count; i++)
        {
            unlockedConditions.Add($"@folderId{i}");
        }

        string unlockedSql = unlockedConditions.Count > 0
            ? $"OR Id IN ({string.Join(", ", unlockedConditions)})"
            : "";

        using var cmd = new SqlCommand($"""
        SELECT Id, Name, OwnerId, IsDefault,
               CourseId, LessonOrder, StartDate, EndDate
        FROM Folders
        WHERE
            OwnerId = @userId
            OR (
                @isAdmin = 0
                AND (
                    (StartDate IS NOT NULL
                     AND EndDate IS NOT NULL
                     AND CAST(GETDATE() AS DATE)
                         BETWEEN StartDate AND EndDate)
                    {unlockedSql}
                )
            )
        ORDER BY IsDefault DESC, Id
        """, conn);

        cmd.Parameters.AddWithValue("@userId", user.Id);
        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);

        for (int i = 0; i < unlockedFolderIds.Count; i++)
        {
            cmd.Parameters.AddWithValue(
                $"@folderId{i}",
                unlockedFolderIds[i]
            );
        }

        conn.Open();

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

    // Thư mục do người đang đăng nhập tạo, "Chưa phân loại" đứng đầu. Ai gọi: màn Thư mục của tôi, ô chọn thư mục ở tab Quản trị.
    public static List<Folder> GetMine()
    {
        var folders = new List<Folder>();

        // TODO (#4): WHERE OwnerId = @userId ORDER BY IsDefault DESC, Id

        using var conn = new SqlConnection(Database.ConnectionString);

        using var cmd = new SqlCommand("""
                                    SELECT Id, Name, OwnerId, IsDefault, CourseId, LessonOrder, StartDate, EndDate
                                    FROM Folders 
                                    WHERE OwnerId = @userId
                                    ORDER BY IsDefault DESC, Id
                                    """, conn);

        cmd.Parameters.AddWithValue("@userId", Session.CurrentUser!.Id);
        conn.Open();
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
