using GithubViewer.Models;

namespace GithubViewer.Web.Contract
{
    public interface IGithubViewerApiService
    {
        GithubUser GetUser(string login, string token);
    }
}