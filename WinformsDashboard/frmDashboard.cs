using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Newtonsoft.Json;
using SkiaSharp;

namespace WinformsDashboard;

public partial class frmDashboard : Form
{
    private HttpListener _listener;
    private Thread _listenerThread;
    private bool _isListening = false;

    private BindingList<SensorData> _historyList;
    private int _packetCount = 0;

    // Dictionary to manage multiple rooms
    private Dictionary<string, RoomConfig> _roomConfigs;
    private Dictionary<string, ObservableCollection<double>> _roomChartValues;
    private ObservableCollection<ISeries> _chartSeries;
    private Dictionary<string, Panel> _roomCards;
    private Dictionary<string, bool> _roomAlerts;

    private Axis[] XAxes { get; set; }
    private Axis[] YAxes { get; set; }

    public frmDashboard()
    {
        InitializeComponent();

        LoadRoomConfigs();

        _roomChartValues = new Dictionary<string, ObservableCollection<double>>();
        _chartSeries = new ObservableCollection<ISeries>();
        _roomCards = new Dictionary<string, Panel>();
        _roomAlerts = new Dictionary<string, bool>();

        XAxes = new Axis[]
        {
            new Axis
            {
                IsVisible = false,
                ShowSeparatorLines = false
            }
        };

        YAxes = new Axis[]
        {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 100,
                TextSize = 10,
                LabelsPaint = new SolidColorPaint(new SKColor(140, 140, 140)),
                SeparatorsPaint = new SolidColorPaint(new SKColor(230, 232, 235)) { StrokeThickness = 1 }
            }
        };

        chartView.Series = _chartSeries;
        chartView.XAxes = XAxes;
        chartView.YAxes = YAxes;
        chartView.DrawMarginFrame = null;

        _historyList = new BindingList<SensorData>();
        dgvHistory.DataSource = _historyList;

        // Bắt sự kiện cho các nút Sidebar
        btnDashboard.Click += (s, e) => { /* Đang ở Dashboard rồi */ };
        btnHistory.Click += (s, e) => { MessageBox.Show("Tính năng Lịch sử chi tiết đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); };
        btnSettings.Click += (s, e) => {
            frmRoomManager frm = new frmRoomManager();
            frm.ShowDialog();
            // Tải lại config sau khi đóng form
            LoadRoomConfigs();
            // Cập nhật lại UI cho các phòng đã hiển thị
            foreach (var kvp in _roomCards)
            {
                var deviceId = kvp.Key;
                var card = kvp.Value;
                Label lblTitle = (Label)card.Controls["lblTitle"];
                if (lblTitle != null)
                {
                    lblTitle.Text = _roomConfigs.ContainsKey(deviceId) ? _roomConfigs[deviceId].RoomName : deviceId;
                }
            }
        };
    }

    private void LoadRoomConfigs()
    {
        _roomConfigs = new Dictionary<string, RoomConfig>();
        var rooms = RoomManager.LoadRooms();
        foreach (var r in rooms)
        {
            if (!string.IsNullOrEmpty(r.DeviceId))
            {
                _roomConfigs[r.DeviceId] = r;
            }
        }
    }

    private void frmDashboard_Load(object sender, EventArgs e)
    {
        flpCards.Controls.Clear(); // Clear default cards, we will add Room Cards dynamically
        flpCards.AutoScroll = true;

        ApplyGridStyling();
        StartHttpServer();
    }

    private void ApplyGridStyling()
    {
        if (dgvHistory.Columns.Count == 0) return;

        if (dgvHistory.Columns["DeviceId"] != null)
        {
            dgvHistory.Columns["DeviceId"].HeaderText = "Thiết bị / Khu vực";
            dgvHistory.Columns["DeviceId"].Width = 140;
        }
        if (dgvHistory.Columns["LeakageCurrent"] != null)
        {
            dgvHistory.Columns["LeakageCurrent"].HeaderText = "Dòng rò (mA)";
            dgvHistory.Columns["LeakageCurrent"].DefaultCellStyle.Format = "F2";
            dgvHistory.Columns["LeakageCurrent"].Width = 100;
        }
        if (dgvHistory.Columns["Alert"] != null)
        {
            dgvHistory.Columns["Alert"].HeaderText = "Cảnh báo";
            dgvHistory.Columns["Alert"].Width = 80;
        }
        if (dgvHistory.Columns["RelayState"] != null)
        {
            dgvHistory.Columns["RelayState"].HeaderText = "Relay";
            dgvHistory.Columns["RelayState"].Width = 60;
        }
        if (dgvHistory.Columns["EspTimestamp"] != null)
        {
            dgvHistory.Columns["EspTimestamp"].HeaderText = "Timestamp ESP";
            dgvHistory.Columns["EspTimestamp"].Width = 100;
        }
        if (dgvHistory.Columns["Timestamp"] != null)
        {
            dgvHistory.Columns["Timestamp"].HeaderText = "Thời gian nhận";
            dgvHistory.Columns["Timestamp"].DefaultCellStyle.Format = "HH:mm:ss dd/MM";
            dgvHistory.Columns["Timestamp"].Width = 120;
        }
    }

    private void StartHttpServer()
    {
        try
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://+:8080/");
            _listener.Start();
            _isListening = true;

            _listenerThread = new Thread(ListenLoop);
            _listenerThread.IsBackground = true;
            _listenerThread.Start();

            lblLog.Text = "✅ Server lắng nghe port 8080... Chờ ESP32 gửi dữ liệu từ các khu vực.";
        }
        catch (HttpListenerException ex)
        {
            lblLog.Text = "❌ Lỗi: " + ex.Message;
            MessageBox.Show(
                "Không thể mở cổng 8080. Hãy chạy dưới quyền Administrator!\n\nLỗi chi tiết: " + ex.Message,
                "Lỗi Quyền Truy Cập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void ListenLoop()
    {
        while (_isListening)
        {
            try
            {
                var context = _listener.GetContext();
                var request = context.Request;
                var response = context.Response;

                if (request.HttpMethod == "POST")
                {
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        var json = reader.ReadToEnd();

                        try
                        {
                            var data = JsonConvert.DeserializeObject<SensorData>(json);
                            if (data != null)
                            {
                                data.Timestamp = DateTime.Now;
                                if (string.IsNullOrEmpty(data.DeviceId)) data.DeviceId = "UNKNOWN_ROOM";
                                
                                _packetCount++;

                                this.Invoke((MethodInvoker)delegate
                                {
                                    ProcessIncomingData(data);
                                    string displayName = _roomConfigs.ContainsKey(data.DeviceId) ? _roomConfigs[data.DeviceId].RoomName : data.DeviceId;
                                    lblLog.Text = $"📦 Gói tin: {_packetCount} | Cuối: {DateTime.Now:HH:mm:ss} | {displayName} ({data.LeakageCurrent:F2}mA)";
                                });
                            }
                        }
                        catch (Exception parseEx)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                lblLog.Text = "⚠️ Lỗi parse JSON: " + parseEx.Message;
                            });
                        }
                    }
                }

                response.StatusCode = 200;
                string responseString = "{\"status\":\"ok\"}";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                if (_isListening)
                {
                    Console.WriteLine("Listener Error: " + ex.Message);
                }
            }
        }
    }

    private void EnsureRoomExists(string deviceId)
    {
        if (!_roomChartValues.ContainsKey(deviceId))
        {
            // 1. Setup Chart Series for this Room
            var newValues = new ObservableCollection<double>();
            _roomChartValues[deviceId] = newValues;

            var random = new Random();
            byte r = (byte)random.Next(50, 200);
            byte g = (byte)random.Next(50, 200);
            byte b = (byte)random.Next(50, 200);

            string roomName = _roomConfigs.ContainsKey(deviceId) ? _roomConfigs[deviceId].RoomName : deviceId;
            var lineSeries = new LineSeries<double>
            {
                Name = roomName,
                Values = newValues,
                Fill = null,
                Stroke = new SolidColorPaint(new SKColor(r, g, b)) { StrokeThickness = 2 },
                GeometryFill = new SolidColorPaint(SKColors.White),
                GeometryStroke = new SolidColorPaint(new SKColor(r, g, b)) { StrokeThickness = 2 },
                GeometrySize = 6,
                LineSmoothness = 0.3
            };
            _chartSeries.Add(lineSeries);

            // 2. Setup Room Card in UI
            Panel roomCard = new Panel
            {
                BackColor = Color.White,
                Size = new Size(220, 72),
                Margin = new Padding(0, 0, 12, 12),
                Name = "pnl" + deviceId
            };

            Label lblTitle = new Label
            {
                Text = _roomConfigs.ContainsKey(deviceId) ? _roomConfigs[deviceId].RoomName : deviceId,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 110, 120),
                Location = new Point(14, 8),
                AutoSize = true,
                Name = "lblTitle"
            };

            Label lblCurrent = new Label
            {
                Text = "0.00",
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 27, 34),
                Location = new Point(14, 20),
                AutoSize = true,
                Name = "lblCurrent"
            };

            Label lblUnit = new Label
            {
                Text = "mA",
                Font = new Font("Segoe UI", 14, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 110, 120),
                Location = new Point(110, 38),
                AutoSize = true
            };

            Panel pnlDot = new Panel
            {
                BackColor = Color.FromArgb(46, 160, 67),
                Size = new Size(16, 16),
                Location = new Point(190, 10),
                Name = "pnlDot"
            };

            roomCard.Controls.Add(lblTitle);
            roomCard.Controls.Add(lblCurrent);
            roomCard.Controls.Add(lblUnit);
            roomCard.Controls.Add(pnlDot);

            _roomCards[deviceId] = roomCard;
            _roomAlerts[deviceId] = false;
            flpCards.Controls.Add(roomCard);
        }
    }

    private void ProcessIncomingData(SensorData data)
    {
        EnsureRoomExists(data.DeviceId);

        // Update History
        _historyList.Insert(0, data);
        if (_historyList.Count > 50)
            _historyList.RemoveAt(50);

        // Update Chart
        var values = _roomChartValues[data.DeviceId];
        values.Add(data.LeakageCurrent);
        if (values.Count > 50)
            values.RemoveAt(0);

        // Update UI Card
        Panel card = _roomCards[data.DeviceId];
        Label lblCurrent = (Label)card.Controls["lblCurrent"];
        Panel pnlDot = (Panel)card.Controls["pnlDot"];

        lblCurrent.Text = data.LeakageCurrent.ToString("F2");

        // Handle Alert
        bool currentlyAlerting = _roomAlerts[data.DeviceId];
        if (data.Alert)
        {
            if (!currentlyAlerting)
            {
                _roomAlerts[data.DeviceId] = true;
                card.BackColor = Color.FromArgb(255, 235, 235);
                pnlDot.BackColor = Color.FromArgb(209, 52, 56);
                lblCurrent.ForeColor = Color.FromArgb(209, 52, 56);
                SystemSounds.Exclamation.Play();
                
                // Update Global Status if any room is alerting
                lblOnlineStatus.Text = "● Cảnh báo rò rỉ!";
                lblOnlineStatus.ForeColor = Color.FromArgb(209, 52, 56);
            }
        }
        else
        {
            if (currentlyAlerting)
            {
                _roomAlerts[data.DeviceId] = false;
                card.BackColor = Color.White;
                pnlDot.BackColor = Color.FromArgb(46, 160, 67);
                lblCurrent.ForeColor = Color.FromArgb(22, 27, 34);
                
                // Check if all rooms are safe
                if (!_roomAlerts.Values.Any(a => a))
                {
                    lblOnlineStatus.Text = "● Đang hoạt động";
                    lblOnlineStatus.ForeColor = Color.FromArgb(46, 160, 67);
                }
            }
        }
    }

    private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
    {
        _isListening = false;
        if (_listener != null && _listener.IsListening)
        {
            _listener.Stop();
            _listener.Close();
        }
    }
}

public class SensorData
{
    public string DeviceId { get; set; } = "";
    public double LeakageCurrent { get; set; }
    public bool Alert { get; set; }
    public bool RelayState { get; set; }

    [Newtonsoft.Json.JsonProperty("timestamp")]
    public string? EspTimestamp { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    public DateTime Timestamp { get; set; }
}
