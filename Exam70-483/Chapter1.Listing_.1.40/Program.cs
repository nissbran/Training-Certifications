using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Interlocked class
    /// 
    /// Making operations atomic is the job of the Interlocked class that can be found in the System.Threading namespace.
    /// When using the Interlocked.Increment and Interlocked.
    /// Decrement, you create an atomic operation, as this example shows.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Interlocked guarantees that the increment and decrement operations are executed atomically. 
            // No other thread will see any intermediate results. 
            // Of course, adding and subtracting is a simple operation. 
            // If you have more complex operations, you would still have to use a lock. 

            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref n);
            }

            up.Wait();

            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
