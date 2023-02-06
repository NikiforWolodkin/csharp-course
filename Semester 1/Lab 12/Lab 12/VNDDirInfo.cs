using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Console.WriteLine("Директория не существует");

                VNDLog.Log("Error GetRoot: Directory not found", DateTime.Now);
            }
        }
    }
}
