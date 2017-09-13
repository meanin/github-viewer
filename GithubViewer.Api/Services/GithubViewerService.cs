using System.Collections.Generic;
using GithubViewer.Api.Domain;
using GithubViewer.Models;
using GithubViewer.Utils;
using GithubViewer.Utils.Domain;

namespace GithubViewer.Api.Services
{
    public class GithubViewerService : IGithubViewerService
    {
        private readonly IWebApiClient _client;
        private readonly ISerializer _serializer;

        public GithubViewerService(IWebApiClient client, ISerializer serializer)
        {
            _client = client;
            _serializer = serializer;
        }

        public GithubUser GetUser(string login)
        {
            var contentContent = _client.Get(GithubApiMethodAppendixBuilder.GetUserMethod(login));
            var githubUser = _serializer.Deserialize<GithubUser>(contentContent);

            if (githubUser == null)
                return GithubUser.NullUser;

            var usersReposContent = _client.Get(GithubApiMethodAppendixBuilder.GetUsersRepositoriesMethod(login));
            githubUser.RepositoryList = _serializer.Deserialize<List<GithubRepository>>(usersReposContent);

            var usersStarredReposContent = _client.Get(GithubApiMethodAppendixBuilder.GetUsersStarredRepositoriesMethod(login));
            githubUser.StarredRepositoryList = _serializer.Deserialize<List<GithubRepository>>(usersStarredReposContent);

            return githubUser;
        }

        public GithubRepositoryDetails GetRepositoryDetails(string login, string repositoryName)
        {
            var contentContent = _client.Get(GithubApiMethodAppendixBuilder.GetRepositoryDetailsMethod(login, repositoryName));
            var repositoryDetails = _serializer.Deserialize<GithubRepositoryDetails>(contentContent);

            return repositoryDetails ?? GithubRepositoryDetails.NullDetails;
        }
    }
}