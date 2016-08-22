using SinglePageTestSite2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WcfServiceWrapper;

namespace SinglePageTestSite2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MemberObject model = User.Identity.GetUserInfo();

            var viewmodel = new ProfileViewModel
            {
                DisplayName = model.DisplayName,
                Mail = model.Mail,
                UniqueIdentifier = model.UniqueIdentifier,
                MemberOf = model.MemberOf

            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}