# HƯỚNG DẪN LẮP RÁP & VẬN HÀNH
## Hệ thống Cảnh báo Rò rỉ Điện năng

---

## 1. SƠ ĐỒ CHÂN GPIO (ESP32 DevKit V1)

```
ESP32               | Thiết bị           | Ghi chú
─────────────────────┼────────────────────┼─────────────────
GPIO 32  ──────────── LED trắng #1        Đèn phòng khách
GPIO 14  ──────────── LED trắng #2        Đèn bếp
GPIO 12  ──────────── LED trắng #3        Quạt (hoặc motor nhỏ)
GPIO 25  ──────────── LED xanh            Trạng thái BÌNH THƯỜNG
GPIO 33  ──────────── LED đỏ              Trạng thái RÒ RỈ

GPIO 13  ──────────── Nút nhấn RÒ RỈ      Nhấn để mô phỏng rò rỉ
GPIO 19  ──────────── Nút nhấn RESET      Nhấn để reset

GPIO 34  ──────────── ZCT (cảm biến dòng) Đo dòng rò thực tế
GPIO 35  ──────────── Biến trở 10kΩ       Chỉnh mức rò 0-100mA

GPIO 26  ──────────── Relay               Ngắt điện thiết bị
GPIO 27  ──────────── Buzzer              Còi báo động
2        ──────────── LED (trên board)     Nhấp nháy khi báo động
```

## 2. ĐẤU DÂY BREADBOARD (TỪNG BƯỚC)

### Bước 1: Cấp nguồn cho ESP32

```
Adapter 12V DC ──┬── Jack DC (cái)
                 │
            [DC-DC LM2596]
            Input: 12V    Output: 5V
                 │
                 └── 5V (+) ──→ ESP32 5V pin
                     GND   ──→ ESP32 GND pin
```

1. Cắm jack DC vào adapter 12V
2. Đấu đầu ra jack DC vào input DC-DC LM2596 (IN+/IN-)
3. Chỉnh biến trở trên LM2596 để output ra đúng 5V
4. Đấu output LM2596 (OUT+/OUT-) vào ESP32 (5V và GND)

### Bước 2: LED thiết bị (LED trắng)

Mỗi LED cần **1 điện trở 220Ω nối tiếp** (hạn dòng ~10-15mA).

```
GPIO 32 ──→ 220Ω ──→ LED#1 (+) ──→ LED#1 (-) ──→ GND
GPIO 14 ──→ 220Ω ──→ LED#2 (+) ──→ LED#2 (-) ──→ GND
GPIO 12 ──→ 220Ω ──→ LED#3 (+) ──→ LED#3 (-) ──→ GND
```

### Bước 3: LED trạng thái (xanh + đỏ)

```
GPIO 25 ──→ 220Ω ──→ LED xanh (+) ──→ LED xanh (-) ──→ GND
GPIO 33 ──→ 220Ω ──→ LED đỏ (+)   ──→ LED đỏ (-)   ──→ GND
```

### Bước 4: Nút nhấn

Mỗi nút cần **1 điện trở pull-down 10kΩ** xuống GND.

```
                ┌──── Nút ────┐
               (+)           (-)
GPIO 13 ────────┤              ├────────────── GND
                │              │
                └── 10kΩ ──────┘
                    ↓ GND
```

Tương tự cho GPIO 19 (nút RESET).

### Bước 5: Biến trở Potentiometer 10kΩ

```
Chân 1 (bên trái)  ──→ 3.3V
Chân 2 (giữa)       ──→ GPIO 35
Chân 3 (bên phải)   ──→ GND
```

### Bước 6: ZCT (SCT013)

```
ZCT Jack ──┬── Dây tín hiệu ──→ GPIO 34
           ├── Dây GND       ──→ GND
           │
           [Luồn dây nguồn qua lõi ZCT]
           Dây L và N đều đi qua lỗ ZCT
```

### Bước 7: Relay

```
GPIO 26 ──→ Relay IN
Relay VCC ──→ 5V
Relay GND ──→ GND

Relay COM ──→ Dây (+) 12V từ adapter
Relay NO  ──→ Cấp nguồn 12V cho thiết bị
```

### Bước 8: Buzzer (KY-012 active)

```
GPIO 27 ──→ Buzzer (+) (S)
Buzzer (-) ──→ GND (-)
```

### Bước 9: Motor DC (quạt/máy giặt)

```
Motor (+) ──→ Relay NO (cùng nhánh nguồn 12V với LED)
Motor (-) ──→ GND
```

## 3. SƠ ĐỒ TỔNG THỂ (NHÌN TỪ TRÊN XUỐNG)

```
┌──────────────────────────────────────────────────────────┐
│                     BREADBOARD                           │
│                                                          │
│  ┌──────────────────────────────────────────────────┐   │
│  │  ESP32 DevKit V1                                 │   │
│  │  ┌─┐ ┌─┐ ┌─┐ ┌─┐ ...                          │   │
│  │  │3│ │3│ │1│ │1│ ...                          │   │
│  │  │2│ │3│ │2│ │4│ ...                          │   │
│  │  └─┘ └─┘ └─┘ └─┘                              │   │
│  └──────────────┬───────────────────────────────────┘   │
│                  │                                       │
│  ┌─────┐ ┌─────┐ │ ┌─────┐ ┌─────┐ ┌─────┐ ┌─────┐   │
│  │LED#1│ │LED#2│ │ │LED#3│ │XANH │ │ ĐỎ  │ │Motor│   │
│  │(PK) │ │(Bếp)│ │ │(Quạt)│ │     │ │     │ │     │   │
│  └─────┘ └─────┘ │ └─────┘ └─────┘ └─────┘ └─────┘   │
│                  │                                       │
│       ┌─────┐ ┌──┴──┐ ┌─────┐ ┌────────┐ ┌────────┐  │
│       │Nút  │ │Nút  │ │Biến  │ │Relay   │ │Buzzer  │  │
│       │RÒ RỈ│ │RESET│ │trở   │ │Module  │ │(KX-012)│  │
│       └─────┘ └─────┘ └─────┘ └────────┘ └────────┘  │
│                                                          │
│  ┌──────────────────────────────────────────────────┐   │
│  │  NGUỒN: DC-DC LM2596 + Adapter 12V               │   │
│  │  [DC-DC] ── 5V ──→ ESP32                         │   │
│  │         ── 12V ──→ Relay COM                     │   │
│  └──────────────────────────────────────────────────┘   │
│                                                          │
└──────────────────────────────────────────────────────────┘
```

## 4. CẤU HÌNH FIRMWARE

### Bước 10: Sửa file config.h

Mở `esp32_firmware_arduino/config.h`, **bắt buộc sửa**:

```c
#define WIFI_SSID              "ten_wifi_nha_anh"     // ← Sửa
#define WIFI_PASSWORD          "mat_khau_wifi"         // ← Sửa
#define SERVER_URL             "http://192.168.1.x:8080/api/v1/sensor-data" // ← Sửa IP
#define DEVICE_ID              "ESP32_NHA_MO_HINH"
```

**Cách tìm IP máy tính (chạy backend):**
```bash
# Mở CMD, gõ:
ipconfig
# Tìm dòng IPv4 Address của WiFi (VD: 192.168.1.5)
```

### Bước 11: Cài Arduino IDE + ESP32 board

1. Mở Arduino IDE → **File** → **Preferences**
2. Thêm URL vào "Additional Boards Manager URLs":
   ```
   https://espressif.github.io/arduino-esp32/package_esp32_index.json
   ```
3. **Tools** → **Board** → **Boards Manager** → tìm "ESP32" → Install
4. Chọn board: **ESP32 Dev Module**

### Bước 12: Nạp firmware

1. Cắm ESP32 qua USB
2. **Tools** → **Port** → chọn COM (VD: COM3)
3. Nhấn **Upload** (→)
4. Nếu lỗi "Failed to connect", giữ nút **BOOT** trên ESP32, nhấn **EN**, thả BOOT → Upload lại
5. Mở **Serial Monitor** (Tools → Serial Monitor) → **115200 baud**

## 5. KHỞI ĐỘNG HỆ THỐNG

### Bước 13: Khởi động MySQL

```bash
# Mở CMD với quyền Admin
"C:\Program Files\MySQL\MySQL Server 8.4\bin\mysqld" --datadir="C:\ProgramData\MySQL\MySQL Server 8.4\Data"
```

### Bước 14: Khởi động Backend

```bash
cd D:\DATNcanhbaodien\backend_springboot
mvn spring-boot:run
```

### Bước 15: Khởi động Dashboard

```bash
cd D:\DATNcanhbaodien\frontend_dashboard
node server.js
```

### Bước 16: Mở trình duyệt

Vào: `http://localhost:3000`

## 6. KIỂM TRA & DEMO

### Kịch bản 1: Bình thường
- ESP32 kết nối WiFi → Serial hiện "WiFi OK! IP: xxx"
- Backend nhận data 3 giây/lần
- Dashboard: hiển thị dòng rò ~0 mA, LED xanh, "BÌNH THƯỜNG"

### Kịch bản 2: Giả lập rò rỉ
- Xoay biến trở (Pot) để đặt mức rò
- Nhấn nút **RÒ RỈ** trên breadboard
- Quan sát:
  - LED đỏ nhấp nháy
  - Buzzer kêu beep beep
  - Relay ngắt → LED trắng + motor tắt
  - Dashboard: popup đỏ + âm thanh + "Đã ngắt tải"

### Kịch bản 3: Reset
- Nhấn nút **RESET**
- Relay đóng → LED trắng sáng lại
- Dashboard về trạng thái bình thường

## 7. XỬ LÝ LỖI THƯỜNG GẶP

| Lỗi | Nguyên nhân | Cách xử lý |
|------|------------|-------------|
| "Failed to connect" khi upload | ESP32 ở chế độ download | Giữ BOOT + nhấn EN |
| Serial ra ký tự lạ | Baud rate sai | Set Serial Monitor 115200 |
| WiFi không kết nối | Sai SSID/password | Kiểm tra config.h |
| Server trả lỗi | MySQL chưa chạy | Chạy mysqld trước |
| ZCT đọc 0 mA | Chưa luồn dây qua lõi | Luồn 2 dây L+N qua lỗ ZCT |
| LED quá mờ | Thiếu điện trở 220Ω | Kiểm tra lại mạch LED |
| Dashboard không load | Node server chưa chạy | `node server.js` |
