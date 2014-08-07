using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// A method marked with async just starts running synchronously on the current thread. 
    /// What it does is enable the method to be split into multiple pieces. 
    /// The boundaries of these pieces are marked with the await keyword. 
    /// 
    /// When you use the await keyword, the compiler generates code that will see whether your asynchronous operation is already finished. 
    /// If it is, your method just continues running synchronously. 
    /// If it’s not yet completed, the state machine will hook up a continuation method that should run when the Task completes.
    /// Your method yields control to the calling thread, and this thread can be used to do other work. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Because the entry method of an application can’t be marked as async, the example uses the Wait method in Main. 
            // This class uses both the async and await keywords in the DownloadContent method. 

            string result = DownloadContent().Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static async Task<string> DownloadContent()
        {
            // The GetStringAsync uses asynchronous code internally and returns a Task<string> to the caller that will finish when the data is retrieved.
            // In the meantime, your thread can do other work.

            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.mircosoft.com");
                Console.WriteLine("After await"); // Will execute before the results return from GetStringAsync, since the thread continues
                return result;
            }
        }
    }
}
