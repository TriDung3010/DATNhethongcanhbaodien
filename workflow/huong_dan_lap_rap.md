# HƯỚNG DẪN LẮP RÁP & VẬN HÀNH (BẢN CHUẨN MỚI NHẤT)
## Giai đoạn 1: Mô hình thu nhỏ (Dùng Biến trở mô phỏng rò rỉ)

---

## 1. DANH SÁCH CHÂN GPIO (ESP32 DevKit V1 38-Pin)
Trong cấu hình hiện tại, chúng ta sử dụng các chân sau:

| ESP32 | Thiết bị kết nối | Ghi chú |
| :--- | :--- | :--- |
| **G32** | Đèn LED Trắng | Đèn sinh hoạt (sáng khi an toàn) |
| **G25** | Đèn LED Xanh | Đèn báo hiệu hệ thống bình thường |
| **G33** | Đèn LED Đỏ | Đèn cảnh báo sự cố rò rỉ |
| **G35** | Biến trở (Núm vặn) | Mô phỏng dòng rò rỉ (0 - 100mA) |
| **G26** | Cục Relay | Ngắt điện khi có sự cố |
| **G27** | Còi Buzzer | Hú báo động khi rò rỉ |
| **G22** | Màn hình OLED (SCK) | Tín hiệu Clock cho OLED |
| **G21** | Màn hình OLED (SDA) | Tín hiệu Data cho OLED |

---

## 2. QUY TRÌNH LẮP RÁP PHẦN CỨNG

> [!WARNING]
> **QUAN TRỌNG VỀ BREADBOARD:** Bảng trắng (Breadboard) 830 lỗ thường bị đứt đôi mạch điện ở giữa (ngay vạch số 30). Bạn BẮT BUỘC phải dùng 4 cọng dây cắm "bắc cầu" nối liền 2 dải Đỏ và 2 dải Xanh ở giữa bảng để toàn bộ bảng được thông điện.

> [!CAUTION]
> **CẤP NGUỒN NGOÀI BẰNG MẠCH GIẢM ÁP LM2596:** 
> Phải dùng đồng hồ VOM đo và vặn ốc chỉnh ngõ ra của LM2596 về đúng **5.0V** TRƯỚC KHI cắm vào ESP32. Nếu để nguyên 12V cắm vào, ESP32 sẽ cháy ngay lập tức.

Để xem hình ảnh trực quan từng đường dây vuông góc và Thẻ hướng dẫn từng linh kiện, hãy mở 2 file sau bằng trình duyệt Web:
1. `so-do-thuc-te.html`: Bản đồ đi dây tổng thể toàn hệ thống.
2. `huong-dan-cam-day-chi-tiet.html`: Thẻ hướng dẫn cắm dây cho từng linh kiện.

### Các bước cắm dây tóm tắt:
1. **Nguồn tổng:** 
   - `OUT+` (LM2596) ──▶ Lỗ `V5` (ESP32)
   - `OUT-` (LM2596) ──▶ Lỗ `GND` (ESP32)
   - Lỗ `3V3` (ESP32) ──▶ Dải Đỏ Breadboard (Tạo trạm nguồn 3.3V)
   - Lỗ `GND` (ESP32) ──▶ Dải Xanh Breadboard (Tạo trạm Mass chung)
2. **OLED:** VDD ──▶ Dải Đỏ, GND ──▶ Dải Xanh, SCK ──▶ G22, SDA ──▶ G21.
3. **Biến trở:** Râu trái ──▶ Dải Đỏ, Râu phải ──▶ Dải Xanh, Chân giữa ──▶ G35.
4. **Relay:** DC+ ──▶ V5 (ESP32), DC- ──▶ Dải Xanh, IN1 ──▶ G26.
5. **Còi:** VCC ──▶ V5 (ESP32), GND ──▶ Dải Xanh, I/O ──▶ G27.
6. **LED (Đỏ/Xanh/Trắng):** Chân Dài (+) qua điện trở 220Ω cắm vào đinh ESP32 (G33/G25/G32), Chân Ngắn (-) cắm Dải Xanh.

---

## 3. CÀI ĐẶT PHẦN MỀM & NẠP CODE

### Bước 1: Cài thư viện OLED
1. Mở Arduino IDE.
2. Chọn menu **Sketch -> Include Library -> Manage Libraries...**
3. Tìm và cài đặt `Adafruit GFX Library`.
4. Tìm và cài đặt `Adafruit SSD1306`.

### Bước 2: Nạp Firmware
1. Rút cáp nguồn 12V ra khỏi LM2596 (để an toàn cho máy tính).
2. Cắm cáp USB từ máy tính vào ESP32.
3. Mở file `esp32_firmware_arduino/esp32_firmware_arduino.ino`.
4. Chọn đúng Board (`ESP32 Dev Module`) và Port (`COMx`).
5. Bấm nút **Upload**. Đợi báo "Done uploading".
6. Sau khi nạp xong, màn hình OLED sẽ sáng lên và hiển thị thông số dòng rò.

---

## 4. VẬN HÀNH & KIỂM TRA

1. Rút cáp USB máy tính ra. Cấp nguồn 12V vào mạch LM2596 để hệ thống chạy độc lập.
2. **Trạng thái Bình Thường:**
   - Màn hình OLED hiển thị `AN TOAN`, dòng rò ~ 0.0mA.
   - Đèn LED Trắng sáng, LED Xanh sáng.
   - Relay đóng (có tiếng tạch).
3. **Mô phỏng Rò rỉ:**
   - Vặn từ từ núm Biến trở. Màn hình OLED sẽ nhảy số mA tăng dần.
   - Khi vượt quá **30.0mA**:
     - Màn hình chớp nháy `NGUY HIEM!`.
     - Còi Buzzer hú tít tít.
     - LED Đỏ sáng lên (LED Xanh và Trắng tắt).
     - Relay ngắt cái "tạch".
4. **Hết Rò rỉ:**
   - Vặn núm Biến trở ngược lại về 0. Hệ thống tự động đóng Relay và khôi phục trạng thái AN TOÀN.
