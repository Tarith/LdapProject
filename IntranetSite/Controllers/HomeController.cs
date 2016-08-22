using System.Web.Mvc;

namespace IntranetSite.Controllers
{
    [Authorize]
    //the authorize should be global in the filters to avoid adding it to all controllers
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}