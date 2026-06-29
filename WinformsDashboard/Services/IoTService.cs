using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WinformsDashboard.DataAccess;
using WinformsDashboard.Models;

namespace WinformsDashboard.Services
{
    public class IoTService
    {
        public static IoTService Instance { get; } = new IoTService();
        
        private HttpListener? _listener;
        private bool _isRunning;
        private readonly SensorDataRepository _sensorRepo = new SensorDataRepository();
        private readonly AlertRepository _alertRepo = new AlertRepository();
        private readonly DeviceRepository _deviceRepo = new DeviceRepository();

        // Event bắn ra GUI mỗi khi có data mới
        public event EventHandler<SensorData>? OnDataReceived;
        public event EventHandler<Alert>? OnAlertTriggered;

        public void StartService(string port = "8080")
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://+:{port}/");
            try
            {
                _listener.Start();
                _isRunning = true;
                Task.Run(() => ListenLoop());
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể khởi động IoT Service (HttpListener). Vui lòng chạy ứng dụng bằng quyền Administrator. Lỗi: " + ex.Message);
            }
        }

        public void StopService()
        {
            _isRunning = false;
            if (_listener != null && _listener.IsListening)
            {
                _listener.Stop();
                _listener.Close();
            }
        }

        private async Task ListenLoop()
        {
            while (_isRunning)
            {
                try
                {
                    if (_listener != null)
                    {
                        var context = await _listener.GetContextAsync();
                        ProcessRequest(context);
                    }
                }
                catch (HttpListenerException)
                {
                    // Catch khi Stop listener
                }
                catch (Exception)
                {
                    // Log error
                }
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            try
            {
                if (context.Request.HttpMethod == "POST")
                {
                    using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                    {
                        string json = reader.ReadToEnd();
                        
                        // Parse JSON đơn giản
                        using (JsonDocument doc = JsonDocument.Parse(json))
                        {
                            var root = doc.RootElement;
                            
                            // Lấy thông tin từ JSON (Tương thích với ESP32)
                            string deviceIdStr = root.TryGetProperty("deviceId", out var did) ? (did.GetString() ?? "ESP32_NHA_MO_HINH") : "ESP32_NHA_MO_HINH";
                            double voltage = root.TryGetProperty("voltage", out var vol) ? vol.GetDouble() : 220;
                            double current = root.TryGetProperty("current", out var cur) ? cur.GetDouble() : 0;
                            double leakage = root.TryGetProperty("leakageCurrent", out var leak) ? leak.GetDouble() : 0;

                            // Tìm Device trong DB bằng DeviceCode
                            var device = _deviceRepo.GetDeviceByCode(deviceIdStr);
                            int dbDeviceId = device != null ? device.DeviceID : 1; // Mặc định là 1 nếu không tìm thấy

                            var sensorData = new SensorData
                            {
                                DeviceID = dbDeviceId,
                                Voltage = voltage,
                                CurrentValue = current,
                                LeakageCurrent = leakage,
                                CreatedAt = DateTime.Now
                            };

                            // Lưu vào DB
                            _sensorRepo.AddSensorData(sensorData);

                            // Trigger Event cập nhật giao diện
                            OnDataReceived?.Invoke(this, sensorData);

                            // Xử lý Cảnh báo (Ngưỡng 30mA)
                            if (leakage > 30.0)
                            {
                                var alert = new Alert
                                {
                                    DeviceID = dbDeviceId,
                                    LeakageCurrent = leakage,
                                    AlertLevel = "High",
                                    Description = $"Dòng rò vượt ngưỡng nguy hiểm ({leakage}mA)!",
                                    AlertTime = DateTime.Now,
                                    IsResolved = false
                                };
                                _alertRepo.AddAlert(alert);
                                OnAlertTriggered?.Invoke(this, alert);
                            }
                        }
                    }

                    // Phản hồi OK
                    var response = context.Response;
                    string resString = "{\"status\":\"ok\"}";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(resString);
                    response.ContentLength64 = buffer.Length;
                    response.ContentType = "application/json";
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.OutputStream.Close();
                }
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                context.Response.Close();
            }
        }
    }
}
