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
            string path = @"C:\Temp\test2.dat";

            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string myValue = "MyValue";
                streamWriter.Write(myValue);
            }

            // Of course, you will also want to read data from a file. 
            // You can do this by directly using a FileStream object, reading the bytes,
            // and converting them back to a string with the correct encoding.
            // This example shows how to read the bytes from a file and convert them to a string with UTF-8 encoding.

            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] data = new byte[fileStream.Length];
                for (int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(data)); // Displays: MyValue
            }

            // If you know that you are parsing a text file, you can also use a StreamReader
            // (as the opposite of the StreamWriter) to read a text file. 
            // The StreamReader uses a default encoding and returns the bytes to you as a string

            using (StreamReader streamReader = File.OpenText(path))
            {
                Console.WriteLine(streamReader.ReadLine());
            }

            Console.ReadLine();
        }
    }
}
