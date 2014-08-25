using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    /// Directories
    /// 
    /// A drive contains a list of directories and files. To work with those items,
    /// you can use the DirectoryInfo object or the static Directory class. 
    /// Both classes offer access to your folder structure.
    /// When executing only a single operation against your file system, it can be more efficient to use the static Directory class.
    /// When you want to execute multiple operations against a folder, DirectoryInfo is a better choice. 
    /// </summary>
    public static class Program
    {
        private const string Directory_1_Name = @"C:\Temp\ProgrammingInCSharp\Directory";
        private const string Directory_2_Name = @"C:\Temp\ProgrammingInCSharp\TestDirectory";
        private const string Directory_3_Name = @"C:\Temp\ProgrammingInCSharp\NewDirectory";
        private const string DirectoryInfo_1_Name = @"C:\Temp\ProgrammingInCSharp\DirectoryInfo";
        private const string DirectoryInfo_2_Name = @"C:\Temp\ProgrammingInCSharp\TestDirectoryInfo";
        private const string DirectoryInfo_3_Name = @"C:\Temp\ProgrammingInCSharp\NewDirectoryInfo";

        static void Main(string[] args)
        {
            // -- Listing 4-2
            CreateDirectory();

            // -- Listing 4-3
            DeleteDirectory();

            // -- Listing 4-4
            DirectorySecurityTest();

            // -- Listing 4-5
            // List the subdirectories for Program containing the character 'a' with a maximum depth of 5
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Program Files");
            ListDirectories(directoryInfo, "*a*", 5, 0);

            // -- Listing 4-6
            MoveADirectory();

            // -- Listing 4-7
            ListAllFiles();

            Console.ReadLine();
        }

        private static void CreateDirectory()
        {
            // You can use both classes to create a new folder. When you create a new folder,
            // you automatically have both read and write rights to the folder.
            // This shows how to create a new directory with the static Directory class or DirectoryInfo.

            var directory = Directory.CreateDirectory(Directory_1_Name);

            var directoryInfo = new DirectoryInfo(DirectoryInfo_1_Name);
            directoryInfo.Create();

            // As you can see, a DirectoryInfo object can be initialized with a non-existing folder.
            // Calling Create will create the directory. After creating the folder,
            // you can call other instance members on the DirectoryInfo object that now points to the newly created folder. 
        }

        private static void DeleteDirectory()
        {
            // You can also remove a folder, but trying to remove a folder that doesn’t exist throws DirectoryNotFoundException. 
            // You can use the Exists method on the static Directory class or the Exists property 
            // on the DirectoryInfo object to determine whether a folder exists

            if (Directory.Exists(Directory_1_Name))
            {
                Directory.Delete(Directory_1_Name);
            }

            var directoyInfo = new DirectoryInfo(DirectoryInfo_1_Name);
            if (directoyInfo.Exists)
            {
                directoyInfo.Delete();
            }
        }

        private static void DirectorySecurityTest()
        {
            // One important thing to remember when working with directories and files
            // is that the operating system controls access to all elements on your local computer
            // or on a shared network drive. Access to folders can be arranged by using the DirectorySecurity
            // class from the System.Security.AccessControl namespace.

            DirectoryInfo directoryInfo = new DirectoryInfo(Directory_2_Name);
            directoryInfo.Create();

            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(
                new FileSystemAccessRule("alla",
                                         FileSystemRights.ReadAndExecute,
                                         AccessControlType.Allow));

            directoryInfo.SetAccessControl(directorySecurity);
        }

        private static void ListDirectories(DirectoryInfo directoryInfo, string searchPattern, int maxLevel, int currentLevel)
        {
            if (currentLevel >= maxLevel)
            {
                return;
            }

            string indent = new string('-', currentLevel);

            try
            {
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories(searchPattern);

                foreach (var subDirectory in subDirectories)
                {
                    Console.WriteLine(indent + subDirectory.Name);
                    ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // You don’t have access to this folder.          
                Console.WriteLine(indent + "Can’t access: " + directoryInfo.Name);
                return;
            }
            catch (DirectoryNotFoundException)
            {
                // The folder is removed while iterating        
                Console.WriteLine(indent + "Can’t find: " + directoryInfo.Name);
                return;
            }

            // When working with a huge directory tree, it can be more efficient to use EnumerateDirectories instead of GetDirectories.
            // When using EnumerateDirectories, you can start enumerating the collection before it’s been completely retrieved. 
            // When using GetDirectories, you get a list of folder names and you have to wait until the whole list of names is ready.
        }
    
        private static void MoveADirectory()
        {
            Directory.Move(Directory_2_Name, Directory_3_Name);

            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryInfo_2_Name);
            directoryInfo.Create();
            directoryInfo.MoveTo(DirectoryInfo_3_Name);

            Directory.Delete(Directory_3_Name);
            Directory.Delete(DirectoryInfo_3_Name);
        }

        private static void ListAllFiles()
        {
            foreach (string file in Directory.GetFiles(@"C:\Windows"))
            {
                 Console.WriteLine(file); 
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows");
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                Console.WriteLine(fileInfo.FullName); 
            }

        }
    }
}
