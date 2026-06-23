#ifndef CONFIG_H
#define CONFIG_H

#define WIFI_SSID            "WIFI_SSID"
#define WIFI_PASSWORD        "WIFI_PASSWORD"

#define SERVER_URL           "http://192.168.1.100:8080/api/v1/sensor-data"
#define DEVICE_ID            "ESP32_001"

#define PIN_ZCT              34
#define PIN_RELAY            26
#define PIN_BUZZER           27
#define PIN_LED              2

#define LEAKAGE_THRESHOLD_MA 30.0
#define ADC_RESOLUTION       4095
#define ADC_VREF             3.3
#define SAMPLE_WINDOW        50
#define SEND_INTERVAL_MS     3000
#define BUZZER_INTERVAL_MS   300

#define ZCT_SENSITIVITY_MV_PER_A 100.0

#endif
