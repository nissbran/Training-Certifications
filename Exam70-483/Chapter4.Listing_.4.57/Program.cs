﻿using System;
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
            // LINQ orderby operator 
            int[] data = { 1, 2, 5, 8, 11 };

            // Query syntax
            var qresult = from d in data
                          where d > 5
                          orderby d descending
                          select d;

            Console.WriteLine("Query syntax: {0}", string.Join(", ", qresult));

            // Extension syntax
            var eresult = data.Where(d => d > 5).OrderByDescending(d => d);

            Console.WriteLine("Extension syntax: {0}", string.Join(", ", eresult));

            Console.ReadLine();
        }
    }
}
