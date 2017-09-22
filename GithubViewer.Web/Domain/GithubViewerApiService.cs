using GithubViewer.Models;
using GithubViewer.Utils.Contract;
using GithubViewer.Web.Contract;

namespace GithubViewer.Web.Domain
{
    public class GithubViewerApiService : IGithubViewerApiService
    {
        private readonly IWebApiClient _webApiClient;
        private readonly ISerializer _serializer;

        public GithubViewerApiService(
            IWebApiClient webApiClient, 
            ISerializer serializer)
        {
            _webApiClient = webApiClient;
            _serializer = serializer;
        }

        public GithubUser GetUser(string login, string token)
        {
            var userString = _webApiClient.Get($"api/githubviewer/user/{login}", token);
            var githubUser = _serializer.Deserialize<GithubUser>(userString);
            return githubUser ?? GithubUser.NullUser;
        }
    }
}