using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Throw exception when cancel was requested
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

                token.ThrowIfCancellationRequested();

            }, token);

            try
            {
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();

                cancellationTokenSource.Cancel();
                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
            }

            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }

    }
}
