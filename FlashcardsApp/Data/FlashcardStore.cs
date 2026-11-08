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
        "FlashcardsApp", "flashcards.db");

    private static SqliteConnection Open(string path)
    {
        var conn = new SqliteConnection($"Data Source={path};Mode=ReadWrite");
        conn.Open(); ;
        return conn;
    }
    public static List<Flashcard> Load(string path)
    {
        if (!File.Exists(path))
        {
            string template = Path.Combine(AppContext.BaseDirectory, "flashcard.db");
            if (File.Exists(template))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                File.Copy(template, path);
            }
            else throw new FileNotFoundException("Không tìm thấy file cơ sở dữ liệu: " + path);

            return new List<Flashcard>
            {
                new() { Word = "make a decision", Meaning = "đưa ra quyết định", Category = "CỤM TỪ",
                    Pronunciation = "/meɪk ə dɪˈsɪʒən/", Example = "I need to make a decision today.",
                    ExampleTranslation = "Tôi cần đưa ra quyết định hôm nay.", CommonMistake = "do a decision",
                    MemoryNote = "Dùng make với decision." },
                new() { Word = "curious", Meaning = "tò mò, ham tìm hiểu", Pronunciation = "/ˈkjʊəriəs/",
                    Example = "She is curious about the world.", ExampleTranslation = "Cô ấy tò mò về thế giới." },
                new() { Word = "improve", Meaning = "cải thiện", Pronunciation = "/ɪmˈpruːv/",
                    Example = "I practice every day to improve my English.", ExampleTranslation = "Tôi luyện tập mỗi ngày để cải thiện tiếng Anh." },
                new() { Word = "confident", Meaning = "tự tin", Pronunciation = "/ˈkɒnfɪdənt/",
                    Example = "He feels confident when speaking English.", ExampleTranslation = "Anh ấy cảm thấy tự tin khi nói tiếng Anh." },
                new() { Word = "achieve", Meaning = "đạt được", Pronunciation = "/əˈtʃiːv/",
                    Example = "Small steps help you achieve your goals.", ExampleTranslation = "Những bước nhỏ giúp bạn đạt được mục tiêu." }
            };
        }

        try
        {
            using var conn = Open(path);
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT Word, Meaning, Example, IsLearned, 
                                        Category, Pronunciation, ExampleTranslation, 
                                        MemoryNote, CommonMistake, LasRating, NextReviewAt
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
        //var cards = JsonSerializer.Deserialize<List<Flashcard>>(File.ReadAllText(path))
        //    ?? throw new InvalidDataException("File từ vựng không có danh sách thẻ hợp lệ.");
        //Validate(cards);
        //return cards;
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
        catch(SqliteException ex)
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
}
