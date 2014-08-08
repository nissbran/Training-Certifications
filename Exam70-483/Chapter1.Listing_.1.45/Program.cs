using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// If you want to cancel a Task after a certain amount of time,
    /// you can use an overload of Task.WaitAny that takes a timeout. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // If the returned index is -1, the task timed out. 
            // It’s important to check for any possible errors on the other tasks.
            // If you don’t catch them, they will go unhandled.

            Task longRunning = Task.Run(() =>
            {
                Thread.Sleep(10000);
            });

            int index = Task.WaitAny(new[] { longRunning }, 1000);
            if (index == -1)
                Console.WriteLine("Task timed out");
        }
    }
}
