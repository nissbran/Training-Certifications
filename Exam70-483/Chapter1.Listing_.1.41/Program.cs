using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Interlocked also supports switching values by using the Exchange method. You use this method as follows:
    /// 
    /// You can also use the CompareExchange method. This method first checks to see whether the expected value is there; 
    /// if it is, it replaces it with another value.
    /// 
    /// Listing 1-41 shows what can go wrong when comparing and exchanging a value in a nonatomic operation.
    /// </summary>
    public static class Program
    {
        static int value = 1;

        public static void Main(string[] args)
        {
            var t1 = Task.Run(() =>
            {
                // Instead of if (value == 1) value = 2;
                Interlocked.CompareExchange(ref value, 2, 1);
            });

            var t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
