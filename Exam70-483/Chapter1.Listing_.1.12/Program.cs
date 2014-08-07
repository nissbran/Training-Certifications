using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Next to continuation Tasks, a Task can also have several child Tasks. 
    /// The parent Task finishes when all the child tasks are ready. 
    /// 
    /// This example shows how this works.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Task<int[]> parent = Task.Run(() =>
            {
                var results = new int[3];

                new Task(() => results[0] = 0,
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                    TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            // The finalTask runs only after the parent Task is finished, and the parent Task finishes when all three children are finished. 
            // You can use this to create quite complex Task hierarchies that will go through all the steps you specified. 

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
