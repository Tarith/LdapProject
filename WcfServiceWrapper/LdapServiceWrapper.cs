using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceWrapper
{
    public class LdapServiceWrapper
    {
        public bool ValidateUser(string username, string password)
        {
            using (var svc = new LdapServiceReference.LdapConnectionServiceClient())
            {
                return svc.ValidateUser(username, password);
            }
        }

        public MemberObject GetUser(string username)
        {
            using (var svc = new LdapServiceReference.LdapConnectionServiceClient())
            {
                var userObject = svc.GetUser(username);

                return new MemberObject {
                    DisplayName = userObject.DisplayName,
                    UniqueIdentifier = userObject.UniqueIdentifier,
                    Mail = userObject.Mail,
                    MemberOf = userObject.MemberOf
                };
            }
        }

        public bool IsMemberOf(string username, string cn)
        {
            using (var svc = new LdapServiceReference.LdapConnectionServiceClient())
            {
                return svc.IsMemberOf(username, cn);
            }
        }
    }

    public class MemberObject
    {
        public string UniqueIdentifier { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
        public ICollection<string> MemberOf { get; set; }
    }
}
