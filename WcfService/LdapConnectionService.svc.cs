using System;

namespace WcfService
{
    public class LdapConnectionService : ILdapConnectionService
    {
        IClientAccountProvider clientAccountProvider = new LdapAccountProvider();

        public UserObject GetUser(string username)
        {
            return clientAccountProvider.GetUser(username);
        }

        public bool IsMemberOf(string username, string cn)
        {
            return clientAccountProvider.IsMemberOf(username, cn);
        }

        public bool ValidateUser(string username, string password)
        {
            //set an authentication token for further validation

            return clientAccountProvider.ValidateUser(username, password);
        }

        //save the information of authenticated users for further validation like is member of
    }
}
