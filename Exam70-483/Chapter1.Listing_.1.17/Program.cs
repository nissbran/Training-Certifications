using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.Listing_._1._17
{
    /// <summary>
    /// You can cancel the loop by using the ParallelLoopState object. 
    /// You have two options to do this: Break or Stop.
    /// Break ensures that all iterations that are currently running will be finished.
    /// Stop just terminates everything.
    /// 
    /// This program shows an example.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // When breaking the parallel loop, the result variable has an IsCompleted value of false and a LowestBreakIteration of 500. 
            // When you use the Stop method, the LowestBreakIteration is null.

            ParallelLoopResult result = Parallel.For(0, 100, (int i, ParallelLoopState loopState) =>
            {
                Console.Write(", {0}", i);
                if (i == 50)
                {
                    Console.WriteLine("Breaking loop");
                    loopState.Break();
                }

                return;
            });
            Console.WriteLine("LowestBreakIteration: {0}", result.LowestBreakIteration);
            Console.ReadLine();
        }
    }
}
