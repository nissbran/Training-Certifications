using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Creating deadlock
    /// 
    /// However, it also causes the threads to block while they are waiting for each other. 
    /// This can give performance problems and it could even lead to a deadlock,
    /// where both threads wait on each other, causing neither to ever complete. 
    /// </summary>
   public static class Program
    {
        public static void Main(string[] args)
        {
            // Because both locks are taken in reverse order, a deadlock occurs. 
            // The first Task locks A and waits for B to become free.
            // The main thread, however, has B locked and is waiting for A to be released.

            object lockA = new object();
            object lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            Thread.Sleep(200); // Needed for fast CPUs

            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }

            up.Wait();

            Console.ReadLine();
        }
    }
}
