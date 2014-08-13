using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Conversions with a helper class
    /// 
    /// The .NET Framework also offers helper classes for conversions between types. 
    /// For converting between noncompatible types, you can use System.BitConverter.
    /// For conversion between compatible types, you can use System.Convert and the Parse or TryParse methods on various types. 
    /// 
    /// This example shows how to use Parse and TryParse.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            int value = Convert.ToInt32("42");
            value = int.Parse("42");
            bool success = int.TryParse("42", out value);

            // When creating your own types, you can override ToString to return a string representation of your object.
            // If necessary, you can then create a Parse and TryParse method that converts the string back to the original object. 
            // Implementing the IFormattable interface is required so that your object can be used by the Convert class
        }
    }
}
