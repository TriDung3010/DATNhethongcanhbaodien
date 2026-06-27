# QUY TRÌNH HOẠT ĐỘNG HỆ THỐNG CẢNH BÁO RÒ RỈ ĐIỆN NĂNG

---

## Mục lục

1. [Tổng quan kiến trúc hệ thống](#1-tổng-quan-kiến-trúc-hệ-thống)
2. [Quy trình Thu thập và Xử lý tại biên (Edge Processing)](#2-quy-trình-thu-thập-và-xử-lý-tại-biên-edge-processing)
3. [Quy trình Truyền tải dữ liệu (Data Transmission)](#3-quy-trình-truyền-tải-dữ-liệu-data-transmission)
4. [Quy trình Xử lý tại WinForms Dashboard](#4-quy-trình-xử-lý-tại-winforms-dashboard)
5. [Sơ đồ luồng dữ liệu tổng thể](#5-sơ-đồ-luồng-dữ-liệu-tổng-thể)

---

## 1. Tổng quan kiến trúc hệ thống

Hệ thống **Cảnh báo rò rỉ điện năng** được thiết kế theo mô hình **kiến trúc hai lớp (Two-Tier Architecture)** gọn nhẹ, phù hợp với mô hình demo đồ án:

| **Tầng** | **Thành phần** | **Công nghệ** |
|---|---|---|
| **Tầng Thiết bị (Device Layer)** | Cảm biến ZCT, Biến trở, ESP32, Relay, Buzzer, OLED | ESP32 (Arduino framework) |
| **Tầng Giao diện PC (Presentation Layer)** | Dashboard Windows Forms thời gian thực | C# .NET 9 WinForms + LiveCharts2 |

> **Nguyên lý hoạt động tổng quát:** Cảm biến ZCT (hoặc biến trở giả lập) đo dòng rò. Nếu vượt ngưỡng 30mA, ESP32 thực hiện **cảnh báo tại chỗ (Edge Alert)** ngay lập tức (ngắt Relay, bật Buzzer, LED đỏ, OLED cảnh báo) và đồng thời **gửi dữ liệu lên WinForms** qua HTTP POST mỗi 3 giây để hiển thị biểu đồ và lịch sử trên máy tính.

---

## 2. Quy trình Thu thập và Xử lý tại biên (Edge Processing)

### 2.1. Nguyên lý đo dòng rò

Cảm biến **ZCT (Zero-phase Current Transformer)** được đặt bao quanh đồng thời cả hai dây **Pha (L)** và **Trung tính (N)**. Trong điều kiện hoạt động bình thường:

- Dòng điện trên dây pha (I_L) và dây trung tính (I_N) có độ lớn xấp xỉ bằng nhau và ngược chiều.
- Từ thông tổng trong lõi ZCT xấp xỉ bằng **0** → Điện áp đầu ra của ZCT ≈ **0V**.

Khi xảy ra rò rỉ điện:

- Xuất hiện dòng rò I_Δ = I_L - I_N ≠ 0.
- Từ thông tổng trong lõi ZCT khác 0 → ZCT tạo ra điện áp xoay chiều tỷ lệ với I_Δ.

**Chế độ giả lập (Demo):** Biến trở 10kΩ kết nối vào GPIO35 (ADC) để giả lập mức dòng rò từ 0–100mA bằng cách xoay núm vặn.

### 2.2. Xử lý tín hiệu Analog trên ESP32

| **Bước** | **Mô tả** | **Chi tiết kỹ thuật** |
|---|---|---|
| **B1** | Đọc tín hiệu Analog | ESP32 đọc ADC 12-bit (0–4095) từ GPIO34 (ZCT) hoặc GPIO35 (biến trở) |
| **B2** | Chuyển đổi sang mA | `simulatedMA = (adcValue / 4095.0) * 100.0` (biến trở) hoặc tính theo peak-to-peak ZCT |
| **B3** | So sánh ngưỡng | So sánh với ngưỡng **30mA** (LEAKAGE_THRESHOLD_MA) |

### 2.3. Logic cảnh báo tại chỗ (Edge Alert)

Khi **I_Δ ≥ 30mA**, ESP32 thực thi **ngay lập tức** mà **không chờ WinForms**:

```
                     ┌─────────────────────────┐
                     │   IΔ >= 30mA?            │
                     │   (So sánh ngưỡng)       │
                     └──────────┬──────────────-┘
                          YES   │         NO
                   ┌────────────┘         └───────────────┐
                   ▼                                       ▼
        ┌──────────────────────┐              ┌──────────────────────┐
        │  CẢNH BÁO RÒ RỈ     │              │  BÌNH THƯỜNG         │
        │  - Relay HIGH (ngắt) │              │  - Relay LOW (đóng)  │
        │  - Buzzer bíp kép    │              │  - Buzzer tắt        │
        │  - LED đỏ ON         │              │  - LED xanh ON       │
        │  - LED thiết bị OFF  │              │  - LED thiết bị ON   │
        │  - OLED "NGUY HIEM!" │              │  - OLED "AN TOAN"    │
        └──────────────────────┘              └──────────────────────┘
```

### 2.4. Chế độ mô phỏng (Simulate Mode)

| Trạng thái | Cách kích hoạt | Nguồn đọc |
|---|---|---|
| **Simulate ON** | Nhấn nút RÒ RỈ (GPIO13) | Biến trở GPIO35 |
| **Simulate OFF** | Nhấn nút RESET (GPIO19) | ZCT GPIO34 |

Mặc định khi khởi động: **Simulate ON** (đọc biến trở).

---

## 3. Quy trình Truyền tải dữ liệu (Data Transmission)

### 3.1. Kết nối WiFi

ESP32 kết nối WiFi theo thông tin trong `config.h`:
```cpp
#define WIFI_SSID     "Dung Gau"
#define WIFI_PASSWORD "Dung3010@"
#define SERVER_URL    "http://192.168.1.9:8080/api/v1/sensor-data"
```

- Hàm `ensureWiFi()` tự động reconnect mỗi 10 giây nếu mất kết nối.
- Nếu không có WiFi, ESP32 vẫn hoạt động Edge Alert bình thường (offline).

### 3.2. Gửi dữ liệu HTTP POST

Mỗi **3 giây**, ESP32 gửi một POST request tới WinForms:

```
POST http://192.168.1.9:8080/api/v1/sensor-data
Content-Type: application/json

{
  "deviceId": "ESP32_NHA_MO_HINH",
  "leakageCurrent": 45.2,
  "unit": "mA",
  "alert": true,
  "relayState": false,
  "timestamp": "639451"
}
```

> **Lưu ý kỹ thuật:** `timestamp` là giá trị `millis()` của ESP32 dạng string (không phải DateTime). WinForms tự gán thời gian nhận thực tế (`DateTime.Now`) vào trường riêng khi nhận được packet.

### 3.3. Sơ đồ kết nối mạng

```
WiFi Router "Dung Gau"
      │
      ├── ESP32  (IP: 192.168.1.25) ──POST 3s──▶ PC (IP: 192.168.1.9):8080
      └── PC     (IP: 192.168.1.9)  ──HttpListener lắng nghe──▶ WinForms
```

---

## 4. Quy trình Xử lý tại WinForms Dashboard

### 4.1. Khởi động ứng dụng

```
Form1_Load()
    └── StartHttpServer()
            ├── Khởi tạo HttpListener prefix: http://+:8080/
            ├── listener.Start()
            ├── Tạo background thread: ListenLoop()
            └── lblLog: "✅ Server lắng nghe port 8080..."
```

> **Yêu cầu:** WinForms phải được chạy với quyền **Administrator** để HttpListener có thể mở port 8080.

### 4.2. Nhận và xử lý dữ liệu

```
ListenLoop() [Background Thread]
    └── Chờ HTTP request từ ESP32
            └── POST nhận được
                    ├── Đọc body JSON
                    ├── Deserialize → SensorData object
                    ├── Gán Timestamp = DateTime.Now
                    └── Invoke UI thread → ProcessIncomingData()

ProcessIncomingData() [UI Thread]
    ├── Thêm vào _historyList (max 50 records)
    ├── Thêm LeakageCurrent vào _chartValues (max 50 points)
    ├── Cập nhật lblCurrent: "Dòng rò: XX.XX mA"
    ├── Cập nhật lblLog: "📦 Gói tin nhận: N | Lần cuối: HH:mm:ss"
    └── Kiểm tra alert:
            ├── alert=true → Nền đỏ + lblStatus "CẢNH BÁO!" + âm thanh
            └── alert=false → Nền bình thường + lblStatus "BÌNH THƯỜNG"
```

### 4.3. Hiển thị dữ liệu

| Thành phần | Dữ liệu hiển thị |
|---|---|
| `lblStatus` | BÌNH THƯỜNG (xanh) / CẢNH BÁO RÒ RỈ! (đỏ đậm) |
| `lblCurrent` | Dòng rò tức thời (mA), cập nhật mỗi 3s |
| `lblLog` | Số gói nhận được + thời gian nhận cuối |
| `chartView` | Biểu đồ đường LiveCharts2, tối đa 50 điểm gần nhất |
| `dgvHistory` | Bảng lịch sử: DeviceId, LeakageCurrent, Alert, RelayState, Timestamp |
| Nền Form | Trắng/xám (bình thường) hoặc đỏ nhạt (cảnh báo) |

### 4.4. Packages sử dụng

| Package | Version | Mục đích |
|---|---|---|
| LiveChartsCore.SkiaSharpView.WinForms | 2.0.5 | Biểu đồ realtime |
| Newtonsoft.Json | 13.0.4 | Deserialize JSON từ ESP32 |
| RestSharp | 114.0.0 | HTTP client (dự phòng) |
| Websocket.Client | 5.5.0 | WebSocket client (dự phòng) |

---

## 5. Sơ đồ luồng dữ liệu tổng thể

```
┌─────────────────────────────────────────────────────────────────────────┐
│                         MÔ HÌNH NHÀ (Phần cứng)                        │
│                                                                         │
│  [ZCT hoặc Biến trở]                                                    │
│         ↓ ADC 12-bit                                                    │
│  [ESP32 38 chân]                                                        │
│    ├── processAlert() → Relay (G26) → Mô-tơ Quạt ON/OFF               │
│    ├── processAlert() → Buzzer (G27) → Bíp kép khi alert               │
│    ├── controlApplianceLEDs() → LED nhà (G32, G14) ON/OFF              │
│    ├── LED trạng thái → G25 (xanh=OK) / G33 (đỏ=Alert)                │
│    └── updateOLED() → Màn hình OLED I2C hiển thị mA + trạng thái      │
│                                                                         │
└─────────────────────────┬───────────────────────────────────────────────┘
                          │ HTTP POST /api/v1/sensor-data (mỗi 3 giây)
                          │ WiFi "Dung Gau" → 192.168.1.9:8080
                          ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                    WINFORMS DASHBOARD (Máy tính PC)                     │
│                                                                         │
│  HttpListener (port 8080)                                               │
│         ↓ Nhận JSON                                                     │
│  ProcessIncomingData()                                                  │
│    ├── Chart realtime (LiveCharts2) - đường dòng rò 50 điểm            │
│    ├── Nhãn dòng rò hiện tại (mA)                                       │
│    ├── Bảng lịch sử 50 bản ghi (RAM, không lưu DB)                     │
│    ├── Nhãn log (số packet + thời gian)                                 │
│    └── Cảnh báo: đổi màu nền + âm thanh hệ thống                       │
│                                                                         │
└─────────────────────────────────────────────────────────────────────────┘
```

---

## 6. Quy trình Khởi động hệ thống

| Bước | Hành động | Kết quả kỳ vọng |
|---|---|---|
| **1** | Bật nguồn mạch ESP32 (qua LM2596 → chân V5) | OLED hiện "Dang khoi dong..." |
| **2** | ESP32 kết nối WiFi "Dung Gau" | OLED hiện "AN TOAN", LED xanh sáng |
| **3** | Trên PC: Chuột phải `WinformsDashboard.exe` → Run as Administrator | Form mở, lblLog: "✅ Server lắng nghe port 8080" |
| **4** | Quan sát WinForms | Sau ~3s, bắt đầu nhận packet từ ESP32 |
| **5** | Xoay biến trở về phía rò rỉ (≥ 30mA) | Relay ngắt, Buzzer kêu, nền WinForms đỏ |
| **6** | Nhấn nút RESET trên mạch | Relay đóng lại, WinForms về BÌNH THƯỜNG |
