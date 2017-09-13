using FluentAssertions;
using GithubViewer.Utils.Services;
using Xunit;

namespace GithubViewer.Utils.Tests
{
    public class StringCacheTests
    {
        private readonly StringCache _cache;
        private readonly string _key;

        public StringCacheTests()
        {
            _cache = new StringCache();
            _key = "key";
        }

        [Fact]
        public void Get_WhenPreviouslyNotPutAOnbjectWithKey_ShouldReturnStringEmpty()
        {
            // arrange

            // act

            var stringObject = _cache.Get(_key);

            // assert

            stringObject.Should().NotBeNull();
            stringObject.Should().BeEmpty();
        }

        [Fact]
        public void Get_WhenPreviouslyPutAOnbjectWithKey_ShouldReturnStringEmpty()
        {
            // arrange

            var obj = "object";
            _cache.Put(_key, obj);

            // act

            var stringObject = _cache.Get(_key);

            // assert

            stringObject.Should().NotBeNull();
            stringObject.Should().Be(obj);
        }
    }
}
