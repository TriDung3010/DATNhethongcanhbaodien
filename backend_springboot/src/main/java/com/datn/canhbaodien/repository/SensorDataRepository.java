package com.datn.canhbaodien.repository;

import com.datn.canhbaodien.model.SensorData;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.time.Instant;
import java.util.List;

@Repository
public interface SensorDataRepository extends JpaRepository<SensorData, Long> {

    List<SensorData> findByDeviceIdOrderByTimestampDesc(String deviceId);

    List<SensorData> findByDeviceIdAndTimestampBetweenOrderByTimestampAsc(
            String deviceId, Instant start, Instant end);

    List<SensorData> findByAlertTrueOrderByTimestampDesc();

    List<SensorData> findTop20ByOrderByTimestampDesc();
}
