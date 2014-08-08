using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Another feature of delegates is that you can combine them together. This is called multicasting. 
    /// You can use the + or += operator to add another method to the invocation list of an existing delegate instance.
    ///
    /// </summary>
   public static class Program
    {
        public static void Main(string[] args)
        {
            new DelegateClass().MultiCast();

            Console.ReadLine();
        }
    }

   public class DelegateClass
   {
       public void MethodOne()
       {
           Console.WriteLine("MethodOne");  
       }

       public void MethodTwo()
       {
           Console.WriteLine("MethodTwo");
       }

       public delegate void Del();

       public void MultiCast()
       {
           Del d = MethodOne;
           d += MethodTwo;

           d();

           // You can also remove a method from an invocation list by using the decrement assignment operator (- or -=). 
           d -= MethodOne;

           d();

           // For example, to find out how many methods a multicast delegate is going to call, you can use the following code:
           int invocationCount = d.GetInvocationList().GetLength(0);
           Console.WriteLine(invocationCount);

       }
   }
}
