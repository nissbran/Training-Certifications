using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// ConcurrentStack
    /// 
    /// A stack is a last in, first out (LIFO) collection. A queue is a first in, first out (FIFO) collection. 
    /// 
    /// ConcurrentStack has two important methods: Push and TryPop. Push is used to add an item to the stack; 
    /// TryPop tries to get an item off the stack. 
    /// You can never be sure whether there are items on the stack because multiple threads might be accessing your collection at the same time.
    /// 
    /// You can also add and remove multiple items at once by using PushRange and TryPopRange.
    /// When you enumerate the collection, a snapshot is taken. 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
            {
                Console.WriteLine("Popped: {0}", result);
            }

            stack.PushRange(new int[] { 1, 2, 3 });

            int[] values = new int[2];
            stack.TryPopRange(values);

            foreach (var i in values)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
