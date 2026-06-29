-- =======================================================
-- Tên dự án: Hệ Thống Cảnh Báo Rò Rỉ Điện IoT
-- DBMS: SQL Server
-- =======================================================

CREATE DATABASE IoTLeakageDB;
GO

USE IoTLeakageDB;
GO

-- 1. Bảng Users (Tài khoản người dùng)
CREATE TABLE Users
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL DEFAULT 'User' -- 'Admin' hoặc 'User'
);
GO

-- Insert 1 tài khoản Admin mặc định (mật khẩu: admin123)
-- Hash bằng BCrypt: $2a$11$F... (Tạm dùng mã giả, ứng dụng sẽ hash lại sau)
INSERT INTO Users (Username, PasswordHash, Role)
VALUES ('admin', '$2a$11$wK1F5N8Kk.zF0z9tE.9F/el.mG5Jq7o1M.jD4/g9cM/0aU9/z/KjG', 'Admin');
GO

-- 2. Bảng Devices (Quản lý thiết bị ESP32)
CREATE TABLE Devices
(
    DeviceID INT IDENTITY(1,1) PRIMARY KEY,
    DeviceCode NVARCHAR(20) NOT NULL UNIQUE,
    DeviceName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100),
    IPAddress NVARCHAR(50),
    Status NVARCHAR(20) DEFAULT 'Online'
);
GO

-- Insert thiết bị mô hình tĩnh
INSERT INTO Devices (DeviceCode, DeviceName, Location, IPAddress, Status)
VALUES ('ESP32_NHA_MO_HINH', 'Thiết bị Phòng Khách', 'Phòng Khách', '192.168.1.100', 'Online');
GO

-- 3. Bảng SensorData (Lịch sử dữ liệu cảm biến)
CREATE TABLE SensorData
(
    DataID INT IDENTITY(1,1) PRIMARY KEY,
    DeviceID INT NOT NULL,
    Voltage FLOAT DEFAULT 220,
    CurrentValue FLOAT NOT NULL,
    LeakageCurrent FLOAT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DeviceID) REFERENCES Devices(DeviceID) ON DELETE CASCADE
);
GO

-- 4. Bảng Alerts (Danh sách các lần cảnh báo)
CREATE TABLE Alerts
(
    AlertID INT IDENTITY(1,1) PRIMARY KEY,
    DeviceID INT NOT NULL,
    LeakageCurrent FLOAT NOT NULL,
    AlertLevel NVARCHAR(50) DEFAULT 'High',
    Description NVARCHAR(255),
    AlertTime DATETIME DEFAULT GETDATE(),
    IsResolved BIT DEFAULT 0,
    FOREIGN KEY (DeviceID) REFERENCES Devices(DeviceID) ON DELETE CASCADE
);
GO

-- 5. Bảng ElectricityConfig
CREATE TABLE ElectricityConfig
(
    ConfigID INT PRIMARY KEY IDENTITY,
    ElectricityPrice FLOAT,
    UpdatedAt DATETIME DEFAULT GETDATE()
);
GO

INSERT INTO ElectricityConfig (ElectricityPrice) VALUES (3000);
GO

-- 6. Bảng PowerLossHistory
CREATE TABLE PowerLossHistory
(
    LossID INT PRIMARY KEY IDENTITY,
    DeviceID INT,
    Voltage FLOAT,
    LeakageCurrent FLOAT,
    PowerLoss FLOAT,
    EnergyLoss FLOAT,
    CostLoss FLOAT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DeviceID) REFERENCES Devices(DeviceID) ON DELETE CASCADE
);
GO
