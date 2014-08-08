using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// ConcurrentQueue
    /// 
    /// ConcurrentQueue offers the methods Enqueue and TryDequeue to add and remove items from the collection.
    /// It also has a TryPeek method and it implements IEnumerable by making a snapshot of the data.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
            {
                Console.WriteLine("Dequeued: {0}", result);
            }

            Console.ReadLine();
        }
    }
}
