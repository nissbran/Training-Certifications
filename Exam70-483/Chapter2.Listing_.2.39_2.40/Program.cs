using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Using explicit interface implementations
    /// 
    /// Interfaces are useful when using encapsulation. 
    /// In the next objective, you look at how you can design and use interfaces.
    /// But regarding the topic of encapsulation, you need to know about explicit interface implementation.
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // -- Listing 2-39

            Implementation test = new Implementation();
            // test.MyMethod(); // This doesnt compile

            IInterfaceA testImp = new Implementation();
            testImp.MyMethod(); // this does

            // The Implementation class implements the interface IInterfaceA explicitly.
            // When you have an instance of Implementation, you can’t access MyMethod. 
            // But when you cast Implementation to IInterfaceA, you have access to MyMethod. 
            // In such a way, explicit interface implementation can be used to hide members of a class to outside users. 

            // -- Listing 2-40

            // There is another situation in which explicit interface implementation is necessary: 
            // when a class implements two interfaces that contain duplicate method signatures
            // but wants a different implementation for both.
            // When implicitly implementing those two interfaces, only one method exists in the implementation.
            // With explicit interface implementation, both interfaces have their own implementation. 

            MoveableObject mObject = new MoveableObject();
            ILeft left = mObject;
            IRight right = mObject;

            // mObject.Move(); // This doesnt compile
            left.Move();
            right.Move();

            Console.Read();
        }
    }

    interface IInterfaceA
    {
        void MyMethod();
    }

    class Implementation : IInterfaceA
    {
        void IInterfaceA.MyMethod() { }
    }

    interface ILeft
    {
        void Move();
    }

    interface IRight
    {
        void Move();
    }

    class MoveableObject : ILeft, IRight
    {
        void ILeft.Move() { Console.WriteLine("Move left"); }
        void IRight.Move() { Console.WriteLine("Move right"); }
    }
}
