using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WinformsDashboard.DataAccess;
using WinformsDashboard.Models;

namespace WinformsDashboard.Services
{
    /// <summary>
    /// IoT Service dùng TcpListener (không cần quyền Administrator).
    /// Lắng nghe HTTP POST từ ESP32 trên cổng 8080.
    /// </summary>
    public class IoTService
    {
        public static IoTService Instance { get; } = new IoTService();

        private TcpListener? _listener;
        private bool _isRunning;
        private readonly SensorDataRepository _sensorRepo = new SensorDataRepository();
        private readonly AlertRepository _alertRepo = new AlertRepository();
        private readonly DeviceRepository _deviceRepo = new DeviceRepository();

        // Events bắn ra GUI mỗi khi có data mới
        public event EventHandler<SensorData>? OnDataReceived;
        public event EventHandler<Alert>?      OnAlertTriggered;
        /// <summary>Log kết nối TCP và lỗi — để Dashboard hiển thị trạng thái nhận data</summary>
        public event EventHandler<string>?     OnConnectionLog;

        private IoTService() { }

        public void StartService(string port = "8080")
        {
            try
            {
                int portNumber = int.Parse(port);
                // Bind 0.0.0.0 để nhận từ mọi IP (bao gồm cả ESP32 qua WiFi)
                _listener = new TcpListener(IPAddress.Any, portNumber);
                _listener.Start();
                _isRunning = true;
                // Chạy vòng lặp nhận request ở background thread
                Task.Run(() => AcceptLoop());
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể khởi động IoT Service trên cổng {port}. Lỗi: {ex.Message}");
            }
        }

        public void StopService()
        {
            _isRunning = false;
            try { _listener?.Stop(); } catch { }
        }

        private async Task AcceptLoop()
        {
            while (_isRunning)
            {
                try
                {
                    if (_listener == null) break;
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    // Xử lý mỗi kết nối trên thread riêng để không block
                    _ = Task.Run(() => HandleClient(client));
                }
                catch (SocketException)
                {
                    // Bình thường khi Stop() được gọi
                    break;
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi không xác định, tiếp tục nhận
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                {
                    stream.ReadTimeout = 5000; // 5 giây timeout

                    // Đọc lần 1: buffer lớn, thường đủ cả headers + body từ ESP32 (request < 300 bytes)
                    byte[] buffer = new byte[8192];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string rawRequest = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Nếu chưa có đủ body, đọc thêm dựa trên Content-Length
                    int sepIdx = rawRequest.IndexOf("\r\n\r\n", StringComparison.Ordinal);
                    if (sepIdx < 0) sepIdx = rawRequest.IndexOf("\n\n", StringComparison.Ordinal);

                    if (sepIdx >= 0)
                    {
                        var clMatch = System.Text.RegularExpressions.Regex.Match(
                            rawRequest, @"Content-Length:\s*(\d+)",
                            System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                        if (clMatch.Success && int.TryParse(clMatch.Groups[1].Value, out int contentLength))
                        {
                            int headerSize  = rawRequest.Contains("\r\n\r\n") ? sepIdx + 4 : sepIdx + 2;
                            int bodyReceived = rawRequest.Length - headerSize;

                            // Đọc thêm nếu body chưa đủ (hiếm khi xảy ra với ESP32)
                            while (bodyReceived < contentLength)
                            {
                                int more = stream.Read(buffer, 0, buffer.Length);
                                if (more == 0) break;
                                rawRequest   += Encoding.UTF8.GetString(buffer, 0, more);
                                bodyReceived += more;
                            }
                        }
                    }

                    if (string.IsNullOrWhiteSpace(rawRequest))
                    {
                        OnConnectionLog?.Invoke(this, "❌ Kết nối rỗng");
                        return;
                    }

                    // Lấy phần body JSON
                    string json = ExtractBody(rawRequest);
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        OnConnectionLog?.Invoke(this, $"❌ Không có body JSON | Raw: {rawRequest[..Math.Min(100, rawRequest.Length)]}");
                        SendOkResponse(stream);
                        return;
                    }

                    ProcessJson(json);
                    SendOkResponse(stream);
                }
            }
            catch (System.IO.IOException ioEx)
            {
                OnConnectionLog?.Invoke(this, $"❌ Lỗi đọc TCP: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                OnConnectionLog?.Invoke(this, $"❌ Lỗi client: {ex.Message}");
            }
        }


        private string ExtractBody(string rawRequest)
        {
            // HTTP header và body cách nhau bởi \r\n\r\n
            int separatorIndex = rawRequest.IndexOf("\r\n\r\n", StringComparison.Ordinal);
            if (separatorIndex < 0)
            {
                // Thử tìm \n\n (một số client dùng)
                separatorIndex = rawRequest.IndexOf("\n\n", StringComparison.Ordinal);
                if (separatorIndex < 0) return string.Empty;
                return rawRequest.Substring(separatorIndex + 2).Trim();
            }
            return rawRequest.Substring(separatorIndex + 4).Trim();
        }

        private void SendOkResponse(NetworkStream stream)
        {
            string body = "{\"status\":\"ok\"}";
            string response =
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: application/json\r\n" +
                $"Content-Length: {Encoding.UTF8.GetByteCount(body)}\r\n" +
                "Connection: close\r\n" +
                "\r\n" +
                body;
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);
        }

        private void ProcessJson(string json)
        {
            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                string deviceIdStr = root.TryGetProperty("deviceId", out var did)
                    ? (did.GetString() ?? "ESP32_NHA_MO_HINH")
                    : "ESP32_NHA_MO_HINH";

                double voltage  = root.TryGetProperty("voltage",        out var vol)  ? vol.GetDouble()  : 220;
                double current  = root.TryGetProperty("current",        out var cur)  ? cur.GetDouble()  : 0;
                double leakage  = root.TryGetProperty("leakageCurrent", out var leak) ? leak.GetDouble() : 0;

                // Tìm Device trong DB bằng DeviceCode
                var device    = _deviceRepo.GetDeviceByCode(deviceIdStr);
                int dbDeviceId = device?.DeviceID ?? 1;

                var sensorData = new SensorData
                {
                    DeviceID       = dbDeviceId,
                    Voltage        = voltage,
                    CurrentValue   = current,
                    LeakageCurrent = leakage,
                    CreatedAt      = DateTime.Now
                };

                // Lưu vào DB
                _sensorRepo.AddSensorData(sensorData);

                // Trigger Event cập nhật giao diện realtime
                OnDataReceived?.Invoke(this, sensorData);
                OnConnectionLog?.Invoke(this, $"✅ Đã nhận: {leakage:F1} mA từ [{deviceIdStr}]");

                // Xử lý Cảnh báo (Ngưỡng 30mA)
                if (leakage > 30.0)
                {
                    var alert = new Alert
                    {
                        DeviceID       = dbDeviceId,
                        LeakageCurrent = leakage,
                        AlertLevel     = "High",
                        Description    = $"Dòng rò vượt ngưỡng nguy hiểm ({leakage:F1}mA)!",
                        AlertTime      = DateTime.Now,
                        IsResolved     = false
                    };
                    _alertRepo.AddAlert(alert);
                    OnAlertTriggered?.Invoke(this, alert);
                }
            }
            catch (JsonException jex)
            {
                OnConnectionLog?.Invoke(this, $"❌ JSON lỗi: {jex.Message} | Raw: {json[..Math.Min(80, json.Length)]}");
            }
            catch (Exception ex)
            {
                OnConnectionLog?.Invoke(this, $"❌ Lỗi xử lý: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
