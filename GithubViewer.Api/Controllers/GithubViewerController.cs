using System.Collections.Generic;
using System.Web.Http;
using GithubViewer.Api.Models;

namespace GithubViewer.Api.Controllers
{
    [RoutePrefix("api/githubviewer")]
    public class GithubViewerController : ApiController
    {
        [Route("user/{login}")]
        public IEnumerable<GithubUser> GetUser(string login)
        {
            return null;
        }
    }
}
