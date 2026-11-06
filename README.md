# Flashcards – Đồ án IT008

App học từ vựng tiếng Anh bằng flash cards sử dụng C# WinForms (.NET 10).
Làm từ **5/11** tới **27/11/2026**.

| Người | Vai trò |
|---|---|
| Võ Lê Anh Vũ | Trưởng nhóm - Tech Lead |
| Võ Việt Tường | Thành viên |
| Nguyễn Trần Tuấn Anh | Thành viên |
| Bùi Nhật Tuấn | Thành viên |

## Chạy app

1. Cài phần mềm theo [Bắt đầu](docs/01-bat-dau.md).
2. `git clone https://github.com/VuxSussy/IT008_Project.git`
3. Mở `FlashcardsApp.slnx` bằng Visual Studio, bấm **F5**.

## Tài liệu

| File | Đọc khi |
|---|---|
| [01 – Bắt đầu](docs/01-bat-dau.md) | Ngày đầu: cài máy, cách dùng Git |
| [02 – Quy ước code](docs/02-quy-uoc-code.md) | Trước khi viết code |
| [03 – Database](docs/03-database.md) | Khi làm phần lưu dữ liệu |
| [04 – Giao diện](docs/04-gui.md) | Khi làm màn hình của mình |

## Thư mục

```
IT008_Project/
├── FlashcardsApp.slnx              mở file này bằng Visual Studio
├── FlashcardsApp/                  code của app
│   ├── Program.cs                  điểm bắt đầu, mở MainWindow
│   ├── MainWindow.cs               cửa sổ chính: menu trái, chỗ hiện màn hình
│   ├── MainWindow.Designer.cs
│   ├── MainWindow.Appearance.cs    màu, font dùng chung
│   ├── Screens/                    mỗi màn một thư mục
│   │   ├── Overview/               Tổng quan
│   │   ├── Folder/                 Thư mục và từ vựng
│   │   ├── Study/                  Học lật thẻ
│   │   ├── TypeAnswer/             Gõ đáp án
│   │   ├── Mistake/                Sổ lỗi
│   │   └── Match/                  Ghép cặp (tùy chọn)
│   ├── Dialogs/                    hộp thoại
│   │   ├── AddCardDialog.cs        thêm, sửa từ
│   │   └── ImportWordsDialog.cs    nhập nhiều từ (thẻ 15)
│   ├── Controls/                   control vẽ riêng, dùng chung
│   │   └── StudyControls.cs
│   └── Data/                       đọc, ghi file SQLite
│       ├── Database.cs             tạo bảng và 30 từ mẫu (thẻ 03)
│       ├── Flashcard.cs
│       └── FlashcardStore.cs
├── docs/                           tài liệu, đọc theo số thứ tự
│   └── assets/                     ảnh minh họa màn hình
├── scripts/                        kiểm tra máy trước khi làm
│   ├── setup-windows.ps1
│   └── setup-mac.sh
└── .github/                        mẫu pull request, người duyệt code
```

File `flashcards.db` (dữ liệu của app) tự tạo cạnh file chạy khi bấm F5, không nằm trong repo.
