using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //var svr = new LdapServiceReference.LdapConnectionServiceClient();

            var svr = new LdapServiceWrapper();

            Console.WriteLine(svr.ValidateUser("tesla", "password"));

            Console.ReadLine();
        }


    }
}
