#ifndef CONFIG_H
#define CONFIG_H

#define WIFI_SSID              "Nha Bui"
#define WIFI_PASSWORD          "1den9@@@"

#define SERVER_URL             "http://192.168.1.145:8080/api/v1/sensor-data"
#define DEVICE_ID              "ESP32_NHA_MO_HINH"

#define PIN_ZCT                34
#define PIN_POT                35
#define PIN_RELAY              26
#define PIN_BUZZER             27
#define PIN_LED                2

#define LEAKAGE_THRESHOLD_MA   30.0
#define ADC_RESOLUTION         4095
#define ADC_VREF               3.3

#define SEND_INTERVAL_MS       3000

#endif
