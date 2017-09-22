using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GithubViewer.Models;
using GithubViewer.Models.Examples;
using GithubViewer.Swashbuckle.Attributes;
using GithubViewer.Utils.Domain;
using Serilog;
using Swashbuckle.Examples;

namespace GithubViewer.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Gets informations from Github Api
    /// </summary>
    [Authorize]
    [RoutePrefix("api/githubviewer")]
    public class GithubViewerController : ApiController
    {
        private readonly IGithubApiService _githubService;

        /// <inheritdoc />
        /// <summary>
        /// Ctor for controller
        /// </summary>
        /// <param name="githubService">Service which connects to Github Api</param>
        public GithubViewerController(IGithubApiService githubService)
        {
            _githubService = githubService;
        }

        /// <summary>
        /// Github user
        /// </summary>
        /// <remarks>
        /// Get information about given Github user
        /// </remarks>
        /// <param name="login">Github User login from url</param>
        /// <returns>Github User information</returns>
        /// <response code="200">Returns Github user information</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Github User not found</response>
        [Route("user/{login}")]
        [ResponseType(typeof(GithubUser))]
        [SwaggerResponseContentType("text/simplecsv")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(GithubUserExamples))]
        public IHttpActionResult GetUser(string login)
        {
            Log.Verbose("Received get user reuqest with login: {login}", login);
            var model = _githubService.GetUser(login);
            if (model != GithubUser.NullUser)
                return Ok(model);
            Log.Warning("User not found", login);
            return NotFound();
        }

        /// <summary>
        /// Github users repositories
        /// </summary>
        /// <remarks>
        /// Get detailed repository list of given Github user
        /// </remarks>
        /// <param name="login">Github User login from url</param>
        /// <returns>Github User repositories list</returns>
        /// <response code="200">Returns Github user repositories list</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Github User not found</response>
        [Route("repository/{login}")]
        [ResponseType(typeof(IEnumerable<GithubRepositoryDetails>))]
        [SwaggerResponseContentType("text/simplecsv")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(GithubRepositoryDetailsExamples))]
        public IHttpActionResult GetUsersRepositories(string login)
        {
            Log.Verbose("Received get users repositories reuqest with login: {login}", login);
            var model = _githubService.GetUser(login);
            if (model == GithubUser.NullUser)
            {
                Log.Warning("User not found");
                return NotFound();
            }

            var repositoriesList = model.RepositoryList
                .Select(repository => _githubService.GetRepositoryDetails(login, repository.Name));
            return Ok(repositoriesList);
        }

        /// <summary>
        /// Github users repository
        /// </summary>
        /// <remarks>
        /// Get information about given Github users repository
        /// </remarks>
        /// <param name="login">Github User login from url</param>
        /// <param name="repository">Github User repository name from url</param>
        /// <returns>Github Users repository information</returns>
        /// <response code="200">Returns Github users repository information</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Github User or repository not found</response>
        [Route("repository/{login}/{repository}")]
        [ResponseType(typeof(GithubRepositoryDetails))]
        [SwaggerResponseContentType("text/simplecsv")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(GithubRepositoryDetailsExamples))]
        public IHttpActionResult GetRepositoryDetails(string login, string repository)
        {
            Log.Verbose("Received get users repository reuqest with login: {login} and repository name: {repository}", login, repository);
            var model = _githubService.GetRepositoryDetails(login, repository);
            if (model != GithubRepositoryDetails.NullDetails)
                return Ok(model);
            Log.Verbose("User or given repository not found");
            return NotFound();
        }
    }
}
