using System.Collections.Generic;
using GithubViewer.Models;
using GithubViewer.Utils.Contract;

namespace GithubViewer.Utils.Services
{
    public class GithubApiService : IGithubApiService
    {
        private readonly IWebApiClient _client;
        private readonly ISerializer _serializer;

        public GithubApiService(IWebApiClient client, ISerializer serializer)
        {
            _client = client;
            _serializer = serializer;
        }

        public GithubUser GetUser(string login)
        {
            var content = _client.Get(GithubApiMethodAppendixBuilder.GetUserMethod(login));
            var githubUser = _serializer.Deserialize<GithubUser>(content);

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
            var content = _client.Get(GithubApiMethodAppendixBuilder.GetRepositoryDetailsMethod(login, repositoryName));
            var repositoryDetails = _serializer.Deserialize<GithubRepositoryDetails>(content);

            return repositoryDetails ?? GithubRepositoryDetails.NullDetails;
        }
    }
}