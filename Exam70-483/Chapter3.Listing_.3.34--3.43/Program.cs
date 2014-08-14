#define MySymbol
//#undef DEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// Creating and managing compiler directives
    /// 
    /// Some programming languages have the concept of a preprocessor,
    /// which is a program that goes through your code and applies some changes to your code before handing it off to the compiler. 
    /// 
    /// C# does not have a specialized preprocessor, but it does support preprocessor compiler directives,
    /// which are special instructions to the compiler to help in the compilation process. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DebugDirective();
            UseCustomSymbol();

            //#warning This code is obsolete

#if DEBUG
            //#error Debug build is not allowed
#endif

            ConditionalTest();

            Person testPerson = new Person
            {
                FirstName = "Kalle",
                LastName = "Kallesson"
            };

            Console.ReadLine();
        }

        public static void DebugDirective()
        {
#if DEBUG
            Console.WriteLine("Debug mode");
#else
            Console.WriteLine("Not debug");
#endif
        }

        public static void UseCustomSymbol()
        {
#if MySymbol
            Console.WriteLine("Customer symbol is defined");
#endif
        }

        public static Assembly LoadAssembly<T>()
        {
#if !WINRT
            Assembly assembly = typeof(T).Assembly;
#else
            Assembly assembly = typeof(T).GetTypeInfo().Assembly;
#endif
            return assembly;
        }

        public static void LineDirective()
        {
#line 200 "Cool"
            int a = 2;
#line default
            int b = 3;
#line hidden
            int c = 4;
#pragma warning disable
            int d;
#pragma warning restore

            int t = a + b + c;
        }

        public static void Warnings()
        {
#pragma warning disable 0162, 0168
            int i;
#pragma warning restore 0168
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
#pragma warning restore 0162
        }


        public static void SomeMethod()
        {
#if DEBUG
            Log("Step1");
#endif
        }
        private static void Log(string message)
        {
            Console.WriteLine("message");
        }

        public static void ConditionalTest()
        {
            LogCond("Step2");
        }

        [Conditional("DEBUG")]
        private static void LogCond(string message)
        {
            Console.WriteLine("message");
        }

    }

    [DebuggerDisplay("Name = {FirstName} {LastName}")]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
