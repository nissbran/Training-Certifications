using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.Listing_._1._13
{
    /// <summary>
    /// In the previous example, you had to create three Tasks all with the same options. 
    /// To make the process easier, you can use a TaskFactory.
    /// A TaskFactory is created with a certain configuration and can then be used to create Tasks with that configuration.
    /// 
    /// This example shows how you can simplify the previous example with a factory.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Task<int[]> parent = Task.Run(() =>
                {
                    var results = new int[3];

                    TaskFactory factory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                    factory.StartNew(() => results[0] = 0);
                    factory.StartNew(() => results[1] = 1);
                    factory.StartNew(() => results[2] = 2);

                    return results;
                });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (var i in parentTask.Result)
                    {
                        Console.WriteLine(i);
                    }
                });

            finalTask.Wait();

            Console.ReadLine();

        }
    }
}
