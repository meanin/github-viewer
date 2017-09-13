using FluentAssertions;
using GithubViewer.Models;
using GithubViewer.Utils.Domain;
using GithubViewer.Utils.Services;
using NSubstitute;
using Xunit;

namespace GithubViewer.Utils.Tests
{
    public class GithubApiServiceTests
    {
        private readonly IWebApiClient _webApiClientMock;
        private readonly GithubApiService _service;
        private readonly ISerializer _serializerMock;

        private readonly string _login;
        private readonly string _repostory;
        private readonly string _getUserUriAppendix;
        private readonly string _getReposForUserUriAppendix;
        private readonly string _getUsersStarredReposUriAppendix;
        private readonly string _getRepositoryDetailsUriAppendix;

        public GithubApiServiceTests()
        {
            _webApiClientMock = Substitute.For<IWebApiClient>();
            _serializerMock = Substitute.For<ISerializer>();
            _service = new GithubApiService(_webApiClientMock, _serializerMock);

            _login = "login";
            _repostory = "repository";
            _getUserUriAppendix = GithubApiMethodAppendixBuilder.GetUserMethod(_login);
            _getReposForUserUriAppendix = GithubApiMethodAppendixBuilder.GetUsersRepositoriesMethod(_login);
            _getUsersStarredReposUriAppendix = GithubApiMethodAppendixBuilder.GetUsersStarredRepositoriesMethod(_login);
            _getRepositoryDetailsUriAppendix = GithubApiMethodAppendixBuilder.GetRepositoryDetailsMethod(_login, _repostory);
        }

        [Fact]
        public void GetUserMethod_ShouldGetOutputFromWebApiClientWithPrefixUsers()
        {
            // arrange

            // act

            _service.GetUser(_login);

            // assert

            _webApiClientMock.Received(1).Get(_getUserUriAppendix);
        }

        [Fact]
        public void GetUserMethod_ShouldSerializeWebApiClientOutput()
        {
            // arrange
            
            const string content = "asd";
            _webApiClientMock.Get(_getUserUriAppendix).Returns(content);

            // act

            _service.GetUser(_login);

            // assert

            _serializerMock.Received(1).Deserialize<GithubUser>(content);
        }

        [Fact]
        public void GetUserMethod_WhenUserWasReturned_ShouldReturnGithubUser()
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
        public void GetUserMethod_WhenNoUserWasReturned_ShouldReturnNullObject()
        {
            // arrange

            var user = new GithubUser();
            _serializerMock.Deserialize<GithubUser>(Arg.Any<string>())
                .Returns((GithubUser)null);

            // act

            var result = _service.GetUser(_login);

            // assert

            result.Should().Be(GithubUser.NullUser);
        }

        [Fact]
        public void GetUserMethod_IfUserWasRetreived_ShouldRetreiveRepositoriesForGivenUser()
        {
            // arrange
            
            _serializerMock.Deserialize<GithubUser>(Arg.Any<string>())
                .Returns(new GithubUser());

            // act

            _service.GetUser(_login);

            // assert

            _webApiClientMock.Received(1).Get(_getUserUriAppendix);
            _webApiClientMock.Received(1).Get(_getReposForUserUriAppendix);
        }

        [Fact]
        public void GetUserMethod_IfUserWasRetreived_ShouldRetreiveUsersStarredRepositories()
        {
            // arrange
            
            _serializerMock.Deserialize<GithubUser>(Arg.Any<string>())
                .Returns(new GithubUser());

            // act

            _service.GetUser(_login);

            // assert

            _webApiClientMock.Received(1).Get(_getUserUriAppendix);
            _webApiClientMock.Received(1).Get(_getUsersStarredReposUriAppendix);
        }

        [Fact]
        public void GetUserMethod_WhenUserWasntRetreived_ShouldNotTryToGetConnectedRepositories()
        {
            // arrange

            _serializerMock.Deserialize<GithubUser>(Arg.Any<string>())
                .Returns((GithubUser)null);
            // act

            _service.GetUser(_login);

            // assert

            _webApiClientMock.Received(1).Get(_getUserUriAppendix);
            _webApiClientMock.DidNotReceive().Get(_getReposForUserUriAppendix);
            _webApiClientMock.DidNotReceive().Get(_getUsersStarredReposUriAppendix);
        }

        [Fact]
        public void GetRepositoryDetails_ShouldGetOutputFromWebApiClientAndDeserialize()
        {
            // arrange
            
            // act

            _service.GetRepositoryDetails(_login, _repostory);

            // assert

            _webApiClientMock.Received(1).Get(_getRepositoryDetailsUriAppendix);
            _serializerMock.Received(1).Deserialize<GithubRepositoryDetails>(Arg.Any<string>());
        }

        [Fact]
        public void GetRepositoryDetails_WhenThereIsNoSuchRepository_ShouldReturnNullObject()
        {
            // arrange

            _serializerMock.Deserialize<GithubRepositoryDetails>(Arg.Any<string>())
                .Returns((GithubRepositoryDetails)null);
            // act

            var result = _service.GetRepositoryDetails(_login, _repostory);

            // assert

            result.Should().Be(GithubRepositoryDetails.NullDetails);
        }

        [Fact]
        public void GetRepositoryDetails_WhenRepositoryWasReturned_ShouldReturnRepositoryDetailed()
        {
            // arrange
            
            var detailedRepository = new GithubRepositoryDetails();
            _serializerMock.Deserialize<GithubRepositoryDetails>(Arg.Any<string>())
                .Returns(detailedRepository);
            // act

            var result = _service.GetRepositoryDetails(_login, _repostory);

            // assert

            result.Should().Be(detailedRepository);
        }
    }
}
