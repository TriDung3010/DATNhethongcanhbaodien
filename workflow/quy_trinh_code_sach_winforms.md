# Quy Trình Lập Trình Sạch (Clean Code) Cho WinForms

Tài liệu này quy định các tiêu chuẩn bắt buộc khi phát triển giao diện và logic cho ứng dụng WinForms trong dự án hệ thống cảnh báo rò rỉ điện năng.

## 1. Nguyên Tắc Phân Tách "Giao Diện tĩnh" và "Logic động"
WinForms sử dụng mô hình Partial Class để tách biệt mã tự sinh của giao diện và mã logic của người lập trình. Việc vi phạm nguyên tắc này sẽ gây ra phình to mã nguồn, khó bảo trì, và không thể sử dụng trình thiết kế trực quan (Visual Studio Designer).

### ❌ KHÔNG ĐƯỢC LÀM (Anti-pattern)
Tuyệt đối KHÔNG ĐƯỢC khởi tạo các control tĩnh (giao diện cố định) bên trong file `.cs` (code-behind).
Ví dụ về code vi phạm (nằm trong file `Form.cs`):
```csharp
// Sai: Khởi tạo và thiết kế giao diện bằng code tay trong file logic
private void SetupUI() 
{
    Label lblTitle = new Label();
    lblTitle.Text = "Tiêu đề";
    lblTitle.Dock = DockStyle.Top;
    this.Controls.Add(lblTitle);
}
```

### ✅ THỰC HÀNH CHUẨN (Best Practice)
Tất cả các thành phần giao diện (Control) mang tính chất tĩnh (cố định, luôn luôn tồn tại) **BẮT BUỘC** phải được tạo ra thông qua **Visual Studio Designer**, mã nguồn của chúng sẽ tự động được lưu vào file `.Designer.cs`.
File `.cs` chính chỉ dùng để:
1. Gán dữ liệu (Data Binding).
2. Viết sự kiện xử lý (Event Handlers như `Click`, `Load`).
3. Đổi màu, đổi trạng thái, ẩn hiện (`Visible = false`) tùy theo logic.

## 2. Quy Tắc Đặt Tên (Naming Convention)
- **Control Giao diện**: Bắt buộc sử dụng tiền tố (prefix) gồm 3 chữ cái thường:
  - `btn`: Button (vd: `btnLogin`, `btnExit`)
  - `lbl`: Label (vd: `lblTitle`, `lblStatus`)
  - `txt`: TextBox (vd: `txtUsername`)
  - `pnl`: Panel (vd: `pnlMain`, `pnlSidebar`)
  - `dgv`: DataGridView (vd: `dgvHistory`)
  - `chart`: LiveCharts (vd: `chartView`)

## 3. Quản Lý Z-Order và Layout
- Khi sử dụng `DockStyle.Fill`, Control mang thuộc tính Fill **phải được khai báo/Add vào cuối cùng** để không che lấp các Control có thuộc tính `Top`, `Bottom`, `Left`, `Right`.
- Trong file `.Designer.cs`, lệnh `Controls.Add()` chạy theo thứ tự từ trên xuống. Phần tử được add càng muộn sẽ nằm dưới (Z-Order thấp hơn). Hãy sử dụng lệnh `SendToBack()` hoặc `BringToFront()` cẩn thận nếu cần.

## 4. Xử Lý Bất Đồng Bộ (UI Threading)
Do WinForms chạy trên một luồng chính (Main UI Thread), khi nhận dữ liệu từ các luồng khác (Background Thread - ví dụ như HttpListener nhận POST request từ mạch ESP32), tuyệt đối **không được cập nhật trực tiếp lên UI**.
Bắt buộc phải sử dụng `Invoke` hoặc `BeginInvoke`:
```csharp
if (this.InvokeRequired)
{
    this.Invoke(new Action(() => UpdateUI(data)));
    return;
}
// Code cập nhật UI an toàn
lblStatus.Text = data;
```
