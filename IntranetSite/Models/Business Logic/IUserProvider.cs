namespace IntranetSite.Models
{
    public interface IUserProvider
    {
        bool ValidateUser(string username, string password);
    }
}
