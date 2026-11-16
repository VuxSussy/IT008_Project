using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Globalization;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography;

namespace FlashcardsApp;

public static class FlashcardStore
{
    public static string DefaultPath => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "FlashcardsApp", "database.db");

    private static SqliteConnection Open(string path)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path))!);
        var conn = new SqliteConnection($"Data Source={path};Mode=ReadWriteCreate");
        conn.Open(); ;
        return conn;
    }
    private static void EnsureDatabase(SqliteConnection conn)
    {
        using (var create = conn.CreateCommand())
        {
            create.CommandText = SeedData.CreateTable;
            create.ExecuteNonQuery();
        }

        using var count = conn.CreateCommand();
        count.CommandText = "SELECT COUNT(*) FROM Flashcards";
        var row = (long)count.ExecuteScalar()!;

        if (row == 0)
        {
            using var insert = conn.CreateCommand();
            insert.CommandText = SeedData.InsertCards;
            insert.ExecuteNonQuery();
        }
    }
    public static List<Flashcard> Load(string path)
    {
        try
        {
            using var conn = Open(path);
            EnsureDatabase(conn);
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT Word, Meaning, Example, IsLearned, 
                                        Category, Pronunciation, ExampleTranslation, 
                                        MemoryNote, CommonMistake, LastRating, NextReviewAt
                                FROM Flashcards
                                ORDER BY Id ASC";
            using var r = cmd.ExecuteReader();
            var cards = new List<Flashcard>();
            while (r.Read())
            {
                cards.Add(new Flashcard
                {
                    Word = r.GetString(0),
                    Meaning = r.GetString(1),
                    Example = r.GetString(2),
                    IsLearned = r.GetInt32(3) == 1 ? true : false,
                    Category = r.GetString(4),
                    Pronunciation = r.GetString(5),
                    ExampleTranslation = r.GetString(6),
                    MemoryNote = r.GetString(7),
                    CommonMistake = r.GetString(8),
                    LastRating = r.GetInt32(9),
                    NextReviewAt = r.IsDBNull(10) ? null : DateTimeOffset.Parse(r.GetString(10), CultureInfo.InvariantCulture)
                });
            }
            return cards;
        }
        catch (SqliteException ex)
        {
            throw new IOException(ex.Message, ex);
        }

    }

    public static void Save(string path, List<Flashcard> cards)
    {
        try
        {
            using var conn = Open(path);
            using var tx = conn.BeginTransaction();
            foreach (var c in cards)
            {
                using var cmd = conn.CreateCommand();
                cmd.Transaction = tx;
                cmd.CommandText = @"
                    INSERT INTO Flashcards (Word, Meaning, Category, Pronunciation, Example,
                        ExampleTranslation, MemoryNote, CommonMistake, IsLearned, LastRating, NextReviewAt)
                    VALUES ($w, $m, $c, $p, $e, $et, $n, $cm, $l, $r, $next)
                    ON CONFLICT(Word) DO UPDATE SET
                        Meaning=$m, Category=$c, Pronunciation=$p, Example=$e,
                        ExampleTranslation=$et, MemoryNote=$n, CommonMistake=$cm,
                        IsLearned=$l, LastRating=$r, NextReviewAt=$next";
                cmd.Parameters.AddWithValue("$w", c.Word);
                cmd.Parameters.AddWithValue("$m", c.Meaning);
                cmd.Parameters.AddWithValue("$c", c.Category ?? "");
                cmd.Parameters.AddWithValue("$p", c.Pronunciation ?? "");
                cmd.Parameters.AddWithValue("$e", c.Example ?? "");
                cmd.Parameters.AddWithValue("$et", c.ExampleTranslation ?? "");
                cmd.Parameters.AddWithValue("$n", c.MemoryNote ?? "");
                cmd.Parameters.AddWithValue("$cm", c.CommonMistake ?? "");
                cmd.Parameters.AddWithValue("$l", c.IsLearned ? 1 : 0);
                cmd.Parameters.AddWithValue("$r", c.LastRating);
                cmd.Parameters.AddWithValue("$next", c.NextReviewAt is null
                    ? DBNull.Value : c.NextReviewAt.Value.ToString("O", CultureInfo.InvariantCulture));
                cmd.ExecuteNonQuery();
            }
            tx.Commit();
        }
        catch (SqliteException ex)
        {
            throw new IOException(ex.Message, ex);
        }
    }

    private static void Validate(List<Flashcard> cards)
    {
        if (cards.Any(card => card is null || string.IsNullOrWhiteSpace(card.Word)
            || string.IsNullOrWhiteSpace(card.Meaning) || card.LastRating is < 0 or > 4))
            throw new InvalidDataException("Thẻ cần có từ, nghĩa và mức đánh giá hợp lệ từ 0 đến 4.");
    }

    // ===== Đọc từ file SQLite (#4) =====
    // Load, Save, Validate ở trên là của bản chạy thử (đọc file JSON). Khi 2 hàm dưới đây chạy được thì:
    //   1. đổi chỗ gọi Load trong MainWindow.CountMistakes và OverviewScreen.ShowNumbers sang GetAll()
    //   2. xóa Load, Save, Validate, DefaultPath
    //   3. sửa Flashcard.cs theo docs/03: bỏ NextReviewAt, CommonMistake; IsLearned và Category thành thuộc tính tính sẵn
    //      (xóa luôn các dòng gán IsLearned, Category, CommonMistake ở trên và trong AddCardDialog.cs để app build được)

    // Lấy tất cả từ. Ai gọi: màn Học, Tổng quan, Gõ đáp án, Ghép cặp.
    public static List<Flashcard> GetAll()
    {
        var cards = new List<Flashcard>();

        // TODO (#4): chép code ở docs/03 mục "Đọc dữ liệu (ví dụ FlashcardStore.GetAll)":
        // mở kết nối bằng Database.ConnectionString, SELECT đủ 11 cột, mỗi dòng đọc được thì cards.Add(new Flashcard { ... })

        return cards;
    }

    // Lấy các từ của một thư mục. Ai gọi: màn Thư mục, StudyScreen.StartFolder.
    public static List<Flashcard> GetByFolder(int folderId)
    {
        var cards = new List<Flashcard>();

        // TODO (#4): giống GetAll, thêm "WHERE FolderId = @folderId" vào cuối câu SELECT và truyền giá trị bằng
        //     cmd.Parameters.AddWithValue("@folderId", folderId);
        // (không cộng chuỗi vào câu SQL, xem docs/02 quy tắc 1)

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

    // true nếu đã có từ trùng cả từ lẫn nghĩa, không phân biệt hoa thường (so bằng C#, không so trong SQL).
    public static bool Exists(string word, string meaning)
    {
        // TODO (#7): return GetAll().Any(card => card.Word.Equals(word, StringComparison.OrdinalIgnoreCase) && ...);
        return false;
    }
}
