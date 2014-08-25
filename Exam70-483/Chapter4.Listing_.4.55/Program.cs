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
            // LINQ Select operator 
            int[] data = { 1, 2, 5, 8, 11 };
            
            // Query syntax
            var qresult = from d in data
                         select d;

            Console.WriteLine("Query syntax: {0}", string.Join(", ", qresult));

            // Extension syntax
            var eresult = data.Select(d => d);

            Console.WriteLine("Extension syntax: {0}", string.Join(", ", eresult));

            Console.ReadLine();
        }
    }
}
