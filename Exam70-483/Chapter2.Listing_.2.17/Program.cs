using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Overriding Methods
    /// 
    /// Another way to extend an existing type is to use inheritance and overriding. 
    /// When a method in a class is declared as virtual, you can override the method in a derived class. 
    /// You can completely replace the existing functionality or you can add to the behavior of the base class.
    /// 
    /// This example shows how to override a method in a derived class to change some functionality.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var der1 = new Derived1();
            var der2 = new Derived2();

            Console.WriteLine("Derived 1: {0}", der1.MyMethod());
            Console.WriteLine("Derived 2: {0}", der2.MyMethod());

            Console.ReadLine();
        }
    }

    class Base
    {
        public virtual int MyMethod()
        {
            return 42;
        }
    }

    class Derived1 : Base
    {
        public override int MyMethod()
        {
            return base.MyMethod() * 2;
        }
    }

    class Derived2 : Base
    {

    }
}
