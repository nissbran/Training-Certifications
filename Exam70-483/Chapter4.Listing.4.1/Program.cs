using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    /// Drives
    /// 
    /// When working with the file system, you obviously start with a storage medium,
    /// which can be a hard drive, CD player, or another storage type. 
    /// The .NET Framework offers the DriveInfo class to access the drives on your computer. 
    /// A DriveInfo object doesn’t have any specific methods for dealing with drives 
    /// (for example, there is not an eject method for a CD player).
    /// It does have several properties to access information such as the name of the drive, size, and available free space.
    /// 
    /// This example shows how to enumerate the current drives and display some information about them.
    /// </summary>
    public static class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();

            foreach (DriveInfo driveInfo in drivesInfo)
            {
                Console.WriteLine("Drive {0}", driveInfo.Name);
                Console.WriteLine("  File type: {0}", driveInfo.DriveType);

                if (driveInfo.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", driveInfo.VolumeLabel);
                    Console.WriteLine("  File system: {0}", driveInfo.DriveFormat);
                    Console.WriteLine("  Available space to current user: {0, 15} bytes", driveInfo.AvailableFreeSpace);
                    Console.WriteLine("  Total available space:           {0, 15} bytes", driveInfo.TotalFreeSpace);
                    Console.WriteLine("  Total size of drive:             {0, 15} bytes", driveInfo.TotalSize);
                }
            }

            Console.ReadLine();
        }
    }
}
