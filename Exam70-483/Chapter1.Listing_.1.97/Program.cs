using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// In C# 5, a new option is added for rethrowing an exception. 
    /// You can use the ExceptionDispatchInfo.Throw method, which can be found in the System.Runtime.ExceptionServices namespace.
    /// This method can be used to throw an exception and preserve the original stack trace. 
    /// You can use this method even outside of a catch block.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            ExceptionDispatchInfo possibleException = null;

            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }

            if (possibleException != null)
            {
                possibleException.Throw();
            }

            // When looking at the stack trace, you see this line, which shows where the original exception stack trace ends and the ExceptionDispatchInfo.
            // Throw is used: 
            // --- End of stack trace from previous location where exception was thrown ---

            // This feature can be used when you want to catch an exception in one thread and throw it on another thread. 
            // By using the ExceptionDispatchInfo class, you can move the exception data between threads and throw it. 
            // The .NET Framework uses this when dealing with the async/ await feature added in C# 5. 
            // An exception that’s thrown on an async thread will be captured and rethrown on the executing thread.

            Console.ReadLine();
        }
    }
}
