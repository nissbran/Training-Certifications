using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatper1
{
    /// <summary>
    /// Catching different exception types 
    /// Using a finally block 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            ParseString("adfgsas");
            ParseString(null);
            ParseString("22");

            Console.ReadLine();
        }

        public static void ParseString(string s)
        {
            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You need to enter a value");
            }
            catch (FormatException)
            {
                
                Console.WriteLine("{0} is not a valid number. Please try again", s);
            }
            finally
            {
                Console.WriteLine("Method complete");
            }
        }
    }
}
