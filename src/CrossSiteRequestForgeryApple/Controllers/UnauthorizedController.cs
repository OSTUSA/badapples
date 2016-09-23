using System.Web.Mvc;

namespace CrossSiteRequestForgeryApple.Controllers
{
    public class UnauthorizedController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}