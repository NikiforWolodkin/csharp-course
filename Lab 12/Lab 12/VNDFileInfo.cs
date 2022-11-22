using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
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
                Console.WriteLine("Расширение: " + Path.GetExtension(fileName));
                Console.WriteLine(file.Length + " байт");

                VNDLog.Log($"GetFileInfo: {file.Name}, {Path.GetExtension(fileName)}, {file.Length}", DateTime.Now);
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
}
