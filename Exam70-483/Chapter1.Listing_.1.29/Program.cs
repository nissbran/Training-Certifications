using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// You can use the CompleteAdding method to signal to the BlockingCollection that no more items will be added. 
    /// If other threads are waiting for new items, they won’t be blocked anymore. 
    /// 
    ///  By using the GetConsumingEnumerable method, you get an IEnumerable that blocks until it finds a new item.
    ///  That way, you can use a foreach with your BlockingCollection to enumerate it.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            BlockingCollection<string> collection = new BlockingCollection<string>();

            Task read = Task.Run(() =>
            {
                foreach (string v in collection.GetConsumingEnumerable())
                {
                    Console.WriteLine(v);
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(s))
                    {
                        collection.CompleteAdding();
                        break;
                    }

                    collection.Add(s);
                }
            });

            write.Wait();
        }
    }
}
