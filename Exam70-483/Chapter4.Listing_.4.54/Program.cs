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
            int[] data = { 1, 2, 5, 8, 11 };

            var result = from d in data
                         where d % 2 == 0
                         select d;

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }

            var result2 = data.Where(d => d % 2 == 0);

            foreach (var i in result2)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
