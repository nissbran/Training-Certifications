using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// If you want to use local data in a thread and initialize it for each thread, you can use the ThreadLocal<T> class. 
    /// This class takes a delegate to a method that initializes the value.
    /// </summary>
    public static class Program
    {
        public static ThreadLocal<int> _field = new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });

        public static void Main(string[] args)
        {
            // Here you see another feature of the .NET Framework. 
            // You can use the Thread.CurrentThread class to ask for information about the thread that’s executing. 
            // This is called the thread’s execution context. This property gives you access to properties like the thread’s 
            // current culture (a CultureInfo associated with the current thread that is used to format dates, times, numbers, currency values, 
            // the sorting order of text, casing conventions, and string comparisons), 
            // principal (representing the current security context), 
            // priority (a value to indicate how the thread should be scheduled by the operating system), and other info.
            // 
            // When a thread is created, the runtime ensures that the initiating thread’s execution context is flowed to the new thread. 
            // This way the new thread has the same privileges as the parent thread. 
            //
            // This copying of data does cost some resources, however. 
            // If you don’t need this data, you can disable this behavior by using the ExecutionContext.SuppressFlow method.

            new Thread(() =>
            {
                Console.WriteLine("Thread A, Thread Id {0}", _field.Value);
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread A: {0}", i);
                }
            }).Start();

            new Thread(() =>
            {
                Console.WriteLine("Thread B, Thread Id {0}", _field.Value);
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", i);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
