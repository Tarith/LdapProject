using AuthorizationModule;
using SinglePageTestSite2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageTestSite2.Controllers
{
    public class SiteTwoAccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (CustomAuthentication.ValidateUser(model.Username, model.Password))
                {
                    CustomAuthentication.SetAuthCookies(model.Username, "");
                    return Redirect(returnUrl);
                }

                ModelState.AddModelError("", "The user name or password provided is incorrect");
            }

            return View(model);
        }
    }
}