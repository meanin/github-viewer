using System;
using FluentAssertions;
using GithubViewer.Utils.Services;
using GithubViewer.Utils.Tests.TestsModel;
using Xunit;

namespace GithubViewer.Utils.Tests
{
    public class JsonSerializerServiceTests
    {
        private readonly JsonSerializerService _serializer;

        public JsonSerializerServiceTests()
        {
            _serializer = new JsonSerializerService();
        }

        [Fact]
        public void Serialize_WhenGivenValidObject_ShouldReturnString()
        {
            // arrange

            var obj = new TestObject { Name = "name" };

            // act

            var serializedString = _serializer.Serialize(obj);

            // assert

            serializedString.Should().BeAssignableTo<string>();
        }

        [Fact]
        public void Serialize_WhenGivenValidObject_ShouldBe()
        {
            // arrange

            var obj = new TestObject { Name = "name" };
            var expectedString = "{\"Name\":\"name\"}";

            // act

            var serializedString = _serializer.Serialize(obj);

            // assert

            serializedString.Should().Be(expectedString);
        }

        [Fact]
        public void Serialize_WhenGivenNull_ShouldReturnNull()
        {
            // arrange

            // act

            var serializedString = _serializer.Serialize<TestObject>(null);

            // assert

            serializedString.Should().Be(String.Empty);
        }

        [Fact]
        public void Deserialize_WhenGivenValidTestObjectAsString_ShouldReturnDeserializedObject()
        {
            // arrange

            var expectedString = "{\"Name\":\"name\"}";

            // act

            var obj = _serializer.Deserialize<TestObject>(expectedString);

            // assert

            obj.Should().NotBeNull();
            obj.Name.Should().Be("name");
        }

        [Fact]
        public void Deserialize_WhenGivenInvalidTestObjectAsString_ShouldReturnNull()
        {
            // arrange

            var expectedString = "{\"Nameame\"}";

            // act
            TestObject obj = null;
            Action act = () =>
            {
                obj = _serializer.Deserialize<TestObject>(expectedString);
            };

            // assert

            act.ShouldNotThrow();
            obj.Should().BeNull();
        }
    }
}
