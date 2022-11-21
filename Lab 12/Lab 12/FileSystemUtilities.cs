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

    public static class VNDDiskInfo
    {
        public static void GetFreeSpace(string driveName)
        {
            try
            {
                var drive = DriveInfo.GetDrives().Where(drive => drive.Name == driveName).ToArray()[0];
                Console.WriteLine(drive.AvailableFreeSpace + "байт");

                VNDLog.Log("GetFreeSpace: " + drive.AvailableFreeSpace, DateTime.Now);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Диск не найден");

                VNDLog.Log("Error GetFreeSpace: Drive not found", DateTime.Now);
            }
        }

        public static void GetDriveFormat(string driveName)
        {
            try
            {
                var drive = DriveInfo.GetDrives().Where(drive => drive.Name == driveName).ToArray()[0];
                Console.WriteLine(drive.DriveFormat);

                VNDLog.Log("GetDriveFormat: " + drive.DriveFormat, DateTime.Now);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Диск не найден");

                VNDLog.Log("Error GetDriveFormat: Drive not found", DateTime.Now);
            }
        }

        public static void GetDriveInfo()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                Console.WriteLine(drive.Name);
                Console.WriteLine("Свободно: " + drive.AvailableFreeSpace + " байт");
                Console.WriteLine("Всего: " + drive.TotalSize + " байт");
                Console.WriteLine("Метка тома: " + drive.RootDirectory);

                VNDLog.Log($"GetDriveInfo: {drive.Name}, {drive.AvailableFreeSpace}, {drive.TotalSize}, {drive.RootDirectory}", DateTime.Now);
            }
        }
    }

    public static class VNDFileInfo
    {
        public static void GetPath(string fileName)
        {
            Console.WriteLine(Path.GetFullPath(fileName));

            VNDLog.Log("GetPath: " + Path.GetFullPath(fileName), DateTime.Now);
        }

        public static void GetFileInfo(string fileName)
        {
            try
            {
                FileInfo file = new FileInfo(fileName);
                
                if (!file.Exists)
                {
                    throw new FileNotFoundException();
                }

                Console.WriteLine(file.Name);
                Console.WriteLine("Расширение: " + file.Name.Substring(file.Name.IndexOf('.') + 1));
                Console.WriteLine(file.Length + " байт");

                VNDLog.Log($"GetFileInfo: {file.Name}, {file.Name.Substring(file.Name.IndexOf('.') + 1)}, {file.Length}", DateTime.Now);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Файл не найден");

                VNDLog.Log("Error GetFileInfo: File not found", DateTime.Now);
            }
        }

        public static void GetFileTime(string fileName)
        {
            try
            {
                FileInfo file = new FileInfo(fileName);

                if (!file.Exists)
                {
                    throw new FileNotFoundException();
                }

                Console.WriteLine("Время создания: " + file.CreationTime);
                Console.WriteLine("Время изменения: " + file.LastWriteTime);

                VNDLog.Log($"GetFileTime: {file.CreationTime}, {file.LastWriteTime}", DateTime.Now);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Файл не найден");

                VNDLog.Log("Error GetFileTime: File not found", DateTime.Now);
            }
        }
    }

    public static class VNDDirInfo
    {
        public static void GetFileCount(string directoryName)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryName);
                
                if (!directory.Exists)
                {
                    throw new DirectoryNotFoundException();
                }

                Console.WriteLine("Файлов: " + directory.GetFiles().Length);

                VNDLog.Log("GetFileCount: " + directory.GetFiles().Length, DateTime.Now);
            }
            catch
            {
                Console.WriteLine("Директория не существует");

                VNDLog.Log("Error GetFileCount: Directory not found", DateTime.Now);
            }
        }

        public static void GetDirectoryCount(string directoryName)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryName);

                if (!directory.Exists)
                {
                    throw new DirectoryNotFoundException();
                }

                Console.WriteLine("Поддиректориев: " + directory.GetDirectories().Length);

                VNDLog.Log("GetDirectoryCount: " + directory.GetDirectories().Length, DateTime.Now);
            }
            catch
            {
                Console.WriteLine("Директория не существует");

                VNDLog.Log("Error GetDirectoryCount: Directory not found", DateTime.Now);
            }
        }

        public static void GetDirectoryTime(string directoryName)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryName);

                if (!directory.Exists)
                {
                    throw new DirectoryNotFoundException();
                }

                Console.WriteLine("Время создания: " + directory.CreationTime);
                Console.WriteLine("Время изменения: " + directory.LastWriteTime);

                VNDLog.Log($"GetDirectoryTime: {directory.CreationTime}, {directory.LastWriteTime}", DateTime.Now);
            }
            catch
            {
                Console.WriteLine("Директория не существует");

                VNDLog.Log("Error GetDirectoryTime: Directory not found", DateTime.Now);
            }
        }

        public static void GetRoot(string directoryName)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryName);

                if (!directory.Exists)
                {
                    throw new DirectoryNotFoundException();
                }

                Console.WriteLine(directory.FullName);

                VNDLog.Log("GetRoot: " + directory.FullName, DateTime.Now);
            }
            catch
            {
                Console.WriteLine("Директория не существует");

                VNDLog.Log("Error GetRoot: Directory not found", DateTime.Now);
            }
        }
    }
}
