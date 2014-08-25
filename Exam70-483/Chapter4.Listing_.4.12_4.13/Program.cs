using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            // The static class Path that can be found in System.IO has some helper methods for dealing with these kinds of situations.
            // One of these methods is the static Combine method that has a number of overloads that accept multiple string parameters. 
            // This example shows how the Combine method results in a correct path.

            string folder = @"C:\temp";
            string fileName = "test.dat";

            string fullPath = Path.Combine(folder, fileName);

            Console.WriteLine("Fullpath: {0}", fullPath);

            // The Path class offers some other helpful methods: GetDirectoryName, GetExtensions, GetFileName, and GetPathRoot. 
            // This example shows how you can use these methods on a string that contains a full path.

            string path = @"C:\temp\subdir\file.txt";

            Console.WriteLine(Path.GetDirectoryName(path)); // Displays C:\temp\subdir
            Console.WriteLine(Path.GetExtension(path)); // Displays .txt 
            Console.WriteLine(Path.GetFileName(path)); // Displays file.txt 
            Console.WriteLine(Path.GetPathRoot(path)); // Displays C:\

            Console.ReadLine();

            // Never try to manually add strings together to form a path. 
            // Always use the Path class when combining multiple strings together to form a legal path.
        }
    }
}
