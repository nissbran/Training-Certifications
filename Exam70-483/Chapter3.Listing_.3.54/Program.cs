using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// 
    /// Creating your own performance counters
    /// 
    /// Creating your own performance counters can be a huge help when checking on the health of your application. 
    /// You can create another application to read them (some kind of dashboard application),
    /// or you can use the Performance Counter Monitor tool that Windows provides.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Created performance counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            var totalOperationsCounter = new PerformanceCounter("MyCategory", "# operations executed", "", false);
            var operationsPerSecondCounter = new PerformanceCounter("MyCategory", "# operations / sec", "", false);

            totalOperationsCounter.Increment();
            operationsPerSecondCounter.Increment();

            Console.WriteLine("Total number of operations: {0}", totalOperationsCounter.RawValue);
            Console.WriteLine("Operations / sec: {0}", operationsPerSecondCounter.RawValue);

            Console.ReadLine();
        }

        private static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection
                {
                    new CounterCreationData(
                        "# operations executed",
                        "Total number of operations executed",
                        PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData(
                        "# operations / sec",
                        "Number of operations executed per second",
                        PerformanceCounterType.RateOfCountsPerSecond32)
                };

                PerformanceCounterCategory.Create("MyCategory", "Sample category for Codeproject", counters);

                return true;
            }

            return false;
        }
    }
}
