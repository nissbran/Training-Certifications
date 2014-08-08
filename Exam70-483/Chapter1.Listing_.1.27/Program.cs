using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.Listing_._1._27
{
    /// <summary>
    /// Of course, it can happen that some of the operations in your parallel query throw an exception.
    /// The .NET Framework handles this by aggregating all exceptions into one AggregateException.
    /// This exception exposes a list of all exceptions that have happened during parallel execution. 
    /// 
    /// This example shows how you can handle this.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            }

            Console.ReadLine();
        }

        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("Error");

            return i % 2 == 0;
        }
    }
}
