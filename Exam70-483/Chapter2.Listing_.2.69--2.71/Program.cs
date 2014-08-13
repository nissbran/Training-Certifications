using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Reflection example
    /// 
    /// When would you use reflection? Assume that you want to create a plug-in system, 
    /// and you have a directory in your system that contains all plug-ins.
    /// If a new assembly is dropped in this location, 
    /// you inspect the assembly for the plug-ins it contains and then add them to your application. 
    /// This is impossible without reflection.
    /// 
    /// When creating a plug-in system, you need some way of finding plug-ins, 
    /// getting some info, and executing them. One option is to create a custom IPlugin interface
    /// that exposes members that give you information about the plug-in and the capability to load it
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // The first line loads the assembly by name.
            // One thing to note is that if you call this multiple times,
            // the runtime will load the assembly only once.
            // If you want to reload the assembly you would have to restart your application.
            // After you have the assembly, you can check which plugins are defined in it and then construct your IPlugin objects. 
            Assembly pluginAssembly = Assembly.Load("Chapter2.Listing_.2.69--2.71");

            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;
            foreach ( Type pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
            }
        }
    }

    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(MyApplication application);
    }

    public class MyApplication {}

    public class MyPlugin : IPlugin
    {
        public string Name
        {
            get { return "MyPlugin"; }
        }

        public string Description
        {
            get { return "Test plugin"; }
        }

        public bool Load(MyApplication application)
        {
            throw new NotImplementedException();
        }
    }

    
}
