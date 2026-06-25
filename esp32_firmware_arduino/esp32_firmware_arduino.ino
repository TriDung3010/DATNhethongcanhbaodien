/*
 * FIRMWARE CHO MÔ HÌNH NHÀ GIẢ LẬP RÒ RỈ ĐIỆN
 * ==========================================
 * - Điều khiển LED thiết bị trong nhà
 * - Nút nhấn: RÒ RỈ + RESET
 * - Biến trở: điều chỉnh mức rò rỉ
 * - ZCT: phát hiện dòng rò thật (hoặc Simulator)
 * - Buzzer + Relay cảnh báo tại chỗ
 * - Gửi JSON lên Server
 */

#include <WiFi.h>
#include <HTTPClient.h>
#include "config.h"
#include <Wire.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 64
#define OLED_RESET    -1
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

// ─── Chân GPIO mô hình nhà ──────────────────────────
#define PIN_LED_DEN1     32     // Thiết bị 1 (đèn phòng khách)
#define PIN_LED_DEN2     14     // Thiết bị 2 (đèn bếp)
#define PIN_LED_DEN3     12     // Thiết bị 3 (quạt)
#define PIN_LED_XANH     25     // LED trạng thái BÌNH THƯỜNG
#define PIN_LED_DO       33     // LED trạng thái RÒ RỈ
#define PIN_NUT_RORI     13     // Nút nhấn mô phỏng rò rỉ
#define PIN_NUT_RESET    19     // Nút nhấn reset

// Chân đã dùng trong config.h:
// PIN_RELAY = 26, PIN_BUZZER = 27, PIN_ZCT = 34, PIN_POT = 35

// ─── Biến toàn cục ──────────────────────────────────
float leakageCurrentMA = 0.0;
bool alertActive = false;
bool relayOn = true;
bool simulateLeak = true;
unsigned long lastSendTime = 0;
unsigned long lastBuzzerToggle = 0;
bool buzzerState = false;
int leakLevel = 0;
unsigned long lastWiFiAttempt = 0;

// ─── WiFi ──────────────────────────────────────────
void connectWiFi() {
    Serial.print("Dang ket noi WiFi: ");
    Serial.println(WIFI_SSID);
    WiFi.mode(WIFI_STA);
    WiFi.begin(WIFI_SSID, WIFI_PASSWORD);

    int attempts = 0;
    while (WiFi.status() != WL_CONNECTED && attempts < 40) {
        delay(500);
        Serial.print(".");
        attempts++;
    }

    if (WiFi.status() == WL_CONNECTED) {
        Serial.println("\nWiFi OK! IP: " + WiFi.localIP().toString());
    } else {
        Serial.println("\nWiFi that bai! Chay offline.");
    }
}

// ─── Giữ kết nối WiFi (tự động reconnect) ──────────
void ensureWiFi() {
    if (WiFi.status() != WL_CONNECTED) {
        unsigned long now = millis();
        if (now - lastWiFiAttempt > 10000) {
            Serial.println("Mat WiFi. Dang ket noi lai...");
            WiFi.disconnect();
            WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
            lastWiFiAttempt = now;
        }
    }
}

// ─── Đọc dòng rò (thực tế từ ZCT hoặc giả lập từ biến trở) ──
float readLeakageCurrent() {
    // Đọc giá trị từ biến trở (mô phỏng mức rò rỉ)
    int potValue = analogRead(PIN_POT);  // 0..4095
    float simulatedMA = (potValue / 4095.0) * 100.0;  // 0..100 mA

    // Nếu đang bật chế độ rò rỉ, trả về giá trị từ biến trở
    if (simulateLeak) {
        return simulatedMA;
    }

    // Nếu không rò rỉ, đọc từ ZCT thật (nếu có)
    int rawMin = 4095, rawMax = 0;
    for (int i = 0; i < 50; i++) {
        int raw = analogRead(PIN_ZCT);
        if (raw < rawMin) rawMin = raw;
        if (raw > rawMax) rawMax = raw;
        delayMicroseconds(100);
    }

    int peakToPeak = rawMax - rawMin;
    float voltageRms = (peakToPeak / 2.0) * (3.3 / 4095) * 0.707;
    float currentMA = (voltageRms / 0.1) * 1000.0;

    if (currentMA < 2.0) currentMA = 0.0;
    return currentMA;
}

// ─── Bật/tắt LED thiết bị theo trạng thái Relay ────
void controlApplianceLEDs(bool powerOn) {
    if (powerOn) {
        digitalWrite(PIN_LED_DEN1, HIGH);
        digitalWrite(PIN_LED_DEN2, HIGH);
        digitalWrite(PIN_LED_DEN3, HIGH);
        digitalWrite(PIN_LED_XANH, HIGH);
        digitalWrite(PIN_LED_DO, LOW);
    } else {
        digitalWrite(PIN_LED_DEN1, LOW);
        digitalWrite(PIN_LED_DEN2, LOW);
        digitalWrite(PIN_LED_DEN3, LOW);
        digitalWrite(PIN_LED_XANH, LOW);
        digitalWrite(PIN_LED_DO, HIGH);
    }
}

// ─── Xử lý cảnh báo tại chỗ (Edge Alert) ──────────
void processAlert(float currentMA) {
    if (currentMA >= LEAKAGE_THRESHOLD_MA) {
        if (!alertActive) {
            alertActive = true;
            relayOn = false;

            digitalWrite(PIN_RELAY, HIGH);      // Ngắt tải
            controlApplianceLEDs(false);         // Tắt đèn thiết bị

            Serial.println("!!! CANH BAO: Dong ro " + String(currentMA) + " mA - Da ngat dien!");
        }
    } else {
        if (alertActive) {
            alertActive = false;
            relayOn = true;

            digitalWrite(PIN_RELAY, LOW);        // Đóng tải lại
            controlApplianceLEDs(true);           // Bật đèn thiết bị

            Serial.println("Het canh bao. Dong dien tro lai.");
        }
    }
}

// ─── Điều khiển Buzzer (nhịp báo động chớp kép) ────
void controlBuzzer() {
    if (alertActive) {
        unsigned long now = millis();
        // Tạo chu kỳ 800ms: Bíp (100ms) - Tắt (100ms) - Bíp (100ms) - Tắt (500ms)
        int cycleTime = now % 800;
        if (cycleTime < 100 || (cycleTime >= 200 && cycleTime < 300)) {
            digitalWrite(PIN_BUZZER, LOW); // LOW là còi kêu (đối với còi Active LOW)
        } else {
            digitalWrite(PIN_BUZZER, HIGH); // HIGH là còi tắt
        }
    } else {
        digitalWrite(PIN_BUZZER, HIGH); // HIGH là tắt còi hoàn toàn
    }
}

// ─── Đọc nút nhấn ──────────────────────────────────
void readButtons() {
    static unsigned long lastDebounce = 0;
    static int lastRoRi = HIGH, lastReset = HIGH;

    int roRiState = digitalRead(PIN_NUT_RORI);
    int resetState = digitalRead(PIN_NUT_RESET);

    // Nút RÒ RỈ: nhấn để bật/tắt chế độ rò rỉ
    if (roRiState == LOW && lastRoRi == HIGH && millis() - lastDebounce > 200) {
        simulateLeak = !simulateLeak;
        Serial.println(simulateLeak ? ">>> CHUC NANG RO RI: BAT" : ">>> CHUC NANG RO RI: TAT");
        lastDebounce = millis();
    }

    // Nút RESET: nhấn để tắt cảnh báo, đóng relay
    if (resetState == LOW && lastReset == HIGH && millis() - lastDebounce > 200) {
        simulateLeak = false;
        Serial.println(">>> RESET: Tat che do ro ri");
        lastDebounce = millis();
    }

    lastRoRi = roRiState;
    lastReset = resetState;
}

// ─── Gửi JSON lên Server ───────────────────────────
void sendDataToServer() {
    if (WiFi.status() != WL_CONNECTED) return;

    HTTPClient http;
    http.begin(SERVER_URL);
    http.addHeader("Content-Type", "application/json");

    String payload = "{";
    payload += "\"deviceId\":\"" + String(DEVICE_ID) + "\",";
    payload += "\"leakageCurrent\":" + String(leakageCurrentMA, 1) + ",";
    payload += "\"unit\":\"mA\",";
    payload += "\"alert\":";
    payload += (alertActive ? "true" : "false");
    payload += ",";
    payload += "\"relayState\":";
    payload += (relayOn ? "true" : "false");
    payload += ",";
    payload += "\"timestamp\":\"" + String(millis()) + "\"";
    payload += "}";

    int httpCode = http.POST(payload);
    if (httpCode > 0) {
        Serial.println("Server: " + http.getString());
    } else {
        Serial.print(".");
    }
    http.end();
}

// ─── In thông số ra Serial ─────────────────────────
void printStatus() {
    int rawPot = analogRead(PIN_POT);
    Serial.print("[Gia tri Volume RAW: ");
    Serial.print(rawPot);
    Serial.print("] Dong ro: ");
    Serial.print(leakageCurrentMA, 1);
    Serial.print(" mA | ");
    Serial.print(alertActive ? "CANH BAO!" : "Binh thuong");
    Serial.print(" | Relay: ");
    Serial.print(relayOn ? "DONG  " : "NGAT  ");
    Serial.print(" | Simulate: ");
    Serial.println(simulateLeak ? "BAT" : "TAT");
}

// ─── Cập nhật màn hình OLED ────────────────────────
void updateOLED() {
    display.clearDisplay();
    
    // Tiêu đề
    display.setTextSize(1);
    display.setTextColor(SSD1306_WHITE);
    display.setCursor(0, 0);
    display.print("DONG RO RI:");

    // Giá trị dòng rò lớn ở giữa
    display.setTextSize(3);
    display.setCursor(15, 15);
    display.print(leakageCurrentMA, 1);
    display.setTextSize(1);
    display.print("mA");

    // Trạng thái dưới đáy
    display.setTextSize(2);
    display.setCursor(0, 45);
    if (alertActive) {
        // Nhấp nháy cảnh báo
        if ((millis() / 300) % 2 == 0) {
            display.print("NGUY HIEM!");
        }
    } else {
        display.print("AN TOAN");
    }

    display.display();
}

// ===================================================
// SETUP
// ===================================================
void setup() {
    Serial.begin(115200);
    delay(1000);
    Serial.println("\n===== MO HINH NHA - CANH BAO RO RI DIEN =====");

    pinMode(PIN_ZCT, INPUT);
    pinMode(PIN_POT, INPUT);
    pinMode(PIN_RELAY, OUTPUT);
    pinMode(PIN_BUZZER, OUTPUT);
    pinMode(PIN_LED, OUTPUT);
    pinMode(PIN_LED_DEN1, OUTPUT);
    pinMode(PIN_LED_DEN2, OUTPUT);
    pinMode(PIN_LED_DEN3, OUTPUT);
    pinMode(PIN_LED_XANH, OUTPUT);
    pinMode(PIN_LED_DO, OUTPUT);
    pinMode(PIN_NUT_RORI, INPUT_PULLUP);
    pinMode(PIN_NUT_RESET, INPUT_PULLUP);

    // Tắt hết
    digitalWrite(PIN_RELAY, LOW);
    digitalWrite(PIN_BUZZER, LOW);
    digitalWrite(PIN_LED, LOW);
    digitalWrite(PIN_LED_DEN1, LOW);
    digitalWrite(PIN_LED_DEN2, LOW);
    digitalWrite(PIN_LED_DEN3, LOW);
    digitalWrite(PIN_LED_XANH, LOW);
    digitalWrite(PIN_LED_DO, LOW);

    analogReadResolution(12);
    
    // Khởi tạo OLED (địa chỉ I2C 0x3C)
    if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {
        Serial.println("Loi khoi tao OLED!");
    } else {
        display.clearDisplay();
        display.setTextSize(1);
        display.setTextColor(SSD1306_WHITE);
        display.setCursor(0, 20);
        display.println(" He Thong Canh Bao");
        display.println("   Dang khoi dong...");
        display.display();
    }

    connectWiFi();

    // Bật đèn lên
    controlApplianceLEDs(true);

    Serial.println("San sang! Nhan nut RO RI de mo phong.");
}

// ===================================================
// LOOP
// ===================================================
void loop() {
    ensureWiFi();
    readButtons();

    if (simulateLeak) {
        leakageCurrentMA = readLeakageCurrent();  // Đọc từ biến trở
    } else {
        leakageCurrentMA = readLeakageCurrent();  // Đọc từ ZCT
    }

    processAlert(leakageCurrentMA);
    controlBuzzer();
    printStatus();
    updateOLED();

    unsigned long now = millis();
    if (now - lastSendTime >= SEND_INTERVAL_MS) {
        sendDataToServer();
        lastSendTime = now;
    }

    // LED trạng thái nhấp nháy nhanh khi rò rỉ
    if (alertActive) {
        digitalWrite(PIN_LED, (millis() / 200) % 2 ? HIGH : LOW);
    }

    delay(200);
}
