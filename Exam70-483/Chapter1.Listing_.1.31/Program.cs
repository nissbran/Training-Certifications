using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// ConcurrentBag also implements IEnumerable<T>, so you can iterate over it. 
    /// This operation is made thread-safe by making a snapshot of the collection when you start iterating it,
    /// so items added to the collection after you started iterating it won’t be visible. 
    /// 
    /// This example shows this in practice.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (var i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();

            Console.ReadLine();
        }
    }
}
