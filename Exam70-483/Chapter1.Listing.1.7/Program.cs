﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// When working directly with the Thread class, you create a new thread each time, and the thread dies when you’re finished with it. 
    /// The creation of a thread, however, is something that costs some time and resources.
    /// 
    /// A thread pool is created to reuse those threads, similar to the way a database connection pooling works.
    /// Instead of letting a thread die, you send it back to the pool where it can be reused whenever a request comes in. 
    /// 
    /// When you work with a thread pool from .NET, you queue a work item that is then picked up by an available thread from the pool.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threapool");
            });

            Console.ReadLine();
        }
    }
}
