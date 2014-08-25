using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Temp\test.dat";

            using (FileStream fileStream = File.Create(path))
            {
                string myValue = "MyValue";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }

            // When writing to a FileStream, you can use the synchronous method Write, 
            // which expects a byte array. A simple File object does not store text directly.
            // As already mentioned, a Stream works with bytes, so you need to convert your text into bytes. 
        }
    }
}
