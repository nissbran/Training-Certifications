using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Sometimes declaring a delegate for an event feels a bit cumbersome.
    /// Because of this, the .NET Framework has a couple of built-in delegate types that you can use when declaring delegates.
    ///  
    /// For the Calculate examples, you have used the following delegate:
    /// 
    ///     public delegate int Calculate(int x, int y);
    /// 
    /// You can replace this delegate with one of the built-in types namely Func<int,int,int>.
    /// The Func<…> types can be found in the System namespace and they represent delegates that return a type and take 0 to 16 parameters.
    /// 
    /// All those types inherit from System.MulticastDelegate so you can add multiple methods to the invocation list. 
    /// If you want a delegate type that doesn’t return a value, you can use the System.Action types. 
    /// They can also take 0 to 16 parameters, but they don’t return a value. 
    /// 
    /// This example shows an example of using the Action type.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Listing 1-81");

            Action<int, int> calc = (x, y) =>
                {
                    Console.WriteLine(x + y);
                };

            calc(3, 4);

            Console.ReadLine();

            // Things start to become more complex when your lambda function starts referring to variables declared outside 
            // of the lambda expression (or to the this reference). 
            // Normally, when control leaves the scope of a variable, the variable is no longer valid.
            // But what if a delegate refers to a local variable and is then returned to the calling method?
            // Now, the delegate has a longer life than the variable.
            // To fix this, the compiler generates code that makes the life of the captured variable at least as long as the longest-living delegate. 
            // This is called a closure
        }
    }
}
