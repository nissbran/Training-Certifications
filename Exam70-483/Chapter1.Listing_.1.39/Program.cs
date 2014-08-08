using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Volatile class
    /// 
    /// The C# compiler is pretty good at optimizing code.
    /// The compiler can even remove complete statements if it discovers that certain code would never be executed.
    /// The compiler sometimes changes the order of statements in your code.
    /// Normally, this wouldn’t be a problem in a single-threaded environment. 
    /// 
    /// But take a look at this example, in which a problem could happen in a multithreaded environment.
    /// </summary>
    public static class Program
    {
        private static volatile int _flag = 0;
        private static int _value = 0;

        public static void Main(string[] args)
        {
            Task.Run(() => Thread1());
            Task.Run(() => Thread2());

            Console.ReadLine();
        }

        public static void Thread1()
        {
            _value = 5;
            _flag = 1;
        }

        public static void Thread2()
        {
            if (_flag == 1)
                Console.WriteLine(_value);
        }
    }
}
