using System.IO;
using System.Text;

namespace Zoo.EventLogger
{
    internal class LogToFile
    {
        private readonly object LogLock = new();
        private StreamWriter? StreamWriter;
        private readonly string FilePath;

        private string GetFormattedDate(DateTime date)
        {
            string[] dateParts = date.ToString().Split(" ");
            string formattedDate = dateParts[0].Replace("/", ".");
            return formattedDate;
        }

        private string GetFormattedTime(DateTime time)
        {
            string formattedTime = time.ToString("h:mm").Replace(":", ".");
            return formattedTime;
        }

        private string GenerateFileName(string prefix, DateTime date, DateTime time)
        {
            StringBuilder fileNameBuilder = new StringBuilder();
            fileNameBuilder.Append(prefix);
            fileNameBuilder.Append(' ');
            fileNameBuilder.Append(GetFormattedDate(date));
            fileNameBuilder.Append('_');
            fileNameBuilder.Append(GetFormattedTime(time));
            return fileNameBuilder.ToString();
        }

        public LogToFile(string filePath)
        {
            string prefix = "EventLogs_";
            DateTime now = DateTime.Now;
            this.FilePath = filePath;
            StreamWriter = new StreamWriter(Path.Combine(filePath, GenerateFileName(prefix, now, now) + ".txt"), true);
        }

        private string FormatLogMessage(string message)
        {
            StringBuilder logMessageBuilder = new StringBuilder();
            logMessageBuilder.Append(DateTime.Now);
            logMessageBuilder.Append(": ");
            logMessageBuilder.Append(message);
            return logMessageBuilder.ToString();
        }

        public void LogEvent(string message)
        {
            lock (LogLock)
            {
                string logMessage = FormatLogMessage(message);
                StreamWriter!.WriteLine(logMessage);
                StreamWriter.Flush();
            }
        }

        public void Close()
        {
            StreamWriter?.Dispose();
            StreamWriter = null;
        }
    }
}
