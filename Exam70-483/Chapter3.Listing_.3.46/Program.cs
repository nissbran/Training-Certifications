using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// Another class that you can use is the TraceSource class,
    /// which was added in .NET 2.0 and should be used instead of the static Trace class. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);

            traceSource.TraceInformation("Tracing application...");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });

            traceSource.Flush();
            traceSource.Close();
        }
    }
}
