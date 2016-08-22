using IntranetSite.Models;
using IntranetSite.Models.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace IntranetSite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
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
                IUnitOfWork business = new UnitOfWork();

                if (business.UserProvider.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "The user name or password provided is incorrect");
            }

            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}