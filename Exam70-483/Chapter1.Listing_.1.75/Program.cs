using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// In C#, delegates form the basic building blocks for events.
    /// A delegate is a type that defines a method signature. 
    /// In C++, for example, you would do this with a function pointer.
    /// In C# you can instantiate a delegate and let it point to another method. 
    /// You can invoke the method through the delegate. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            new Calculator().UseDelegate();

            Console.ReadLine();
        }
    }

    public class Calculator
    {
        public delegate int Calculate(int x, int y);
        public int Add(int x, int y) { return x + y; }
        public int Multiply(int x, int y) { return x * y; }

        public void UseDelegate()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4));

            calc = Multiply;
            Console.WriteLine(calc(3, 4));
        }
    }
}
