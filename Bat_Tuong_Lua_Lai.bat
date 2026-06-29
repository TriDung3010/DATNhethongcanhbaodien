@echo off
:: Kiem tra quyen Admin
net session >nul 2>&1
if %errorLevel% == 0 (
    echo [OK] Dang chay voi quyen Admin.
) else (
    echo [LOI] Vui long bam CHUOT PHAI vao file nay va chon "Run as administrator".
    pause
    exit /b
)

echo DANG BAT LAI TUONG LUA WINDOWS...
netsh advfirewall set allprofiles state on
echo.
echo XONG! Tuong lua da duoc bat lai de bao mat cho may tinh.
pause
