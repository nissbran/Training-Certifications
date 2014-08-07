using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Language-Integrated Query (LINQ) is a popular addition to the C# language.
    /// You can use it to perform queries over all kinds of data. 
    /// Parallel Language-Integrated Query (PLINQ) can be used on objects to potentially turn a sequential query into a parallel one. 
    /// Extension methods for using PLINQ are defined in the System.Linq.ParallelEnumerable class. 
    /// Parallel versions of LINQ operators, such as Where, Select, SelectMany, GroupBy, Join, OrderBy, Skip, and Take, can be used. 
    /// 
    /// This example shows how you can convert a query to a parallel query.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // The runtime determines whether it makes sense to turn your query into a parallel one.
            // When doing this, it generates Task objects and starts executing them. 
            // If you want to force PLINQ into a parallel query, 
            // you can use the WithExecutionMode method and specify that it should always execute the query in parallel. 

            var numbers = Enumerable.Range(0, 100);
            var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();

            // One thing to keep in mind is that parallel processing does not guarantee any particular orde

            foreach (var number in parallelResult)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }
}
