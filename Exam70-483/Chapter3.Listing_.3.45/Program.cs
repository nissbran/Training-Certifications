using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// The .NET Framework offers classes that can help you with logging and tracing in the System.Diagnostics namespace.
    /// One such class is the Debug class, which can, as its name suggests, be used only in a debug build.
    /// This is because the ConditionalAttribute with a value of DEBUG is applied to the Debug class.
    /// You can use it for basic logging and executing assertions on your code. 
    /// 
    /// This program shows an example of using the Debug class.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }
    }
}
