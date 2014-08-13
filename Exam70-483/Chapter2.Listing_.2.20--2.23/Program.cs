using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Implicit conversions
    /// 
    /// An implicit conversion doesn’t need any special syntax.
    /// It can be executed because the co piler knows that the conversion is allowed and that it’s safe to convert. 
    /// 
    /// Explicit conversions
    /// 
    /// Because of the type safety of the C# language, the compiler protects you from all implicit conversions that are not safe,
    /// such as converting a double to an int. 
    /// If you do want to make this conversion, you need to do it explicitly. 
    /// This is called casting.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // -------- Implicit conversions --------
            // Listing 2-20 Implicitly converting an integer to a double
            // A value type such as int can be stored as a double because an int can fit inside a double without losing any precision. 
            int i = 42;
            double d = i;

            // Listing 2-21 Implicitly converting an object to a base type
            // Another implicit conversion is that from a reference type to one of its base types.
            // For example, each reference type can be stored inside an object because ultimately each reference type inherits from an object. 
            // If an object implements an interface, it can also be implicitly converted to the interface.
            HttpClient client = new HttpClient(); 
            object o = client;
            IDisposable disp = client;

            // -------- Explicit conversions --------
            // Listing 2-22 Casting a double to an int 
            double x = 1234.7; 
            int a; 
            // Cast double to int
            a = (int)x; // a = 1234

            // Listing 2-23 Explicitly casting a base type to a derived type
            // As with implicit conversion, explicit conversions also exist for reference types.
            // Where you can go implicitly from a derived type to a base type, you need to cast from a derived to a base type
            Object stream = new MemoryStream();
            MemoryStream memoryStream = (MemoryStream)stream;
        }
    }
}
