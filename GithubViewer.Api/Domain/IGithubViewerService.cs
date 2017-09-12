using GithubViewer.Models;

namespace GithubViewer.Api.Domain
{
    public interface IGithubViewerService
    {
        GithubRepositoryDetails GetRepositoryDetails(string login, string repositoryName);
        GithubUser GetUser(string login);
    }
}