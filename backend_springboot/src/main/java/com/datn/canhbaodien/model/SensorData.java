package com.datn.canhbaodien.model;

import jakarta.persistence.*;
import java.time.Instant;

@Entity
@Table(name = "sensor_data")
public class SensorData {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "device_id", nullable = false, length = 50)
    private String deviceId;

    @Column(name = "leakage_current", nullable = false)
    private Double leakageCurrent;

    @Column(name = "unit", length = 10)
    private String unit = "mA";

    @Column(name = "alert", nullable = false)
    private Boolean alert = false;

    @Column(name = "relay_state")
    private Boolean relayState = true;

    @Column(name = "timestamp", nullable = false)
    private Instant timestamp;

    @Column(name = "created_at")
    private Instant createdAt;

    @PrePersist
    protected void onCreate() {
        createdAt = Instant.now();
    }

    public SensorData() {}

    public Long getId() { return id; }
    public void setId(Long id) { this.id = id; }

    public String getDeviceId() { return deviceId; }
    public void setDeviceId(String deviceId) { this.deviceId = deviceId; }

    public Double getLeakageCurrent() { return leakageCurrent; }
    public void setLeakageCurrent(Double leakageCurrent) { this.leakageCurrent = leakageCurrent; }

    public String getUnit() { return unit; }
    public void setUnit(String unit) { this.unit = unit; }

    public Boolean getAlert() { return alert; }
    public void setAlert(Boolean alert) { this.alert = alert; }

    public Boolean getRelayState() { return relayState; }
    public void setRelayState(Boolean relayState) { this.relayState = relayState; }

    public Instant getTimestamp() { return timestamp; }
    public void setTimestamp(Instant timestamp) { this.timestamp = timestamp; }

    public Instant getCreatedAt() { return createdAt; }
    public void setCreatedAt(Instant createdAt) { this.createdAt = createdAt; }
}
