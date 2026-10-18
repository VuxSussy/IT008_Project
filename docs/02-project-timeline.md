# Timeline phát triển app flashcard

> **Kế hoạch đề xuất:** 6 tuần tính từ ngày nhóm bắt đầu. Repo hiện chưa có mã nguồn app; các mốc dưới đây là mục tiêu, không phải tiến độ đã hoàn thành. Khi có ngày bắt đầu và hạn nộp, thay “Tuần 1–6” bằng ngày cụ thể và điều chỉnh theo số thành viên.

## 1. Phạm vi bản đầu tiên (MVP)

Người dùng có thể tạo bộ thẻ, thêm/sửa/xóa thẻ, học bằng cách xem mặt trước rồi lật xem mặt sau, và mở lại app mà nội dung đã lưu vẫn còn. App cần có trạng thái rỗng, xác nhận khi xóa và thông báo lỗi dễ hiểu. Nhóm chọn nền tảng, công nghệ và cách lưu dữ liệu trong Tuần 1; tài liệu này chưa giả định app web hay mobile.

Đăng nhập, chia sẻ bộ thẻ, đồng bộ nhiều thiết bị, nhắc học và thuật toán lặp lại ngắt quãng là ý tưởng **sau MVP**. Chỉ đưa vào mốc bàn giao nếu còn thời gian và nhóm thống nhất yêu cầu.

## 2. Các mốc thực hiện

| Thời gian | Trọng tâm | Việc chính | Kết quả cần có |
| --- | --- | --- | --- |
| Tuần 1 | Chốt yêu cầu và thiết kế | Xác định người dùng, luồng học, chức năng; chọn nền tảng/công nghệ; phác thảo màn hình và mô hình dữ liệu | Danh sách yêu cầu MVP, sơ đồ màn hình, đầu việc được chia nhỏ |
| Tuần 2 | Dựng nền app | Tạo cấu trúc dự án, cách chạy app, điều hướng, màn hình danh sách bộ thẻ; thiết lập lưu dữ liệu | App khởi chạy được, tạo và hiển thị bộ thẻ mẫu |
| Tuần 3 | Quản lý bộ thẻ và thẻ | Thêm/sửa/xóa bộ thẻ và thẻ; kiểm tra dữ liệu nhập và trạng thái rỗng | Người dùng tự tạo được bộ thẻ và nội dung thẻ |
| Tuần 4 | Luồng học | Hiển thị thẻ, lật mặt, chuyển thẻ, kết thúc phiên học; kiểm tra dữ liệu sau khi mở lại app | Hoàn chỉnh một phiên học với bộ thẻ tự tạo |
| Tuần 5 | Kiểm thử và hoàn thiện | Kiểm tra luồng chính, dữ liệu rỗng/sai, thao tác xóa, đóng mở app; sửa lỗi và cải thiện giao diện | Bản gần hoàn thiện, lỗi quan trọng được xử lý |
| Tuần 6 | Đóng gói và bàn giao | Kiểm thử lại, viết hướng dẫn chạy/sử dụng, chuẩn bị demo và báo cáo | Bản bàn giao chạy được, có tài liệu và kịch bản demo |

## 3. Mốc kiểm tra

- **Cuối Tuần 1:** chốt phạm vi MVP và cách chia việc; mọi thay đổi phạm vi sau đó cần đánh giá tác động tới thời gian.
- **Cuối Tuần 3:** kiểm tra từ đầu đến cuối luồng tạo bộ thẻ và thẻ. Nếu chưa đạt, ưu tiên sửa luồng này trước tính năng mới.
- **Cuối Tuần 4:** demo một phiên học hoàn chỉnh với dữ liệu do người dùng nhập.
- **Cuối Tuần 5:** chốt tính năng; Tuần 6 dành cho lỗi, tài liệu và bàn giao.

## 4. Rủi ro và cách xử lý

| Rủi ro | Cách xử lý |
| --- | --- |
| Chọn công nghệ hoặc cách lưu dữ liệu quá muộn | Chốt trong Tuần 1 bằng một bản chạy thử nhỏ |
| Tăng phạm vi tính năng giữa chừng | Giữ danh sách “sau MVP”; chỉ đổi phạm vi khi nhóm đánh giá lại timeline |
| Các phần làm riêng không ghép được | Gộp PR nhỏ thường xuyên; chạy thử luồng chung hằng tuần |
| Thiếu thời gian kiểm thử và tài liệu | Giữ Tuần 5–6 cho hoàn thiện, không dồn vào ngày cuối |

Quy trình làm việc chi tiết nằm ở [01-git-workflow.md](01-git-workflow.md).
