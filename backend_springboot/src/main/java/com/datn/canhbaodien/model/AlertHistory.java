package com.datn.canhbaodien.model;

import jakarta.persistence.*;
import java.time.Instant;

@Entity
@Table(name = "alert_history")
public class AlertHistory {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "device_id", nullable = false, length = 50)
    private String deviceId;

    @Column(name = "leakage_current", nullable = false)
    private Double leakageCurrent;

    @Column(name = "severity", length = 20)
    private String severity = "CRITICAL";

    @Column(name = "message", length = 255)
    private String message;

    @Column(name = "relay_triggered")
    private Boolean relayTriggered = true;

    @Column(name = "acknowledged")
    private Boolean acknowledged = false;

    @Column(name = "alert_time", nullable = false)
    private Instant alertTime;

    @PrePersist
    protected void onCreate() {
        alertTime = Instant.now();
    }

    public AlertHistory() {}

    public AlertHistory(String deviceId, Double leakageCurrent, String severity, String message) {
        this.deviceId = deviceId;
        this.leakageCurrent = leakageCurrent;
        this.severity = severity;
        this.message = message;
    }

    public Long getId() { return id; }
    public void setId(Long id) { this.id = id; }

    public String getDeviceId() { return deviceId; }
    public void setDeviceId(String deviceId) { this.deviceId = deviceId; }

    public Double getLeakageCurrent() { return leakageCurrent; }
    public void setLeakageCurrent(Double leakageCurrent) { this.leakageCurrent = leakageCurrent; }

    public String getSeverity() { return severity; }
    public void setSeverity(String severity) { this.severity = severity; }

    public String getMessage() { return message; }
    public void setMessage(String message) { this.message = message; }

    public Boolean getRelayTriggered() { return relayTriggered; }
    public void setRelayTriggered(Boolean relayTriggered) { this.relayTriggered = relayTriggered; }

    public Boolean getAcknowledged() { return acknowledged; }
    public void setAcknowledged(Boolean acknowledged) { this.acknowledged = acknowledged; }

    public Instant getAlertTime() { return alertTime; }
    public void setAlertTime(Instant alertTime) { this.alertTime = alertTime; }
}
