using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Using dynamic types
    /// 
    /// As stated before, C# is a partially static typed language. The dynamic keyword, added in C# 4.0,
    /// is where you enter the world of weakly typed languages. 
    /// Working in a weakly typed system is helpful when communicating with external resources 
    /// (such as COM Interop, Iron- Python, JavaScript Object Notation (JSON) result sets, 
    /// or the HTML Document Object Model [DOM]) or when working with reflection inside C#. 
    /// 
    /// When the C# compiler encounters the dynamic keyword, it stops with statically type checking 
    /// (for example, checking whether a method exists on a type or if it has certain argu- ments).
    /// Instead, the compiler saves the intent of the code so that it can be later executed at runtime. 
    /// This is why using dynamic types won’t generate any compiletime errors, although it can certainly generate runtime errors.
    /// </summary>
    public static class Program
    {
        static void Main(string[] args)
        {
            // All the type checking and necessary conversions take place at runtime.
            TestDynamic(new List<dynamic>()
                {
                    new {
                        Value1 = 234,
                        Value2 = "Hej"
                    },
                    new {
                        Value1 = "Ost",
                        Value2 = 43
                    }
                });

            Console.ReadLine();
        }

        static void TestDynamic(IEnumerable<dynamic> entities)
        {
            foreach (var entity in entities)
            {
                Console.WriteLine("Value 1: {0}", entity.Value1);
                Console.WriteLine("Value 2: {0}", entity.Value2);
            }
        }
    }
}
