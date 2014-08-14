using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// Secure strings
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // The SecureString is used with a using statement,
            // so the Dispose method is called when you are done with the string
            // so that it doesn’t stay in memory any longer then strictly necessary. 
            using (SecureString ss = new SecureString())
            {
                Console.WriteLine("Please enter password: ");
                while(true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                ss.MakeReadOnly();

                Console.WriteLine();

                ConvertToUnsecureString(ss);
            }

            Console.ReadLine();
        }

        // At some point, you probably want to convert the SecureString back to a normal string so you can use it.
        // The .NET Framework offers some special functionality for this.
        // It’s important to make sure that the regular string is cleared from memory as soon as possible. 
        // This is why there is a try/finally statement around the code.
        // The finally statement makes sure that the string is removed from memory even if there is an exception thrown in the code.
        // This method shows an example of how to do this.
        public static void ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }

            // It’s important to realize that a SecureString is not completely secure.
            // You can create an application, running in full thrust, which will be able to read the SecureString content.
            // However, it does add to the complexity of hacking your application. 
            // All the small steps you can take to make your application more secure will create a bigger hindrance for an attacker.
        }
    }
}
