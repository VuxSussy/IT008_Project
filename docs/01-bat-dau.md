# Warn Up

## Cài những thứ cần thiết vào máy

1. **Git**: <https://git-scm.com/download/win>
2. **Visual Studio 2026 Community**: <https://visualstudio.microsoft.com/>. Tick ô **.NET desktop development**.
3. App dùng **SQLite**, dữ liệu là một file tự tạo khi mở app.
4. Gửi tên tài khoản GitHub cho trưởng nhóm để được thêm vào nhóm sau đó clone repo về:

```bash
git config --global user.name "your-github-name"
git config --global user.email "your-email@example.com"
git clone https://github.com/VuxSussy/IT008_Project.git
```

5. Mở `FlashcardsApp.slnx`, bấm **F5**. App mở ra là được.

| Lỗi | Cách sửa |
|---|---|
| Không mở được `.slnx` | Visual Studio Installer → **Modify** → tick **.NET desktop development** |
| Form không mở trong Designer | Đóng Visual Studio, mở lại `FlashcardsApp.slnx` |
| Nút phát âm mờ hoặc đọc giọng lạ | Máy chưa có giọng đọc tiếng Anh: **Settings → Time & language → Speech → Add voices → English (United States)**. Cần mạng lúc tải, sau đó phát âm không cần mạng |

## Có dữ liệu thật (sau khi xong thẻ 03, khoảng 7/11)

1. Kéo code mới về: `git switch main` rồi `git pull`.
2. Bấm **F5** trong Visual Studio. Lần đầu mở, app tự tạo file `flashcards.db` và thêm 30 từ mẫu.

## Ai dùng macOS

WinForms chỉ chạy và mở Designer trên Windows. Trên Mac chỉ sửa được code và tài liệu bằng VS Code.

- Mở thư mục repo bằng VS Code, bấm **Install** khi VS Code gợi ý cài tiện ích (EditorConfig, C# Dev Kit).
- Không tự đổi `git config core.autocrlf`: file `.gitattributes` đã lo kiểu xuống dòng cho mọi máy.
- Không sửa file `.Designer.cs` trên Mac; phần giao diện để làm trên máy Windows.

## Mỗi lần làm với một issue

Ví dụ issue **05 · FolderScreen: hiện thư mục và bảng từ** (chỉ là ví dụ minh hoạ)

```bash
git switch main
git pull                                   # lấy code mới nhất
git switch -c vu/05-folder-screen          # nhánh riêng: tên/"số issue"-"mô tả"
git status                                 # xem đã sửa file nào
git add FlashcardsApp/Screens/Folder/
git commit -m "Hiện danh sách thư mục và bảng từ trong FolderScreen" # mô tả bằng tiếng việt và sử dụng tiếng ạnh cho những từ chuyên ngành hoặc dịch ra tiếng việt sẽ khó hiểu
git push -u origin vu/05-folder-screen
```

Rồi lên GitHub bấm **Compare & pull request**, ghi `Closes #5` trong ô mô tả (số GitHub của thẻ, xem cạnh tên thẻ), nhắn nhóm nhờ ai đó review nếu cần (mặc định sẽ là Tead Lead). Nếu ổn thì bấm **Merge pull request** để gộp vào code chung. Trên Project, kéo thẻ sang cột **Done**.

## Nghiêm cấm

- Không đẩy thẳng lên `main`.
- Không `git add .` khi chưa xem `git status`.

