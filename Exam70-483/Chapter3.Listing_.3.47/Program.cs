using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// Configuring TraceListener. 
    /// </summary>
    public static class Program
    {
        static void Main(string[] args)
        {
            using (Stream outputFile = File.Create("tracefile.txt"))
            {
                TextWriterTraceListener textListener = new TextWriterTraceListener(outputFile);

                TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);

                traceSource.Listeners.Clear();
                traceSource.Listeners.Add(textListener);

                traceSource.TraceInformation("trace output");

                traceSource.Flush();
                traceSource.Close();
            }
        }
    }
}
