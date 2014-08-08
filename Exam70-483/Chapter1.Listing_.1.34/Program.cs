using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// ConcurrentDictionary 
    /// 
    /// A ConcurrentDictionary stores key and value pairs in a thread-safe manner. 
    /// You can use methods to add and remove items, and to update items in place if they exist. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // When working with a ConcurrentDictionary you have methods that can atomically add, get, and update items.
            // An atomic operation means that it will be started and finished as a single step without other threads interfering.
            // TryUpdate checks to see whether the current value is equal to the existing value before updating it.
            // AddOrUpdate makes sure an item is added if it’s not there, and updated to a new value if it is. 
            // GetOrAdd gets the current value of an item if it’s available; if not, it adds the new value by using a factory method.

            var dictionary = new ConcurrentDictionary<string, int>();

            if (dictionary.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }

            if (dictionary.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
            }

            dictionary["k1"] = 42; // Overwrite unconditionally

            int r1 = dictionary.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dictionary.GetOrAdd("k2", 3);

            Console.ReadLine();
        }
    }
}
