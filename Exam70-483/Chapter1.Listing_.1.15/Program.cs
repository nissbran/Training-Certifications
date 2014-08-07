using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Instead of waiting until all tasks are finished, you can also wait until one of the tasks is finished. 
    /// You use the WaitAny method for this. 
    /// 
    /// This example shows how this works.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var tasks = new List<Task<int>>();

            tasks.Add(Task.Run(() => { Thread.Sleep(2000); return 1; }));
            tasks.Add(Task.Run(() => { Thread.Sleep(1000); return 2; }));
            tasks.Add(Task.Run(() => { Thread.Sleep(3000); return 3; }));

            while (tasks.Count > 0)
            {
                int i = Task.WaitAny(tasks.ToArray());

                Task<int> completedTask = tasks[i];

                Console.WriteLine(completedTask.Result);

                tasks.RemoveAt(i);
            }

            Console.ReadLine();
        }
    }
}
