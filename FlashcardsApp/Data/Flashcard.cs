namespace FlashcardsApp;

public sealed class Flashcard
{
    public int Id { get; set; }
    public int FolderId { get; set; } = 1;
    public string Word { get; set; } = "";
    public string Meaning { get; set; } = "";
    public string Example { get; set; } = "";
    public bool IsLearned { get; set; }
    public string Category { get; set; } = "TỪ VỰNG";
    public string Pronunciation { get; set; } = "";
    public string ExampleTranslation { get; set; } = "";
    public string MemoryNote { get; set; } = "";
    public string CommonMistake { get; set; } = "";
    public int LastRating { get; set; }
    public int WrongCount { get; set; }
    public string LastWrongAnswer { get; set; } = "";
    public DateTimeOffset? NextReviewAt { get; set; }
}
