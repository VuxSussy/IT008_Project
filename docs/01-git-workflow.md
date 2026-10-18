# Quy trình làm việc nhóm và Git

> Quy trình đề xuất cho giai đoạn khởi tạo. Nhóm có thể điều chỉnh khi chốt cách làm việc.

## 1. Một vòng làm việc

1. **Chọn việc:** tạo issue hoặc ghi đầu việc trên bảng công việc, kèm mục tiêu, người phụ trách và tiêu chí hoàn thành.
2. **Làm rõ yêu cầu:** xác định màn hình, dữ liệu, hành vi mong đợi và trường hợp lỗi trước khi viết mã.
3. **Triển khai:** tạo nhánh từ `main`; mỗi nhánh giải quyết một việc có phạm vi rõ ràng.
4. **Tự kiểm tra:** chạy app, kiểm tra luồng chính và trường hợp biên liên quan; viết kiểm thử tự động khi logic dễ lỗi hoặc cần tránh lỗi tái diễn.
5. **Gửi pull request (PR):** mô tả thay đổi, cách kiểm tra, ảnh màn hình nếu có giao diện và liên kết issue liên quan.
6. **Review và gộp:** ít nhất một thành viên khác xem PR; sửa góp ý, kiểm tra lại rồi mới gộp vào `main`.
7. **Cập nhật tiến độ:** đóng issue, cập nhật bảng công việc và ghi lại các quyết định quan trọng.

## 2. Quy ước Git

- `main` là nhánh tích hợp, giữ ở trạng thái có thể chạy được.
- Đặt tên nhánh theo dạng `feature/ten-tinh-nang`, `fix/ten-loi`, `docs/ten-tai-lieu`. Ví dụ: `feature/create-deck`.
- Commit ngắn, có nghĩa: `feat: add deck creation`, `fix: preserve card order`, `docs: add project timeline`.
- Không đẩy mật khẩu, khóa bí mật, dữ liệu cá nhân hoặc file cấu hình nhạy cảm lên repo.
- Khi có xung đột gộp nhánh, người làm nhánh giải quyết và kiểm tra lại phần liên quan.

Ví dụ bắt đầu một đầu việc:

```bash
git switch main
git pull
git switch -c feature/create-deck
# Chỉnh sửa và kiểm tra thay đổi
git add .
git commit -m "feat: add deck creation"
git push -u origin feature/create-deck
```

## 3. Trạng thái công việc

| Trạng thái | Ý nghĩa |
| --- | --- |
| Backlog | Đã ghi nhận, chưa chọn làm |
| Ready | Yêu cầu và tiêu chí hoàn thành đã rõ |
| In progress | Đang thực hiện |
| In review | Đã có PR, đang được xem xét |
| Done | Đã gộp, kiểm tra đạt và cập nhật tài liệu liên quan |

Họp ngắn định kỳ để nêu việc đã làm, việc tiếp theo và trở ngại. Quyết định ảnh hưởng đến phạm vi hoặc timeline cần được ghi trong issue hoặc PR.

## 4. Tiêu chí hoàn thành một đầu việc

- Đáp ứng tiêu chí chấp nhận ghi trong issue.
- App chạy được; các luồng và trường hợp lỗi liên quan đã được kiểm tra.
- Không còn lỗi nghiêm trọng đã biết do thay đổi này gây ra.
- PR được review và gộp vào `main`.
- Hướng dẫn sử dụng hoặc tài liệu kỹ thuật được cập nhật nếu cần.

Xem [timeline dự kiến](02-project-timeline.md) để biết các mốc bàn giao.
