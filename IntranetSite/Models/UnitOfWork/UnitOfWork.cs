namespace IntranetSite.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserProvider _userProvider;
        public IUserProvider UserProvider
        {
            get
            {
                if (_userProvider == null)
                {
                    _userProvider = new UserProvider();
                }

                return _userProvider;
            }
        }
    }
}
