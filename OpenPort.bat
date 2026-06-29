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

echo Dang mo cong 8080 tren Windows Firewall de ESP32 co the gui du lieu...
netsh advfirewall firewall add rule name="ESP32_IoT_8080" dir=in action=allow protocol=TCP localport=8080 profile=any
echo.
echo XONG! Cong 8080 da duoc mo. ESP32 bay gio da co the gui du lieu vao WinForms.
pause
