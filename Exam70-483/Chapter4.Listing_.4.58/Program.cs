using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ multiple from statements 
            int[] data1 = { 1, 2, 5 };
            int[] data2 = { 2,4,6 };

            // Query syntax
            var qresult = from d1 in data1
                          from d2 in data2
                          select d1 * d2;

            Console.WriteLine("Query syntax: {0}", string.Join(", ", qresult));

            // Extension syntax
            var eresult = data1.SelectMany(d => data2.Select(y => y * d));

            Console.WriteLine("Extension syntax: {0}", string.Join(", ", eresult));

            Console.ReadLine();
        }
    }
}
