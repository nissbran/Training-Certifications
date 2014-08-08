using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// When you assign a method to a delegate, the method signature does not have to match the delegate exactly.
    /// This is called covariance and contravariance.
    /// Covariance makes it possible that a method has a return type that is more derived than that defined in the delegate. 
    /// Contravariance permits a method that has parameter types that are less derived than those in the delegate type. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class DelegateClass
    {
        public delegate TextWriter CovarianceDel();

        public StreamWriter MethodStream() { return null; }
        public StringWriter MethodString() { return null; }

        public void Covariance()
        {
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;

            // Because both StreamWriter and StringWriter inherit from TextWriter, you can use the CovarianceDel with both methods. 
        }

        public delegate void ContravarianceDel(StreamWriter tw); 
        void DoSomething(TextWriter tw) { } 

        public void Cotravariance()
        {
            ContravarianceDel del = DoSomething;

            // Because the method DoSomething can work with a TextWriter, it surely can also work with a StreamWriter. 
            // Because of contravariance, you can call the delegate and pass an instance of StreamWriter to the DoSomething method.
        }
    }
}
