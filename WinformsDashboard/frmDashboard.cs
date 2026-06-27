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
using System.Threading.Tasks;
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

    private ObservableCollection<double> _chartValues;
    private BindingList<SensorData> _historyList;
    private bool _isAlerting = false;
    private int _packetCount = 0;

    private ISeries[] Series { get; set; }
    private Axis[] XAxes { get; set; }
    private Axis[] YAxes { get; set; }

    public frmDashboard()
    {
        InitializeComponent();

        _chartValues = new ObservableCollection<double>();

        Series = new ISeries[]
        {
            new LineSeries<double>
            {
                Values = _chartValues,
                Fill = new SolidColorPaint(new SKColor(0, 120, 212, 30)),
                Stroke = new SolidColorPaint(new SKColor(0, 120, 212)) { StrokeThickness = 2 },
                GeometryFill = new SolidColorPaint(SKColors.White),
                GeometryStroke = new SolidColorPaint(new SKColor(0, 120, 212)) { StrokeThickness = 2 },
                GeometrySize = 6,
                LineSmoothness = 0.3
            }
        };

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

        chartView.Series = Series;
        chartView.XAxes = XAxes;
        chartView.YAxes = YAxes;
        chartView.DrawMarginFrame = null;

        _historyList = new BindingList<SensorData>();
        dgvHistory.DataSource = _historyList;
    }

    private void frmDashboard_Load(object sender, EventArgs e)
    {
        ApplyGridStyling();
        StartHttpServer();
    }

    private void ApplyGridStyling()
    {
        if (dgvHistory.Columns.Count == 0) return;

        if (dgvHistory.Columns["DeviceId"] != null)
        {
            dgvHistory.Columns["DeviceId"].HeaderText = "Thi\u1ebft b\u1ecb";
            dgvHistory.Columns["DeviceId"].Width = 120;
        }
        if (dgvHistory.Columns["LeakageCurrent"] != null)
        {
            dgvHistory.Columns["LeakageCurrent"].HeaderText = "D\u00f2ng r\u00f2 (mA)";
            dgvHistory.Columns["LeakageCurrent"].DefaultCellStyle.Format = "F2";
            dgvHistory.Columns["LeakageCurrent"].Width = 100;
        }
        if (dgvHistory.Columns["Alert"] != null)
        {
            dgvHistory.Columns["Alert"].HeaderText = "C\u1ea3nh b\u00e1o";
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
            dgvHistory.Columns["Timestamp"].HeaderText = "Th\u1eddi gian nh\u1eadn";
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

            lblLog.Text = "\u2705 Server l\u1eafng nghe port 8080... Ch\u1edd ESP32 g\u1eedi d\u1eef li\u1ec7u.";
        }
        catch (HttpListenerException ex)
        {
            lblLog.Text = "\u274c L\u1ed7i: " + ex.Message;
            MessageBox.Show(
                "Kh\u00f4ng th\u1ec3 m\u1edf c\u1ed5ng 8080. H\u00e3y ch\u1ea1y d\u01b0\u1edbi quy\u1ec1n Administrator!\n\nL\u1ed7i chi ti\u1ebft: " + ex.Message,
                "L\u1ed7i Quy\u1ec1n Truy C\u1eadp",
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
                                _packetCount++;

                                this.Invoke((MethodInvoker)delegate
                                {
                                    ProcessIncomingData(data);
                                    lblLog.Text = $"\ud83d\udce6 G\u00f3i tin: {_packetCount} | Cu\u1ed1i: {DateTime.Now:HH:mm:ss} | {request.Url?.PathAndQuery}";
                                });
                            }
                        }
                        catch (Exception parseEx)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                lblLog.Text = "\u26a0\ufe0f L\u1ed7i parse JSON: " + parseEx.Message;
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

    private void ProcessIncomingData(SensorData data)
    {
        _historyList.Insert(0, data);
        if (_historyList.Count > 50)
            _historyList.RemoveAt(50);

        _chartValues.Add(data.LeakageCurrent);
        if (_chartValues.Count > 50)
            _chartValues.RemoveAt(0);

        lblCurrent.Text = data.LeakageCurrent.ToString("F2");
        lblPacketCount.Text = _packetCount.ToString();

        if (data.Alert)
        {
            if (!_isAlerting)
            {
                _isAlerting = true;
                pnlStatusCard.BackColor = Color.FromArgb(255, 235, 235);
                pnlStatusDot.BackColor = Color.FromArgb(209, 52, 56);
                lblStatus.Text = "C\u1ea2NH B\u00c1O R\u00d2 R\u1ec8!";
                lblStatus.ForeColor = Color.FromArgb(209, 52, 56);
                lblCurrent.ForeColor = Color.FromArgb(209, 52, 56);
                lblOnlineStatus.Text = "\u25cf C\u1ea3nh b\u00e1o!";
                lblOnlineStatus.ForeColor = Color.FromArgb(209, 52, 56);
                SystemSounds.Exclamation.Play();
            }
        }
        else
        {
            if (_isAlerting)
            {
                _isAlerting = false;
                pnlStatusCard.BackColor = Color.White;
                pnlStatusDot.BackColor = Color.FromArgb(46, 160, 67);
                lblStatus.Text = "B\u00ccNH TH\u01af\u1edcNG";
                lblStatus.ForeColor = Color.FromArgb(46, 160, 67);
                lblCurrent.ForeColor = Color.FromArgb(22, 27, 34);
                lblOnlineStatus.Text = "\u25cf \u0110ang ho\u1ea1t \u0111\u1ed9ng";
                lblOnlineStatus.ForeColor = Color.FromArgb(46, 160, 67);
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
