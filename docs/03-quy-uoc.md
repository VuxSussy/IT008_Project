## Đặt tên

| Thứ | Quy ước | Ví dụ |
|---|---|---|
| Form | `form` + PascalCase | `formDangNhap`, `formQuanLySach` |
| UserControl | `uc` + PascalCase | `ucThanhTimKiem` |
| Control trên form | tiền tố + PascalCase | `btnLuu`, `txtTenDangNhap`, `dgvDanhSach`, `cboVaiTro`, `lblTongTien`, `dtpNgayLap`, `numSoLuong`, `chkConHang` |
| Lớp theo bảng | `<TenBang>DTO/DAL/BUS` | `SachDTO`, `SachDAL`, `SachBUS` |
| Phương thức | PascalCase, động từ đầu | `LayDanhSach()`, `Them()`, `CapNhat()`, `Xoa()`, `TimKiem()` |
| Field private | `_camelCase` | `_sachBus` |
| Biến cục bộ | camelCase | `tongTien` |

Tên tiếng Việt **không dấu** cho nghiệp vụ, tiếng Anh cho khái niệm kỹ thuật (`DbHelper`, `ExecuteQuery`) – thống nhất cả nhóm.
