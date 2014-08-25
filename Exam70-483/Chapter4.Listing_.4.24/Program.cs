using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    ///  When a method does have a return value, it returns Task<T>, where T is the type of the value that is returned.
    ///  In this program, the GetStringAsync method is used. This method returns Task<string>, 
    ///  which means that eventually when the process is finished, a string value is available (or an exception).
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var resultTask = ReadAsyncHttpRequest();
            Console.WriteLine(resultTask.Result);

            Console.ReadLine();

            // Whenever the .NET Framework offers an async equivalent of a synchronous method, it is best to use it.
            // It creates a better user experience and a more scalable application. 
            // However, when you are working on a performance-critical application, it pays to know what the compiler does for you. 
            // If you are uncertain, use a profiler to actually measure the difference so you can make an informed decision.
        }

        public static async Task<string> ReadAsyncHttpRequest()
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync("http://www.microsoft.com");
            }
        }
    }
}
