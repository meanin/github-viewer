using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using FluentAssertions;
using GithubViewer.Api.Controllers;
using GithubViewer.Models;
using GithubViewer.Utils.Domain;
using NSubstitute;
using Xunit;

namespace GithubViewer.Api.Tests
{
    public class GithubViewerControllerTests
    {
        private readonly GithubViewerController _controller;
        private readonly IGithubApiService _githubApiService;

        private readonly string _login = "login";
        private readonly string _repository = "repository";

        public GithubViewerControllerTests()
        {
            _githubApiService = Substitute.For<IGithubApiService>();
            _controller = new GithubViewerController(_githubApiService);
        }

        [Fact]
        public void GetUser_WhenLoginExist_ShouldReturnOkNegotiatedContentResult()
        {
            // arrange

            _githubApiService.GetUser(_login).Returns(new GithubUser());
            
            // act

            var result = _controller.GetUser(_login);

            // assert

            result.Should().BeAssignableTo<OkNegotiatedContentResult<GithubUser>>();
        }

        [Fact]
        public void GetUser_WhenLoginDoesNotExist_ShouldReturnNotFoundResult()
        {
            // arrange

            _githubApiService.GetUser(_login).Returns(GithubUser.NullUser);

            // act

            var result = _controller.GetUser(_login);

            // assert

            result.Should().BeAssignableTo<NotFoundResult>();
        }

        [Fact]
        public void GetUsersRepositories_WhenLoginExist_ShouldReturnOkNegotiatedContentResult()
        {
            // arrange

            _githubApiService.GetUser(_login).Returns(new GithubUser { RepositoryList = new List<GithubRepository>() });

            // act

            var result = _controller.GetUsersRepositories(_login);

            // assert

            result.Should().BeAssignableTo<OkNegotiatedContentResult<IEnumerable<GithubRepositoryDetails>>>();
        }

        [Fact]
        public void GetUsersRepositories_WhenLoginExist_ShouldGetRepositoryDetailsForEachRepository()
        {
            // arrange

            _githubApiService.GetUser(_login).Returns(new GithubUser
            {
                RepositoryList = new List<GithubRepository> {new GithubRepository {Name = _repository}}
            });

            // act

            var result = _controller.GetUsersRepositories(_login) as OkNegotiatedContentResult<IEnumerable<GithubRepositoryDetails>>;

            // assert

            // only to enumerate elements
            result.Content.ToList();
            _githubApiService.Received(1).GetUser(_login);
            _githubApiService.Received(1).GetRepositoryDetails(_login, _repository);
            result.Should().BeAssignableTo<OkNegotiatedContentResult<IEnumerable<GithubRepositoryDetails>>>();
        }

        [Fact]
        public void GetUsersRepositories_WhenLoginDoesNotExist_ShouldReturnNotFoundResult()
        {
            // arrange

            _githubApiService.GetUser(_login).Returns(GithubUser.NullUser);

            // act

            var result = _controller.GetUsersRepositories(_login);

            // assert

            result.Should().BeAssignableTo<NotFoundResult>();
        }

        [Fact]
        public void GetUsersRepositoryDetails_WhenLoginAndRepositoryExist_ShouldReturnOkNegotiatedContentResult()
        {
            // arrange

            _githubApiService.GetRepositoryDetails(_login, _repository).Returns(new GithubRepositoryDetails());

            // act

            var result = _controller.GetRepositoryDetails(_login, _repository);
            
            // assert

            result.Should().BeAssignableTo<OkNegotiatedContentResult<GithubRepositoryDetails>>();
        }

        [Fact]
        public void GetUsersRepositoryDetails_WhenLoginOrRepositoryDoesNotExist_ShouldReturnNotFoundResult()
        {
            // arrange

            _githubApiService.GetRepositoryDetails(_login, _repository).Returns(GithubRepositoryDetails.NullDetails);

            // act

            var result = _controller.GetRepositoryDetails(_login, _repository);

            // assert

            result.Should().BeAssignableTo<NotFoundResult>();
        }
    }
}
