namespace WcfService
{
    public interface IClientAccountProvider
    {
        //only this method should get the username and password
        //after that, it should be a validation token what's validated
        bool ValidateUser(string username, string password);

        UserObject GetUser(string username);

        bool IsMemberOf(string username, string cn);

        
    }
}
