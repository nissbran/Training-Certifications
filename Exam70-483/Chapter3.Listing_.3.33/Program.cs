using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// This console application creates an instance of a Timer object and then sets the timer to fire every 2 seconds.
    /// When it does, it outputs the current data and time. 
    /// It also calls GC.Collect to force the garbage collector to run.
    /// Normally, you would never do this, but in this example it shows some interesting behavior. 
    /// 
    /// When you run this application in debug mode, 
    /// it does a nice job of outputting the time every 2 seconds and keeps on doing this until you terminate the application. 
    /// 
    /// But when you execute this application in release mode, it outputs the current date and time only once. 
    /// This demonstrates the difference between a debug and a release build.
    /// When executing a release build, the compiler optimizes the code. 
    /// In this scenario, it sees that the Timer object is not used anymore, 
    /// so it’s no longer considered a root object and the garbage collector removes it from memory.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Timer t = new Timer(TimerCallback, null, 0, 2000);
            Console.ReadLine();
        }

        private static void TimerCallback(object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            GC.Collect();
        }
    }
}
