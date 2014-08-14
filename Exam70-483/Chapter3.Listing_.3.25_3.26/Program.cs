using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3.Listing_._3._25_3._26
{
    /// <summary>
    /// CAS: Code Access Security
    ///
    /// The .NET Framework helps you protect your computers from malicious code via a mechanism called code access security (CAS).
    /// Instead of giving every application full trust,
    /// applications can be restricted on the types of resources they can access and the operations they can execute. 
    /// 
    /// When using CAS, your code is the untrusted party.
    /// You need to ask for permission to execute certain operations or access protected resources. 
    /// The common language runtime (CLR) enforces security restrictions on managed code and makes sure that your code
    /// has the correct permissions to access privileged resources. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DeclarativeCAS();
            ImperativeCAS();
        }

        [FileIOPermission(SecurityAction.Demand, AllLocalFiles=FileIOPermissionAccess.Read)]
        public static void DeclarativeCAS()
        {

        }

        /// <summary>
        /// You can also do this in an imperative way, which means that you explicitly ask for the permission in the code. 
        /// </summary>
        public static void ImperativeCAS()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllLocalFiles = FileIOPermissionAccess.Read;

            try
            {
                f.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
        }
    }
}
