using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// When using PLINQ, you can use the ForAll operator to iterate over 
    /// a collection when the iteration can also be done in a parallel way.
    /// 
    /// This exampel shows how to do this. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // In contrast to foreach, ForAll does not need all results before it starts executing.
            // In this example, ForAll does, however, remove any sort order that is specified.

            var numbers = Enumerable.Range(0, 20);

            var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0);

            parallelResult.ForAll(e => Console.WriteLine(e));

            Console.ReadLine();
        }
    }
}
