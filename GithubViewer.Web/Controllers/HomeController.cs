using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GithubViewer.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Github()
        {
            // TODO: Try to get email, suggest to search for own repositories
            //var email = Request.GetOwinContext().Authentication.User.Claims.SingleOrDefault(c => c.Type == "email")?.Value;

            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}