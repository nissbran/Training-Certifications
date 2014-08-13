using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Now you can extend classes without modifying the original code. 
    /// When designing your classes, it’s important to plan for extension points such as these. 
    /// You can disable inheritance by using the sealed keyword on a class or a method. 
    /// When used on a class, you can’t derive other classes from it. 
    /// When used on a method, derived classes can’t override the method.
    /// 
    /// This shows how this works.
    /// </summary>
    class Program
    {
        static void Main(string[] args) { }
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
        public sealed override int MyMethod()
        {
            return base.MyMethod() * 2;
        }
    }

    class Derived2 : Derived1
    {
        // This line would give a compile error    
        // public override int MyMethod() { return 1;} 
    }
}
