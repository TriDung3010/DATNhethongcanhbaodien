# HƯỚNG DẪN LẮP RÁP & VẬN HÀNH (BẢN CHUẨN MỚI NHẤT)
## Giai đoạn 1: Mô hình thu nhỏ (Dùng Biến trở mô phỏng rò rỉ)

---

## 1. DANH SÁCH CHÂN GPIO (ESP32 DevKit V1 38-Pin)
Trong cấu hình hiện tại, chúng ta sử dụng các chân sau:

| ESP32 | Thiết bị kết nối | Ghi chú |
| :--- | :--- | :--- |
| **G32** | Đèn LED Trắng #1 | Đèn sinh hoạt phòng khách |
| **G14** | Đèn LED Trắng #2 | Đèn sinh hoạt nhà bếp |
| **G25** | Đèn LED Xanh | Đèn báo hiệu hệ thống bình thường |
| **G33** | Đèn LED Đỏ | Đèn cảnh báo sự cố rò rỉ |
| **G35** | Biến trở (Núm vặn) | Mô phỏng dòng rò rỉ (0 - 100mA) |
| **G26** | Cục Relay | Ngắt tải (Quạt) khi có sự cố rò rỉ |
| **G27** | Còi Buzzer | Hú báo động khi rò rỉ (Active LOW) |
| **G22** | Màn hình OLED (SCK) | Tín hiệu Clock cho OLED |
| **G21** | Màn hình OLED (SDA) | Tín hiệu Data cho OLED |

---

## 2. QUY TRÌNH LẮP RÁP PHẦN CỨNG

> [!WARNING]
> **QUY HOẠCH 2 TRẠM NGUỒN (CHỐNG NÓNG ESP32):** 
> Dải Đỏ TRÁI dùng làm Trạm 5V (nuôi Relay và ESP). Dải Đỏ PHẢI dùng làm Trạm 3.3V (nuôi OLED, Còi, Biến trở). Tách biệt 2 trạm này để ESP32 không bị quá tải nhiệt.

> [!CAUTION]
> **CẤP NGUỒN NGOÀI BẰNG MẠCH GIẢM ÁP LM2596:** 
> Phải dùng đồng hồ VOM đo và vặn ốc chỉnh ngõ ra của LM2596 về đúng **5.0V** TRƯỚC KHI cắm vào ESP32. Nếu để nguyên 12V cắm vào, ESP32 sẽ cháy ngay lập tức.

Để xem hình ảnh trực quan từng đường dây vuông góc và Thẻ hướng dẫn từng linh kiện, hãy mở 2 file sau bằng trình duyệt Web:
1. `so-do-thuc-te.html`: Bản đồ đi dây tổng thể toàn hệ thống.
2. `huong-dan-cam-day-chi-tiet.html`: Thẻ hướng dẫn chi tiết từng lỗ cắm.

### Các bước cắm dây tóm tắt:
1. **Nguồn tổng:** 
   - `OUT+` (LM2596) ──▶ **Dải Đỏ TRÁI** (Trạm 5V)
   - `OUT-` (LM2596) ──▶ **Dải Xanh TRÁI** (Trạm Mass)
   - Lỗ `V5` (ESP32) ──▶ Nhận điện 5V từ **Dải Đỏ TRÁI**
   - Lỗ `3V3` (ESP32) ──▶ Cấp điện 3.3V ra **Dải Đỏ PHẢI** (Trạm 3.3V)
   - Dải Xanh TRÁI ──▶ Nối thông sang **Dải Xanh PHẢI** để chung Mass.
2. **OLED:** VDD ──▶ **Dải Đỏ PHẢI** (3.3V), GND ──▶ Dải Xanh, SCK ──▶ G22, SDA ──▶ G21.
3. **Biến trở:** Râu trái ──▶ **Dải Đỏ PHẢI** (3.3V), Râu phải ──▶ Dải Xanh, Chân giữa ──▶ G35.
4. **Relay:** DC+ ──▶ **Dải Đỏ TRÁI** (5V), DC- ──▶ Dải Xanh, IN1 ──▶ G26.
5. **Còi Buzzer:** VCC ──▶ **Dải Đỏ PHẢI** (3.3V), GND ──▶ Dải Xanh, I/O ──▶ G27.
6. **Mô-tơ Quạt (Tải):** Dây đỏ cắm vào lỗ **NO/NC** của Relay. Dây đen cắm vào **Mass**. Dùng 1 dây cắm từ lỗ **COM** của Relay sang **Dải Đỏ TRÁI (5V)**.
7. **LED (Đỏ/Xanh/Trắng):** Chân Dài (+) qua điện trở 220Ω cắm vào đinh ESP32 (G33/G25/G32/G14), Chân Ngắn (-) cắm Dải Xanh.

---

## 3. CÀI ĐẶT PHẦN MỀM & NẠP CODE

### Bước 1: Khắc phục lỗi tiếng Việt Arduino IDE
1. Tạo thư mục `D:\Arduino`.
2. Mở Arduino IDE -> File -> Preferences. Chỉnh **Sketchbook location** thành `D:\Arduino`.
3. Tắt phần mềm mở lại, chọn **Sketch -> Include Library -> Manage Libraries...**
4. Tìm và cài đặt `Adafruit GFX Library` và `Adafruit SSD1306`.

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
   - Relay đóng điện, **Mô-tơ Quạt quay vù vù**.
3. **Mô phỏng Rò rỉ:**
   - Vặn từ từ núm Biến trở. Màn hình OLED sẽ nhảy số mA tăng dần.
   - Khi vượt quá **30.0mA**:
     - Màn hình chớp nháy `NGUY HIEM!`.
     - Còi Buzzer hú tít tít theo nhịp.
     - LED Đỏ sáng lên (LED Xanh và Trắng tắt).
     - Relay ngắt cái "tạch", **Mô-tơ Quạt dừng quay ngay lập tức**.
4. **Hết Rò rỉ:**
   - Vặn núm Biến trở ngược lại về 0. Hệ thống tự động đóng Relay, Quạt quay trở lại bình thường.
