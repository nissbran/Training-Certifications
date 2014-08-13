using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.Listing_._2._79_2._80_2._81
{
    /// <summary>
    ///  Finalization
    /// Because of this, C# supports the concept of finalization. 
    /// This mechanism allows a type to clean up prior to garbage collection.
    /// It’s important to understand that a C# finalizer is not the same as a C++ destructor. 
    /// C++ destructors can be called deterministic. You know when they will execute. 
    /// In C#, however, you can’t be sure when a finalizer is called.
    /// It will happen only when the garbage collector determines that your object is ready for being cleaned up. 
    /// 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var testclass = new MyClass();

            Console.ReadLine();

            // When running this piece of code in Release mode,
            // the garbage collector will see that there are no more references to stream, 
            // and it will free any memory associated with the StreamWriter instance. 
            // This will run the finalizer, which in turn will release any file handles to the temp.dat file
            // (in debug mode, the compiler will make sure that the reference isn’t garbage collected till the end of the method). 
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete("temp.dat");

            // This is not an ideal situation. You shouldn’t depend on the garbage collector to run a finalizer
            // at some point in time to close your file. Instead, you should do this yourself. 
            // To offer you the opportunity of explicitly freeing unmanaged resources,
            // C# offers the idea of the IDisposable interface

            StreamWriter stream2 = File.CreateText("Temp2.dat");
            stream2.Write("some data 2");
            stream2.Dispose();

            File.Delete("Temp2.data");

            // But what if an exception would occur before stream.Dispose() is called?
            // To make sure that your resources are always cleaned up,
            // you need to wrap all types that implement IDisposable in a try/finally statement. 
            // Because this is so common, C# has a special statement for this: 
            // the using statement. The using statement is translated by the compiler in a try/finally
            // statement that calls Dispose on the object. 
            // Because of this, the using statement can be used only with types that implement IDisposable.

            using (StreamWriter sw = File.CreateText("Temp3.dat"))
            {
                sw.Write("Some data 3");
            }

            File.Delete("Temp3.dat");
        }
    }

    class MyClass
    {
        // A finalizer in C# requires some special syntax, just as a constructor. 
        // You need to prefix the class name with a tilde (~) to create a finalizer.
        ~MyClass()
        {
            Console.WriteLine("MyClass dies");
        }
    }
}
