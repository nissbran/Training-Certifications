using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Chatper4.Listing_._4._39
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string DoWork(string left, string right);
    }
}
