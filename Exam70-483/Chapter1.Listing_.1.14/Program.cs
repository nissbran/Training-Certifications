using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Next to calling Wait on a single Task, you can also use the method WaitAll to wait 
    /// for multiple Tasks to finish before continuing execution. 
    /// 
    /// This example shows how to use this.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // In this case, all three Tasks are executed simultaneously, 
            // and the whole run takes approxi- mately 1000ms instead of 3000. 
            // Next to WaitAll, you also have a WhenAll method that you can use 
            // to schedule a continuation method after all Tasks have finished.

            var tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(tasks);

            Console.ReadLine();
        }
    }
}
