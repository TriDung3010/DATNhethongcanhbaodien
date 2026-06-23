# QUY TRÌNH HOẠT ĐỘNG HỆ THỐNG CẢNH BÁO RÒ RỈ ĐIỆN NĂNG

---

## Mục lục

1. [Tổng quan kiến trúc hệ thống](#1-tổng-quan-kiến-trúc-hệ-thống)
2. [Quy trình Thu thập và Xử lý tại biên (Edge Processing)](#2-quy-trình-thu-thập-và-xử-lý-tại-biên-edge-processing)
3. [Quy trình Truyền tải dữ liệu (Data Transmission)](#3-quy-trình-truyền-tải-dữ-liệu-data-transmission)
4. [Quy trình Xử lý tại Máy chủ (Backend Processing)](#4-quy-trình-xử-lý-tại-máy-chủ-backend-processing)
5. [Quy trình Cập nhật Giao diện Thời gian thực (Real-time Dashboard)](#5-quy-trình-cập-nhật-giao-diện-thời-gian-thực-real-time-dashboard)
6. [Sơ đồ luồng dữ liệu tổng thể](#6-sơ-đồ-luồng-dữ-liệu-tổng-thể)

---

## 1. Tổng quan kiến trúc hệ thống

Hệ thống **Cảnh báo rò rỉ điện năng** được thiết kế theo mô hình **kiến trúc ba lớp (Three-Tier Architecture)** bao gồm:

| **Tầng** | **Thành phần** | **Công nghệ** |
|---|---|---|
| **Tầng Thiết bị (Device Layer)** | Cảm biến ZCT, ESP32, Module Relay, Buzzer | ESP32 (Arduino framework / ESP-IDF) |
| **Tầng Máy chủ (Server Layer)** | RESTful API, WebSocket Server, Database | Java Spring Boot, MySQL |
| **Tầng Giao diện (Presentation Layer)** | Dashboard Web thời gian thực | HTML / CSS / JavaScript (hoặc React / Vue) |

> **Nguyên lý hoạt động tổng quát:** Cảm biến ZCT đo chênh lệch dòng điện giữa dây pha (L) và dây trung tính (N). Nếu chênh lệch vượt ngưỡng an toàn, hệ thống thực hiện **cảnh báo tại chỗ (Edge Alert)** và đồng thời **truyền dữ liệu lên máy chủ** để cập nhật giao diện giám sát từ xa.

---

## 2. Quy trình Thu thập và Xử lý tại biên (Edge Processing)

### 2.1. Nguyên lý đo dòng rò

Cảm biến **ZCT (Zero-phase Current Transformer)** được đặt bao quanh đồng thời cả hai dây **Pha (L)** và **Trung tính (N)**. Trong điều kiện hoạt động bình thường:

-   Dòng điện trên dây pha (\(I_L\)) và dây trung tính (\(I_N\)) có độ lớn xấp xỉ bằng nhau và ngược chiều.
-   Từ thông tổng trong lõi ZCT xấp xỉ bằng **0** → Điện áp đầu ra của ZCT ≈ **0V**.

Khi xảy ra rò rỉ điện (dòng điện thoát xuống đất qua vỏ thiết bị hoặc môi trường):

-   Xuất hiện dòng rò \(I_{\Delta} = I_L - I_N \neq 0\).
-   Từ thông tổng trong lõi ZCT khác 0 → ZCT tạo ra điện áp xoay chiều tỷ lệ với \(I_{\Delta}\).

### 2.2. Xử lý tín hiệu Analog trên ESP32

| **Bước** | **Mô tả** | **Chi tiết kỹ thuật** |
|---|---|---|
| **B1** | Đọc tín hiệu Analog | ESP32 đọc điện áp đầu ra ZCT qua chân ADC (Analog-to-Digital Converter) với độ phân giải **12-bit (0–4095)**. |
| **B2** | Lọc nhiễu (Noise Filtering) | Sử dụng bộ lọc trung bình trượt (Moving Average Filter) hoặc bộ lọc Kalman đơn giản để loại bỏ nhiễu tần số cao. |
| **B3** | Chuyển đổi sang giá trị dòng điện (mA) | Áp dụng công thức hiệu chuẩn (Calibration Formula) để chuyển giá trị ADC thô thành dòng điện rò thực tế: \(I_{\Delta}(mA) = \frac{V_{ADC}}{Hệ\;số\;nhạy\;của\;ZCT}\) |
| **B4** | So sánh ngưỡng | So sánh \(I_{\Delta}\) với ngưỡng an toàn **\(I_{threshold} = 30mA\)** (theo tiêu chuẩn IEC 60755). |

### 2.3. Logic cảnh báo tại chỗ (Edge Alert)

Khi **\(I_{\Delta} \ge I_{threshold}\)**, ESP32 thực thi **ngay lập tức** mà **không chờ Server**:

```
                     ┌─────────────────────────┐
                     │   IΔ >= 30mA?            │
                     │   (So sánh ngưỡng)       │
                     └──────┬──────────┬────────┘
                            │ CÓ       │ KHÔNG
                            ▼          ▼
            ┌───────────────────┐    (Tiếp tục giám sát)
            │ Bật Buzzer        │
            │ (Báo động âm      │
            │  thanh tại chỗ)   │
            └────────┬──────────┘
                     ▼
            ┌───────────────────┐
            │ Ngắt tải qua      │
            │ Module Relay      │
            │ (Ngắt điện đầu ra)│
            └────────┬──────────┘
                     ▼
            ┌───────────────────┐
            │ Ghi trạng thái     │
            │ Alert = true       │
            │ vào bộ nhớ        │
            └───────────────────┘
```

> **Ưu điểm của xử lý tại biên:** Đảm bảo an toàn tức thời (real-time safety) với độ trễ chỉ ở mức **miligiây**, không phụ thuộc vào kết nối mạng Wi-Fi hay tình trạng Server.

---

## 3. Quy trình Truyền tải dữ liệu (Data Transmission)

### 3.1. Cấu trúc gói dữ liệu JSON

Sau khi hoàn tất xử lý tại biên, ESP32 đóng gói dữ liệu thành chuỗi JSON với định dạng sau:

```json
{
    "deviceId": "ESP32_001",
    "leakageCurrent": 45.2,
    "unit": "mA",
    "alert": true,
    "relayState": false,
    "timestamp": "2026-06-19T14:30:00.000+07:00"
}
```

| **Trường** | **Kiểu dữ liệu** | **Mô tả** |
|---|---|---|
| `deviceId` | String | Mã định danh duy nhất của thiết bị ESP32 |
| `leakageCurrent` | Float | Giá trị dòng rò hiện tại (mA) |
| `unit` | String | Đơn vị đo (mA) |
| `alert` | Boolean | `true` nếu vượt ngưỡng, `false` nếu bình thường |
| `relayState` | Boolean | `true` nếu relay đang đóng (có điện), `false` nếu đã ngắt |
| `timestamp` | String | Thời gian ghi nhận theo chuẩn ISO 8601 |

### 3.2. Giao thức truyền tải

Hệ thống hỗ trợ hai giao thức truyền tải:

#### a. RESTful API (HTTP POST)

-   **Endpoint:** `POST /api/v1/sensor-data`
-   **Content-Type:** `application/json`
-   **Tần suất gửi:** Mỗi **1–5 giây** (cấu hình được) hoặc gửi ngay khi có cảnh báo.
-   **Cơ chế:** ESP32 gửi HTTP Request → Backend trả về HTTP Response (ACK).

```
 ESP32                      Backend (Spring Boot)
   │                              │
   │── HTTP POST /api/v1/sensor-data ──►│
   │   (Body: JSON payload)             │
   │                              │
   │◄── HTTP 200 OK (ACK) ────────│
   │   (Response: { status: "ok" })     │
```

#### b. MQTT (Message Queue Telemetry Transport)

-   **Topic:** `datn/device/{deviceId}/sensor-data`
-   **QoS:** 1 (At least once) — đảm bảo dữ liệu không bị mất.
-   **Broker:** Có thể tích hợp MQTT Broker (Mosquitto) hoặc dùng Spring Boot MQTT Gateway.

```
 ESP32                 MQTT Broker           Backend (Subscriber)
   │                        │                        │
   │── PUBLISH ────────────►│                        │
   │   Topic: datn/...      │                        │
   │   QoS: 1               │── FORWARD ────────────►│
   │                        │   (Message queue)      │
```

> **Khuyến nghị:** Sử dụng RESTful API cho giai đoạn phát triển ban đầu (đơn giản, dễ debug). Nâng cấp lên MQTT khi hệ thống mở rộng với nhiều thiết bị (scalability).

---

## 4. Quy trình Xử lý tại Máy chủ (Backend Processing)

### 4.1. Kiến trúc Backend (Java Spring Boot)

```
                    ┌─────────────────────────────────────┐
                    │         SPRING BOOT SERVER          │
                    │                                     │
    ┌───────────┐   │  ┌──────────┐  ┌────────────────┐  │
    │           │   │  │ REST     │  │ WebSocket       │  │
    │  ESP32    │───┼──│ Controller│  │ MessageHandler │  │
    │           │   │  │ (API)    │  │                │  │
    └───────────┘   │  └─────┬────┘  └───────┬────────┘  │
                    │        │               │           │
                    │  ┌─────▼────┐          │           │
                    │  │ Service  │          │           │
                    │  │   Layer  │──────────┘           │
                    │  └─────┬────┘                      │
                    │        │                          │
                    │  ┌─────▼────┐                     │
                    │  │  JPA     │  ┌──────────────┐   │
                    │  │ Repository│  │   MySQL DB   │   │
                    │  │ (DAO)   │──►│ (Lưu trữ)    │   │
                    │  └──────────┘  └──────────────┘   │
                    └─────────────────────────────────────┘
```

### 4.2. Quy trình xử lý chi tiết

| **Bước** | **Xử lý tại Backend** |
|---|---|
| **B1** | **Tiếp nhận dữ liệu:** `RestController` nhận HTTP POST hoặc MQTT Message, giải mã JSON thành đối tượng `SensorDataDTO`. |
| **B2** | **Xác thực (Validation):** Kiểm tra tính hợp lệ của dữ liệu (`deviceId` không rỗng, `leakageCurrent` không âm, `timestamp` hợp lệ). |
| **B3** | **Lưu trữ (Persistence):** `SensorDataService` gọi `JpaRepository` để lưu bản ghi vào bảng `sensor_data` trong MySQL. |
| **B4** | **Kiểm tra trạng thái cảnh báo:** Kiểm tra trường `alert` trong JSON: |
|       | - Nếu **`alert = true`** → Chuyển sang **B5**. |
|       | - Nếu **`alert = false`** → Kết thúc quy trình xử lý (chỉ lưu dữ liệu). |
| **B5** | **Đẩy sự kiện WebSocket:** `WebSocketHandler` gửi message JSON đến tất cả các client đang kết nối đến topic `/topic/alert`. |
| **B6** | **Ghi log sự kiện:** Ghi log cảnh báo vào bảng `alert_history` để phục vụ báo cáo sau này. |

### 4.3. Lược đồ WebSocket Push

```
 Backend Spring Boot                       Frontend Browser
        │                                       │
        │  ─── WebSocket handshake ────────────►│
        │       (HTTP Upgrade)                   │
        │                                       │
        │  ◄── Client subscribed ───────────────│
        │       Topic: /topic/alert              │
        │                                       │
        │  (Khi alert = true)                    │
        │  ─── SEND /topic/alert ──────────────►│
        │      JSON: {                           │
        │        "deviceId": "ESP32_001",        │
        │        "leakageCurrent": 45.2,         │
        │        "severity": "CRITICAL",         │
        │        "message": "Rò rỉ điện!"        │
        │      }                                 │
        │                                       │
```

> **Công nghệ sử dụng:** Spring WebSocket (STOMP over WebSocket) hoặc Socket.IO tùy theo lựa chọn kiến trúc Frontend.

---

## 5. Quy trình Cập nhật Giao diện Thời gian thực (Real-time Dashboard)

### 5.1. Luồng xử lý phía Frontend

```
                  ┌──────────────────────────────────┐
                  │        WEB BROWSER               │
                  │    (Frontend Dashboard)           │
                  │                                  │
                  │  ┌────────────────────────────┐  │
                  │  │ WebSocket Client           │  │
                  │  │ (STOMP / Socket.IO)        │  │
                  │  └─────┬──────────────────────┘  │
                  │        │                         │
                  │        │ Nhận event /topic/alert │
                  │        ▼                         │
                  │  ┌────────────────────────────┐  │
                  │  │ Event Handler              │  │
                  │  │ - Parse JSON               │  │
                  │  │ - Xác định mức độ nghiêm   │  │
                  │  │   trọng (Critical/Warning) │  │
                  │  └─────┬──────────────────────┘  │
                  │        │                         │
                  │        ├─────────────────────┐   │
                  │        ▼                     ▼   │
                  │  ┌──────────┐    ┌────────────┐  │
                  │  │ UI Alert │    │ Charts     │  │
                  │  │ - Popup  │    │ - Cập nhật │  │
                  │  │ - Đèn đỏ │    │   biểu đồ   │  │
                  │  │   nhấp   │    │   line chart│  │
                  │  │   nháy   │    │ - Thêm điểm │  │
                  │  │ - Âm     │    │   dữ liệu   │  │
                  │  │   thanh  │    │   mới       │  │
                  │  └──────────┘    └────────────┘  │
                  └──────────────────────────────────┘
```

### 5.2. Các hành động khi nhận cảnh báo

Khi Frontend nhận được sự kiện cảnh báo từ WebSocket, hệ thống thực hiện **đồng thời** các hành động sau:

| **STT** | **Hành động** | **Mô tả chi tiết** | **Cơ chế thực thi** |
|---|---|---|---|
| **1** | **Đổi màu giao diện** | Chuyển nền Dashboard từ màu xanh (bình thường) sang **đỏ chớp nháy** (blink animation) để thu hút sự chú ý. | CSS Animation (`@keyframes blink`) + JavaScript class toggle. |
| **2** | **Hiển thị Popup cảnh báo** | Popup modal hiển thị thông tin: Thiết bị, giá trị dòng rò, thời gian, mức độ nguy hiểm. | JavaScript DOM manipulation hoặc Component State (React/Vue). |
| **3** | **Phát âm thanh Alert** | Trình duyệt phát file âm thanh `alert.mp3` hoặc `beep.wav` để cảnh báo người vận hành từ xa. | Web Audio API hoặc thẻ `<audio>` với `play()`. |
| **4** | **Cập nhật biểu đồ thời gian thực** | Thêm điểm dữ liệu mới vào biểu đồ Line Chart (giá trị dòng rò theo thời gian), làm nổi bật vùng vượt ngưỡng (threshold zone). | Thư viện Chart.js / ECharts / D3.js kết hợp với cập nhật dữ liệu động. |
| **5** | **Cập nhật bảng sự kiện** | Thêm một dòng mới vào bảng "Lịch sử cảnh báo" (Alert History Table) hiển thị gần đây nhất ở đầu bảng. | JavaScript array shift/unshift + re-render. |
| **6** | **Gửi thông báo trình duyệt** | Nếu được cấp quyền, gửi **Browser Notification** (Push Notification API) để cảnh báo ngay cả khi tab trình duyệt đang thu nhỏ. | `Notification API` (Web Notification). |

### 5.3. Giao diện tham chiếu (Wireframe ý tưởng)

```
 ┌──────────────────────────────────────────────────────────────┐
 │  ⚠️  CẢNH BÁO RÒ RỈ ĐIỆN  ⚠️          [Trạng thái: KHẨN CẤP] │
 │  ┌─────────────────────────────────────────────────────────┐ │
 │  │  [POPUP CẢNH BÁO]                                       │ │
 │  │  ┌───────────────────────────────────────────────────┐  │ │
 │  │  │ 🔴 RÒ RỈ ĐIỆN PHÁT HIỆN!                         │  │ │
 │  │  │ Thiết bị    : ESP32_001                           │  │ │
 │  │  │ Dòng rò     : 45.2 mA                             │  │ │
 │  │  │ Ngưỡng      : 30.0 mA                             │  │ │
 │  │  │ Thời gian   : 2026-06-19 14:30:00                 │  │ │
 │  │  │ Hành động   : Relay đã NGẮT                     │  │ │
 │  │  │ ┌──────────────────────────────────────────────┐  │ │
 │  │  │ │             [ XÁC NHẬN ]                     │  │ │
 │  │  │ └──────────────────────────────────────────────┘  │ │
 │  │  └───────────────────────────────────────────────────┘  │ │
 │  └─────────────────────────────────────────────────────────┘ │
 │                                                              │
 │  ┌─────────────────────┐  ┌────────────────────────────────┐ │
 │  │ BIỂU ĐỒ DÒNG ĐIỆN   │  │ THÔNG SỐ HIỆN TẠI             │ │
 │  │                     │  │ ┌──────────────────────────┐  │ │
 │  │  50mA ┤═══════╗    │  │ │ Dòng rò hiện tại         │  │ │
 │  │       ┤       ║    │  │ │        45.2 mA    🔴     │  │ │
 │  │  30mA ┤───────╫────│  │ └──────────────────────────┘  │ │
 │  │       ┤       ║    │  │ ┌──────────────────────────┐  │ │
 │  │   0mA ┤═══════╝    │  │ │ Trạng thái Relay         │  │ │
 │  │       └─────────────│  │ │        ĐÃ NGẮT          │  │ │
 │  │       Thời gian →   │  │ └──────────────────────────┘  │ │
 │  └─────────────────────┘  └────────────────────────────────┘ │
 │                                                              │
 │  ┌────────────────────────────────────────────────────────┐  │
 │  │ LỊCH SỬ CẢNH BÁO                                       │  │
 │  │ ┌────────┬──────────┬────────┬──────────────────────┐  │  │
 │  │ │ Thiết b│ Dòng rò  │Trạng   │ Thời gian            │  │  │
 │  │ ├────────┼──────────┼────────┼──────────────────────┤  │  │
 │  │ │ ESP32_1│ 45.2 mA │🔴Nguy  │ 2026-06-19 14:30:00  │  │  │
 │  │ │ ESP32_1│ 12.1 mA │🟢An toà│ 2026-06-19 14:29:55  │  │  │
 │  │ │ ESP32_1│ 10.8 mA │🟢An toà│ 2026-06-19 14:29:50  │  │  │
 │  │ └────────┴──────────┴────────┴──────────────────────┘  │  │
 │  └────────────────────────────────────────────────────────┘  │
 └──────────────────────────────────────────────────────────────┘
```

---

## 6. Sơ đồ luồng dữ liệu tổng thể

### 6.1. Sơ đồ luồng dữ liệu dạng ASCII

```
  ╔══════════════════════════════════════════════════════════════════╗
  ║              SƠ ĐỒ LUỒNG DỮ LIỆU TỔNG THỂ                      ║
  ║         (End-to-End Data Flow Diagram)                          ║
  ╚══════════════════════════════════════════════════════════════════╝

  ┌─────────────────────────────────────────────────────────────────┐
  │                    TẦNG THIẾT BỊ (EDGE)                        │
  │                                                                 │
  │  ┌────────┐    ┌────────┐    ┌─────────────┐    ┌──────────┐   │
  │  │ ZCT    │───►│ ADC    │───►│ Xử lý tín   │───►│ So sánh  │   │
  │  │ Cảm biến│    │ ESP32  │    │ hiệu (lọc,  │    │ ngưỡng   │   │
  │  │ dòng rò│    │ (đọc)  │    │ chuyển đổi)  │    │ 30mA?    │   │
  │  └────────┘    └────────┘    └─────────────┘    └────┬─────┘   │
  │                                                      │         │
  │                          ┌───────────────────────────┤         │
  │                          ▼                           ▼         │
  │                    ┌────────────┐            ┌──────────────┐   │
  │                    │ Bình thường│            │ Vượt ngưỡng  │   │
  │                    │ (Alert=Fa) │            │ (Alert=True) │   │
  │                    └──────┬─────┘            └──────┬───────┘   │
  │                           │                         │           │
  │                           │              ┌──────────▼────────┐  │
  │                           │              │ Bật Buzzer +      │  │
  │                           │              │ Ngắt Relay        │  │
  │                           │              │ (Cảnh báo tại chỗ)│  │
  │                           │              └──────────┬────────┘  │
  │                           │                         │           │
  └───────────────────────────┼─────────────────────────┼───────────┘
                              │                         │
                    ┌─────────▼─────────────────────────▼──────────┐
                    │        ĐÓNG GÓI JSON                         │
                    │  {deviceId, leakageCurrent, alert,           │
                    │   relayState, timestamp}                     │
                    └─────────┬────────────────────────────────────┘
                              │
                              │ Gửi qua Wi-Fi
                              ▼
  ┌─────────────────────────────────────────────────────────────────┐
  │                    TẦNG MÁY CHỦ (SERVER)                       │
  │                                                                 │
  │  ┌─────────────────────┐     ┌───────────────────────────────┐  │
  │  │ REST Controller      │     │ MQTT Subscriber               │  │
  │  │ (HTTP POST)          │     │ (nếu dùng MQTT)               │  │
  │  └──────────┬──────────┘     └──────────┬────────────────────┘  │
  │             │                           │                       │
  │             └──────────┬────────────────┘                       │
  │                        ▼                                        │
  │              ┌──────────────────┐                               │
  │              │ Service Layer    │                               │
  │              │ (Business Logic) │                               │
  │              └────────┬─────────┘                               │
  │                        │                                        │
  │            ┌───────────┼───────────────┐                        │
  │            ▼           ▼               ▼                        │
  │  ┌────────────┐ ┌────────────┐ ┌──────────────┐                │
  │  │ JPA        │ │ WebSocket  │ │ Logger       │                │
  │  │ Repository │ │ Push       │ │ (Ghi log     │                │
  │  │ (Lưu DB)   │ │ (/topic/   │ │  sự kiện)    │                │
  │  │            │ │  alert)    │ │              │                │
  │  └──────┬─────┘ └──────┬─────┘ └──────────────┘                │
  │         │              │                                        │
  │         ▼              │                                        │
  │  ┌──────────┐          │                                        │
  │  │ MySQL DB │          │                                        │
  │  └──────────┘          │                                        │
  └────────────────────────┼────────────────────────────────────────┘
                           │
                           │ WebSocket (STOMP)
                           ▼
  ┌─────────────────────────────────────────────────────────────────┐
  │                 TẦNG GIAO DIỆN (FRONTEND)                      │
  │                                                                 │
  │  ┌─────────────────────────────────────────────────────────┐    │
  │  │                  WEB BROWSER                            │    │
  │  │                                                         │    │
  │  │  ┌──────────────┐    ┌────────────────────────────┐     │    │
  │  │  │ WebSocket    │───►│ Event Handler              │     │    │
  │  │  │ Client       │    │ - Parse JSON               │     │    │
  │  │  │ (STOMP/Sock) │    │ - Phân luồng xử lý         │     │    │
  │  │  └──────────────┘    └──────┬─────────────────────┘     │    │
  │  │                             │                            │    │
  │  │         ┌───────────────────┼────────────────────┐       │    │
  │  │         ▼                   ▼                    ▼       │    │
  │  │  ┌────────────┐    ┌──────────────┐    ┌──────────────┐  │    │
  │  │  │ UI Alert   │    │ Biểu đồ      │    │ Bảng lịch sử │  │    │
  │  │  │ - Popup    │    │ Line Chart   │    │ Alert Table  │  │    │
  │  │  │ - Đèn đỏ   │    │ (Chart.js)   │    │ (DOM/Render) │  │    │
  │  │  │ - Âm thanh │    │              │    │              │  │    │
  │  │  │ - Notifi   │    │              │    │              │  │    │
  │  │  └────────────┘    └──────────────┘    └──────────────┘  │    │
  │  └─────────────────────────────────────────────────────────┘    │
  └─────────────────────────────────────────────────────────────────┘
```

### 6.2. Mô tả luồng dữ liệu tổng quát

```
 [Cảm biến ZCT] ──(Analog Signal)──► [ESP32 ADC]
                                          │
                                    [Xử lý tại biên]
                                     - Lọc nhiễu
                                     - Chuyển đổi ADC → mA
                                     - So sánh ngưỡng 30mA
                                          │
                          ┌───────────────┴───────────────┐
                          ▼                               ▼
              [Bình thường (Alert = false)]    [Rò rỉ (Alert = true)]
                          │                               │
                          │                      [Edge Action]
                          │                   - Bật Buzzer
                          │                   - Ngắt Relay
                          │                               │
                          └───────────────┬───────────────┘
                                          ▼
                                [Đóng gói JSON]
                                {deviceId, leakageCurrent,
                                 alert, relayState, timestamp}
                                          │
                                    (Wi-Fi / HTTP MQTT)
                                          ▼
                              [Backend Spring Boot]
                                   - Xác thực
                                   - Lưu DB (MySQL)
                                   - Push WebSocket
                                          │
                                    (WebSocket / STOMP)
                                          ▼
                              [Frontend Dashboard]
                                   - Cập nhật UI
                                   - Popup + Âm thanh
                                   - Biểu đồ thời gian thực
                                   - Browser Notification
```

---

## 7. Kết luận

Quy trình hoạt động của hệ thống **Cảnh báo rò rỉ điện năng** được thiết kế theo mô hình **xử lý tại biên kết hợp với giám sát từ xa**, đảm bảo các yêu cầu:

| **Yêu cầu** | **Giải pháp** | **Công nghệ** |
|---|---|---|
| **Phản hồi tức thời** | Xử lý cảnh báo tại chỗ trên ESP32 (Edge Computing) | ESP32 GPIO + Relay + Buzzer |
| **Giám sát từ xa** | Truyền dữ liệu qua Wi-Fi lên Backend | RESTful API / MQTT |
| **Lưu trữ lịch sử** | Lưu trữ dữ liệu vào cơ sở dữ liệu MySQL | JPA / Hibernate |
| **Cảnh báo thời gian thực** | WebSocket Push từ Backend đến Frontend | Spring WebSocket + STOMP |
| **Trực quan hóa dữ liệu** | Dashboard web với biểu đồ và bảng lịch sử | Chart.js / ECharts |

> **Lưu ý:** Tài liệu này mô tả quy trình hoạt động ở mức kiến trúc tổng thể (Architecture Design). Các chi tiết kỹ thuật cụ thể về cài đặt từng module sẽ được trình bày trong các tài liệu thiết kế chi tiết (Detailed Design Document) và tài liệu hướng dẫn triển khai (Deployment Guide).

---

*Tài liệu được biên soạn cho Đồ án tốt nghiệp - Hệ thống Cảnh báo rò rỉ điện năng*
