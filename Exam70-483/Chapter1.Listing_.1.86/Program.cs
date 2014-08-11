using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// If you use the regular event syntax, the compiler generates the accessor for you.
    /// This makes it clear that events are not delegates; instead they are a convenient wrapper around delegates. 
    /// 
    /// Delegates are executed in a sequential order. Generally, delegates are executed in the order in which they were added,
    /// although this is not something that is specified within the Common Language Infrastructure (CLI), so you shouldn’t depend on it. 
    /// 
    /// One thing that is a direct result of the sequential order is how to handle exceptions. 
    /// This program shows an example in which one of the event subscribers throws an error.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Listing 1-86");

            Pub p = new Pub();

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");

            p.OnChange += (sender, e) =>
            {
                throw new Exception("Error");
            };

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");

            p.Raise();

            // As you can see, the first subscriber is executed successfully,
            // the second one throws an exception,
            // and the third one is never called. 

            Console.ReadLine();
        }
    }

    public class Pub
    {
        public event EventHandler OnChange = delegate { };
        public void Raise()
        {
            OnChange(this, EventArgs.Empty);
        }
    }
}
