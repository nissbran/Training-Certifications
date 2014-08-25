using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    /// Async IO
    /// 
    /// This program shows an example of how to write asynchronously to a file. 
    /// The Write method is replaced by WriteAsync,
    /// the method is marked with the async modifier to signal to the compiler that you want some help on transforming your code,
    /// and finally you use the await keyword on the returned task.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var result = CreateAndWriteAsyncToFile();

            result.Wait();

            // The returned Task object represents some ongoing work by encapsulating the state of the asynchronous operation.
            // Eventually, the Task object returns the result of the operation or exceptions that were asynchronously raised. 

            Console.ReadLine();
        }

        public static async Task CreateAndWriteAsyncToFile()
        {
            using (FileStream stream = new FileStream("testasync.dat", 
                FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);

                await stream.WriteAsync(data, 0, data.Length);
            }
        }
    }
}
