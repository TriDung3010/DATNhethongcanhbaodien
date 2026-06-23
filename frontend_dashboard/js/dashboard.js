const API_BASE = 'http://localhost:8080/api/v1';
const WS_URL = 'http://localhost:8080/ws';

let alertSoundEnabled = true;
let chart = null;
let chartData = [];
const MAX_DATA_POINTS = 50;

function formatDateTime(isoStr) {
    const d = new Date(isoStr);
    return d.toLocaleString('vi-VN', {
        hour: '2-digit', minute: '2-digit', second: '2-digit',
        day: '2-digit', month: '2-digit', year: 'numeric'
    });
}

function playAlertSound() {
    if (!alertSoundEnabled) return;
    try {
        const ctx = new (window.AudioContext || window.webkitAudioContext)();
        const osc = ctx.createOscillator();
        const gain = ctx.createGain();
        osc.connect(gain);
        gain.connect(ctx.destination);
        osc.type = 'square';
        osc.frequency.value = 880;
        gain.gain.setValueAtTime(0.3, ctx.currentTime);
        gain.gain.exponentialRampToValueAtTime(0.01, ctx.currentTime + 0.5);
        osc.start(ctx.currentTime);
        osc.stop(ctx.currentTime + 0.5);

        setTimeout(() => {
            const osc2 = ctx.createOscillator();
            const gain2 = ctx.createGain();
            osc2.connect(gain2);
            gain2.connect(ctx.destination);
            osc2.type = 'square';
            osc2.frequency.value = 660;
            gain2.gain.setValueAtTime(0.3, ctx.currentTime);
            gain2.gain.exponentialRampToValueAtTime(0.01, ctx.currentTime + 0.5);
            osc2.start(ctx.currentTime);
            osc2.stop(ctx.currentTime + 0.5);
        }, 200);
    } catch(e) {
        console.log('Sound not supported');
    }
}

function showAlertPopup(data) {
    document.getElementById('modalDeviceId').textContent = data.deviceId || 'N/A';
    document.getElementById('modalLeakage').textContent = (data.leakageCurrent || 0).toFixed(1) + ' mA';
    document.getElementById('modalThreshold').textContent = '30.0 mA';
    document.getElementById('modalTime').textContent = formatDateTime(data.timestamp || new Date().toISOString());
    document.getElementById('modalSeverity').textContent = data.severity || 'CRITICAL';

    const overlay = document.getElementById('alertOverlay');
    overlay.classList.add('show');
}

function dismissAlert() {
    document.getElementById('alertOverlay').classList.remove('show');
    document.body.classList.remove('alert-active');
}

function updateCurrentValues(data) {
    const val = document.getElementById('currentLeakage');
    val.textContent = (data.leakageCurrent || 0).toFixed(1);
    val.className = 'value' + (data.alert ? ' danger' : ' success');

    document.getElementById('currentDevice').textContent = data.deviceId || '---';
    document.getElementById('currentUnit').textContent = data.unit || 'mA';

    const relayBadge = document.getElementById('relayStatus');
    if (data.relayState === false) {
        relayBadge.innerHTML = '<span class="badge badge-danger">DA NGAT</span>';
    } else {
        relayBadge.innerHTML = '<span class="badge badge-success">DONG</span>';
    }
}

function updateChart(newValue) {
    const now = new Date();
    const label = now.toLocaleTimeString('vi-VN');
    chartData.push({ x: label, y: newValue });
    if (chartData.length > MAX_DATA_POINTS) chartData.shift();

    if (chart) {
        chart.data.labels = chartData.map(d => d.x);
        chart.data.datasets[0].data = chartData.map(d => d.y);
        chart.update('none');
    }
}

function addAlertRow(data) {
    const tbody = document.getElementById('alertTableBody');
    const tr = document.createElement('tr');
    tr.innerHTML = `
        <td>${data.deviceId || 'N/A'}</td>
        <td>${(data.leakageCurrent || 0).toFixed(1)} mA</td>
        <td><span class="badge badge-danger">RO RI</span></td>
        <td>${formatDateTime(data.timestamp || data.alertTime || new Date().toISOString())}</td>
    `;
    tbody.insertBefore(tr, tbody.firstChild);
    if (tbody.children.length > 50) tbody.removeChild(tbody.lastChild);
}

async function fetchLatestData() {
    try {
        const resp = await fetch(`${API_BASE}/sensor-data/latest`);
        const data = await resp.json();
        if (data.length > 0) {
            const latest = data[0];
            updateCurrentValues(latest);
            data.reverse().forEach(d => updateChart(d.leakageCurrent));
        }
    } catch(e) {
        console.log('Failed to fetch latest data');
    }
}

async function fetchAlertHistory() {
    try {
        const resp = await fetch(`${API_BASE}/alerts`);
        const data = await resp.json();
        data.forEach(row => addAlertRow(row));
    } catch(e) {
        console.log('Failed to fetch alerts');
    }
}

function initChart() {
    const ctx = document.getElementById('leakageChart').getContext('2d');
    chart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [],
            datasets: [{
                label: 'Dong ro (mA)',
                data: [],
                borderColor: '#1a237e',
                backgroundColor: 'rgba(26, 35, 126, 0.1)',
                borderWidth: 2,
                fill: true,
                tension: 0.3,
                pointRadius: 3,
                pointBackgroundColor: '#1a237e'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true,
                    title: { display: true, text: 'Dong dien (mA)' }
                },
                x: {
                    title: { display: true, text: 'Thoi gian' }
                }
            }
        }
    });
}

function connectWebSocket() {
    const socket = new SockJS(WS_URL);
    const stompClient = Stomp.over(socket);
    stompClient.debug = null;

    stompClient.connect({}, function(frame) {
        document.getElementById('wsStatus').className = 'status-dot connected';
        document.getElementById('wsStatusText').textContent = 'Da ket noi';

        stompClient.subscribe('/topic/alert', function(message) {
            const data = JSON.parse(message.body);
            console.log('Alert received:', data);

            updateCurrentValues(data);
            updateChart(data.leakageCurrent);
            addAlertRow(data);
            showAlertPopup(data);
            playAlertSound();

            document.body.classList.add('alert-active');
            setTimeout(() => document.body.classList.remove('alert-active'), 3000);
        });

        stompClient.subscribe('/topic/data', function(message) {
            const data = JSON.parse(message.body);
            updateCurrentValues(data);
            updateChart(data.leakageCurrent);
        });
    }, function(error) {
        document.getElementById('wsStatus').className = 'status-dot disconnected';
        document.getElementById('wsStatusText').textContent = 'Mat ket noi';
        setTimeout(connectWebSocket, 5000);
    });
}

document.addEventListener('DOMContentLoaded', function() {
    initChart();
    fetchLatestData();
    fetchAlertHistory();
    connectWebSocket();

    document.getElementById('dismissBtn').addEventListener('click', dismissAlert);

    document.getElementById('soundToggle').addEventListener('click', function() {
        alertSoundEnabled = !alertSoundEnabled;
        this.textContent = alertSoundEnabled ? 'Am thanh: ON' : 'Am thanh: OFF';
    });

    setInterval(fetchLatestData, 10000);
});
