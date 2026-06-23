package com.datn.canhbaodien.dto;

public class AlertEventDTO {

    private String deviceId;
    private Double leakageCurrent;
    private String severity;
    private String message;
    private String timestamp;

    public AlertEventDTO() {}

    public AlertEventDTO(String deviceId, Double leakageCurrent, String severity, String message, String timestamp) {
        this.deviceId = deviceId;
        this.leakageCurrent = leakageCurrent;
        this.severity = severity;
        this.message = message;
        this.timestamp = timestamp;
    }

    public String getDeviceId() { return deviceId; }
    public void setDeviceId(String deviceId) { this.deviceId = deviceId; }

    public Double getLeakageCurrent() { return leakageCurrent; }
    public void setLeakageCurrent(Double leakageCurrent) { this.leakageCurrent = leakageCurrent; }

    public String getSeverity() { return severity; }
    public void setSeverity(String severity) { this.severity = severity; }

    public String getMessage() { return message; }
    public void setMessage(String message) { this.message = message; }

    public String getTimestamp() { return timestamp; }
    public void setTimestamp(String timestamp) { this.timestamp = timestamp; }
}
