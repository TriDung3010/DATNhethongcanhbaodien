# AGENTS.md - Hệ thống Cảnh báo Rò rỉ Điện năng

## Tổng quan
Đồ án tốt nghiệp: Hệ thống IoT phát hiện và cảnh báo rò rỉ điện năng.
ESP32 đọc dòng rò (ZCT/Biến trở) → nếu vượt 30mA → ngắt relay + báo buzzer + hiển thị OLED + gửi JSON qua HTTP POST lên WinForms Dashboard (PC) → hiển thị biểu đồ realtime + cảnh báo âm thanh.

## Kiến trúc hệ thống (2 lớp)

```
[Lớp Thiết bị]                          [Lớp Giao diện PC]
ZCT / Biến trở                           WinForms Dashboard
      ↓                                        ↑
ESP32 (xử lý tại biên)  ──HTTP POST──▶  HttpListener :8080
  ├── Ngắt Relay (G26)                    ├── Chart realtime
  ├── Bật Buzzer (G27)                    ├── Lịch sử 50 bản ghi (RAM)
  ├── LED cảnh báo (G33)                  └── Cảnh báo âm thanh + đổi màu
  └── OLED hiển thị (I2C)
```

## Cấu trúc thư mục

```
C:\Users\PC\DATNhethongcanhbaodien\
├── AGENTS.md                          # File này
├── start.bat                          # Hướng dẫn chạy WinForms
├── WinformsDashboard.sln              # Solution file mở bằng Visual Studio
├── esp32_firmware_arduino/            # Firmware ESP32 (Arduino IDE)
│   ├── esp32_firmware_arduino.ino     # Code chính
│   └── config.h                      # WiFi, Server URL, GPIO, ngưỡng
├── WinformsDashboard/                 # Dashboard Windows Forms (.NET 9)
│   ├── Form1.cs                       # Logic chính: HttpListener + xử lý data
│   ├── Form1.Designer.cs              # Layout controls
│   ├── Program.cs                     # Entry point
│   ├── WinformsDashboard.csproj       # Project file
│   └── publish/                       # File .exe đã build sẵn
└── workflow/                          # Tài liệu báo cáo
    ├── quy_trinh_he_thong_canh_bao.md
    ├── thiet_ke_mo_hinh_nha.md
    ├── danh_sach_linh_kien.md
    ├── huong_dan_lap_rap.md
    ├── plantuml_diagrams.md
    ├── workflow_diagrams.puml
    └── quy_trinh_code_sach_winforms.md
```

## GPIO ESP32

| GPIO | Kết nối | Ghi chú |
|------|---------|---------|
| 34 | ZCT (cảm biến dòng) | ADC - đọc dòng rò thật |
| 35 | Biến trở 10kΩ | ADC - giả lập mức rò 0-100mA |
| 26 | Relay | Ngắt tải (Mô-tơ Quạt) khi rò rỉ |
| 27 | Buzzer (KY-012 active) | Còi báo (Nguồn 3.3V, Active LOW) |
| 32 | LED trắng #1 | Đèn phòng khách |
| 14 | LED trắng #2 | Đèn bếp |
| 12 | (Bỏ trống) | Từng là Quạt (nay Quạt đã chuyển sang Relay) |
| 25 | LED xanh | Trạng thái BÌNH THƯỜNG |
| 33 | LED đỏ | Trạng thái RÒ RỈ |
| 13 | Nút nhấn RÒ RỈ | INPUT_PULLUP, toggle simulate |
| 19 | Nút nhấn RESET | INPUT_PULLUP, tắt simulate |
| 2 | LED (trên board) | Nhấp nháy khi alert |
| 21 | OLED SDA | I2C Data |
| 22 | OLED SCL | I2C Clock |

## WinForms Dashboard

### Endpoint nhận dữ liệu
- **HttpListener:** `http://+:8080/` (catch-all, không phân biệt path)
- **Method:** POST
- **Body JSON từ ESP32:**
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

### Controls chính
| Control | Mô tả |
|---------|-------|
| `lblTitle` | Tiêu đề hệ thống |
| `lblStatus` | Trạng thái: BÌNH THƯỜNG / CẢNH BÁO RÒ RỈ |
| `lblCurrent` | Dòng rò hiện tại (mA) |
| `lblLog` | Log nhận packet: số gói, thời gian, path |
| `chartView` | Biểu đồ LiveCharts2 - đường dòng rò realtime |
| `dgvHistory` | Bảng lịch sử 50 bản ghi gần nhất |

### Logic xử lý
- `StartHttpServer()` — mở HttpListener port 8080
- `ListenLoop()` — vòng lặp nhận request (background thread)
- `ProcessIncomingData()` — cập nhật chart, label, cảnh báo
- Alert: nền đỏ + âm thanh `SystemSounds.Exclamation` khi `alert=true`

## Cách chạy

```
1. Mở thư mục: C:\Users\PC\DATNhethongcanhbaodien\WinformsDashboard\publish\
2. Chuột phải vào WinformsDashboard.exe
3. Chọn "Run as Administrator" (BẮT BUỘC để mở port 8080)
4. Cắm ESP32, bật nguồn mạch → data tự động cập nhật lên WinForms
```

> **Lưu ý:** KHÔNG chạy Spring Boot hay bất kỳ service nào khác trên port 8080, vì sẽ xung đột với WinForms.

## Firmware Logic (Edge Alert)

Loop 200ms:
- `readButtons()` — nút RÒ RỈ toggle simulate, nút RESET clear
- `readLeakageCurrent()` — nếu simulate thì đọc biến trở (G35), nếu không thì đọc ZCT (G34)
- `processAlert()` — nếu >= 30mA: ngắt relay, tắt LED, bật alert. Nếu < 30mA: đóng relay, bật LED
- `controlBuzzer()` — nhịp bíp kép 800ms khi alert
- `updateOLED()` — hiển thị dòng rò + trạng thái lên màn hình OLED
- `sendDataToServer()` — HTTP POST 3 giây/lần lên WinForms
- `ensureWiFi()` — tự động reconnect nếu mất WiFi

## Luồng dữ liệu

```
ZCT/Biến trở → ESP32 đọc ADC → processAlert (local) → HTTP POST → WinForms HttpListener
                    ↓                                                      ↓
              Relay + Buzzer                                     Cập nhật Chart + Label
              OLED hiển thị                                      Lịch sử 50 bản ghi RAM
```

## Lưu ý phần cứng (Thiết kế chống nóng ESP32)

- Hệ thống sử dụng 2 trạm nguồn độc lập trên Breadboard:
  - **Trạm 5V (Dải đỏ TRÁI):** Lấy điện từ module LM2596. Cấp nguồn cho **Relay**, và cấp vào chân **V5** để nuôi ESP32.
  - **Trạm 3.3V (Dải đỏ PHẢI):** Lấy điện từ chân **3V3** của ESP32 nhả ra. Cấp nguồn cho **OLED, Biến trở, và Còi Buzzer** (còi dùng 3.3V để không bị hú liên tục do chênh lệch áp với tín hiệu 3.3V của ESP32).
  - **Trạm Mass (Dải xanh 2 BÊN):** Nối chung toàn bộ GND của LM2596, ESP32 và các linh kiện.
- **Mô-tơ Quạt (Tải):** Được cấp nguồn 5V nối tiếp qua cổng NO/NC của cục Relay, tuyệt đối không cắm trực tiếp vào ESP32 (tránh cháy chip).

## Lưu ý khi sửa code

- **WinForms:** Dùng `HttpListener` với prefix `http://+:8080/`, PHẢI chạy với quyền Admin. SensorData dùng `[JsonIgnore]` cho `Timestamp` và `[JsonProperty("timestamp")]` cho `EspTimestamp` (string) để tránh lỗi parse DateTime từ giá trị millis() của ESP32.
- **ESP32:** Dùng `analogRead()` với độ phân giải 12 bit, không dùng ArduinoJson (build JSON thủ công bằng String). URL server: `http://<IP_PC>:8080/api/v1/sensor-data` (không có trailing slash).
- **Ngưỡng rò rỉ:** 30mA (hằng số `LEAKAGE_THRESHOLD_MA` trong config.h)
- **IP máy tính:** Xem bằng lệnh `ipconfig`, điền vào `SERVER_URL` trong config.h

## Lưu ý khi sửa code WinForms (Designer vs Code-behind)

- **Quy tắc Code Sạch (Clean Code):** Bắt buộc tuân thủ theo tài liệu [Quy Trình Code Sạch](file:///d:/DATNhethongcanhbaodien/workflow/quy_trinh_code_sach_winforms.md).
- **Tuyệt đối CẤM code giao diện trong file .cs:** Không được dùng code C# (ví dụ: `new Label()`, `new Button()`, `Controls.Add()`) để vẽ giao diện tĩnh bên trong các file `.cs` chính. Tất cả giao diện tĩnh **PHẢI** được tạo qua Visual Studio Designer và lưu tự động vào file `.Designer.cs`. File `.cs` chỉ được chứa logic, sự kiện và data binding. Tránh làm hỏng/xung đột thiết kế giao diện của hệ thống.
- **Phân tách tĩnh/động:** Bất kỳ thuộc tính tĩnh nào (như Dock, Padding, BackColor cố định) PHẢI đưa vào file .Designer.cs. Chỉ sử dụng code .cs cho các logic động.
- **Z-Order và Docking:** Khi dùng Dock = Fill chung với Tiêu đề, Tiêu đề phải được set Dock = Top (hoặc Bottom/Left/Right) và phải nằm trước trong danh sách Controls.Add() để chiếm không gian, tránh bị control Fill đè lên.
- **Tránh hàm căn giữa vô tác dụng:** Hàm `this.CenterToScreen()` phải được đặt **SAU** khi các dòng code thay đổi kích thước form động (như `this.ClientSize = ...`) trong sự kiện Load.
- **Lỗi Cache Designer:** Visual Studio rất hay bị kẹt file .Designer.cs trong bộ nhớ RAM, gây ra lỗi "The name XYZ does not exist". Khi đó code trên ổ đĩa là đúng, lỗi do Cache. Phải đóng Tab Designer -> Clean -> Rebuild, hoặc chèn một hàm rỗng cùng tên để lừa Designer tải lại.
