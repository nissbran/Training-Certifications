using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            int n = 1;
            switch(n)
            {
                case 1:
                    {
                        Console.WriteLine("Case 1");
                        goto case 2;
                    }
                case 2:
                    {
                        Console.WriteLine("Case 2");
                        break;
                    }
            }
        }
    }
}
