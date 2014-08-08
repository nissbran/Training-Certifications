using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Short circuit
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            OrShortCircuit();

            Console.ReadLine();
        }

        public static void XORTest()
        {
            bool a = true; 
            bool b = false;
            Console.WriteLine(a ^ a); // False 
            Console.WriteLine(a ^ b); // True
            Console.WriteLine(b ^ b); // False

        }

        public static void Process(string input)
        {
            bool result = (input != null) && (input.StartsWith("v"));
        }

        public static void AndShortCircuit()
        {
            int value = 42;
            bool result = (0 < value) && (value < 100);
        }

        public static void OrShortCircuit()
        {
            bool x = true;
            bool result = x || GetY();
        }

        private static bool GetY()
        {
            Console.WriteLine("This method doesn’t get called");
            return true;
        }

    }
}
