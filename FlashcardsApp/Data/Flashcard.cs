namespace FlashcardsApp;

public sealed class Flashcard
{
    // Cột của bảng Flashcards (docs/03)
    public int Id { get; set; }
    public int FolderId { get; set; } = 1;
    public string Word { get; set; } = "";
    public string Meaning { get; set; } = "";
    public string Pronunciation { get; set; } = "";
    public string Example { get; set; } = "";
    public string ExampleTranslation { get; set; } = "";
    public string MemoryNote { get; set; } = "";

    // Lấy từ bảng CardProgress của người đang đăng nhập (LEFT JOIN, chưa học thì 0)
    public int LastRating { get; set; }               // 0 = chưa học, 1 Quên, 2 Khó, 3 Nhớ, 4 Dễ
    public int WrongCount { get; set; }
    public string LastWrongAnswer { get; set; } = "";

    // Tính sẵn, không lưu trong database
    public bool IsLearned => LastRating >= 3;
    public string Category => Word.Contains(' ') ? "CỤM TỪ" : "TỪ VỰNG";
}
