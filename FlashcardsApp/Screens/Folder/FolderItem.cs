namespace FlashcardsApp;

public class FolderItem
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public override string ToString() => Id == 1 ? $"🔒 {Name}" : Name;
}
