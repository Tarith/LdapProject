using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using WcfServiceWrapper;

namespace AuthorizationModule
{
    public class AuthorizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            //register event handlers
            context.AuthenticateRequest += OnAuthenticateRequest;
        }

        private void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var identityCookieName = "TARITHIDENT";
            var app = (HttpApplication)sender;
            var identityCookie = app.Context.Request.Cookies[identityCookieName];

            if (identityCookie != null)
            {
                var identityTicket = (FormsAuthenticationTicket)null;

                try
                {
                    identityTicket = FormsAuthentication.Decrypt(identityCookie.Value);
                }
                catch (Exception)
                {
                    app.Context.Request.Cookies.Remove(identityCookieName);
                    return;
                }

                var name = string.Empty;
                var groups = new string[0];
                var authCookie = app.Context.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie != null)
                {
                    try
                    {
                        var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        if (authTicket.Name != identityTicket.Name)
                        {
                            return;
                        }

                        name = authTicket.Name;
                    }
                    catch (Exception)
                    {
                        app.Context.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
                        return;
                    }

                    var svc = new LdapServiceWrapper();
                    var userObject = svc.GetUser(name);

                    groups = userObject.MemberOf.ToArray();
                }

                var customIdentity = new CustomIdentity(name, identityTicket.UserData);
                var userPrincipal = new GenericPrincipal(customIdentity, groups);
                app.Context.User = userPrincipal;
            }

        }

        public void Dispose() { }
    }

    
}

