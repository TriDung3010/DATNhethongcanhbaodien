@echo off
title DATN - Canh bao dien
echo ============================================
echo   HETHONG CANH BAO RO RI DIEN NANG
echo ============================================
echo.
echo [1] Kiem tra MySQL...
tasklist /FI "IMAGENAME eq mysqld.exe" 2>NUL | find /I "mysqld.exe" >NUL
if errorlevel 1 (
    echo MySQL chua chay. Dang khoi dong...
    start "MySQL" "C:\Program Files\MySQL\MySQL Server 8.4\bin\mysqld.exe" --datadir="C:\ProgramData\MySQL\MySQL Server 8.4\Data"
    timeout /t 3 >NUL
) else (
    echo MySQL dang chay.
)
echo.
echo [2] Khoi dong Backend (Spring Boot)...
start "Backend" cmd /c "cd /d D:\DATNcanhbaodien\backend_springboot && mvn spring-boot:run"
timeout /t 5 >NUL
echo.
echo [3] Khoi dong Frontend (Dashboard)...
start "Frontend" cmd /c "cd /d D:\DATNcanhbaodien\frontend_dashboard && node server.js"
timeout /t 2 >NUL
echo.
echo ============================================
echo   MO TRINH DUYET: http://localhost:3000
echo ============================================
start http://localhost:3000
echo.
pause
