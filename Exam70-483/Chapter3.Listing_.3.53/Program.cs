using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press escape key to stop");
            using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available bytes"))
            {
                string text = "Available memory: ";
                Console.Write(text);
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Thread.Sleep(500);
                        Console.Write(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            }

            // All performance counters are part of a category,
            // and within that category they have a unique name. 
            // To access the performance counters, your application has to run under full trust, 
            // or the account that it’s running under should be an administrator or be a part of the Performance Monitor Users group. 
        }
    }
}
