package com.datn.canhbaodien.dto;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;

public class SensorDataDTO {

    @NotBlank(message = "deviceId is required")
    private String deviceId;

    @NotNull(message = "leakageCurrent is required")
    private Double leakageCurrent;

    private String unit = "mA";

    @NotNull(message = "alert is required")
    private Boolean alert;

    private Boolean relayState = true;

    @NotBlank(message = "timestamp is required")
    private String timestamp;

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

    public String getTimestamp() { return timestamp; }
    public void setTimestamp(String timestamp) { this.timestamp = timestamp; }
}
