using Lab_12;

VNDLog.Clear();

VNDDiskInfo.GetFreeSpace(@"C:\");
VNDDiskInfo.GetDriveFormat(@"C:\");
VNDDiskInfo.GetDriveInfo();
Console.WriteLine();

VNDFileInfo.GetPath(@"../../../vndlogfile.txt");
VNDFileInfo.GetFileInfo(@"../../../vndlogfile.txt");
VNDFileInfo.GetFileTime(@"../../../vndlogfile.txt");
Console.WriteLine();

VNDDirInfo.GetFileCount(@"../../../../Lab 12");
VNDDirInfo.GetDirectoryCount(@"../../../../Lab 12");
VNDDirInfo.GetDirectoryTime(@"../../../../Lab 12");
VNDDirInfo.GetRoot(@"../../../../Lab 12");
Console.WriteLine();

VNDLog.ClearOldLogs();

VNDLog.Read("GetRoot");
Console.WriteLine();
VNDLog.Read(DateTime.Today);
Console.WriteLine();
