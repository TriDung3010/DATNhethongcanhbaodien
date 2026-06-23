package com.datn.canhbaodien.controller;

import com.datn.canhbaodien.dto.SensorDataDTO;
import com.datn.canhbaodien.model.AlertHistory;
import com.datn.canhbaodien.model.SensorData;
import com.datn.canhbaodien.service.SensorDataService;
import jakarta.validation.Valid;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api/v1")
public class SensorDataController {

    private final SensorDataService sensorDataService;

    public SensorDataController(SensorDataService sensorDataService) {
        this.sensorDataService = sensorDataService;
    }

    @PostMapping("/sensor-data")
    public ResponseEntity<Map<String, Object>> receiveSensorData(
            @Valid @RequestBody SensorDataDTO dto) {
        SensorData saved = sensorDataService.processSensorData(dto);
        return ResponseEntity.ok(Map.of(
                "status", "ok",
                "id", saved.getId(),
                "alert", saved.getAlert()
        ));
    }

    @GetMapping("/sensor-data/latest")
    public ResponseEntity<List<SensorData>> getLatestData() {
        return ResponseEntity.ok(sensorDataService.getLatestData());
    }

    @GetMapping("/alerts")
    public ResponseEntity<List<AlertHistory>> getAlertHistory() {
        return ResponseEntity.ok(sensorDataService.getAlertHistory());
    }
}
