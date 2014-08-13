using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// WeakReference
    /// </summary>
    class Program
    {
        static WeakReference data;

        static void Main(string[] args)
        {
            object result = GetData();
            Console.WriteLine(data.Target);
            //GC.Collect(); //Uncommenting this line will make data.Target null 
            Console.WriteLine(data.Target);
            result = GetData();

            Console.ReadLine();
        }

        private static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(new List<string> { "Test", "Test2" });
            }

            if (data.Target == null)
            {
                data.Target = new List<string> { "Test", "Test2" };
            }

            return data.Target;
        }
    }
}
