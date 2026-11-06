# Quy ước code

**Mọi tên trong code viết bằng tiếng Anh**: lớp, hàm, biến, nút, bảng, cột. Chữ hiện trên màn hình, câu báo lỗi và chú thích trong code viết tiếng Việt.

## 1. Thư mục và vai trò

```
FlashcardsApp/
├── Program.cs        Chỗ app bắt đầu chạy
├── MainWindow.cs     Cửa sổ chính: menu trái + chỗ hiện màn hình
├── Screens/          Mỗi màn một thư mục riêng, chỉ mở thư mục màn của mình
│   ├── Overview/       OverviewScreen      Tổng quan
│   ├── Folder/         FolderScreen        Thư mục và từ vựng
│   ├── Study/          StudyScreen         Học lật thẻ
│   ├── TypeAnswer/     TypeAnswerScreen    Gõ đáp án
│   ├── Mistake/        MistakeScreen       Sổ lỗi
│   └── Match/          MatchScreen         Ghép cặp, tùy chọn
├── Dialogs/          Hộp thoại bật lên: AddCardDialog, ImportWordsDialog
├── Controls/         Nút, thẻ vẽ tay và màu chung (StudyControls.cs, StudyTheme)
└── Data/             Lớp dữ liệu và mọi câu SQL
                      Flashcard, Folder, Database, FlashcardStore, FolderStore, StudyStore
```

| Phần | Được làm | Không được làm |
|---|---|---|
| `MainWindow` | Giữ menu, đổi màn bằng `ShowScreen`, chuyển phím tắt (Space, 1–4) cho màn Học | Chứa giao diện hay xử lý riêng của một màn |
| `Screens/` | Kéo thả giao diện, nhận cú bấm, kiểm tra ô nhập, gọi hàm trong `Data/`, hiện kết quả | Viết câu SQL; sửa control của màn khác |
| `Dialogs/` | Hỏi người dùng một việc rồi đóng lại, trả kết quả qua thuộc tính | Tự lưu vào dữ liệu khi màn gọi nó chưa đồng ý |
| `Controls/` | Nút, thẻ vẽ tay, màu và chữ dùng chung (`StudyTheme`) | Đọc hay ghi dữ liệu |
| `Data/` | Lớp dữ liệu (`Flashcard`, `Folder`), mọi câu SQL, đọc ghi file `flashcards.db` | Gọi `MessageBox` hay đụng tới control trên màn hình |

Chiều gọi chỉ đi một hướng: **`MainWindow` → `Screens/` → `Dialogs/` → `Data/`**. `Data/` không biết gì về màn hình, nên ai cũng gọi được mà không sợ hỏng giao diện.

Cần một hàm dữ liệu mới thì nhắn người làm phần dữ liệu kèm tên hàm mong muốn, ví dụ `FlashcardStore.CountLearned()`. Trong lúc chờ, dùng tạm vài từ viết sẵn trong code.

`Data/Flashcard.cs` và `Data/FlashcardStore.cs` lấy từ bản chạy thử, hiện vẫn đọc file JSON. Thẻ 03 đổi `FlashcardStore` sang đọc SQLite (xem [03 – Cơ sở dữ liệu](03-database.md)).

## 2. Các màn gọi nhau thế nào

Màn này không đụng vào nút hay ô của màn khác. Muốn nhờ màn khác làm gì thì gọi một hàm `public` của màn đó. Các hàm đã thống nhất:

| Hàm | Nằm ở | Ai gọi | Làm gì |
|---|---|---|---|
| `ShowScreen(screen)` | `MainWindow` | Nút menu, các màn cần chuyển màn | Hiện một màn vào chỗ nội dung |
| `Flip()` | `StudyScreen` | Nút Lật, phím Space | Lật thẻ đang học |
| `Rate(rating)` | `StudyScreen` | 4 nút Quên/Khó/Nhớ/Dễ, phím 1–4 | Lưu mức nhớ, sang thẻ tiếp |
| `StartFolder(folderId)` | `StudyScreen` | Nút Học thư mục này, nút Học ngay | Bắt đầu học một thư mục |
| `Start(cards)` | `TypeAnswerScreen` | Nút Luyện lại ở Sổ lỗi | Luyện gõ một danh sách từ |

Cần thêm hàm kiểu này thì ghi vào bảng trên và báo người làm màn đó.

## 3. Hộp thoại

Mở bằng `ShowDialog()`, đọc kết quả qua thuộc tính sau khi hộp thoại đóng:

```csharp
using var dialog = new AddCardDialog(cards);
if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Card is not null)
{
    FlashcardStore.Add(dialog.Card);
}
```

Bên trong hộp thoại: kiểm tra ô nhập, gán kết quả vào thuộc tính (ví dụ `Card`), đặt `DialogResult = DialogResult.OK` rồi đóng. Bấm Hủy thì đặt `DialogResult.Cancel`.

## 4. Ví dụ: thêm một từ

**Dữ liệu** (`Data/FlashcardStore.cs`, đầu file có `using Microsoft.Data.Sqlite;`):

```csharp
public static void Add(Flashcard card)
{
    using var conn = new SqliteConnection(Database.ConnectionString);
    using var cmd = new SqliteCommand(
        "INSERT INTO Flashcards (FolderId, Word, Meaning) VALUES (@folderId, @word, @meaning)", conn);
    cmd.Parameters.AddWithValue("@folderId", card.FolderId);
    cmd.Parameters.AddWithValue("@word", card.Word);
    cmd.Parameters.AddWithValue("@meaning", card.Meaning);
    conn.Open();
    cmd.ExecuteNonQuery();
}
```

**Màn hình** (nút Lưu trong `AddCardDialog`):

```csharp
private void saveButton_Click(object sender, EventArgs e)
{
    string word = wordTextBox.Text.Trim(), meaning = meaningTextBox.Text.Trim();
    if (word == "" || meaning == "") { MessageBox.Show("Bạn chưa nhập đủ từ và nghĩa."); return; }
    try
    {
        if (FlashcardStore.Exists(word, meaning)) { MessageBox.Show("Từ này đã có."); return; }
        FlashcardStore.Add(new Flashcard { Word = word, Meaning = meaning, FolderId = folderId });
        MessageBox.Show("Đã thêm từ.");
    }
    catch (Exception ex)
    {
        MessageBox.Show("Không lưu được vào file dữ liệu. Hãy tắt app, mở lại rồi thử lần nữa.\n\n" + ex.Message);
    }
}
```

## 5. Quy tắc

1. **Câu SQL dùng `@ten`** cho chữ người dùng gõ, không cộng chuỗi. Gõ `don't` là câu cộng chuỗi hỏng ngay.
2. **Luôn `using var`** trước `conn`, `cmd`, `reader` để kết nối tự đóng. Quên đóng thì file `flashcards.db` bị giữ, lần ghi sau báo lỗi "database is locked".
3. **Không để `catch { }` trống.** Màn hình bắt lỗi khi gọi `Data/` và báo bằng câu tiếng Việt dễ hiểu; `Data/` không tự hiện thông báo.
4. **Xóa thì hỏi lại**: *"Bạn có chắc muốn xóa từ này?"*
5. **Kéo thả bằng Designer**, không gõ tay vào `.Designer.cs`. Commit đủ các file của màn: `.cs`, `.Designer.cs`, `.resx` nếu có.
6. **Mọi file dùng `namespace FlashcardsApp;`**, dù nằm ở thư mục nào. Tạo file trong thư mục con (ví dụ chuột phải `Screens/Study` → **Add → New Item**), Visual Studio tự ghi `namespace FlashcardsApp.Screens.Study`: sửa ngay thành `namespace FlashcardsApp;`, nếu không file đó sẽ không gọi được các lớp khác. Với màn mới, sửa cả file `.cs` lẫn `.Designer.cs`.
7. **Một lớp một file**, tên file trùng tên lớp: lớp `FolderStore` nằm trong `FolderStore.cs`.
8. **Màu và chữ lấy trong `StudyTheme`** (`Controls/StudyControls.cs`), không tự gõ mã màu, để các màn trông giống nhau.

## 6. Đặt tên

| Cái gì | Cách đặt | Ví dụ |
|---|---|---|
| Lớp, hàm, thuộc tính | Tiếng Anh, viết hoa chữ đầu mỗi từ | `FlashcardStore`, `GetAll()`, `WrongCount` |
| Hàm | Bắt đầu bằng động từ | `Add()`, `Delete()`, `CheckAnswer()` |
| Biến, tham số | Tiếng Anh, chữ đầu viết thường | `folderId`, `answer`, `cards` |
| Màn hình | Tên + `Screen`, nằm trong `Screens/<Tên>/` | `Screens/Study/StudyScreen.cs` |
| Hộp thoại | Tên + `Dialog`, nằm trong `Dialogs/` | `AddCardDialog`, `ImportWordsDialog` |
| Lớp đọc ghi dữ liệu | Tên + `Store`, nằm trong `Data/` | `FolderStore`, `StudyStore` |
| Nút, ô trên màn hình | Tên + loại, đặt ngay khi kéo vào | `saveButton`, `wordTextBox`, `folderListBox` |
| Hàm sự kiện | Để Visual Studio tự tạo: tên control + `_` + sự kiện | `saveButton_Click`, `searchTextBox_TextChanged` |
| Bảng, cột SQL | Bảng số nhiều, cột viết hoa chữ đầu | `Flashcards`, `FolderId` |

Đặt tên control trong ô **(Name)** ở cửa sổ Properties **trước** khi nhấp đúp tạo sự kiện. Đổi tên sau thì hàm sự kiện vẫn giữ tên cũ như `button1_Click`.

## 7. Trình bày code

File `.editorconfig` ở gốc repo đã đặt sẵn, Visual Studio tự làm theo: thụt lề 4 dấu cách, chữ UTF-8 (giữ đúng dấu tiếng Việt), xuống dòng kiểu Windows. Trước khi gửi code, bấm **Ctrl+K, Ctrl+D** để Visual Studio căn lại cả file.

Chú thích viết tiếng Việt, ngắn, giải thích **vì sao** làm vậy chứ không đọc lại code:

```csharp
// Đổi chỗ thẻ đầu nếu trùng thẻ vừa học, để không gặp cùng một từ hai lần liền
```

## 8. Thêm màn hoặc hộp thoại mới

1. Màn mới: tạo thư mục trong `Screens/`, chuột phải thư mục → **Add → User Control (Windows Forms)**. Hộp thoại mới: chuột phải `Dialogs/` → **Add → Form (Windows Forms)**.
2. Sửa dòng `namespace` trong cả 2 file thành `namespace FlashcardsApp;` (quy tắc 6).
3. Thêm 2 dòng vào cuối `FlashcardsApp.csproj` để file `.Designer.cs` nằm gọn dưới file `.cs` và nhấp đúp mở thẳng Designer:

```xml
<Compile Update="Dialogs\ImportWordsDialog.cs" SubType="Form" />
<Compile Update="Dialogs\ImportWordsDialog.Designer.cs" DependentUpon="ImportWordsDialog.cs" />
```

Màn hình thì ghi `SubType="UserControl"` thay cho `"Form"`.

## 9. Trước khi gửi code

- [ ] F5 chạy được, đã thử cả lúc nhập đúng, nhập sai, để trống.
- [ ] Màn hình mình sửa vẫn mở được trong Designer.
- [ ] Không viết câu SQL ngoài `Data/`, không sửa file của màn khác.
- [ ] Đã bấm Ctrl+K, Ctrl+D để căn lại code.
- [ ] `git status` không có `bin/`, `obj/`, `.vs/`, `.csproj.user`.
