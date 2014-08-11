using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Inspecting an exception 
    /// 
    /// When using a catch block, you can use both an exception type and a named identifier. 
    /// This way, you effectively create a variable that will hold the exception for you so you can inspect its properties.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int i = int.Parse("123s");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Message: {0}", e.Message); 
                Console.WriteLine("StackTrace: {0}", e.StackTrace);
                Console.WriteLine("HelpLink: {0}", e.HelpLink);
                Console.WriteLine("InnerException: {0}", e.InnerException);
                Console.WriteLine("TargetSite: {0}", e.TargetSite);
                Console.WriteLine("Source: {0}", e.Source);
            }

            Console.ReadLine();
        }
    }
}
