using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// If you want to ensure that the results are ordered, you can add the AsOrdered operator. 
    /// Your query is still processed in parallel, but the results are buffered and sorted. 
    /// 
    /// This example shows how this works.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 == 0).ToArray();

            foreach (int i in parallelResult)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
