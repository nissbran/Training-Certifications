using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// The Thread constructor has another overload that takes an instance of a ParameterizedThreadStart delegate. 
    /// This overload can be used if you want to pass some data through the start method of your thread to your worker method.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));

            // In this case, the value 5 is passed to the ThreadMethod as an object. You can cast it to the expected type to use it in your method. 
            t.Start(5);
            t.Join();
        }

        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
