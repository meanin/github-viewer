using FluentAssertions;
using GithubViewer.Utils.Contract;
using GithubViewer.Utils.Services;
using Xunit;

namespace GithubViewer.Utils.Tests
{
    public class StringCacheTests
    {
        private readonly ICache<string> _cache;
        private readonly string _key;

        public StringCacheTests()
        {
            _cache = new SimpleInMemoryCache<string>();
            _key = "key";
        }

        [Fact]
        public void Get_WhenPreviouslyNotPutAOnbjectWithKey_ShouldReturnStringEmpty()
        {
            // arrange

            // act

            var stringObject = _cache.Get(_key);

            // assert

            stringObject.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Get_WhenPreviouslyPutAOnbjectWithKey_ShouldReturnStringEmpty()
        {
            // arrange

            const string obj = "object";
            _cache.Put(_key, obj);

            // act

            var stringObject = _cache.Get(_key);

            // assert

            stringObject.Should().NotBeNull();
            stringObject.Should().Be(obj);
        }
    }
}
