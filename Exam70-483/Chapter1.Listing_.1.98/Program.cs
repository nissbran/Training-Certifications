using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    /// <summary>
    /// Creating custom exceptions
    /// 
    /// Once throwing an exception becomes necessary, it’s best to use the exceptions defined in the .NET Framework.
    /// But there are situations in which you want to use a custom exception. 
    /// This is especially useful when developers working with your code are aware of those exceptions and
    /// can handle them in a more specific way than the framework exceptions. 
    /// 
    /// A custom exception should inherit from System.Exception. You need to provide at least a parameterless constructor.
    ///  It’s also a best practice to add a few other constructors: 
    ///     one that takes a string,
    ///     one that takes both a string and an exception,
    ///     and one for serialization
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    [Serializable]
    public class OrderProcessingException : Exception, ISerializable
    {
        // By convention, you should use the Exception suffix in naming all your custom exceptions.
        // It’s also important to add the Serializable attribute,
        // which makes sure that your exception can be serialized and works correctly
        // across application domains (for example, when a web service returns an exception). 

        // You should never inherit from System.ApplicationException. 
        // The original idea was that all C# runtime exceptions should inherit from System.Exception 
        // and all custom exceptions from System.ApplicationException. 
        // However, because the .NET Framework doesn’t follow this pattern, 
        // the class became useless and lost its meaning.

        public int OrderId { get; private set; }

        public OrderProcessingException(int orderId)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }
        public OrderProcessingException(int orderId, string message, Exception innerException)
            : base(message, innerException)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }

        protected OrderProcessingException(SerializationInfo info, StreamingContext context)
        {
            OrderId = (int)info.GetValue("OrderId", typeof(int));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId, typeof(int));
        }

    }
}
