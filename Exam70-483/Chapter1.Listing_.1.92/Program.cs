using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Of course, there are still situations in which a finally block won’t run.
    /// For example, when the try block goes into an infinite loop, it will never exit the try block and never enter the finally block.
    /// And in situations such as a power outage, no other code will run. The whole operating system will just terminate. 
    /// 
    /// There is one other situation that you can use to prevent a finally block from running.
    /// Of course, this isn’t something you want to use on a regular basis,
    /// but you may have a situation in which just shutting down the application is safer than running finally blocks. 
    /// 
    /// Preventing the finally block from running can be achieved by using Environment.FailFast. 
    /// This method has two different overloads, one that only takes a string and another one that also takes an exception.
    /// When this method is called, the message (and optionally the exception) are written to the Windows application event log,
    /// and the application is terminated. 
    /// 
    /// This exampel shows how you can use this method. When you run this application without a debugger attached, a message is written to the event log.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();

            try
            {
                int i = int.Parse(s);
                if (i == 42)
                {
                    Environment.FailFast("Special number entered");
                }
            }
            finally
            {
                Console.WriteLine("Program complete.");
            }
        }
    }
}
