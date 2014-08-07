using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Another thing that’s important to know about threads is the difference between fore- ground and background threads. 
    /// Foreground threads can be used to keep an application alive.
    /// Only when all foreground threads end does the common language runtime (CLR) shut down your application. 
    /// Background threads are then terminated. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));

            // If you run this application with the IsBackground property set to true, the application exits immediately. 
            // If you set it to false (creating a foreground thread), the application prints the ThreadProc message ten times.
            t.IsBackground = true;
            t.Start();
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}
