using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTestProject
{
    [TestClass]
    public class SinglePageTest1Test
    {
        [TestMethod]
        public void RedirectToLoginIfUnauthenticated()
        {
            var controller = new SinglePageTestSite1.Controllers.HomeController();
            var type = controller.GetType();
            var attributes = type.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Assert.IsTrue(attributes.Any());
        }
    }
}
