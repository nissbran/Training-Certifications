using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// DynamicObject and ExpandoObject 
    /// 
    /// The .NET Framework offers two special classes when working with dynamic types: 
    ///     DynamicObject and ExpandoObject.
    /// 
    /// DynamicObject is the most flexible. When inheriting from DynamicObject,
    /// you can override members that enable you to override operations such as getting or setting a member,
    /// calling a method, or performing conversions. 
    /// By using DynamicObject, you can create truly dynamic objects and have full control over how they operate at runtime.
    /// 
    /// This example shows how to inherit from DynamicObject.
    /// </summary>
    public static class Program
    {
        private static dynamic dataBag = new ExpandoObject();

        static void Main(string[] args)
        {
            dynamic obj = new SampleObject();
            Console.WriteLine(obj.SomeProperty); 

            // ExpandoObject is a sealed implementation that enables you to get and set properties on a type. 
            // In ASP.NET Model-View-Controller (MVC), for example, 
            // there is a ViewBag that can be used to pass data from the Controller to the View.
            // ViewBag is an ExpandoObject. Instead of creating a new,
            // statically typed property for each data element you want to pass, you can use the ViewBag

            dataBag.ViewData = "Test";

            Console.WriteLine(dataBag.ViewData);
            Console.ReadLine();

            // The dynamic keyword should be used carefully. It gives you great flexibility, 
            // but because you lose static typing it can also easily lead to errors that can only be found at runtime. 
            // But when integrating with other languages or to replace reflection,
            // the dynamic support is a nice addition to the .NET Framework.
        }
    }

    public class SampleObject : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }
}
