using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    /// Running I/O operations in parallel
    /// 
    /// Real asynchronous I/O makes sure that your thread can do other work until the operating system
    /// notifies your application that the I/O is ready.
    /// Multiple async I/O operations can still be executed one after the other. 
    /// 
    /// When you look at this example, you can see that multiple awaits are used in one method.
    /// With the current code, each web request starts when the previous one is finished. 
    /// The thread won’t be blocked while running these requests,
    /// but the amount of time the method takes is the sum of the three web requests.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ExecuteMultipleRequests().Wait();
            sw.Stop();

            Console.WriteLine("ExecuteMultipleRequests time: {0} ms", sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();
            ExecuteMultipleRequestsInParallel().Wait();
            sw.Stop();

            Console.WriteLine("ExecuteMultipleRequestsInParallel time: {0} ms", sw.ElapsedMilliseconds);

            // Using Tasks and async/await makes using asynchronous code a lot easier. 
            // Whenever possible, determine whether an operation is taking a long time and is not CPU-bound.
            // If true or likely to be true, running it asynchronously is a good idea.

            Console.ReadLine();
        }

        public static async Task ExecuteMultipleRequests()
        {
            using (HttpClient client = new HttpClient())
            {
                string microsoft = await client.GetStringAsync("http://www.microsoft.com");
                string msdn = await client.GetStringAsync("http://msdn.microsoft.com");
                string blogs = await client.GetStringAsync("http://blogs.msdn.com");
            }
        }

        /// <summary>
        /// You can also write code that will execute those operations in parallel.
        /// If you would execute those requests in parallel, 
        /// you would only have to wait as long as the longest request takes (the other two will already be finished). 
        /// You can do this by using the static method Task.WhenAll. 
        /// As soon as you call GetStringAsync, the async operation gets started. However, you don’t immediately wait for the result. 
        /// Instead, you let all three requests start and then you wait for them to finish. 
        /// Now, all three operations run parallel, which can save you a lot of time.
        /// </summary>
        public static async Task ExecuteMultipleRequestsInParallel()
        {
            using (HttpClient client = new HttpClient())
            {
                Task microsoft = client.GetStringAsync("http://www.microsoft.com");
                Task msdn = client.GetStringAsync("http://msdn.microsoft.com");
                Task blogs = client.GetStringAsync("http://blogs.msdn.com");

                await Task.WhenAll(microsoft, msdn, blogs);
            }
        }
    }
}
