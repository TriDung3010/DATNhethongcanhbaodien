# AGENTS.md - Hệ thống Cảnh báo Rò rỉ Điện năng

## Tổng quan
Đồ án tốt nghiệp: Hệ thống IoT phát hiện và cảnh báo rò rỉ điện năng.
ESP32 đọc dòng rò (ZCT) → nếu vượt 30mA → ngắt relay + báo buzzer + gửi JSON lên Spring Boot → push WebSocket → Dashboard real-time.

## Cấu trúc thư mục

```
D:\DATNcanhbaodien\
├── AGENTS.md                          # File này
├── start.bat                          # Khởi động MySQL + Backend + Frontend
├── esp32_firmware_arduino/            # Firmware ESP32 (Arduino IDE)
│   ├── esp32_firmware_arduino.ino     # Code chính
│   └── config.h                       # WiFi, Server URL, GPIO, ngưỡng
├── backend_springboot/                # Spring Boot 3.3.5 (Java 17, Maven)
│   ├── pom.xml
│   ├── src/main/java/com/datn/canhbaodien/
│   │   ├── CanhBaoDienApplication.java
│   │   ├── config/WebConfig.java         # CORS (*)
│   │   ├── config/WebSocketConfig.java   # STOMP over SockJS (/ws)
│   │   ├── controller/SensorDataController.java  # POST + GET
│   │   ├── dto/SensorDataDTO.java
│   │   ├── dto/AlertEventDTO.java
│   │   ├── model/SensorData.java          # JPA entity
│   │   ├── model/AlertHistory.java        # JPA entity
│   │   ├── repository/SensorDataRepository.java
│   │   ├── repository/AlertHistoryRepository.java
│   │   └── service/SensorDataService.java  # Logic + WebSocket push
│   └── src/main/resources/application.yml
├── frontend_dashboard/               # Dashboard Web (Node.js server)
│   ├── server.js                     # Static file server (port 3000)
│   ├── index.html                    # Chart.js + SockJS + STOMP
│   ├── css/dashboard.css
│   └── js/dashboard.js               # WebSocket client + biểu đồ
└── workflow/                          # Tài liệu báo cáo
    ├── quy_trinh_he_thong_canh_bao.md
    ├── thiet_ke_mo_hinh_nha.md
    ├── danh_sach_linh_kien.docx
    ├── huong_dan_lap_rap.md
    └── plantuml_diagrams.md
    └── workflow_diagrams.puml
```

## GPIO ESP32

| GPIO | Kết nối | Ghi chú |
|------|---------|---------|
| 34 | ZCT (cảm biến dòng) | ADC - đọc dòng rò thật |
| 35 | Biến trở 10kΩ | ADC - giả lập mức rò 0-100mA |
| 26 | Relay | Ngắt tải khi rò rỉ |
| 27 | Buzzer (KY-012 active) | Còi báo (HIGH = kêu) |
| 32 | LED trắng #1 | Đèn phòng khách |
| 14 | LED trắng #2 | Đèn bếp |
| 12 | LED trắng #3 | Quạt (hoặc motor nhỏ) |
| 25 | LED xanh | Trạng thái BÌNH THƯỜNG |
| 33 | LED đỏ | Trạng thái RÒ RỈ |
| 13 | Nút nhấn RÒ RỈ | INPUT_PULLUP, toggle simulate |
| 19 | Nút nhấn RESET | INPUT_PULLUP, tắt simulate |
| 2 | LED (trên board) | Nhấp nháy khi alert |

## API Backend

| Method | Endpoint | Mô tả |
|--------|----------|-------|
| POST | `/api/v1/sensor-data` | ESP32 gửi JSON `{deviceId, leakageCurrent, alert, relayState}` |
| GET | `/api/v1/sensor-data/latest` | Lấy 20 bản ghi gần nhất |
| GET | `/api/v1/alerts` | Lấy 20 alert lịch sử gần nhất |
| WS | `/ws` (STOMP) | Subscribe `/topic/alert` |

## Database (MySQL 8.4)

- Database: `datn_canh_bao_dien`
- User: `datn_user` / `Datn@2026`
- Bảng: `sensor_data` (id, device_id, leakage_current, unit, alert, relay_state, timestamp, created_at)
- Bảng: `alert_history` (id, device_id, leakage_current, alert_type, description, resolved, timestamp, created_at)

## Cách chạy

```bash
# 1. MySQL
"C:\Program Files\MySQL\MySQL Server 8.4\bin\mysqld" --datadir="C:\ProgramData\MySQL\MySQL Server 8.4\Data"

# 2. Backend (port 8080)
cd D:\DATNcanhbaodien\backend_springboot
mvn spring-boot:run

# 3. Frontend (port 3000)
cd D:\DATNcanhbaodien\frontend_dashboard
node server.js

# 4. Browser
http://localhost:3000
```

Hoặc chạy `start.bat` để làm hết 1 lần.

## Firmware Logic (Edge Alert)

1. Loop 200ms:
   - `readButtons()` — nút RÒ RỈ toggle simulate, nút RESET clear
   - `readLeakageCurrent()` — nếu simulate thì đọc biến trở, nếu không thì đọc ZCT
   - `processAlert()` — nếu >= 30mA: ngắt relay, tắt LED, bật alert. Nếu < 30mA: đóng relay, bật LED
   - `controlBuzzer()` — nhấp nháy 300ms khi alert
   - `sendDataToServer()` — HTTP POST 3 giây/lần
   - `ensureWiFi()` — tự động reconnect nếu mất WiFi

## Luồng dữ liệu

```
ZCT/Pot → ESP32 đọc ADC → processAlert (local) → HTTP POST → Spring Boot REST API
                                                              ├── Lưu MySQL
                                                              └── Push STOMP /topic/alert
                                                                       └── Dashboard (Chart.js)
```

## Lưu ý khi sửa code

- Backend: Dùng đúng package `com.datn.canhbaodien`, tuân thủ REST convention
- Frontend: CDN Chart.js 4.x, SockJS 1.x, STOMP 2.x
- ESP32: Dùng `analogRead()` với độ phân giải 12 bit, không dùng ArduinoJson (build JSON thủ công bằng String)
- Ngưỡng rò rỉ: 30mA (hằng số `LEAKAGE_THRESHOLD_MA` trong config.h)
