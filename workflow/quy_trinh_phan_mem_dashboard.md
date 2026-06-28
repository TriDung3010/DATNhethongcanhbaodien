# Quy trình hoạt động Phần mềm Dashboard Cảnh báo Rò rỉ

Tài liệu này mô tả chi tiết luồng xử lý dữ liệu và logic hoạt động của phần mềm WinForms Dashboard trên máy tính, lớp thứ 2 trong hệ thống giám sát.

## 1. Khởi động và Lắng nghe dữ liệu

*   **Bắt đầu:** Khi phần mềm được bật lên (phải chạy bằng quyền Administrator), sự kiện `Form_Load` sẽ được kích hoạt.
*   **HttpServer:** Hàm `StartHttpServer()` khởi tạo đối tượng `HttpListener`.
*   **Mở cổng:** Phần mềm mở cổng mạng cục bộ với tiền tố `http://+:8080/` để nhận mọi yêu cầu gửi đến port 8080.
*   **Vòng lặp:** Một luồng chạy ngầm (Background Thread) gọi hàm `ListenLoop()` liên tục chờ và hứng các request HTTP POST từ ESP32 gửi lên mạng nội bộ.

## 2. Tiếp nhận và Phân tích Dữ liệu (Parse)

*   **Nhận POST:** Khi ESP32 gửi một bản tin POST mang dữ liệu JSON:
    ```json
    {
      "deviceId": "ESP32_NHA_MO_HINH",
      "leakageCurrent": 45.2,
      "unit": "mA",
      "alert": true,
      "relayState": false,
      "timestamp": "639451"
    }
    ```
*   **Đọc Payload:** Ứng dụng đọc phần InputStream của HTTP Request và chuyển thành định dạng chuỗi (String).
*   **Deserialize:** Sử dụng thư viện `Newtonsoft.Json`, chuỗi JSON được tự động map vào model class `SensorData`.
*   **Bổ sung:** Cập nhật trường `Timestamp` thực tế của Windows (thời gian nhận bản tin) thay cho `EspTimestamp` (thời gian tính bằng mili-giây kể từ lúc mạch ESP32 khởi động).

## 3. Cập nhật Giao diện (Update UI)

Do ứng dụng xử lý dữ liệu trên Background Thread, việc cập nhật giao diện (Label, Grid, Chart) phải được gọi thông qua hàm `Invoke` để trở lại UI Thread.

*   **Grid (Lịch sử):** Đẩy dữ liệu mới lên đầu danh sách `BindingList`. Nếu danh sách vượt quá 50 bản ghi, phần mềm tự động xóa bản ghi cũ nhất (ở cuối danh sách).
*   **Biểu đồ (Chart):** Dòng rò (LeakageCurrent) được đưa vào mảng dữ liệu `ObservableCollection` của thư viện `LiveCharts2`, tạo hiệu ứng biểu đồ thời gian thực.
*   **Card Tổng quan:** Cập nhật số gói tin đã nhận (Packet Count) và dòng điện rò rỉ (Current) trên các Label.

## 4. Xử lý Cảnh báo (Alert Handling)

Ứng dụng đọc cờ `alert` trong chuỗi JSON để xử lý phản ứng:

*   **Khi `alert` == true:**
    *   Màu nền (Background) của Card trạng thái đổi sang màu Đỏ (Red).
    *   Chữ trạng thái chuyển thành "CẢNH BÁO RÒ RỈ!".
    *   Trạng thái góc trên cùng chuyển thành đèn Đỏ.
    *   Phát âm thanh cảnh báo của Windows `SystemSounds.Exclamation.Play()` để báo hiệu cho người dùng trên máy tính.
*   **Khi `alert` == false:**
    *   Giao diện trở về tông màu Xanh lá (Bình thường).
    *   Ngừng chuông, trạng thái trở về "BÌNH THƯỜNG".

## 5. Phản hồi Server

Sau khi đã hoàn thành các tác vụ cập nhật giao diện và cảnh báo, `HttpListener` sẽ trả về `StatusCode = 200` và chuỗi JSON `{"status":"ok"}` để xác nhận với ESP32 là đã nhận được dữ liệu thành công. Mạch ESP32 nhận được mã 200 sẽ ngừng timeout và chờ chu kỳ gửi tiếp theo.
