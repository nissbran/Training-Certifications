using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// The ContinueWith method has a couple of overloads that you can use to configure when the continuation will run. 
    /// This way you can add different continuation methods that will run when an exception happens,
    /// the Task is canceled, or the Task completes successfully.
    /// 
    /// This example shows how to do this.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
                {
                    return 42;
                });
            
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
            
            Task t2 = Task.Run(() =>
            {
                throw new Exception("Fault");
            }).ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            t2.Wait();

            Console.ReadLine();
        }
    }
}
