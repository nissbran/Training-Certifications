using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{

    /// <summary>
    /// Named arguments, optional arguments, and overloading visibility 
    /// 
    /// A new feature in C# 4 is the use of named and optional arguments. 
    /// Optional arguments enable you to omit arguments for some parameters.
    /// Named arguments are useful to specify which arguments you want to pass a value.
    /// Named and optional arguments can be used with methods, indexers, constructors, and delegates. 
    /// Optional arguments can be useful when you want to specify default values for certain parameters.
    /// 
    /// This example shows how to use named and optional arguments.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // ThirdArgument is used as a named argument
            // secondArgument isnt used so its optional
            MyMethod(1, thirdArgument: true);

            // Both secondArgument and thirdArgument is optional
            MyMethod(2);

            // It’s also possible to create methods with the same name that differ in the arguments they take,
            // which is called overloading. 
            // An example in the .NET Framework is Console.WriteLine.
            // This method has 19 different overloads that take different parameters. 
            // You create an overload for a method by using the exact same name and return type, 
            // but by differing in the arguments you expect. 
            OverloadedMethod(2);
            OverloadedMethod("String 2");
        }

        static void MyMethod(int firstArgument, string secondArgument = "Default value", bool thirdArgument = false) { }

        static void OverloadedMethod(int intValue) { }
        static void OverloadedMethod(string stringValue) { }
    }
}
