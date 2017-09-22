using System.Web.Mvc;

namespace GithubViewer.Web.Controllers
{
    public class GithubViewerController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}