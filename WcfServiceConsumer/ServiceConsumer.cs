using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceConsumer.LdapServiceReference;

namespace WcfServiceConsumer
{
    public class ServiceConsumer
    {
        public ILdapConnectionService GetLdapService()
        {
            using (var svc = new LdapConnectionServiceClient())
            {
                return svc;
            }
        }
    }
}
