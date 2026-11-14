# Danh sách hàm

Các hàm sẽ có trong app, xếp theo file. Mỗi hàm ghi việc nó làm, ai gọi nó, và việc đó nằm ở issue nào. Hàm vẽ và hàm sự kiện do Visual Studio tạo (`saveButton_Click`, `OnPaint`...) không ghi vào đây.

Cột **Tình trạng** tính theo nhánh `main`:

- **Đã có**: đã viết xong, gọi được.
- **Có khung**: đã có tên và tham số, bên trong còn trống. Không đổi tên hay tham số, vì nơi khác đã gọi hàm này.
- **Chưa có**: chưa có trong code.

Hàm `public` (màn khác hoặc lớp khác gọi tới) là bản thống nhất của cả nhóm: muốn đổi tên, tham số hay kiểu trả về thì sửa file này trước, rồi báo người đang gọi hàm đó. Hàm ghi "(riêng)" là `private`, chỉ dùng trong một file; tên nào chưa có trong issue là tên gợi ý, người làm được đặt tên khác.

## 1. Dữ liệu (`Data/`)

Chỉ các lớp trong `Data/` được viết câu SQL. Hàm nào cũng có thể ném lỗi khi không đọc ghi được file `flashcards.db`; màn hình gọi hàm thì tự bắt lỗi và báo (xem [02 – Quy ước code](02-quy-uoc-code.md), quy tắc 3).

### `Database` (`Data/Database.cs`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `EnsureCreated()` | `void` | Chưa có file `flashcards.db` thì tạo file, tạo 2 bảng, thêm 3 thư mục và 30 từ mẫu | `Program.cs`, trước `Application.Run` | [#4](https://github.com/VuxSussy/IT008_Project/issues/4) | Có khung |
| `ConnectionString` (thuộc tính) | `string` | Chuỗi kết nối tới `flashcards.db`, bật kiểm tra thư mục tồn tại | Mọi lớp `...Store` | [#4](https://github.com/VuxSussy/IT008_Project/issues/4) | Đã có |

### `FlashcardStore` (`Data/FlashcardStore.cs`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `GetAll()` | `List<Flashcard>` | Lấy tất cả từ | Màn Học, Tổng quan, Gõ đáp án, Ghép cặp | [#4](https://github.com/VuxSussy/IT008_Project/issues/4) | Có khung |
| `GetByFolder(folderId)` | `List<Flashcard>` | Lấy các từ của một thư mục | Màn Thư mục, `StudyScreen.StartFolder` | [#4](https://github.com/VuxSussy/IT008_Project/issues/4) | Có khung |
| `Add(card)` | `void` | Thêm một từ | `AddCardDialog`, `ImportWordsDialog` | [#7](https://github.com/VuxSussy/IT008_Project/issues/7) | Chưa có |
| `Update(card)` | `void` | Sửa một từ (tìm theo `card.Id`) | Màn Thư mục, nút sửa trong bảng từ | [#7](https://github.com/VuxSussy/IT008_Project/issues/7) | Chưa có |
| `Delete(id)` | `void` | Xóa một từ | Màn Thư mục, nút xóa trong bảng từ | [#7](https://github.com/VuxSussy/IT008_Project/issues/7) | Chưa có |
| `Exists(word, meaning)` | `bool` | `true` nếu đã có từ trùng cả từ lẫn nghĩa, không phân biệt hoa thường (so bằng C#, không so trong SQL) | `AddCardDialog`, `ImportWordsDialog` | [#7](https://github.com/VuxSussy/IT008_Project/issues/7) | Chưa có |
| `Load(path)`, `Save(path, cards)` | | Đọc ghi file JSON của bản chạy thử. Bỏ khi đã có `GetAll()`; trước khi bỏ, đổi chỗ gọi trong `MainWindow` và `OverviewScreen` | `MainWindow.CountMistakes`, `OverviewScreen.ShowNumbers` | [#4](https://github.com/VuxSussy/IT008_Project/issues/4) | Đã có, sẽ bỏ |

### `FolderStore` (`Data/FolderStore.cs`)

Thư mục số 1 "Chưa phân loại" không đổi tên, không xóa được.

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `GetAll()` | `List<Folder>` | Lấy tất cả thư mục | Màn Thư mục, Tổng quan (đếm số thư mục), ô chọn thư mục ở màn Học | [#4](https://github.com/VuxSussy/IT008_Project/issues/4) | Có khung |
| `Add(name)` | `void` | Tạo thư mục mới | Màn Thư mục, nút Thư mục mới | [#7](https://github.com/VuxSussy/IT008_Project/issues/7) | Chưa có |
| `Rename(id, name)` | `void` | Đổi tên thư mục | Màn Thư mục, nút đổi tên | [#7](https://github.com/VuxSussy/IT008_Project/issues/7) | Chưa có |
| `Delete(id)` | `void` | Chuyển các từ trong thư mục về thư mục số 1, rồi xóa thư mục | Màn Thư mục, nút thùng rác | [#7](https://github.com/VuxSussy/IT008_Project/issues/7) | Chưa có |

### `StudyStore` (`Data/StudyStore.cs`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `SaveResult(cardId, rating, typedAnswer)` | `void` | Ghi kết quả học một thẻ theo bảng "Học xong một thẻ thì ghi gì" ở [03 – Database](03-database.md). `typedAnswer` là chữ gõ sai, `null` nếu không gõ hoặc gõ đúng | `StudyScreen.Rate`, màn Gõ đáp án | [#12](https://github.com/VuxSussy/IT008_Project/issues/12) | Chưa có |
| `GetMistakes()` | `List<Flashcard>` | Các từ có `LastRating` là 1 hoặc 2, từ sai nhiều lần lên đầu | Màn Sổ lỗi, `MainWindow` (số trên nút Sổ lỗi) | [#12](https://github.com/VuxSussy/IT008_Project/issues/12) | Chưa có |

### Lớp chứa dữ liệu

`Flashcard` (`Data/Flashcard.cs`) và `Folder` (`Data/Folder.cs`) chỉ có thuộc tính, không có hàm. Danh sách thuộc tính xem ở [03 – Database](03-database.md). `IsLearned` (`LastRating` từ 3 trở lên) và `Category` được tính sẵn, không lưu vào bảng.

## 2. Cửa sổ chính (`MainWindow.cs`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `ShowScreen(screen)` | `void` | Hiện một màn vào chỗ nội dung, đánh dấu nút menu đang chọn | Nút menu, các màn cần chuyển màn: `(FindForm() as MainWindow)?.ShowScreen(...)` | [#3](https://github.com/VuxSussy/IT008_Project/issues/3) | Đã có |
| `UpdateMenu()` (riêng) | `void` | Tô nút menu đang chọn, cập nhật số trên nút Sổ lỗi | `ShowScreen` | [#3](https://github.com/VuxSussy/IT008_Project/issues/3) | Đã có |
| `CountMistakes()` (riêng) | `int` | Đếm số từ trong sổ lỗi. Đang đọc file JSON; khi có [#12](https://github.com/VuxSussy/IT008_Project/issues/12) thì đổi thành `StudyStore.GetMistakes().Count` | `UpdateMenu` | [#3](https://github.com/VuxSussy/IT008_Project/issues/3) | Đã có, sẽ sửa |

Phím Space và phím 1–4 được `MainWindow` chuyển cho `StudyScreen.Flip()` và `StudyScreen.Rate(rating)`.

## 3. Các màn hình (`Screens/`)

Các hàm `public` của màn hình trùng với bảng ở [02 – Quy ước code](02-quy-uoc-code.md), mục 2.

### Tổng quan (`OverviewScreen`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `ShowNumbers()` (riêng) | `void` | Điền 4 ô số, vòng tròn tiến độ và chú thích | Khi mở màn | [#8](https://github.com/VuxSussy/IT008_Project/issues/8) | Đã có, đang đọc file JSON |
| `ShowWordOfDay()` (riêng) | `void` | Chọn từ chưa thuộc theo ngày (`pool[DateTime.Today.DayOfYear % pool.Count]`), hiện vào `wordOfDayPanel`; không có từ nào thì ẩn | Khi mở màn | [#15](https://github.com/VuxSussy/IT008_Project/issues/15) | Chưa có |

### Thư mục (`FolderScreen`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `LoadFolders()` (riêng) | `void` | Đổ danh sách thư mục vào `folderListBox` | Khi mở màn, sau khi tạo, đổi tên, xóa thư mục | [#6](https://github.com/VuxSussy/IT008_Project/issues/6) | Chưa có |
| `LoadWords(folderId)` (riêng) | `void` | Đổ các từ của thư mục đang chọn vào `wordGrid`, lọc theo ô tìm kiếm | Chọn thư mục, gõ ô tìm, sau khi thêm, sửa, xóa từ | [#6](https://github.com/VuxSussy/IT008_Project/issues/6) | Chưa có |

Các nút thêm, sửa, xóa thư mục và từ chỉ gọi hàm của `FolderStore`, `FlashcardStore` rồi tải lại ([#11](https://github.com/VuxSussy/IT008_Project/issues/11)). Nút Học thư mục này gọi `StudyScreen.StartFolder(folderId)`. Nút Nhập nhiều từ mở `ImportWordsDialog` ([#16](https://github.com/VuxSussy/IT008_Project/issues/16)).

### Học lật thẻ (`StudyScreen`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `Flip()` | `void` | Hiện nghĩa, câu ví dụ, mẹo nhớ; bật 4 nút Quên/Khó/Nhớ/Dễ | Nút Lật, phím Space | [#5](https://github.com/VuxSussy/IT008_Project/issues/5) | Có khung |
| `Rate(rating)` | `void` | Gọi `StudyStore.SaveResult(card.Id, rating, null)` rồi sang thẻ tiếp; hết lượt thì gọi `StartRound()` | 4 nút Quên/Khó/Nhớ/Dễ, phím 1–4 | [#9](https://github.com/VuxSussy/IT008_Project/issues/9) | Có khung |
| `StartFolder(folderId)` | `void` | Lấy từ của thư mục (0 là tất cả) rồi bắt đầu vòng 1; thư mục trống thì báo | Nút Học ngay, nút Học thư mục này | [#9](https://github.com/VuxSussy/IT008_Project/issues/9) | Có khung |
| `ShowCard(card)` (riêng) | `void` | Hiện từ và phiên âm, ẩn phần còn lại, làm mờ 4 nút | `StartRound`, `Rate` | [#5](https://github.com/VuxSussy/IT008_Project/issues/5) | Chưa có |
| `StartRound()` (riêng) | `void` | Xáo danh sách, về thẻ đầu, tăng số vòng; thẻ đầu trùng thẻ vừa học thì đổi chỗ với thẻ thứ hai | `StartFolder`, `Rate` | [#9](https://github.com/VuxSussy/IT008_Project/issues/9) | Chưa có |
| `Speak(word)` (riêng) | `void` | Đọc từ bằng giọng đọc của Windows, chạy nền để app không đứng | Nút phát âm | [#5](https://github.com/VuxSussy/IT008_Project/issues/5) | Chưa có |

### Gõ đáp án (`TypeAnswerScreen`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `Start(cards)` | `void` | Bắt đầu luyện gõ với danh sách từ được đưa vào (mặc định là tất cả) | Khi mở màn, nút Luyện lại ở Sổ lỗi | [#10](https://github.com/VuxSussy/IT008_Project/issues/10) | Chưa có |
| `CheckAnswer(typed, answer)` (riêng) | `bool` | Bỏ khoảng trắng hai đầu, so không phân biệt hoa thường | Nút Chấm, phím Enter | [#10](https://github.com/VuxSussy/IT008_Project/issues/10) | Chưa có |
| `ShowDiff(typed, answer)` (riêng) | `void` | Tô cam phần gõ sai ở giữa (giống từ đầu, giống từ cuối, còn lại là chỗ sai) trong `diffPanel` | Khi chấm sai | [#17](https://github.com/VuxSussy/IT008_Project/issues/17) | Chưa có |

### Sổ lỗi (`MistakeScreen`)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `LoadMistakes()` (riêng) | `void` | Đổ `StudyStore.GetMistakes()` vào `mistakeGrid` theo nút lọc đang chọn (Tất cả / Gõ sai / Quên, Khó) | Khi mở màn, bấm nút lọc | [#13](https://github.com/VuxSussy/IT008_Project/issues/13) | Chưa có |

Nút Luyện lại chuyển sang màn Gõ đáp án rồi gọi `TypeAnswerScreen.Start(...)` với các từ trong sổ.

### Ghép cặp (`MatchScreen`, không bắt buộc)

| Hàm | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `NewGame()` (riêng) | `void` | Lấy ngẫu nhiên 6 từ, xáo cột nghĩa, đặt lại giờ và số lần nhầm | Khi mở màn, nút Chơi lại | [#18](https://github.com/VuxSussy/IT008_Project/issues/18) | Chưa có |

## 4. Hộp thoại (`Dialogs/`)

Hộp thoại không tự lưu: trả kết quả qua thuộc tính, màn gọi nó mới lưu (xem [02 – Quy ước code](02-quy-uoc-code.md), mục 3).

| Hàm / thuộc tính | Trả về | Làm gì | Ai gọi | Issue | Tình trạng |
|---|---|---|---|---|---|
| `AddCardDialog(existing)` | | Mở hộp thoại thêm, sửa một từ | Màn Thư mục | [#11](https://github.com/VuxSussy/IT008_Project/issues/11) | Đã có (từ bản chạy thử) |
| `AddCardDialog.Card` | `Flashcard?` | Từ người dùng vừa nhập, đọc sau khi bấm Lưu | Màn Thư mục | [#11](https://github.com/VuxSussy/IT008_Project/issues/11) | Đã có |
| `ImportWordsDialog(folderId)` | | Mở hộp thoại nhập nhiều từ vào một thư mục | Màn Thư mục, nút Nhập nhiều từ | [#16](https://github.com/VuxSussy/IT008_Project/issues/16) | Chưa có |
| `ParseLines(text)` (riêng) | `void` | Tách từng dòng `từ - nghĩa` bằng `Split(" - ")`, hiện dòng đúng và dòng lỗi vào `previewListBox`, cập nhật `summaryLabel` | Khi gõ hoặc dán vào `inputTextBox` | [#16](https://github.com/VuxSussy/IT008_Project/issues/16) | Chưa có |

Nút Thêm của `ImportWordsDialog` gọi `FlashcardStore.Add` cho từng dòng đúng, bỏ qua từ đã có (`Exists`), như [#16](https://github.com/VuxSussy/IT008_Project/issues/16) đã ghi.
