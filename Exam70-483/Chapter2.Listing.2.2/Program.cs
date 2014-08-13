using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.Listing._2._2
{
    /// <summary>
    /// Creating a custom struct or value type
    /// 
    /// All objects in C# inherit from System.Object. 
    /// Value types, however, inherit from System. ValueType (which inherits from System.Object).
    /// System.ValueType overrides some of the default functions (such as GetHashCode, Equals, and ToString)
    /// to give them a more meaningful implementation for a value type. 
    /// 
    /// In C#, you cannot directly inherit from System.ValueType.
    /// Instead, you can use the struct keyword to create a new value type. 
    /// 
    /// The criteria for a custom value type are:
    ///     * The object is small
    ///     * The object is logically immutable
    ///     * There are a lot of objects
    ///     
    /// This example shows how you can create a struct that contains the coordinates for a point.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Structs and classes can have methods, fields, properties, constructors, and other functionalities.
            // You cannot, however, declare your own empty constructor for a struct. 
            // Also, structs cannot be used in an inheritance hierarchy (which saves you some memory bytes!). 

            // It’s important to know the different types that are available in C#.
            // A value type should be used for small, immutable objects that are used a lot.
            // In all other situations, use a reference type.

            var point = new Point(21, 23);

            Console.WriteLine("Point struct: {0}, {1}", point.x, point.y);
            Console.ReadLine();
        }
    }

    public struct Point
    {
        public int x, y;

        public Point(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
}
