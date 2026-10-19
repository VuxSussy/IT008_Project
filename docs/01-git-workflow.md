# Quy trình làm việc nhóm và Git

## 1. Mô hình: GitHub Flow

```
main ──●────────●──────────●────────●──── (luôn chạy được, được bảo vệ)
        \      /  \        /
         ●──●─●    ●──●───●
     feat/12-dang-nhap   fix/31-sai-tong-tien
```
## 2. Đặt tên nhánh

```
<loai>/<so-issue>-<mo-ta-ngan-khong-dau>
```

| Loại | Dùng khi | Ví dụ |
|---|---|---|
| `feat/` | Chức năng mới | `feat/12-kho-tu-vung` |
| `fix/` | Sửa lỗi | `fix/31-mat-gui` |
| `docs/` | Tài liệu | `docs/2-gioi-thieu-vuxsussy` |
| `refactor/` | Dọn code, không đổi chức năng | `refactor/20-tach-usercontrol` |
| `chore/` | Cấu hình, CI, thư viện | `chore/5-them-closedxml` |

## 3. Commit message

```
<loai>(<pham-vi>): <mô tả ngắn, thì hiện tại, ≤ 72 ký tự>

<thân – tùy chọn: giải thích TẠI SAO>
```

Ví dụ tốt:
```
feat(dang-nhap): kiểm tra mật khẩu bằng SHA-256 + salt
fix(hoa-don): làm tròn tổng tiền về đơn vị đồng
docs(team): thêm giới thiệu của Vũ
```

Ví dụ **tệ** (sẽ bị yêu cầu sửa khi review): `update`, `fix bug`, `aaa`, `final final 2`.

> **Commit nhỏ, commit thường xuyên.** Mỗi commit làm 1 việc và vẫn build được.

## 4. Vòng đời 1 đầu việc

```bash
#99. Tải repos về máy
git clone https://github.com/VuxSussy/IT008_Project.git
git config --global user.name "Tên của bạn"
git config --global user.email "email@example.com"
gh auth login
#Login xong thì check status
gh auth status
-- ⚠️ Disclaimer: phải tạo tài khoản github nếu chưa có

# 0. Nhận issue trên GitHub (Assign cho mình), ví dụ issue #12

# 1. Luôn bắt đầu từ main mới nhất
git switch main
git pull #kéo những thay đổi mới nhất ở hàm main về thư mục

# 2. Tạo nhánh
git switch -c feat/12-form-dang-nhap

# 3. Code... rồi xem mình đã sửa gì
git status
git diff

# 4. Stage có chọn lọc – KHÔNG "git add ." mù quáng
git add <file>
git commit -m "feat(dang-nhap): tạo form đăng nhập"

# 5. Trước khi push: cập nhật theo main (rebase, không merge)
git fetch origin
git rebase origin/main
#    → có conflict thì xem mục 6

# 6. Push nhánh lên GitHub (lần đầu dùng -u)
git push -u origin feat/12-form-dang-nhap

# 7. Mở PR (web hoặc GitHub CLI)
gh pr create --fill --assignee @me

# 8. Sửa theo review → commit thêm → push lại (PR tự cập nhật)
# 9. Được approve + CI xanh → "Squash and merge" → "Delete branch"

# 10. Dọn dẹp ở máy
git switch main
git pull
git branch -d feat/12-form-dang-nhap

-- Lên zalo tag @VuxSussy để được review code
```

## 5. Pull Request & Code review

**Người tạo PR**
- Tiêu đề PR theo Conventional Commits (vì nó sẽ thành commit trên `main`).
- Ghi `Closes #12` để merge xong issue tự đóng.
- PR nhỏ: lý tưởng **< 400 dòng thay đổi**. To quá → tách.
- Tự review diff của chính mình trên GitHub trước khi request người khác.

**Người review** – xem theo thứ tự:
1. Chạy được không? (checkout về máy: `gh pr checkout 12`)
2. Đúng kiến trúc?
3. Đặt tên rõ ràng? Có code thừa, comment rác, `MessageBox` debug không?
4. Góp ý **về code**. Dùng tiền tố:
   - `nit:` góp ý nhỏ, không bắt buộc sửa
   - `question:` hỏi để hiểu
   - `blocker:` phải sửa mới merge
