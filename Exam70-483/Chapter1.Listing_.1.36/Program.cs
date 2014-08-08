using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// It’s important to synchronize access to shared data. 
    /// One feature the C# language offers is the lock operator, which is some syntactic sugar that the compiler translates in a call to System.Thread.Monitor.
    /// 
    /// This shows the use of the lock operator to fix the previous example.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // After this change, the program always outputs 0 because access to the variable n is now synchronized. 
            // There is no way that one thread could change the value while the other thread is working with it.

            int n = 0;

            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (_lock)
                    {
                        n++;
                    }
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                { 
                    n--;
                }
            }

            up.Wait();
            Console.WriteLine(n);

            Console.ReadLine();
        }
    }
}
