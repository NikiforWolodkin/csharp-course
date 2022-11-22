using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Lab_12
{
    internal static class VNDLog
    {
        private class LogRecord
        {
            public string Message { get; set; }
            public DateTime Time { get; set; }

            public LogRecord(string message, DateTime time)
            {
                Message = message;
                Time = time;
            }
        }

        internal static void Read()
        {
            string jsonString = System.IO.File.ReadAllText(@"../../../vndlogfile.txt");
            List<LogRecord> logs;
            try
            {
                logs = JsonSerializer.Deserialize<List<LogRecord>>(jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Журнал пустой");
                return;
            }

            foreach (var log in logs)
            {
                Console.WriteLine(log.Message);
                Console.WriteLine(log.Time);
            }
        }

        internal static void Read(string keyword)
        {
            string jsonString = System.IO.File.ReadAllText(@"../../../vndlogfile.txt");
            List<LogRecord> logs;
            try
            {
                logs = JsonSerializer.Deserialize<List<LogRecord>>(jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Журнал пустой");
                return;
            }

            foreach (var log in logs)
            {
                if (log.Message.Contains(keyword))
                {
                    Console.WriteLine(log.Message);
                    Console.WriteLine(log.Time);
                }
            }
        }

        internal static void Read(DateTime time)
        {
            string jsonString = System.IO.File.ReadAllText(@"../../../vndlogfile.txt");
            List<LogRecord> logs;
            try
            {
                logs = JsonSerializer.Deserialize<List<LogRecord>>(jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Журнал пустой");
                return;
            }

            foreach (var log in logs)
            {
                if (log.Time > time)
                {
                    Console.WriteLine(log.Message);
                    Console.WriteLine(log.Time);
                }
            }
        }

        internal static void Read(DateTime startTime, DateTime endTime)
        {
            string jsonString = System.IO.File.ReadAllText(@"../../../vndlogfile.txt");
            List<LogRecord> logs;
            try
            {
                logs = JsonSerializer.Deserialize<List<LogRecord>>(jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Журнал пустой");
                return;
            }

            foreach (var log in logs)
            {
                if (log.Time > startTime && log.Time < endTime)
                {
                    Console.WriteLine(log.Message);
                    Console.WriteLine(log.Time);
                }
            }
        }

        internal static void Clear()
        {
            System.IO.File.WriteAllText(@"../../../vndlogfile.txt", string.Empty);
        }

        internal static void ClearOldLogs()
        {
            string jsonString = System.IO.File.ReadAllText(@"../../../vndlogfile.txt");
            List<LogRecord> logs;
            try
            {
                logs = JsonSerializer.Deserialize<List<LogRecord>>(jsonString);
            }
            catch (JsonException ex)
            {
                logs = new List<LogRecord>();
            }

            List<LogRecord> logsUpdated = new List<LogRecord>();
            TimeSpan hour = new TimeSpan(1, 0, 0);
            foreach (var log in logs)
            {
                if (log.Time > DateTime.Now.Subtract(hour))
                {
                    logsUpdated.Add(log);
                }
            }

            jsonString = JsonSerializer.Serialize(logsUpdated);

            Clear();
            System.IO.File.WriteAllText(@"../../../vndlogfile.txt", jsonString);
        }

        internal static void Log(string message, DateTime time)
        {
            string jsonString = System.IO.File.ReadAllText(@"../../../vndlogfile.txt");
            List<LogRecord> logs;
            try
            {
                logs = JsonSerializer.Deserialize<List<LogRecord>>(jsonString);
            }
            catch (JsonException ex)
            {
                logs = new List<LogRecord>();
            }

            logs.Add(new LogRecord(message, time));
            jsonString = JsonSerializer.Serialize(logs);

            Clear();
            System.IO.File.WriteAllText(@"../../../vndlogfile.txt", jsonString);
        }
    }
}
