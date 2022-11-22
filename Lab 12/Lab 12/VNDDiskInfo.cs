using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
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
}
