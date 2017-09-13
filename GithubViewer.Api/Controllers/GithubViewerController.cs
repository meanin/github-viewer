using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using GithubViewer.Api.Domain;
using GithubViewer.Models;
using GithubViewer.Utils.Attributes;

namespace GithubViewer.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Gets informations from Github Api
    /// </summary>
    [RoutePrefix("api/githubviewer")]
    public class GithubViewerController : ApiController
    {
        private readonly IGithubViewerService _controllerService;

        /// <inheritdoc />
        /// <summary>
        /// Ctor for controller
        /// </summary>
        /// <param name="controllerService">Service which connects to Github Api</param>
        public GithubViewerController(IGithubViewerService controllerService)
        {
            _controllerService = controllerService;
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
        /// <response code="404">Github User not found</response>
        [Route("user/{login}")]
        [ResponseType(typeof(GithubUser))]
        [SwaggerResponseContentType("text/simplecsv")]
        public IHttpActionResult GetUser(string login)
        {
            var model = _controllerService.GetUser(login);
            if (model != GithubUser.NullUser)
                return Ok(model);
            return NotFound();
        }

        /// <summary>
        /// Github user repositories
        /// </summary>
        /// <remarks>
        /// Get detailed repository list of given Github user
        /// </remarks>
        /// <param name="login">Github User login from url</param>
        /// <returns>Github User repositories list</returns>
        /// <response code="200">Returns Github user repositories list</response>
        /// <response code="404">Github User not found</response>
        [Route("user/{login}/repos")]
        [ResponseType(typeof(IEnumerable<GithubRepositoryDetails>))]
        [SwaggerResponseContentType("text/simplecsv")]
        public IHttpActionResult GetUsersRepositories(string login)
        {
            var model = _controllerService.GetUser(login);
            if (model == GithubUser.NullUser)
                return NotFound();

            var repositoriesList = model.RepositoryList
                .Select(repository => _controllerService.GetRepositoryDetails(login, repository.Name));
            return Ok(repositoriesList);
        }

        /// <summary>
        /// Get information about given Github users repository
        /// </summary>
        /// <remarks>
        /// Get information about given Github users repository
        /// </remarks>
        /// <param name="login">Github User login from url</param>
        /// <param name="repository">Github User repository name from url</param>
        /// <returns>Github Users repository information</returns>
        /// <response code="200">Returns Github users repository information</response>
        /// <response code="404">Github User or repository not found</response>
        [Route("user/{login}/{repository}")]
        [ResponseType(typeof(GithubRepositoryDetails))]
        [SwaggerResponseContentType("text/simplecsv")]
        public IHttpActionResult GetRepositoryDetails(string login, string repository)
        {
            var model = _controllerService.GetRepositoryDetails(login, repository);
            if (model != GithubRepositoryDetails.NullDetails)
                return Ok(model);
            return NotFound();
        }
    }
}
