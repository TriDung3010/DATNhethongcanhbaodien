# PlantUML Diagrams cho Báo Cáo Đồ Án

Copy từng đoạn code vào https://www.plantuml.com/ hoặc tool PlantUML offline.

---

## 1. KIẾN TRÚC HỆ THỐNG (Component Diagram)

```plantuml
@startuml
!theme plain
skinparam componentStyle rectangle

title SƠ ĐỒ KIẾN TRÚC HỆ THỐNG

actor "Người dùng" as user
actor "ESP32\n(NodeMCU-32s)" as esp32

package "Backend Server" {
  [REST API\n/ api/v1/*] as rest
  [WebSocket\n/ ws] as ws
  [Service Layer] as service
  database "MySQL\n(Data)" as db
}

package "Frontend" {
  [Dashboard Web] as web
}

package "Thiết bị phần cứng" {
  [ZCT\n(Cảm biến dòng)] as zct
  [Relay\n(Ngắt tải)] as relay
  [Buzzer] as buzzer
  [LED + Motor] as devices
  [Biến trở] as pot
  [Nút nhấn] as btn
}

esp32 --> zct : Đọc ADC
esp32 --> pot : Đọc ADC
esp32 <-- btn : Nhấn nút
esp32 --> relay : Điều khiển
esp32 --> buzzer : Điều khiển
esp32 --> devices : Điều khiển

esp32 -right-> rest : HTTP POST\n(sensor data)
rest --> service
service --> db : JPA/Hibernate
service ..> ws : Push alert\n(/topic/alert)
ws <-- web : STOMP/SockJS
user --> web : Xem dashboard
@enduml
```

---

## 2. LUỒNG DỮ LIỆU (Sequence Diagram)

```plantuml
@startuml
!theme plain
actor ESP32
participant "REST API" as api
participant "Service" as svc
participant "Database" as db
participant "WebSocket" as ws
actor "Dashboard" as dash

title LUỒNG GỬI & HIỂN THỊ DỮ LIỆU CẢM BIẾN

== Chu kỳ gửi (3s) ==
ESP32 -> api: POST /api/v1/sensor-data\n{deviceId, leakageCurrent, alert, relayState}
api -> svc: SensorDataDTO
svc -> db: Lưu SensorData entity
svc -> svc: Kiểm tra ngưỡng 30mA
alt leakage >= 30mA
    svc -> db: Lưu AlertHistory entity
    svc -> ws: Gửi STOMP /topic/alert\n{leakageCurrent, alert=true}
    ws -> dash: Cập nhật popup + biểu đồ
else leakage < 30mA
    ws -> dash: Trạng thái BÌNH THƯỜNG
end

== ESP32 xử lý tại chỗ ==
ESP32 -> ESP32: processAlert()
alt leakage >= 30mA
    ESP32 -> Relay: NGẮT tải
    ESP32 -> Buzzer: Kêu beep
    ESP32 -> LED: Đỏ nhấp nháy
else
    ESP32 -> Relay: ĐÓNG tải
    ESP32 -> Buzzer: Tắt
    ESP32 -> LED: Xanh sáng
end
@enduml
```

---

## 3. GIẢI THUẬT FIRMWARE (Activity Diagram)

```plantuml
@startuml
!theme plain
title GIẢI THUẬT XỬ LÝ CẢNH BÁO (Edge Alert)

start
repeat
  :Đọc nút nhấn;

  if (Nhấn RÒ RỈ?) then (Có)
    :Bật/tắt chế độ simulate;
  else (Không)
  endif

  if (Chế độ simulate?) then (Có)
    :Đọc biến trở (GPIO 35);
    :leakageCurrent = potValue * 100 / 4095;
  else (Không)
    :Đọc ZCT (GPIO 34);
    :leakageCurrent = RMS(mA);
  endif

  if (leakageCurrent >= 30mA?) then (Có)
    if (alertActive == false?) then (Vừa vượt ngưỡng)
      :Bật alertActive;
      :Ngắt Relay (HIGH);
      :Tắt LED thiết bị;
      :Gửi cảnh báo lên Server;
    else (Đã báo trước)
    endif
    :Buzzer nhấp nháy 300ms;
  else (Không)
    if (alertActive == true?) then (Vừa hết rò rỉ)
      :Tắt alertActive;
      :Đóng Relay (LOW);
      :Bật LED thiết bị;
      :Gửi trạng thái lên Server;
    else (Đã bình thường)
    endif
    :Buzzer TẮT;
  endif

  :In status Serial;

  if (Đã 3 giây?) then (Có)
    :Gửi POST JSON lên Server;
  else (Không)
  endif

repeat while (Luôn chạy)
@enduml
```

---

## 4. LỚP BACKEND (Class Diagram)

```plantuml
@startuml
!theme plain
title SƠ ĐỒ LỚP - BACKEND SPRING BOOT

package "Entity" {
  class SensorData {
    + Long id
    + String deviceId
    + Float leakageCurrent
    + Boolean alert
    + Boolean relayState
    + LocalDateTime timestamp
  }
  class AlertHistory {
    + Long id
    + String deviceId
    + Float leakageCurrent
    + String alertType
    + String description
    + Boolean resolved
    + LocalDateTime timestamp
  }
}

package "DTO" {
  class SensorDataDTO {
    + String deviceId
    + Float leakageCurrent
    + Boolean alert
    + Boolean relayState
  }
  class AlertEventDTO {
    + String deviceId
    + Float leakageCurrent
    + String alertType
    + String description
  }
}

package "Repository" {
  interface SensorDataRepository {
    + findTopByOrderByTimestampDesc(): SensorData
    + findFirst10ByOrderByTimestampDesc(): List
  }
  interface AlertHistoryRepository {
    + findByResolvedFalse(): List
    + findFirst20ByOrderByTimestampDesc(): List
  }
}

package "Service" {
  class SensorDataService {
    + processSensorData(dto): SensorData
    + getLatestData(): SensorDataDTO
    + getAlerts(): List
  }
}

package "Controller" {
  class SensorDataController {
    + postSensorData(dto): ResponseEntity
    + getLatestData(): ResponseEntity
    + getAlerts(): ResponseEntity
  }
}

package "Config" {
  class WebSocketConfig {
    + configureMessageBroker()
    + registerStompEndpoints()
  }
  class WebConfig {
    + addCorsMappings()
  }
}

SensorDataController --> SensorDataService
SensorDataService --> SensorDataRepository
SensorDataService --> AlertHistoryRepository
SensorDataRepository --> SensorData
AlertHistoryRepository --> AlertHistory
SensorDataDTO <.. SensorDataController
AlertEventDTO <.. SensorDataService
@enduml
```

---

## 5. TRIỂN KHAI HỆ THỐNG (Deployment Diagram)

```plantuml
@startuml
!theme plain
title SƠ ĐỒ TRIỂN KHAI

node "ESP32" {
  [Firmware .ino]
  [ADC ZCT GPIO34]
  [ADC Pot GPIO35]
  [GPIO Outputs]
  [WiFi Client]
}

node "Máy tính" {
  database "MySQL 8.4\nPort 3306" as mysql
  node "Spring Boot\nPort 8080" {
    [REST API]
    [WebSocket]
    [JPA/Hibernate]
  }
  node "Node.js HTTP\nPort 3000" {
    [Dashboard .html]
    [Server .js]
  }
}

cloud "WiFi Router" {
  [Mạng LAN 192.168.x.x]
}

ESP32 --> "WiFi Router" : HTTP POST
"WiFi Router" --> "Spring Boot\nPort 8080"
"Spring Boot\nPort 8080" --> mysql : JDBC
"Dashboard .html" --> "Spring Boot\nPort 8080" : STOMP/WS + REST
"Node.js HTTP\nPort 3000" --> "Dashboard .html" : Serve static
@enduml
```
