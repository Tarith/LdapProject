using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WcfServiceWrapper;

namespace SinglePageTestSite2.Models
{
    public static class IdentityExtensions
    {
        public static MemberObject GetUserInfo(this IIdentity identity)
        {
            var service = new LdapServiceWrapper();
            return service.GetUser(identity.Name);
        }
    }
}
