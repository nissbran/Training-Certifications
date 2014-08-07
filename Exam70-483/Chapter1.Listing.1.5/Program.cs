using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// A thread has its own call stack that stores all the methods that are executed. 
    /// Local variables are stored on the call stack and are private to the thread.
    /// A thread can also have its own data that’s not a local variable.
    /// By marking a field with the ThreadStatic attribute, each thread gets its own copy of a field.
    /// </summary>
    public static class Program
    {
        [ThreadStatic]
        public static int _field;

        public static void Main(string[] args)
        {
            // With the ThreadStaticAttribute applied, the maximum value of _field becomes 10. 
            // If you remove it, you can see that both threads access the same value and it becomes 20. 

            new Thread(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _field++;
                        Console.WriteLine("Thread A: {0}", _field);
                    }
                }).Start();

            new Thread(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _field++;
                        Console.WriteLine("Thread B: {0}", _field);
                    }
                }).Start();

            Console.ReadKey();
        }
    }
}
