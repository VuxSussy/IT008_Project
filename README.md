# Flashcards – Đồ án IT008

App học từ vựng tiếng Anh bằng flash cards sử dụng C# WinForms (.NET 10).

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
| [05 – Danh sách hàm](docs/05-danh-sach-ham.md) | Trước khi viết hoặc gọi một hàm của người khác |

## Thư mục

```
IT008_Project/
├── FlashcardsApp.slnx              mở file này bằng Visual Studio
├── FlashcardsApp/                  code của app
│   ├── Program.cs                  điểm bắt đầu: tạo dữ liệu, đăng nhập, mở MainWindow
│   ├── MainWindow.cs               cửa sổ chính: menu trái 3 nhóm, ô tài khoản, chỗ hiện màn hình
│   ├── MainWindow.Designer.cs
│   ├── Screens/                    mỗi màn một thư mục
│   │   ├── Overview/               Tổng quan
│   │   ├── Course/                 Khóa học
│   │   ├── Folder/                 Thư mục của tôi
│   │   ├── Study/                  Học lật thẻ
│   │   ├── TypeAnswer/             Gõ đáp án
│   │   ├── Mistake/                Sổ lỗi
│   │   ├── Challenge/              Thử thách hằng ngày
│   │   ├── Rush/                   Đua từ
│   │   ├── Leaderboard/            Bảng xếp hạng
│   │   ├── Match/                  Ghép cặp (tùy chọn)
│   │   └── Admin/                  Quản trị, chỉ Admin thấy
│   │       ├── AdminScreen.cs          khung 4 tab
│   │       ├── AdminCoursePanel.cs     tab Khóa học
│   │       ├── AdminSeasonPanel.cs     tab Theo mùa
│   │       ├── AdminChallengePanel.cs  tab Thử thách
│   │       └── AdminUserPanel.cs       tab Người dùng
│   ├── Dialogs/                    hộp thoại
│   │   ├── LoginDialog.cs          đăng nhập, đăng ký
│   │   ├── AddCardDialog.cs        thêm, sửa từ
│   │   └── ImportWordsDialog.cs    nhập nhiều từ (chưa có, #16)
│   ├── Controls/                   control vẽ riêng, dùng chung
│   │   ├── StudyTheme.cs           màu dùng chung, hàm bo góc
│   │   ├── Icons.cs                vẽ biểu tượng
│   │   ├── StudyButton.cs          nút bo góc
│   │   ├── CardPanel.cs            khung trắng bo góc
│   │   ├── HomeRow.cs              một dòng bấm được ở màn Tổng quan
│   │   ├── ProgressRing.cs         vòng tròn tiến độ
│   │   ├── ChipLabel.cs            viên bo tròn có biểu tượng (chuỗi ngày, điểm)
│   │   ├── AvatarBox.cs            hình tròn có chữ cái đầu của tên
│   │   └── LogoBox.cs, SpacedLabel.cs, StatusLabel.cs
│   └── Data/                       lớp dữ liệu và mọi câu SQL
│       ├── Database.cs             tạo bảng và dữ liệu mẫu
│       ├── Session.cs              người đang đăng nhập
│       ├── User.cs, Flashcard.cs, Folder.cs, Course.cs, Lesson.cs
│       ├── RankRow.cs, ChallengeResult.cs, ChallengeDay.cs, UserSummary.cs
│       ├── UserStore.cs            tài khoản
│       ├── FlashcardStore.cs       từ vựng
│       ├── FolderStore.cs          thư mục, thư mục theo mùa
│       ├── StudyStore.cs           kết quả học, sổ lỗi
│       ├── ActivityStore.cs        ngày học, chuỗi ngày
│       ├── CourseStore.cs          khóa học và bài
│       ├── ChallengeStore.cs       thử thách hằng ngày
│       └── RushStore.cs            đua từ
├── docs/                           tài liệu, đọc theo số thứ tự
│   └── assets/                     ảnh minh họa màn hình
├── scripts/                        kiểm tra máy trước khi làm
│   ├── setup-windows.ps1
│   └── setup-mac.sh
└── .github/                        mẫu pull request, người duyệt code
```

