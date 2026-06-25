# THIẾT KẾ MÔ HÌNH NGÔI NHÀ GIẢ LẬP
## Hệ thống Cảnh báo Rò rỉ Điện năng

---

## 1. Nguyên lý hoạt động của mô hình

Sử dụng **nguồn 12V DC an toàn** ( adapter hoặc pin ) để mô phỏng hệ thống điện gia đình.

Cách tạo **dòng rò giả lập**:

```
Bình thường:  I_phase = I_neutral  → ZCT cân bằng → 0V
Có rò rỉ:     I_phase ≠ I_neutral  → ZCT lệch      → báo động
```

Trong mô hình, dùng **2 dây dẫn** luồn qua ZCT:
- **Dây Pha (L):** cấp nguồn 12V đến thiết bị
- **Dây Trung tính (N):** hồi tiếp về nguồn

Khi nhấn nút **"Rò rỉ"**, một điện trở sẽ nối tắt 1 phần dòng điện từ Pha xuống mass (mô phỏng rò xuống đất) → dòng qua ZCT mất cân bằng → ESP32 phát hiện.

---

## 2. Sơ đồ khối mô hình

```
                        ┌─────────────────────────┐
                        │   NGUỒN 12V DC          │
                        │   (Adapter / Pin)       │
                        └────────┬────────────────┘
                                 │
                    ┌────────────┴────────────┐
                    │        ZCT              │
                    │  (cả 2 dây L & N luồn   │
                    │   qua lõi ferrite)       │
                    └────────────┬────────────┘
                                 │
              ┌──────────────────┼──────────────────┐
              ▼                  ▼                   ▼
      ┌──────────────┐  ┌──────────────┐  ┌────────────────┐
      │ Thiết bị 1   │  │ Thiết bị 2   │  │ Công tắc rò rỉ │
      │ (LED trắng)  │  │ (Motor nhỏ)  │  │ Nút nhấn + R   │
      └──────────────┘  └──────────────┘  │ -> mass giả lập│
                                          └────────────────┘

 ESP32 đọc ZCT ──→ phát hiện mất cân bằng ──→ ngắt Relay + Buzzer
                                                   ↓
                                          Gửi lên Server
                                                   ↓
                                          Dashboard Web
```

---

## 3. Danh sách linh kiện cần mua

| **STT** | **Linh kiện** | **Số lượng** | **Ghi chú** |
|---|---|---|---|
| 1 | ESP32 Dev Board | 1 | NodeMCU-32s hoặc ESP32 DevKit |
| 2 | ZCT (Cảm biến dòng rò) | 1 | Loại SCT013 30A/1V hoặc ZCT-30mA |
| 3 | Module Relay 1 kênh 5V | 1 | Loại kích mức HIGH |
| 4 | Buzzer 5V | 1 | Buzzer tích hợp (active buzzer) |
| 5 | LED trắng 5mm | 5 | Mô phỏng đèn/thiết bị |
| 6 | Motor DC 3-6V | 1 | Mô phỏng quạt/máy giặt |
| 7 | Nút nhấn (Push button) | 2 | 1 nút rò rỉ, 1 nút reset |
| 8 | Điện trở 10Ω / 5W | 1 | Tạo dòng rò giả lập |
| 9 | Điện trở 220Ω | 5 | Cho LED |
| 10 | Điện trở 10kΩ | 2 | Pull-down cho nút nhấn |
| 11 | Biến trở 10kΩ (Pot) | 1 | Tùy chỉnh mức rò rỉ |
| 12 | Breadboard + dây nối | 1 | Test mạch |
| 13 | Adapter 12V DC 1A | 1 | Nguồn cho mô hình |
| 14 | Jack DC (đực) | 1 | Cắm nguồn |
| 15 | Mô hình nhà (gỗ/mica) | 1 | Đặt làm hoặc tự cắt |
| 16 | Dây điện mềm | 2m | Đi dây trong mô hình |

---

## 4. Sơ đồ đấu dây chi tiết

### 4.1. Kết nối ESP32

```
ESP32                  Linh kiện
─────                  ─────────
GPIO 34 ────────────── ZCT OUT (chân tín hiệu)
GPIO 26 ────────────── Relay IN (điều khiển ngắt tải Quạt)
GPIO 27 ────────────── Buzzer I/O (Báo động)
GPIO 25 ────────────── LED xanh (trạng thái bình thường)
GPIO 33 ────────────── LED đỏ (trạng thái rò rỉ)
GPIO 32 ────────────── LED trắng thiết bị 1
GPIO 14 ────────────── LED trắng thiết bị 2
GPIO 35 ────────────── Biến trở (mô phỏng rò rỉ)
GPIO 22 ────────────── OLED SCK
GPIO 21 ────────────── OLED SDA
3.3V    ────────────── OLED VCC + Buzzer VCC + Biến trở VCC
5V      ────────────── Relay VCC
GND     ────────────── Mass chung
```

### 4.2. Mạch nguồn và ZCT

```
Adapter 12V ──┬── Jack DC ──┬── (+) ──┬── Dây Pha (L) ──┐
              │             │         │                 │
              │             │    [DC-DC 5V]             │
              │             │         │                 │
              │             │         └── 5V → ESP32    │
              │             │                           │
              │             └── GND ── Dây N (N) ──────┤
              │                                         │
              │            ╔══════════════════════╗      │
              │            ║       LÕI ZCT       ║      │
              └───── Dây ──║── (L) ──────────►── ║──────┘
              rò (R 10Ω)  ║                      ║
                           ║── (N) ──────────►── ║─────── GND
                           ╚══════════════════════╝
                                    │
                                    └──→ ESP32 GPIO 34
```

**Nguyên lý tạo dòng rò:**

Khi nhấn nút "Rò rỉ" → một nhánh phụ (qua R 10Ω) nối từ dây Pha xuống mass (GND) → dòng điện chia làm 2 đường:
1. Đường chính qua thiết bị rồi về N (qua ZCT)
2. Đường rò qua R 10Ω xuống mass (không qua ZCT)

→ Dòng qua dây L ≠ dòng qua dây N → ZCT phát hiện chênh lệch.

### 4.3. Layout mô hình nhà

```
┌──────────────────────────────────────────────────┐
│                    MÔ HÌNH NHÀ                    │
│  ┌────────────────────────────────────────────┐   │
│  │  TẦNG TRÊN                                 │   │
│  │  ┌─────────┐  ┌─────────┐                  │   │
│  │  │Phòng ngủ│  │Phòng tắm│                  │   │
│  │  │ LED #1  │  │ LED #2  │                  │   │
│  │  └─────────┘  └─────────┘                  │   │
│  ├────────────────────────────────────────────┤   │
│  │  TẦNG DƯỚI                                 │   │
│  │  ┌─────────┐  ┌─────────┐  ┌─────────┐     │   │
│  │  │Bếp     │  │Phòng    │  │Sân      │     │   │
│  │  │ LED #3 │  │khách    │  │Motor    │     │   │
│  │  │        │  │ LED #4  │  │(máy    │     │   │
│  │  └─────────┘  └─────────┘  │giặt)   │     │   │
│  └────────────────────────────┴─────────┘     │   │
│                                                │   │
│  ┌──────────────────────────────────────────┐  │   │
│  │  ĐẾ - HỘP KỸ THUẬT                       │  │   │
│  │  ┌─────┐ ┌─────┐ ┌──────┐ ┌──────────┐  │  │   │
│  │  │ESP32│ │Relay│ │Buzzer│ │Nút Rò rỉ │  │  │   │
│  │  └─────┘ └─────┘ └──────┘ └──────────┘  │  │   │
│  │  ┌─────────────────────────────────┐     │  │   │
│  │  │  Nguồn 12V + ZCT                │     │  │   │
│  │  └─────────────────────────────────┘     │  │   │
│  └──────────────────────────────────────────┘  │   │
└──────────────────────────────────────────────────┘
```

---

## 5. Cách demo khi báo cáo

### Kịch bản 1: Chế độ bình thường
1. Cấp nguồn 12V → đèn trong nhà sáng hết
2. Dashboard web hiển thị: dòng rò ~0 mA, trạng thái **BÌNH THƯỜNG**

### Kịch bản 2: Xảy ra rò rỉ
1. Nhấn nút **"Rò rỉ"** trên mô hình
2. Quan sát:
   - **Tại chỗ:** Buzzer kêu, LED đỏ nhấp nháy, Relay ngắt → đèn tắt hết
   - **Dashboard:** Nhấp nháy đỏ + popup + âm thanh + biểu đồ tăng vọt

### Kịch bản 3: Reset hệ thống
1. Nhấn nút **"Reset"**
2. Relay đóng lại → đèn sáng trở lại
3. Dashboard trở về bình thường

---

## 6. Gợi ý vật liệu làm mô hình nhà

| **Vật liệu** | **Ưu điểm** |
|---|---|
| **Mica trong 3mm** | Nhìn thấy LED bên trong, chuyên nghiệp |
| **Gỗ MDF 3mm** | Dễ cắt, sơn màu, chắc chắn |
| **Bìa carton cứng** | Rẻ, dễ làm |
| **In 3D (nhựa PLA)** | Đẹp nhất, cần file thiết kế |

> **Khuyên dùng:** Mica trong + sơn mờ — vừa thấy được LED bên trong, vừa đẹp khi chụp hình báo cáo.

---

## 7. Cải tiến cho demo ấn tượng

- [ ] **Thêm LCD 16x2** hiển thị dòng rò ngay trên mô hình
- [ ] **Thêm nút chỉnh biến trở** để tăng/giảm mức rò rỉ (thay vì cố định)
- [ ] **Dán nhãn** từng phòng và thiết bị (tủ lạnh, máy giặt, ...)
- [ ] **Sơn hoặc dán giấy dán tường** decor cho mô hình
- [ ] **Gắn cảm biến nhiệt** mô phỏng thiết bị quá tải

---

*Tài liệu thiết kế mô hình - Hệ thống Cảnh báo Rò rỉ Điện năng*
