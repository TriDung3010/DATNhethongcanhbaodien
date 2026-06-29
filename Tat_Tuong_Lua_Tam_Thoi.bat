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

echo DANG TAT TAM THOI TUONG LUA WINDOWS DE KIEM TRA...
netsh advfirewall set allprofiles state off
echo.
echo XONG! Tuong lua da tat. 
echo Bay gio anh hay mo lai phan mem WinForms va xem ESP32 co gui duoc du lieu khong nhe!
pause
