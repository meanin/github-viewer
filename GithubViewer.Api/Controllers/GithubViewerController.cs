using System.Web.Http;
using GithubViewer.Api.Domain;
using GithubViewer.Models;

namespace GithubViewer.Api.Controllers
{
    [RoutePrefix("api/githubviewer")]
    public class GithubViewerController : ApiController
    {
        private readonly IGithubViewerService _controllerService;

        public GithubViewerController(IGithubViewerService controllerService)
        {
            _controllerService = controllerService;
        }

        [Route("user/{login}")]
        public IHttpActionResult GetUser(string login)
        {
            var model = _controllerService.GetUser(login);
            if (model != GithubUser.NullUser)
                return Ok(model);
            return NotFound();
        }

        [Route("user/{login}/{repository}")]
        public IHttpActionResult GetRepositoryDetails(string login, string repository)
        {
            var model = _controllerService.GetRepositoryDetails(login, repository);
            if (model != GithubRepositoryDetails.NullDetails)
                return Ok(model);
            return NotFound();
        }
    }
}
