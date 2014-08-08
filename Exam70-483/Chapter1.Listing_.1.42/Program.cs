using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Canceling tasks 
    /// 
    /// When working with multithreaded code such as the TPL, the Parallel class, or PLINQ, you often have long-running tasks.
    /// The .NET Framework offers a special class that can help you in canceling these tasks:
    ///     CancellationToken. 
    ///     
    /// You pass a CancellationToken to a Task, which then periodically monitors the token to see whether cancellation is requested. 
    /// 
    /// This example shows how you can use a CancellationToken to end a task.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // The CancellationToken is used in the asynchronous Task. 
            // The CancellationTokenSource is used to signal that the Task should cancel itself. 

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            var task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();

            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }
    }
}
