using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    /// WebRequest and WebResponse
    /// 
    /// WebRequest and WebResponse form a pair of classes that you can use together to send a request
    /// for information and then receive the response with the data you requested. 
    /// 
    /// A WebRequest is created by using a static Create method on the WebRequest class.
    /// The Create method inspects the address that you pass to it and then selects the correct protocol implementation. 
    /// If you would pass the address http://www.microsoft.com to it, 
    /// it would see that you are working with the HTTP protocol and it would return an HttpWebRequest.
    /// After creating the correct WebRequest, you can set other properties such as authentication or caching instructions. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("http://www.microsoft.com");

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = responseStream.ReadToEnd();
                    Console.WriteLine(responseText);
                }
            }

            Console.ReadLine();
        }
    }
}
