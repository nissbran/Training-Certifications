using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.Listing._2._1
{
    /// <summary>
    /// Enumerations can also be used with a special Flags attribute;
    /// you can use one enum to set multiple combinations of values. 
    /// 
    /// This example shows how to do this.
    /// </summary>
    public static class Program
    {
        private static Days readingDays = Days.Monday | Days.Saturday;

        public static void Main(string[] args)
        {
            var monday = Days.Monday;
            var saturday = Days.Saturday;
            var sunday = Days.Sunday;

            if (readingDays.HasFlag(monday))
            {
                Console.WriteLine("Monday is Reading days");
            }

            if (readingDays.HasFlag(saturday))
            {
                Console.WriteLine("Saturday is Reading days");
            }

            if (readingDays.HasFlag(sunday))
            {
                Console.WriteLine("Sunday is Reading days");
            }

            Console.ReadLine();
        }
    }

    [Flags]
    enum Days
    {
        None = 0x0, 
        Sunday = 0x1,
        Monday = 0x2, 
        Tuesday = 0x4,
        Wednesday = 0x8, 
        Thursday = 0x10, 
        Friday = 0x20, 
        Saturday = 0x40
    }

    

}
