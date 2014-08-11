using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// There is, however, one change you still have to make to follow the coding conventions in the .NET Framework. 
    /// Instead of using the Action type for your event, you should use the EventHandler or EventHandler<T>. 
    /// EventHandler is declared as the following delegate:
    ///
    ///     public delegate void EventHandler(object sender, EventArgs e);
    ///     
    /// By default, it takes a sender object and some event arguments. 
    /// The sender is by convention the object that raised the event (or null if it comes from a static method). 
    /// By using EventHandler<T>, you can specify the type of event arguments you want to use. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Listing 1-84");

            var p = new Pub();

            p.OnChange += (sender, e) => Console.WriteLine("Event raised by {0}, with value: {1}", sender, e.Value);

            p.Raise();

            Console.WriteLine("Listing 1-85");

            var pca = new PubWithCustomEventAccessor();
            pca.OnChange += (sender, e) => Console.WriteLine("Handler added with custom accessor. Event raised with value: {0}", e.Value);

            pca.Raise();

            Console.ReadLine();
        }
    }

    public class MyArgs : EventArgs
    {
        public int Value { get; set; }

        public MyArgs(int value)
        {
            Value = value;
        }
    }

    public class Pub
    {
        public event EventHandler<MyArgs> OnChange = delegate { };

        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }

    }

    /// <summary>
    /// Although the event implementation in Pub uses a public field, you can still customize addition and removal of subscribers. 
    /// This is called a custom event accessor
    /// </summary>
    public class PubWithCustomEventAccessor
    {
        private event EventHandler<MyArgs> onChange = delegate { };
        
        /// <summary>
        /// A custom event accessor looks a lot like a property with a get and set accessor.
        /// Instead of get and set you use add and remove. 
        /// It’s important to put a lock around adding and removing subscribers to make sure that the operation is thread safe.
        /// </summary>
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise()
        {
            onChange(this, new MyArgs(42));
        }
    }
}
