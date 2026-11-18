using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace FlashcardsApp;

public static class FlashcardStore
{
    // ===== Đọc từ file SQl (#4) =====
    // Load, Save, Validate ở trên là của bản chạy thử (đọc file JSON). Khi 2 hàm dưới đây chạy được thì:
    //   1. đổi chỗ gọi Load trong MainWindow.CountMistakes và OverviewScreen.ShowNumbers sang GetAll()
    //   2. xóa Load, Save, Validate, DefaultPath

    private const string SelectSql = """
    SELECT f.Id, f.FolderId, f.Word, f.Meaning,
           f.Pronunciation, f.Example, f.ExampleTranslation, f.MemoryNote,
           ISNULL(p.LastRating, 0),
           ISNULL(p.WrongCount, 0),
           ISNULL(p.LastWrongAnswer, '')
    FROM Flashcards f
    JOIN Folders fo ON fo.Id = f.FolderId
    LEFT JOIN CardProgress p
        ON p.CardId = f.Id AND p.UserId = @userId
    """;


    // Lấy tất cả từ. Ai gọi: màn Học, Tổng quan, Gõ đáp án, Ghép cặp.
    public static List<Flashcard> GetAll()
    {
        var cards = new List<Flashcard>();

        using var conn = new SqlConnection(Database.ConnectionString);
        // TODO (#39): chỉ lấy bài đã mở bằng CourseStore.GetUnlockedFolderIds()
        using var cmd = new SqlCommand(SelectSql + """
         WHERE
            fo.OwnerId = @userId
            OR
            fo.CourseId IS NOT NULL
            OR (
                fo.StartDate IS NOT NULL
                AND fo.EndDate IS NOT NULL
                AND CAST(GETDATE() AS DATE)
                    BETWEEN fo.StartDate AND fo.EndDate
            )
        ORDER BY f.Id
        """, conn);
        cmd.Parameters.AddWithValue("@userId", Session.CurrentUser!.Id);

        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            cards.Add(new Flashcard
            {
                Id = reader.GetInt32(0),
                FolderId = reader.GetInt32(1),
                Word = reader.GetString(2),
                Meaning = reader.GetString(3),
                Pronunciation = reader.GetString(4),
                Example = reader.GetString(5),
                ExampleTranslation = reader.GetString(6),
                MemoryNote = reader.GetString(7),
                LastRating = reader.GetInt32(8),
                WrongCount = reader.GetInt32(9),
                LastWrongAnswer = reader.GetString(10)
            });
        }
        return cards;
    }

    // Lấy các từ của một thư mục. Ai gọi: màn Thư mục, StudyScreen.StartFolder.
    public static List<Flashcard> GetByFolder(int folderId)
    {
        var cards = new List<Flashcard>();

        using var conn = new SqlConnection(Database.ConnectionString);
        using var cmd = new SqlCommand(SelectSql + " WHERE f.FolderId = @folderId", conn);
        cmd.Parameters.AddWithValue("@userId", Session.CurrentUser!.Id);
        cmd.Parameters.AddWithValue("@folderId", folderId);

        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            cards.Add(new Flashcard
            {
                Id = reader.GetInt32(0),
                FolderId = reader.GetInt32(1),
                Word = reader.GetString(2),
                Meaning = reader.GetString(3),
                Pronunciation = reader.GetString(4),
                Example = reader.GetString(5),
                ExampleTranslation = reader.GetString(6),
                MemoryNote = reader.GetString(7),
                LastRating = reader.GetInt32(8),
                WrongCount = reader.GetInt32(9),
                LastWrongAnswer = reader.GetString(10)
            });
        }
        return cards;
    }

    // Thêm một từ. Ai gọi: AddCardDialog, ImportWordsDialog (qua màn Thư mục).
    public static void Add(Flashcard card)
    {
        // TODO (#7): code mẫu ở docs/02 mục 4, INSERT đủ các cột của docs/03
    }

    // Sửa một từ, tìm theo card.Id. Ai gọi: màn Thư mục, nút sửa trong bảng từ.
    public static void Update(Flashcard card)
    {
        // TODO (#7)
    }

    // Xóa một từ. Ai gọi: màn Thư mục, nút xóa trong bảng từ (sau khi hỏi lại).
    public static void Delete(int id)
    {
        // TODO (#7)
    }

    // true nếu thư mục của người đang đăng nhập đã có từ trùng cả từ lẫn nghĩa. SQL Server so không phân biệt hoa thường, nên so thẳng trong câu SQL.
    public static bool Exists(string word, string meaning)
    {
        // TODO (#7): SELECT COUNT(*) FROM Flashcards f JOIN Folders d ON d.Id = f.FolderId
        //     WHERE d.OwnerId = @userId AND f.Word = @word AND f.Meaning = @meaning
        return false;
    }
}
