using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WinformsDashboard
{
    public class RoomConfig
    {
        public string DeviceId { get; set; } = "";
        public string RoomName { get; set; } = "";
        public double ThresholdAlert { get; set; } = 30.0;
    }

    public static class RoomManager
    {
        private static readonly string FilePath = "rooms.json";

        public static List<RoomConfig> LoadRooms()
        {
            if (!File.Exists(FilePath))
            {
                return new List<RoomConfig>();
            }

            try
            {
                string json = File.ReadAllText(FilePath);
                var rooms = JsonConvert.DeserializeObject<List<RoomConfig>>(json);
                return rooms ?? new List<RoomConfig>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading rooms: " + ex.Message);
                return new List<RoomConfig>();
            }
        }

        public static void SaveRooms(List<RoomConfig> rooms)
        {
            try
            {
                string json = JsonConvert.SerializeObject(rooms, Formatting.Indented);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving rooms: " + ex.Message);
            }
        }
    }
}
