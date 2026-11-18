namespace FlashcardsApp;

// Người đang đăng nhập. LoginDialog (#36) gán sau khi đăng nhập đúng; các màn và lớp ...Store chỉ đọc.
public static class Session
{
    public static User? CurrentUser { get; set; }
}
