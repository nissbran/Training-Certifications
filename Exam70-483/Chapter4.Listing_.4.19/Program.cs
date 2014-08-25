using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    /// Another example where this can be used is with a BufferedStream.
    /// Hard drives are optimized for reading larger blocks of data.
    /// Reading a file byte by byte can be slower than reading big chunks of data and processing them byte by byte. 
    /// Just as with the GZipStream, the BufferedStream takes another Stream in its constructor. 
    /// The BufferedStream helps you with checking to determine whether it’s possible to read or write larger chunks of data at once. 
    /// 
    /// This example shows how to write some data to a BufferedStream that wraps a FileStream. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\temp\bufferedStream.txt";

            using (FileStream fileStream = File.Create(path))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamWriter streamWriter = new StreamWriter(bufferedStream))
                    {
                        streamWriter.Write("A line of text");
                    }
                }
            }
        }
    }
}
