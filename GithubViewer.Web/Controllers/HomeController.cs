using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using GithubViewer.Models;
using GithubViewer.Web.Contract;

namespace GithubViewer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGithubViewerApiService _githubViewerApiService;

        public HomeController(IGithubViewerApiService githubViewerApiService)
        {
            _githubViewerApiService = githubViewerApiService;
        }

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
        public ActionResult Github(string login = "")
        {
            if(string.IsNullOrEmpty(login))
                return View();

            var token = (User as ClaimsPrincipal)?.FindFirst("access_token").Value;
            var model = _githubViewerApiService.GetUser(login, token);
            if (model != GithubUser.NullUser)
                return View(model);

            ModelState.AddModelError("Login", "Login is not valid");
            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}