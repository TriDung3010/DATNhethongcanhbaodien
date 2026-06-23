package com.datn.canhbaodien.repository;

import com.datn.canhbaodien.model.AlertHistory;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface AlertHistoryRepository extends JpaRepository<AlertHistory, Long> {

    List<AlertHistory> findByDeviceIdOrderByAlertTimeDesc(String deviceId);

    List<AlertHistory> findTop50ByOrderByAlertTimeDesc();

    List<AlertHistory> findByAcknowledgedFalseOrderByAlertTimeDesc();
}
