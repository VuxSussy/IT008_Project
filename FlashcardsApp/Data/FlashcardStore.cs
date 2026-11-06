using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FlashcardsApp;

public static class FlashcardStore
{
    public static string DefaultPath => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "FlashcardsApp", "flashcards.json");

    public static List<Flashcard> Load(string path)
    {
        if (!File.Exists(path))
        {
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

        var cards = JsonSerializer.Deserialize<List<Flashcard>>(File.ReadAllText(path))
            ?? throw new InvalidDataException("File từ vựng không có danh sách thẻ hợp lệ.");
        Validate(cards);
        return cards;
    }

    public static void Save(string path, List<Flashcard> cards)
    {
        Validate(cards);
        var json = JsonSerializer.Serialize(cards, new JsonSerializerOptions { WriteIndented = true });
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path))!);
        var temporaryPath = path + ".tmp";
        try
        {
            // Ghi xong file tạm rồi mới thay file chính, tránh mất dữ liệu khi ghi lỗi.
            File.WriteAllText(temporaryPath, json);
            File.Move(temporaryPath, path, overwrite: true);
        }
        finally
        {
            if (File.Exists(temporaryPath)) File.Delete(temporaryPath);
        }
    }

    private static void Validate(List<Flashcard> cards)
    {
        if (cards.Any(card => card is null || string.IsNullOrWhiteSpace(card.Word)
            || string.IsNullOrWhiteSpace(card.Meaning) || card.LastRating is < 0 or > 4))
            throw new InvalidDataException("Thẻ cần có từ, nghĩa và mức đánh giá hợp lệ từ 0 đến 4.");
    }
}
