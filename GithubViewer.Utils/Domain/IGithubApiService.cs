using GithubViewer.Models;

namespace GithubViewer.Utils.Domain
{
    /// <summary>
    /// Interface for geting information from Github API
    /// </summary>
    public interface IGithubApiService
    {
        /// <summary>
        /// Gets detailed information about Github users repository
        /// </summary>
        /// <param name="login">Github User login</param>
        /// <param name="repositoryName">Github User repository name</param>
        /// <returns>Github repository details</returns>
        GithubRepositoryDetails GetRepositoryDetails(string login, string repositoryName);
        /// <summary>
        /// Gets Github user information
        /// </summary>
        /// <param name="login">Github User login</param>
        /// <returns>Github user</returns>
        GithubUser GetUser(string login);
    }
}