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
