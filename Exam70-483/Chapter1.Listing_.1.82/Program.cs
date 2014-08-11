using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// A popular design pattern (a reusable solution for a recurring problem) in application development is that of publish-subscribe.
    /// You can subscribe to an event and then you are notified when the publisher of the event raises a new event. 
    /// This is used to establish loose coupling between components in an application. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Listing 1-82");

            // Your code creates a new instance of Pub, subscribes to the event with two different methods and then raises the event by calling p.Raise. 
            // The Pub class is completely unaware of any subscribers. It just raises the event.

            var p = new Pub();

            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");

            p.Raise();

            // Although this system works, there are a couple of weaknesses. 
            // If you change the subscribe line for method 2 to the following, 
            // you would effectively remove the first subscriber by using = instead of +=:

            p.OnChange = () => Console.WriteLine("Overwrite of onchange subscriptions");

            p.Raise();

            // Another weakness is that nothing prevents outside users of the class from raising the event.
            // By just calling p.OnChange() every user of the class can raise the event to all subscribers. 
            Console.WriteLine("Raising the event from outside");

            p.OnChange();

            Console.WriteLine();
            Console.WriteLine("Listing 1-83");

            // To overcome these weaknesses, the C# language uses the special event keyword.

            p.OnChangeEvent += () => Console.WriteLine("This from an event keyword event");

            // p.OnChangeEvent(); will result in compilation error
            p.RaiseEvent();

            Console.ReadLine();
        }
    }

    public class Pub
    {
        public Action OnChange { get; set; }
        
        public void Raise()
        {
            // If there would be no subscribers to an event, the OnChange property would be null.
            // This is why the Raise method checks to see whether OnChange is not null. 

            if (OnChange != null)
            {
                OnChange();
            }
        }

        // EVENT KEYWORD --------------------------------------------------------------------------------

        // By using the event syntax, there are a couple of interesting changes.
        // First, you are no longer using a public property but a public field.
        // Normally, this would be a step back. 
        // However, with the event syntax, the compiler protects your field from unwanted access. 

        // An event cannot be directly assigned to (with the = instead of +=) operator.
        // So you don’t have the risk of someone removing all previous subscriptions, as with the delegate syntax. 

        // OnChangeEvent also uses some special syntax to initialize the event to an empty delegate. 
        // This way, you can remove the null check around raising the event because you can be certain that the event is never null. 
        public event Action OnChangeEvent = delegate { };

        public void RaiseEvent()
        {
            OnChangeEvent();
        }

    }
}
