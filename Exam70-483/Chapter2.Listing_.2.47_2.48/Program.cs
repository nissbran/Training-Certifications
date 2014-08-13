using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Changing behavior 
    /// 
    /// When building a class hierarchy, you sometimes want to replace or extend the behavior of a base class.
    /// Assume that you want to add some logging capabilities to the repository you created. 
    /// You don’t want to rewrite all filtering code; instead you just want to add some extra behavior.
    /// 
    /// This is where the virtual and override keywords come into play.
    /// Marking a method virtual allows derived classes to override the method. 
    /// The derived class can choose to completely replace or to extend the behavior of the base class.
    /// </summary>
    class Base
    {
        protected virtual void Execute() { }
    }

    class Derived : Base
    {
        /// <summary>
        /// By marking the method in the base class as virtual, the derived class can override it. 
        /// By prefixing a method name with base, a derived class can execute the method on the base class.
        /// By skipping the call to base, the derived class completely replaces the functionality. 
        /// </summary>
        protected override void Execute()
        {
            Log("Before executing");
            base.Execute();
            Log("After executing");
        }

        private void Log(string message) { }
    }

    class Base2
    {
         public void Execute() { Console.WriteLine("Base2.Execute"); }
    }

    /// <summary>
    /// If a base class doesn’t declare a method as virtual, a derived class can’t override the method. 
    /// It can, however, use the new keyword, which explicitly hides the member from a base class 
    /// (this is different from using the new keyword to create a new instance of an object). 
    /// This can cause some tricky situations, as show in the main method below
    /// </summary>
    class Derived2 : Base2
    {
        public new void Execute() { Console.WriteLine("Derived2.Execute"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Base2 b = new Base2();
            b.Execute();
            b = new Derived2();
            b.Execute();

            // Running this code will output Base2.Execute twice. 
            // If you change the base execute method to be virtual and 
            // the derived class to override instead of hide the Execute method,
            // the code will display Base2.Execute and Derived2.Execute. 
            // You should try to avoid hiding methods with the new keyword.

            Derived2 d = new Derived2();
            d.Execute();
            b = d;
            b.Execute();

            Console.ReadLine();
        }
    }

}

