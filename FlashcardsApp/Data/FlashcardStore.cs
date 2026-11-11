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

}
