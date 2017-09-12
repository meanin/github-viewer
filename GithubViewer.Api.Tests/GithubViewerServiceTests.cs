using FluentAssertions;
using GithubViewer.Api.Services;
using GithubViewer.Models;
using GithubViewer.Utils.Domain;
using NSubstitute;
using Xunit;

namespace GithubViewer.Api.Tests
{
    public class GithubViewerServiceTests
    {
        private readonly IWebApiClient _webApiClientMock;
        private readonly GithubViewerService _service;
        private readonly string _login;
        private readonly ISerializer _serializerMock;

        public GithubViewerServiceTests()
        {
            _login = "login";
            _webApiClientMock = Substitute.For<IWebApiClient>();
            _serializerMock = Substitute.For<ISerializer>();
            _service = new GithubViewerService(_webApiClientMock, _serializerMock);
        }

        [Fact]
        public void GetUserMethod_ShouldGetOutputFromWebApiClientWithPrefixUsers()
        {
            // arrange

            // act

            _service.GetUser(_login);

            // assert

            _webApiClientMock.Received(1).Get($"users/{_login}");
        }

        [Fact]
        public void GetUserMethod_ShouldSerializeWebApiClientOutput()
        {
            // arrange

            var getUserUriAppendix = $"users/{_login}";
            const string content = "asd";
            _webApiClientMock.Get(getUserUriAppendix).Returns(content);

            // act

            _service.GetUser(_login);

            // assert

            _serializerMock.Received(1).Deserialize<GithubUser>(content);
        }

        [Fact]
        public void GetUserMethod_ShouldReturnGithubUser()
        {
            // arrange

            var user = new GithubUser();
            _serializerMock.Deserialize<GithubUser>(Arg.Any<string>())
                .Returns(user);

            // act

            var result = _service.GetUser(_login);

            // assert

            result.Should().Be(user);
        }

        [Fact]
        public void GetUserMethod_IfUserWasRetreived_ShouldRetreiveRepositoriesForGivenUser()
        {
            // arrange

            var getUserUriAppendix = $"users/{_login}";
            var getReposForUserUriAppendix = $"users/{_login}/repos";
            _serializerMock.Deserialize<GithubUser>(Arg.Any<string>())
                .Returns(new GithubUser());

            // act

            _service.GetUser(_login);

            // assert

            _webApiClientMock.Received(1).Get(getUserUriAppendix);
            _webApiClientMock.Received(1).Get(getReposForUserUriAppendix);
        }

        [Fact]
        public void GetUserMethod_IfUserWasRetreived_ShouldRetreiveUsersStarredRepositories()
        {
            // arrange

            var getUserUriAppendix = $"users/{_login}";
            var getUsersStarredReposUriAppendix = $"users/{_login}/starred";
            _serializerMock.Deserialize<GithubUser>(Arg.Any<string>())
                .Returns(new GithubUser());

            // act

            _service.GetUser(_login);

            // assert

            _webApiClientMock.Received(1).Get(getUserUriAppendix);
            _webApiClientMock.Received(1).Get(getUsersStarredReposUriAppendix);
        }

        [Fact]
        public void GetUserMethod_WhenUserWasntRetreived_ShouldNotTryToGetConnectedRepositories()
        {
            // arrange

            var getUserUriAppendix = $"users/{_login}";
            _serializerMock.Deserialize<GithubUser>(Arg.Any<string>())
                .Returns((GithubUser)null);
            var getReposForUserUriAppendix = $"users/{_login}/repos";
            var getUsersStarredReposUriAppendix = $"users/{_login}/starred";

            // act

            _service.GetUser(_login);

            // assert

            _webApiClientMock.Received(1).Get(getUserUriAppendix);
            _webApiClientMock.DidNotReceive().Get(getReposForUserUriAppendix);
            _webApiClientMock.DidNotReceive().Get(getUsersStarredReposUriAppendix);
        }

        [Fact]
        public void GetRepositoryDetails_ShouldGetOutputFromWebApiClientAndDeserialize()
        {
            
        }
    }
}
