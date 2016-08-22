using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceWrapper;

namespace UnitTestProject
{
    [TestClass]
    public class WcfServiceTest
    {
        [TestMethod]
        public void UserPassWithValidCredentials()
        {
            var srv = new LdapServiceWrapper();
            var result = srv.ValidateUser("gauss", "password");
            Assert.IsTrue(result);

            result = srv.ValidateUser("boyle", "password");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UserFailsWithInvalidCredentials()
        {
            var srv = new LdapServiceWrapper();
            var result = srv.ValidateUser("badusser", "badpassword");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetUserReturnsAUserObject()
        {
            var srv = new LdapServiceWrapper();
            var result = srv.GetUser("curie");
            Assert.IsInstanceOfType(result, typeof(MemberObject));
        }

        [TestMethod]
        public void ValidationPassWhenUserInRightGroup()
        {
            var srv = new LdapServiceWrapper();
            var result = srv.IsMemberOf("euler", "Mathematicians");
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ValidationFailWhenUserInRightGroup()
        {
            var srv = new LdapServiceWrapper();
            var result = srv.IsMemberOf("euler", "BadGroup");
            Assert.IsFalse(result);
        }

    }
}
