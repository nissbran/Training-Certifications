using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

        public delegate Person PersonCovarianceTest();

        public Employee MethodEmp() { return null; }
        public Person MethodPers() { return null; }

        public void PersonCovariance()
        {
            PersonCovarianceTest pct = MethodEmp;
        }

        public delegate void PersonContravarianceDel(Employee e);
        public void DoMethodEmp(Employee e) { }
        public void DoMethodPers(Person p) { }

        public void PersonContravariance()
        {
            PersonContravarianceDel pct = DoMethodEmp;
            pct = DoMethodPers;
            Func<float, float> f;
            f = delegate(float x) { return x * x; };
            //f = float Func(float x)  { return x*x;};
            f = (float x) => { return x * x; };

           // Action note;

            //note = { return "test";};
            //note = () => return "test";
            f = x => x * x;

            Func<float, float> test = (x) => x;
            //int y = test(22);
            test(22);
            Func<float, float> test2 = test;

            //var testType = typeof(Person);
            Assembly ass;
            var test4 = typeof(Assembly);
            test4.GetField("test", BindingFlags.Instance & BindingFlags.IgnoreReturn);
        }

        public delegate void MovedEventHandler();
        public delegate decimal MyFunc(decimal[] values);
        public event MovedEventHandler MovedEvent;

        public Func<Person> GetPerson() { return null; }
    }


    public class Person
    {
        public event Action MovedEvent;
    }
    public class Employee : Person { 
    
        public void Test()
        {
            
        }
    }

}
