using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int x = 3;
            if (x == 3) goto customLabel;
            x++;

            customLabel:
            Console.WriteLine(x);
            Console.ReadLine();
         }
    }
}
