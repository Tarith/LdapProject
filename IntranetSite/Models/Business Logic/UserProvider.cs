using WcfServiceWrapper;

namespace IntranetSite.Models
{
    public class UserProvider : IUserProvider
    {
        public bool ValidateUser(string username, string password)
        {
            var service = new LdapServiceWrapper();
            return service.ValidateUser(username, password);
        }
    }
}
