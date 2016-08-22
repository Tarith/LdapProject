namespace IntranetSite.Models
{
    public interface IUnitOfWork
    {
        IUserProvider UserProvider { get; }
    }
}
