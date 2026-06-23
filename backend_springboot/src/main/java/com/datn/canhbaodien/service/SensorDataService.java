package com.datn.canhbaodien.service;

import com.datn.canhbaodien.dto.AlertEventDTO;
import com.datn.canhbaodien.dto.SensorDataDTO;
import com.datn.canhbaodien.model.AlertHistory;
import com.datn.canhbaodien.model.SensorData;
import com.datn.canhbaodien.repository.AlertHistoryRepository;
import com.datn.canhbaodien.repository.SensorDataRepository;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.time.format.DateTimeFormatter;
import java.time.format.DateTimeParseException;
import java.util.List;

@Service
public class SensorDataService {

    private static final double LEAKAGE_THRESHOLD_MA = 30.0;
    private static final String ALERT_TOPIC = "/topic/alert";

    private final SensorDataRepository sensorDataRepository;
    private final AlertHistoryRepository alertHistoryRepository;
    private final SimpMessagingTemplate messagingTemplate;

    public SensorDataService(SensorDataRepository sensorDataRepository,
                             AlertHistoryRepository alertHistoryRepository,
                             SimpMessagingTemplate messagingTemplate) {
        this.sensorDataRepository = sensorDataRepository;
        this.alertHistoryRepository = alertHistoryRepository;
        this.messagingTemplate = messagingTemplate;
    }

    public SensorData processSensorData(SensorDataDTO dto) {
        Instant timestamp = parseTimestamp(dto.getTimestamp());

        SensorData entity = new SensorData();
        entity.setDeviceId(dto.getDeviceId());
        entity.setLeakageCurrent(dto.getLeakageCurrent());
        entity.setUnit(dto.getUnit());
        entity.setAlert(dto.getAlert());
        entity.setRelayState(dto.getRelayState());
        entity.setTimestamp(timestamp);

        SensorData saved = sensorDataRepository.save(entity);

        if (Boolean.TRUE.equals(dto.getAlert())) {
            String severity = dto.getLeakageCurrent() >= LEAKAGE_THRESHOLD_MA * 2
                    ? "CRITICAL" : "WARNING";
            String message = String.format("Ro ri dien phat hien! Thiet bi: %s, Dong ro: %.1f mA",
                    dto.getDeviceId(), dto.getLeakageCurrent());

            AlertHistory alertLog = new AlertHistory(
                    dto.getDeviceId(), dto.getLeakageCurrent(), severity, message);
            alertLog.setRelayTriggered(!Boolean.TRUE.equals(dto.getRelayState()));
            alertHistoryRepository.save(alertLog);

            AlertEventDTO event = new AlertEventDTO(
                    dto.getDeviceId(), dto.getLeakageCurrent(),
                    severity, message, timestamp.toString());

            messagingTemplate.convertAndSend(ALERT_TOPIC, event);
        }

        return saved;
    }

    public List<SensorData> getLatestData() {
        return sensorDataRepository.findTop20ByOrderByTimestampDesc();
    }

    public List<AlertHistory> getAlertHistory() {
        return alertHistoryRepository.findTop50ByOrderByAlertTimeDesc();
    }

    private Instant parseTimestamp(String ts) {
        try {
            return Instant.parse(ts);
        } catch (DateTimeParseException e) {
            return Instant.now();
        }
    }
}
