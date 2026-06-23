#include <Arduino.h>
#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>
#include "config.h"

float leakageCurrentMA = 0.0;
bool alertActive = false;
bool relayOn = true;
unsigned long lastSendTime = 0;
unsigned long lastBuzzerToggle = 0;
bool buzzerState = false;

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
        Serial.println("\nWiFi da ket noi!");
        Serial.print("IP: ");
        Serial.println(WiFi.localIP());
    } else {
        Serial.println("\nKet noi WiFi that bai! Chay o che do offline.");
    }
}

float readLeakageCurrent() {
    int rawSum = 0;
    int rawMin = 4095;
    int rawMax = 0;

    for (int i = 0; i < SAMPLE_WINDOW; i++) {
        int raw = analogRead(PIN_ZCT);
        rawSum += raw;
        if (raw < rawMin) rawMin = raw;
        if (raw > rawMax) rawMax = raw;
        delayMicroseconds(100);
    }

    int avgRaw = rawSum / SAMPLE_WINDOW;
    int peakToPeak = rawMax - rawMin;

    float voltageRms = (peakToPeak / 2.0) * (ADC_VREF / ADC_RESOLUTION) * 0.707;
    float currentMA = (voltageRms / (ZCT_SENSITIVITY_MV_PER_A / 1000.0)) * 1000.0;

    if (currentMA < 2.0) currentMA = 0.0;

    return currentMA;
}

void processAlert(float currentMA) {
    if (currentMA >= LEAKAGE_THRESHOLD_MA) {
        if (!alertActive) {
            alertActive = true;
            relayOn = false;
            digitalWrite(PIN_RELAY, HIGH);
            digitalWrite(PIN_LED, HIGH);
            Serial.println("CANH BAO: Phat hien ro ri dien! Dong ro: " + String(currentMA) + " mA");
            Serial.println("Da ngat Relay. Buzzer dang keu.");
        }
    } else {
        if (alertActive) {
            alertActive = false;
            relayOn = true;
            digitalWrite(PIN_RELAY, LOW);
            digitalWrite(PIN_LED, LOW);
            digitalWrite(PIN_BUZZER, LOW);
            Serial.println("Het canh bao. Dong lai Relay.");
        }
    }
}

void controlBuzzer() {
    if (alertActive) {
        unsigned long now = millis();
        if (now - lastBuzzerToggle >= BUZZER_INTERVAL_MS) {
            buzzerState = !buzzerState;
            digitalWrite(PIN_BUZZER, buzzerState ? HIGH : LOW);
            lastBuzzerToggle = now;
        }
    } else {
        digitalWrite(PIN_BUZZER, LOW);
    }
}

void sendDataToServer() {
    if (WiFi.status() != WL_CONNECTED) return;

    HTTPClient http;
    http.begin(SERVER_URL);
    http.addHeader("Content-Type", "application/json");

    JsonDocument doc;
    doc["deviceId"] = DEVICE_ID;
    doc["leakageCurrent"] = leakageCurrentMA;
    doc["unit"] = "mA";
    doc["alert"] = alertActive;
    doc["relayState"] = relayOn;

    time_t now = time(nullptr);
    struct tm *timeinfo = localtime(&now);
    char timestamp[25];
    strftime(timestamp, sizeof(timestamp), "%Y-%m-%dT%H:%M:%S.000Z", timeinfo);
    doc["timestamp"] = timestamp;

    String payload;
    serializeJson(doc, payload);

    int httpCode = http.POST(payload);

    if (httpCode > 0) {
        String response = http.getString();
        Serial.println("Server response: " + String(httpCode) + " - " + response);
    } else {
        Serial.println("HTTP POST failed: " + http.errorToString(httpCode));
    }

    http.end();
}

void printSystemInfo() {
    Serial.println("\n===== THONG SO HE THONG =====");
    Serial.println("Thiet bi: " + String(DEVICE_ID));
    Serial.println("Nguong canh bao: " + String(LEAKAGE_THRESHOLD_MA) + " mA");
    Serial.println("PIN ZCT: " + String(PIN_ZCT));
    Serial.println("PIN Relay: " + String(PIN_RELAY));
    Serial.println("PIN Buzzer: " + String(PIN_BUZZER));
    Serial.print("WiFi: ");
    if (WiFi.status() == WL_CONNECTED) {
        Serial.println("Da ket noi (" + WiFi.localIP().toString() + ")");
    } else {
        Serial.println("Chua ket noi");
    }
    Serial.println("==============================\n");
}

void setup() {
    Serial.begin(115200);
    delay(1000);
    Serial.println("\n\n===== HE THONG CANH BAO RO RI DIEN =====");
    Serial.println("Khoi dong he thong...");

    pinMode(PIN_ZCT, INPUT);
    pinMode(PIN_RELAY, OUTPUT);
    pinMode(PIN_BUZZER, OUTPUT);
    pinMode(PIN_LED, OUTPUT);

    digitalWrite(PIN_RELAY, LOW);
    digitalWrite(PIN_BUZZER, LOW);
    digitalWrite(PIN_LED, LOW);

    analogReadResolution(12);

    connectWiFi();
    printSystemInfo();

    configTime(7 * 3600, 0, "pool.ntp.org", "time.nist.gov");

    Serial.println("San sang!");
}

void loop() {
    leakageCurrentMA = readLeakageCurrent();

    processAlert(leakageCurrentMA);

    controlBuzzer();

    Serial.print("Dong ro: ");
    Serial.print(leakageCurrentMA, 1);
    Serial.print(" mA | ");
    Serial.print(alertActive ? "CANH BAO" : "Binh thuong");
    Serial.print(" | Relay: ");
    Serial.println(relayOn ? "DONG" : "DA NGAT");

    unsigned long now = millis();
    if (now - lastSendTime >= SEND_INTERVAL_MS) {
        sendDataToServer();
        lastSendTime = now;
    }

    delay(200);
}
