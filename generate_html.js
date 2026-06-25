const fs = require('fs');

const leftPins = [
  "3V3", "EN", "SP", "SN", "G34", "G35", "G32", "G33", "G25", "G26", 
  "G27", "G14", "G12", "GND", "G13", "SD2", "SD3", "CMD", "V5"
];
const rightPins = [
  "GND", "G23", "G22", "TXD", "RXD", "G21", "GND", "G19", "G18", "G5", 
  "G17", "G16", "G4", "G0", "G2", "G15", "SD1", "SD0", "CLK"
];

// Color mapping for pins
const pinColors = {
  "3V3": "#86efac", // Xanh lá nhạt
  "V5": "#c2410c", // Cam đậm
  "GND": "#94a3b8", // Xám/Đen
  "G32": "#ef4444", // Đỏ
  "G14": "#f97316", // Cam
  "G12": "#eab308", // Vàng
  "G25": "#22c55e", // Xanh lá
  "G33": "#b91c1c", // Đỏ đậm
  "G26": "#a855f7", // Tím
  "G27": "#ea580c", // Cam sọc
  "G34": "#3b82f6", // Xanh dương
  "G35": "#06b6d4", // Xanh ngọc
  "G13": "#d8b4fe", // Tím nhạt
  "G19": "#7e22ce"  // Tím đậm
};

let svgLeftPins = '';
leftPins.forEach((pin, i) => {
  let cy = 130 + i * 30;
  let color = pinColors[pin] || "#cbd5e1";

  svgLeftPins += `
      <circle cx="0" cy="${cy}" r="4" fill="${color}"/>
      <text x="-15" y="${cy + 4}" fill="${color}">${pin}</text>`;
});

let svgRightPins = '';
rightPins.forEach((pin, i) => {
  let cy = 130 + i * 30;
  let color = pinColors[pin] || "#cbd5e1";

  svgRightPins += `
      <circle cx="180" cy="${cy}" r="4" fill="${color}"/>
      <text x="195" y="${cy + 4}" fill="${color}">${pin}</text>`;
});

// Generate markers
let markers = '';
for (const [pin, color] of Object.entries(pinColors)) {
  markers += `<marker id="arrow-${pin}" viewBox="0 0 10 10" refX="8" refY="5" markerWidth="5" markerHeight="5" orient="auto"><path d="M 0 0 L 10 5 L 0 10 z" fill="${color}"/></marker>\n`;
}

const html = `<!DOCTYPE html>
<html lang="vi">
<head>
<meta charset="UTF-8">
<title>Sơ đồ lắp đặt ESP32 - 38 Pin DevKit</title>
<style>
body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: #0f172a; color: #f8fafc; margin: 0; padding: 20px; }
h1 { text-align: center; color: #38bdf8; font-size: 24px; margin-bottom: 5px; text-transform: uppercase; letter-spacing: 1px; }
p.sub { text-align: center; color: #94a3b8; font-size: 14px; margin-bottom: 20px; }
.legend { display: flex; flex-wrap: wrap; gap: 20px; justify-content: center; margin: 20px 0 30px; background: #1e293b; padding: 15px; border-radius: 8px; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); }
.legend div { display: flex; align-items: center; gap: 8px; font-size: 13px; color: #cbd5e1; font-weight: 500; }
.lw { width: 30px; height: 4px; border-radius: 2px; }
svg { display: block; margin: auto; background: #1e293b; border-radius: 12px; box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1); }
.table-container { max-width: 1200px; margin: 40px auto; background: #1e293b; border-radius: 12px; overflow: hidden; box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1); }
h2 { color: #38bdf8; padding: 20px; margin: 0; border-bottom: 1px solid #334155; font-size: 18px; text-transform: uppercase; }
table { width: 100%; border-collapse: collapse; text-align: left; }
th, td { padding: 12px 20px; border-bottom: 1px solid #334155; }
th { background: #0f172a; color: #94a3b8; font-weight: 600; font-size: 13px; text-transform: uppercase; }
td { color: #cbd5e1; font-size: 14px; }
tr:last-child td { border-bottom: none; }
tr:hover td { background: #334155; }
.box { fill: #0f172a; stroke: #3b82f6; stroke-width: 2; rx: 6; }
.box-text-title { fill: #38bdf8; font-weight: bold; font-size: 13px; text-anchor: middle; }
.box-text-sub { fill: #94a3b8; font-size: 11px; text-anchor: middle; }
</style>
</head>
<body>
<h1>Sơ Đồ Lắp Đặt Hệ Thống - ESP32 38 PIN</h1>
<p class="sub">Được vẽ chính xác theo vị trí chân cắm của ESP-32 38 Pin (GND ở chân 14, VIN ở chân 19 bên trái)</p>
<div class="legend">
  <div><span class="lw" style="background:#ef4444"></span>Đỏ (LED 1)</div>
  <div><span class="lw" style="background:#f97316"></span>Cam (LED 2)</div>
  <div><span class="lw" style="background:#eab308"></span>Vàng (LED 3)</div>
  <div><span class="lw" style="background:#22c55e"></span>Xanh lá (LED Xanh)</div>
  <div><span class="lw" style="background:#b91c1c"></span>Đỏ đậm (LED Đỏ)</div>
  <div><span class="lw" style="background:#a855f7"></span>Tím (Relay)</div>
  <div><span class="lw" style="background:repeating-linear-gradient(45deg, #ea580c, #ea580c 5px, #1e293b 5px, #1e293b 10px);"></span>Cam sọc (Buzzer)</div>
  <div><span class="lw" style="background:#3b82f6"></span>Xanh dương (ZCT)</div>
  <div><span class="lw" style="background:#06b6d4"></span>Xanh ngọc (Biến trở)</div>
  <div><span class="lw" style="background:#d8b4fe"></span>Tím nhạt (Nút Rò rỉ)</div>
  <div><span class="lw" style="background:#7e22ce"></span>Tím đậm (Nút Reset)</div>
  <div><span class="lw" style="background:#86efac"></span>Xanh lá nhạt (3V3)</div>
  <div><span class="lw" style="background:#c2410c"></span>Cam đậm (5V)</div>
  <div><span class="lw" style="background:#94a3b8"></span>GND (Xám/Đen)</div>
</div>

<svg viewBox="0 0 1400 900" width="100%" xmlns="http://www.w3.org/2000/svg">
  <!-- Marker -->
  <defs>
    ${markers}
  </defs>

  <!-- ESP32 BOARD -->
  <g transform="translate(600, 50)">
    <rect x="0" y="0" width="180" height="740" rx="12" fill="#0f172a" stroke="#475569" stroke-width="3"/>
    
    <!-- Chip shield -->
    <rect x="30" y="200" width="120" height="130" rx="4" fill="#cbd5e1"/>
    <text x="90" y="260" text-anchor="middle" fill="#334155" font-size="18" font-weight="bold">ESP-32</text>
    <text x="90" y="280" text-anchor="middle" fill="#64748b" font-size="10">WIFI+BT SoC</text>
    
    <rect x="60" y="690" width="60" height="30" rx="3" fill="#64748b"/>
    <text x="90" y="710" text-anchor="middle" fill="#1e293b" font-size="10" font-weight="bold">USB</text>

    <!-- Left Pins -->
    <g font-size="11" text-anchor="end">${svgLeftPins}</g>

    <!-- Right Pins -->
    <g font-size="11" text-anchor="start">${svgRightPins}</g>
  </g>

  <!-- ================= LƯỚI NGUỒN ================= -->
  <!-- GND Bus cho Col 1 (x=30) -->
  <line x1="30" y1="280" x2="30" y2="760" stroke="${pinColors['GND']}" stroke-width="2"/>
  <!-- GND Bus cho Col 2 (x=270) -->
  <line x1="270" y1="250" x2="270" y2="760" stroke="${pinColors['GND']}" stroke-width="2"/>
  <!-- GND Ngang nối 2 bus tới chân ESP32 (GND là y=520+50 = 570) -->
  <line x1="30" y1="570" x2="600" y2="570" stroke="${pinColors['GND']}" stroke-width="2"/>
  <line x1="30" y1="760" x2="270" y2="760" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- 3.3V Bus (Chân 1 Left là y=130+50 = 180) -->
  <path d="M 600 180 L 100 180 L 100 330" fill="none" stroke="${pinColors['3V3']}" stroke-width="2" marker-start="url(#arrow-3V3)"/>
  
  <!-- ================= CỘT 2 (x=300) ================= -->
  <!-- ZCT (G34, y=250+50=300) -->
  <g transform="translate(300, 280)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G34']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G34']}">ZCT SCT-013</text>
    <text x="80" y="32" class="box-text-sub">Cảm biến dòng rò</text>
  </g>
  <path d="M 460 300 L 600 300" fill="none" stroke="${pinColors['G34']}" stroke-width="2" marker-end="url(#arrow-G34)"/>
  <line x1="300" y1="300" x2="270" y2="300" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- LED 1 (G32, y=310+50=360) -->
  <g transform="translate(300, 340)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G32']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G32']}">LED 1 (Phòng khách)</text>
    <text x="80" y="32" class="box-text-sub">+ Trở 220Ω</text>
  </g>
  <path d="M 600 360 L 460 360" fill="none" stroke="${pinColors['G32']}" stroke-width="2" marker-start="url(#arrow-G32)"/>
  <line x1="300" y1="360" x2="270" y2="360" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- LED Xanh (G25, y=370+50=420) -->
  <g transform="translate(300, 400)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G25']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G25']}">LED XANH (Bình thường)</text>
    <text x="80" y="32" class="box-text-sub">+ Trở 220Ω</text>
  </g>
  <path d="M 600 420 L 460 420" fill="none" stroke="${pinColors['G25']}" stroke-width="2" marker-start="url(#arrow-G25)"/>
  <line x1="300" y1="420" x2="270" y2="420" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- Buzzer (G27, y=430+50=480) -->
  <g transform="translate(300, 460)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G27']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G27']}">BUZZER</text>
    <text x="80" y="32" class="box-text-sub">Còi báo động</text>
  </g>
  <path d="M 600 480 L 460 480" fill="none" stroke="${pinColors['G27']}" stroke-width="2" stroke-dasharray="8,4" marker-start="url(#arrow-G27)"/>
  <line x1="300" y1="480" x2="270" y2="480" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- LED 3 (G12, y=490+50=540) -->
  <g transform="translate(300, 520)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G12']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G12']}">LED 3 (Quạt)</text>
    <text x="80" y="32" class="box-text-sub">+ Trở 220Ω</text>
  </g>
  <path d="M 600 540 L 460 540" fill="none" stroke="${pinColors['G12']}" stroke-width="2" marker-start="url(#arrow-G12)"/>
  <line x1="300" y1="540" x2="270" y2="540" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- Nút Rò rỉ (G13, y=550+50=600) -->
  <g transform="translate(300, 580)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G13']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G13']}">NÚT RÒ RỈ</text>
    <text x="80" y="32" class="box-text-sub">+ 10kΩ Pull-down</text>
  </g>
  <path d="M 460 600 L 600 600" fill="none" stroke="${pinColors['G13']}" stroke-width="2" marker-end="url(#arrow-G13)"/>
  <line x1="300" y1="600" x2="270" y2="600" stroke="${pinColors['GND']}" stroke-width="2"/>


  <!-- ================= CỘT 1 (x=50) ================= -->
  <!-- Dây cột 1 luồn qua khe giữa các hộp cột 2 một cách hoàn hảo! -->
  
  <!-- Biến trở (G35, y=280+50=330) -->
  <g transform="translate(50, 310)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G35']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G35']}">BIẾN TRỞ 10kΩ</text>
    <text x="80" y="32" class="box-text-sub">Chỉnh ngưỡng</text>
  </g>
  <path d="M 210 330 L 600 330" fill="none" stroke="${pinColors['G35']}" stroke-width="2" marker-end="url(#arrow-G35)"/>
  <line x1="50" y1="330" x2="30" y2="330" stroke="${pinColors['GND']}" stroke-width="2"/>
  <line x1="100" y1="310" x2="100" y2="330" stroke="${pinColors['3V3']}" stroke-width="2"/> <!-- Nối 3V3 -->

  <!-- LED Đỏ (G33, y=340+50=390) -->
  <g transform="translate(50, 370)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G33']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G33']}">LED ĐỎ (Báo động)</text>
    <text x="80" y="32" class="box-text-sub">+ Trở 220Ω</text>
  </g>
  <path d="M 600 390 L 210 390" fill="none" stroke="${pinColors['G33']}" stroke-width="2" marker-start="url(#arrow-G33)"/>
  <line x1="50" y1="390" x2="30" y2="390" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- Relay (G26, y=400+50=450) -->
  <g transform="translate(50, 430)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G26']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G26']}">RELAY MODULE</text>
    <text x="80" y="32" class="box-text-sub">Ngắt tải AC</text>
  </g>
  <path d="M 600 450 L 210 450" fill="none" stroke="${pinColors['G26']}" stroke-width="2" marker-start="url(#arrow-G26)"/>
  <line x1="50" y1="450" x2="30" y2="450" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- LED 2 (G14, y=460+50=510) -->
  <g transform="translate(50, 490)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G14']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G14']}">LED 2 (Bếp)</text>
    <text x="80" y="32" class="box-text-sub">+ Trở 220Ω</text>
  </g>
  <path d="M 600 510 L 210 510" fill="none" stroke="${pinColors['G14']}" stroke-width="2" marker-start="url(#arrow-G14)"/>
  <line x1="50" y1="510" x2="30" y2="510" stroke="${pinColors['GND']}" stroke-width="2"/>

  <!-- ================= COMPONENT RIGHT ================= -->
  <!-- Nút Reset (G19, Right Pin 8, y=340+50=390) -->
  <g transform="translate(900, 370)">
    <rect x="0" y="0" width="160" height="40" class="box" stroke="${pinColors['G19']}"/>
    <text x="80" y="16" class="box-text-title" fill="${pinColors['G19']}">NÚT RESET</text>
    <text x="80" y="32" class="box-text-sub">+ 10kΩ Pull-down</text>
  </g>
  <path d="M 900 390 L 780 390" fill="none" stroke="${pinColors['G19']}" stroke-width="2" marker-end="url(#arrow-G19)"/>
  
  <line x1="1060" y1="390" x2="1100" y2="390" stroke="${pinColors['GND']}" stroke-width="2"/>
  <line x1="1100" y1="390" x2="1100" y2="180" stroke="${pinColors['GND']}" stroke-width="2"/>
  <line x1="1100" y1="180" x2="780" y2="180" stroke="${pinColors['GND']}" stroke-width="2"/> <!-- Nối về GND chân 1 Right -->

  <!-- ================= POWER SUPPLY BOTTOM ================= -->
  <!-- V5 (Chân 19 Left, y=670+50=720) -->
  <g transform="translate(200, 700)">
    <rect x="0" y="0" width="140" height="40" class="box" stroke="${pinColors['V5']}"/>
    <text x="70" y="16" class="box-text-title" fill="${pinColors['V5']}">LM2596 DC-DC</text>
    <text x="70" y="32" class="box-text-sub">Hạ áp xuống 5V</text>
  </g>
  <path d="M 340 720 L 600 720" fill="none" stroke="${pinColors['V5']}" stroke-width="2" marker-end="url(#arrow-V5)"/>
  <line x1="270" y1="740" x2="270" y2="760" stroke="${pinColors['GND']}" stroke-width="2"/>
  <line x1="270" y1="740" x2="250" y2="740" stroke="${pinColors['GND']}" stroke-width="2"/>

  <g transform="translate(20, 700)">
    <rect x="0" y="0" width="120" height="40" class="box" stroke="#fbbf24"/>
    <text x="60" y="16" class="box-text-title" fill="#fcd34d">ADAPTER 12V</text>
    <text x="60" y="32" class="box-text-sub">Nguồn điện</text>
  </g>
  <line x1="140" y1="720" x2="200" y2="720" stroke="#fbbf24" stroke-width="2"/>
  <text x="170" y="715" text-anchor="middle" fill="#fbbf24" font-size="10">12V</text>
  <line x1="20" y1="720" x2="30" y2="720" stroke="${pinColors['GND']}" stroke-width="2"/>

</svg>

<div class="table-container">
  <h2>Bảng Nối Dây Chi Tiết - Bản chuẩn 38 Pin</h2>
  <table>
    <tr><th>Chân ESP32</th><th>Thành Phần</th><th>Mô Tả</th><th>Màu Dây Trên Sơ Đồ</th></tr>
    <tr><td>G32 (Trái)</td><td>LED 1 (+ Điện trở 220Ω)</td><td>Đèn phòng khách</td><td>Đỏ</td></tr>
    <tr><td>G14 (Trái)</td><td>LED 2 (+ Điện trở 220Ω)</td><td>Đèn bếp</td><td>Cam</td></tr>
    <tr><td>G12 (Trái)</td><td>LED 3 (+ Điện trở 220Ω)</td><td>Đèn quạt / Motor</td><td>Vàng</td></tr>
    <tr><td>G25 (Trái)</td><td>LED Xanh lá (+ 220Ω)</td><td>Báo hệ thống bình thường</td><td>Xanh lá</td></tr>
    <tr><td>G33 (Trái)</td><td>LED Đỏ (+ 220Ω)</td><td>Báo động rò rỉ điện</td><td>Đỏ đậm</td></tr>
    <tr><td>G26 (Trái)</td><td>Relay Module (IN)</td><td>Ngắt tải khi có rò rỉ</td><td>Tím</td></tr>
    <tr><td>G27 (Trái)</td><td>Buzzer (+)</td><td>Còi báo động</td><td>Cam sọc (nét đứt)</td></tr>
    <tr><td>G34 (Trái)</td><td>ZCT SCT-013 (OUT)</td><td>Đọc dòng rò rỉ thực tế</td><td>Xanh dương</td></tr>
    <tr><td>G35 (Trái)</td><td>Biến trở 10kΩ (Wiper)</td><td>Chỉnh ngưỡng mô phỏng</td><td>Xanh ngọc</td></tr>
    <tr><td>G13 (Trái)</td><td>Nút RÒ RỈ (+ 10kΩ Pull-down)</td><td>Bật/tắt mô phỏng rò rỉ</td><td>Tím nhạt</td></tr>
    <tr><td>G19 (Phải)</td><td>Nút RESET (+ 10kΩ Pull-down)</td><td>Reset cảnh báo</td><td>Tím đậm</td></tr>
    <tr><td>3V3 (Trái)</td><td>Nguồn VCC Biến trở</td><td>Nguồn cấp 3.3V</td><td>Xanh lá nhạt</td></tr>
    <tr><td>V5 (Trái dưới)</td><td>Nguồn OUT 5V từ LM2596</td><td>Cấp nguồn nuôi ESP32</td><td>Cam đậm</td></tr>
    <tr><td>GND</td><td>GND toàn hệ thống</td><td>Mass chung (0V)</td><td>Xám/Đen</td></tr>
  </table>
</div>

</body>
</html>
`;
fs.writeFileSync('so-do-lap-dat.html', html);
