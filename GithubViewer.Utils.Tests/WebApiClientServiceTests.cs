using System;
using FluentAssertions;
using GithubViewer.Utils.Contract;
using GithubViewer.Utils.Services;
using NSubstitute;
using Xunit;

namespace GithubViewer.Utils.Tests
{
    public class WebApiClientServiceTests
    {
        private readonly ICache<string> _cache;
        private const string _uri = "https://api.github.com/";

        public WebApiClientServiceTests()
        {
            _cache = Substitute.For<ICache<string>>();
        }

        [Fact]
        public void OnCreatingWhenGivenStringIsNotUri_ShouldThrow()
        {
            // arrange

            IWebApiClient service;

            // act

            Action act = () => service = new WebApiClientService("noturi", _cache);

            // assert

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void OnCreatingWhenGivenStringIsUri_ShouldNotThrow()
        {
            // arrange

            IWebApiClient service;

            // act

            Action act = () => service = new WebApiClientService("https://api", _cache);

            // assert

            act.ShouldNotThrow<Exception>();
        }

        [Fact]
        public void Get_WhenCacheContainsMethodResult_ShouldNotPutResultIntoCache()
        {
            // arrange

            var service = new WebApiClientService(_uri, _cache);
            var method = "method";
            _cache.Get(method).Returns("blablablah");

            // act

            service.Get(method);

            // assert

            _cache.Received(1).Get(method);
            _cache.DidNotReceive().Put(method, Arg.Any<string>());
        }
    }
}
