﻿using Lab_12;

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

VNDFileManager.GetFilesAndDirectories(@"C:\");
VNDFileManager.CreateDirectory(@"../../../VNDInspect");
VNDFileManager.CreateFile(@"../../../VNDInspect/vnddirinfo.txt");
VNDFileManager.WriteToFile(@"../../../VNDInspect/vnddirinfo.txt", "Hello World!");
VNDFileManager.CopyFile(@"../../../VNDInspect/vnddirinfo.txt", "../../../VNDInspect/vnddirinfocopy.txt");
VNDFileManager.DeleteFile(@"../../../VNDInspect/vnddirinfo.txt");
VNDFileManager.CreateDirectory(@"../../../VNDFiles");
VNDFileManager.CopyFiles(@"../../../", @"../../../VNDFiles", ".txt");
VNDFileManager.MoveDirectory(@"../../../VNDFiles", @"../../../VNDInspect/VNDFiles");
VNDFileManager.Archive(@"../../../VNDInspect/VNDFiles", @"../../../VNDInspect/VNDFiles.zip");
VNDFileManager.Extract(@"../../../VNDInspect/VNDFiles.zip", @"../../../VNDInspect/VNDFilesExtracted");
Console.WriteLine();

VNDLog.ClearOldLogs();

VNDLog.Read("GetRoot");
Console.WriteLine();
VNDLog.Read(DateTime.Today);
Console.WriteLine();
