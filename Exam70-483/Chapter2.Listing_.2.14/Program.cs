using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Using a where clause on a class definition
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var intResult = MyGenericMethod<int>();
            var stringResult = MyGenericMethod<string>();
        }

        // When working with a reference type, the default value is null;
        // with a value type such as int, it is 0.
        // But what is the default value when working with a generic type parameter?
        // In this case, you can use the special default(T) keyword. 
        // This gives you the default value for the specific type of T
        public static T MyGenericMethod<T>()
        {
            return default(T);
        }
    }

    class MyClass<T> where T: class, new()
    {
        public MyClass()
        {
            MyProperty = new T();
        }

        public T MyProperty { get; set; }
    }

    
}
