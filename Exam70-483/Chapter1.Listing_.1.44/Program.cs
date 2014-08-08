using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Instead of catching the exception, you can also add a continuation Task that executes only when the Task is canceled.
    /// In this Task, you have access to the exception that was thrown, and you can choose to handle it if that’s appropriate. 
    /// 
    /// This example shows what such a continuation task would look like.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
                token.ThrowIfCancellationRequested();
            }, token).ContinueWith((t) =>
            {
                Console.WriteLine("You have canceled the task");
            }, TaskContinuationOptions.OnlyOnCanceled);
            
            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();

            cancellationTokenSource.Cancel();
            task.Wait();

            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }
    }
}
