using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// As you have seen, with the TPL support in .NET, it’s quite easy to create a multithreaded application.
    /// But when you build real-world applications with multithreading,
    /// you run into problems when you want to access the same data from multiple threads simultaneously. 
    /// 
    /// This shows an example of what can go wrong.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    n++;
                }
            });

            for (int i = 0; i < 1000000; i++) n--;

            up.Wait();
            Console.WriteLine(n);

            Console.ReadLine();
        }
    }
}
