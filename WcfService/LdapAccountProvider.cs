using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.DirectoryServices;

namespace WcfService
{
    public class LdapAccountProvider : IClientAccountProvider
    {
        public UserObject GetUser(string username)
        {
            try
            {
                //create the LdapConnection
                var myLdapConnection = CreateEntryForAuthorizedUsers();

                //create search object which opoerates on LDAP connection object and set search object to only find the user specified
                var search = new DirectorySearcher(myLdapConnection);
                search.Filter = string.Format("(uid={0})", username);

                //create results objects from search object
                var result = search.FindOne();

                if (result != null)
                {
                    var user = new UserObject
                    {
                        MemberOf = new Collection<string>()
                    };

                    user.UniqueIdentifier = result.Properties["uid"][0].ToString();
                    user.DisplayName = result.Properties["cn"][0].ToString();
                    user.Mail = result.Properties["mail"][0].ToString();

                    search.Filter = "(objectclass=groupOfUniqueNames)";
                    var resultCollection = search.FindAll();

                    foreach (SearchResult group in resultCollection)
                    {
                        foreach (var member in group.Properties["uniquemember"])
                        {
                            if (member.ToString().Contains(username))
                            {
                                user.MemberOf.Add(group.Properties["cn"][0].ToString());
                                break;
                            }
                        }
                    }

                    return user;
                }else
                {
                    //user not found!
                }

            }
            catch (Exception)
            {

                new UserObject
                {
                    MemberOf = new Collection<string>()
                };
            }

            return null;
        }

        public bool IsMemberOf(string username, string cn)
        {
            try
            {
                //create the LdapConnection
                var myLdapConnection = CreateEntryForAuthorizedUsers();

                //create search object which opoerates on LDAP connection object and set search object to only find the user specified
                var search = new DirectorySearcher(myLdapConnection);
                search.Filter = string.Format("(ou={0})", cn);
                search.PropertiesToLoad.Add("uniquemember");

                //create results objects from search object
                var result = search.FindOne();

                if (result != null)
                {
                    //the user exists, cycle through LDAP fields
                    var fields = result.Properties;

                    foreach (string ldapField in fields.PropertyNames)
                    {
                        //cycle through objects in each field
                        foreach (var fieldValue in fields["uniquemember"])
                        {
                            if (fieldValue.ToString().Contains(username))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
           

            return false;
        }

        public bool ValidateUser(string username, string password)
        {
            try
            {
                //create the LdapConnection
                var myLdapConnection = CreateDirectoryEntry(username, password);

                //create search object which opoerates on LDAP connection object and set search object to only find the user specified
                var search = new DirectorySearcher(myLdapConnection);
                search.Filter = string.Format("(uid={0})", username);

                //create results objects from search object
                var result = search.FindOne();

                //if the result object is not null, then is a valid user
                if (result != null)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        private DirectoryEntry CreateDirectoryEntry(string username, string password)
        {
            //create and return new LDAP connection with desider settings
            var LdapHost = ConfigurationManager.AppSettings["LdapHost"];
            var LdapPort = ConfigurationManager.AppSettings["LdapPort"];
            var LdapBaseDN = ConfigurationManager.AppSettings["LdapBaseDN"];

            return new DirectoryEntry(string.Format("LDAP://{0}:{1}/{2}", LdapHost,LdapPort,LdapBaseDN), string.Format("uid={0},{1}", username, LdapBaseDN), password, AuthenticationTypes.None);
        }

        private DirectoryEntry CreateEntryForAuthorizedUsers()
        {
            //create and return new LDAP connection with desider settings
            var LdapHost = ConfigurationManager.AppSettings["LdapHost"];
            var LdapPort = ConfigurationManager.AppSettings["LdapPort"];
            var LdapBaseDN = ConfigurationManager.AppSettings["LdapBaseDN"];

            return new DirectoryEntry(string.Format("LDAP://{0}:{1}/{2}", LdapHost, LdapPort, LdapBaseDN), "", "", AuthenticationTypes.None);
        }
    }
}
