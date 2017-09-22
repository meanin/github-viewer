using GithubViewer.Utils.Contract;
using GithubViewer.Utils.Services;
using NSubstitute;
using Xunit;

namespace GithubViewer.Utils.Tests
{
    public class WebApiClientServiceIntegrationTests
    {
        private readonly ICache<string> _cache;
        private readonly WebApiClientService _service;
        private const string GithubApiUri = "https://api.github.com/";

        public WebApiClientServiceIntegrationTests()
        {
            _cache = Substitute.For<ICache<string>>();
            _service = new WebApiClientService(GithubApiUri, _cache);
        }

        [Fact]
        public void Get_ShouldCheckIfResultIsAlreadyInCache()
        {
            // arrange

            const string method = "invalid method";

            // act

            _service.Get(method);

            // assert

            _cache.Received(1).Get(method);
        }

        [Fact]
        public void Get_WhenValidMethod_ShouldPutResultIntoCache()
        {
            // arrange

            const string method = "users/meanin";

            // act

            _service.Get(method);

            // assert

            _cache.Received(1).Get(method);
            _cache.Received(1).Put(method, Arg.Any<string>());
        }
    }
}
