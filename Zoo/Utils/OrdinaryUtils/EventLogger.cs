using System;
using System.IO;

namespace Zoo.Utils.OrdinaryUtils
{
    internal class EventLogger
    {
        private static readonly object _lockObject = new();
        private static StreamWriter _streamWriter;
        private static readonly string _path;

        static EventLogger()
        {
            string path = "EventLogs_";
            DateTime thisDay = DateTime.Today;
            string[] todayDates = thisDay.ToString().Split(" ");
            string today = todayDates[0].Replace("/", ".");
            path += " " + today + "_";
            string time = DateTime.Now.ToString("h:mm").Replace(":", ".");
            path += time;

            _path = path;
            _streamWriter = new StreamWriter(@$"C:\Users\AssafHillel\source\repos\Zoo\Zoo\{_path}.txt", true);
        }

        public void LogIntoEvent(string message)
        {
            lock (_lockObject)
            {
                _streamWriter.WriteLine($"{DateTime.Now}: {message}");
                _streamWriter.Flush();
            }
        }

        public static void Close()
        {
            _streamWriter?.Dispose();
            _streamWriter = null;
        }
    }
}
