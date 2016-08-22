using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface ILdapConnectionService
    {
        [OperationContract]
        bool ValidateUser(string username, string password);

        //Get user object method
        [OperationContract]
        UserObject GetUser(string username);

        //Get groups objects method
        [OperationContract]
        bool IsMemberOf(string username, string cn);
    }

    [DataContract]
    public class UserObject
    {
        [DataMember]
        public string UniqueIdentifier { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public ICollection<string> MemberOf { get; set; }
    }
}
