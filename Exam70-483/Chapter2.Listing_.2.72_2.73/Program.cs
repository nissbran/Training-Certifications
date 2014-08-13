using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.Listing_._2._72_2._73
{
    /// <summary>
    /// Reflection can also be used to inspect the value of a property or a field.
    /// Suppose that you need to create a method that iterates over an object and selects all 
    /// the private integer fields to display them on-screen. You can easily do this by using reflection.
    /// You use the BindingFlags enumeration to control how reflection searches for members.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestClass();

            DumpObject(test);

            // -- Listing 2.73
            // Reflection can also be used to execute a method on a type.
            // You can specify the param- eters the method needs, 
            // and at runtime the .NET Framework will see whether the parameters match 
            // and it will execute the method.

            int i = 42;
            MethodInfo compareToMethod = i.GetType().GetMethod("CompareTo", new Type[] { typeof(int) });
            int result = (int)compareToMethod.Invoke(i, new object[] { 41 });
            Console.WriteLine("Compare to result: {0}", result);

            Console.ReadLine();
        }

        static void DumpObject(Object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int))
                {
                    Console.WriteLine(field.GetValue(obj));
                }
            }
        }
    }

    class TestClass
    {
        private int _testfield = 2;
        private string _testStringField = "Hello";
        public int _publicTestField = 4;
    }
}
