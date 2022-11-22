using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
    public static class VNDFileManager
    {
        public static void GetFilesAndDirectories(string directoryName)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryName);
                directory.Refresh();

                if (!directory.Exists)
                {
                    throw new DirectoryNotFoundException();
                }

                string log = "";
                foreach (var dir in directory.GetDirectories())
                {
                    Console.WriteLine(dir);
                    log += dir;
                }
                foreach (var file in directory.GetFiles())
                {
                    Console.WriteLine(file);
                    log += file;
                }

                VNDLog.Log("GetFilesAndDirectories: " + log, DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Директория не найдена");

                VNDLog.Log("Error GetFilesAndDirectories: Directory not found", DateTime.Now);
            }
        }

        public static void CreateDirectory(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                directory.Refresh();

                if (directory.Exists)
                {
                    throw new Exception();
                }

                Directory.CreateDirectory(path);
                Console.WriteLine("Директория создана");

                VNDLog.Log("CreateDirectory: " + path, DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Директория не создана");

                VNDLog.Log("Error CreateDirectory: Directory wasn't created", DateTime.Now);
            }
        }

        public static void CreateFile(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                file.Refresh();

                if (file.Exists)
                {
                    throw new Exception();
                }

                File.Create(path);
                Console.WriteLine("Файл создан");

                VNDLog.Log("CreateFile: " + path, DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Файл не создан");

                VNDLog.Log("Error CreateFile: File wasn't created", DateTime.Now);
            }
        }

        public static void CopyFile(string sourcePath, string newPath)
        {
            try
            {
                FileInfo file = new FileInfo(sourcePath);
                file.Refresh();

                if (!file.Exists)
                {
                    throw new Exception();
                }

                File.Copy(sourcePath, newPath);
                Console.WriteLine("Файл скопирован");

                VNDLog.Log($"CopyFile: {sourcePath}, {newPath}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Файл не скопирован");

                VNDLog.Log("Error CopyFile: File not copied", DateTime.Now);
            }
        }

        public static void DeleteFile(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                file.Refresh();

                if (!file.Exists)
                {
                    throw new Exception();
                }

                File.Delete(path);
                Console.WriteLine("Файл удален");

                VNDLog.Log("DeleteFile: " + path, DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Файл не найден");

                VNDLog.Log("Error DeleteFile: File not found", DateTime.Now);
            }
        }

        public static void WriteToFile(string path, string text)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                file.Refresh();

                if (!File.Exists(path))
                {
                    throw new Exception();
                }

                File.WriteAllText(path, text);
                Console.WriteLine("Файл записан");

                VNDLog.Log($"WriteToFile: {path}, {text}", DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Файл не найден");

                VNDLog.Log("Error WriteToFile: File not found", DateTime.Now);
            }
        }
    }
}
