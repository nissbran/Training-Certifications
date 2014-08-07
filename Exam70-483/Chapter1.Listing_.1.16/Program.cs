using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// The System.Threading.Tasks namespace also contains another class that can be used for parallel processing. 
    /// The Parallel class has a couple of static methods—For, ForEach, and Invoke— that you can use to parallelize work. 
    /// 
    /// This example shows Parallel.For and Parallel.ForEach.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Parallel for index: {0}", i);
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Parallel foreach index: {0}", i);
            });

            Console.ReadLine();
        }
    }
}
