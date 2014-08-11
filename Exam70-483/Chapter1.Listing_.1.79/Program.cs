using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatper1
{
    /// <summary>
    /// Lambda expression to create a delegate 
    /// </summary>
    public static class Program
    {
        public delegate int Calculate(int x, int y);

        public static void Main(string[] args)
        {
            Console.WriteLine("Listing 1-79");
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4));

            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4));

            // You can create lambdas that span multiple statements.
            // You can do this by adding curly braces around the statements that form the lambda

            Console.WriteLine();
            Console.WriteLine("Listing 1-80");

            calc = (x, y) =>
            {
                Console.WriteLine("Adding numbers");
                return x + y;
            };

            Console.WriteLine(calc(3, 4));

            Console.ReadLine();
        }
    }
}
