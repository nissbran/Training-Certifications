using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// If you have a complex query that can benefit from parallel processing but also has some parts that should be done sequentially,
    /// you can use the AsSequential to stop your query from being processed in parallel.
    /// One scenario where this is required is to preserve the ordering of your query. 
    /// 
    /// This example shows how you can use the AsSequential operator to make sure that the Take method doesn’t mess up your order.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 20);

            var parallelResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 == 0).AsSequential();

            foreach (var i in parallelResult.Take(5))        
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
