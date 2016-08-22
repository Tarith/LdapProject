using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using WcfServiceWrapper;

namespace AuthorizationModule
{
    public class CustomAuthentication
    {
        public static void SetAuthCookies(string username, string fullname)
        {
            var context = HttpContext.Current;

            var identityTicket = new FormsAuthenticationTicket(1, username, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(30), true, fullname);

            var encryptedIdentityTicket = FormsAuthentication.Encrypt(identityTicket);

            var identityCookie = new HttpCookie("TARITHIDENT", encryptedIdentityTicket);
            identityCookie.Expires = DateTime.UtcNow.AddMinutes(30);

            HttpContext.Current.Response.Cookies.Add(identityCookie);

            FormsAuthentication.SetAuthCookie(username, false);
            
        }

        public static bool ValidateUser(string username, string password)
        {
            var svc = new LdapServiceWrapper();
            return svc.ValidateUser(username, password);
        }       
    }

    public class CustomIdentity : GenericIdentity
    {
        private string _fullname;

        public CustomIdentity(string username, string fullname) : base(username)
        {
            _fullname = fullname;
        }

        public bool HasIdentity
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_fullname);
            }
        }

        public string FullName
        {
            get
            {
                return _fullname;

            }
        }

        public static CustomIdentity EmptyIdentity
        {
            get
            {
                return new CustomIdentity("", "");
            }
        }
    }
}
