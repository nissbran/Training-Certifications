using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Throwing exceptions
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // When catching an exception, you can choose to rethrow the exception. 
            // You have three ways of doing this: 
            //  * Use the throw keyword without an identifier.
            //  * Use the throw keyword with the original exception.
            //  * Use the throw keyword with a new exception. 

            // -- Use the throw keyword without an identifier.
            // The first option rethrows the exception without modifying the call stack.
            // This option should be used when you don’t want any modifications to the exception.
            // This shows an example of using this mechanism.
            try
            {
                SomeOperation();
            }
            catch (Exception logEx)
            {
                Log(logEx);
                throw; // rethrow the original exception 
            }

            // -- Use the throw keyword with the original exception.
            // When you choose the second option, you reset the call stack to the current location in code. 
            // So you can’t see where the exception originally came from, and it is harder to debug the error. 
            // This example shows this behaviour

            try
            {
                SomeOperation();
            }
            catch (Exception logEx)
            {
                Log(logEx);
                throw logEx; // Throw original exception again, reset the stack to this location
            }

            // -- Use the throw keyword with a new exception. 
            // Using the third option can be useful when you want to raise another exception to the caller of your code. 
            // You can throw another exception, something like a custom MyException, and set the InnerException to the original exception.
            // In your MyException you can put extra information for the user of your code to place the error in context and help them solve it.
            // The original exception is preserved, including the stack trace, and a new exception with extra information is added.

            try
            {
                SomeOperation();
            }
            catch (Exception ex)
            {
                throw new MyException("My error", ex);
            }
        }

        public static string OpenAndParse(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("fileName", "Filename is required");
            }

            return File.ReadAllText(fileName);
        }

        public static void SomeOperation() { throw new Exception("Test"); }
        public static void Log(Exception logEx) { }


    }

    public class MyException : Exception
    {
        public MyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
