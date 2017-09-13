using System;
using FluentAssertions;
using GithubViewer.Utils.Services;
using GithubViewer.Utils.Tests.TestsModel;
using Xunit;

namespace GithubViewer.Utils.Tests
{
    public class XmlSerializerServiceTests
    {
        private readonly XmlSerializerService _serializer;

        public XmlSerializerServiceTests()
        {
            _serializer = new XmlSerializerService();
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
            var expectedString = "<?xml version=\"1.0\" encoding=\"utf-16\"?><TestObject><Name>name</Name></TestObject>";

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

            serializedString.Should().Be(string.Empty);
        }

        [Fact]
        public void Deserialize_WhenGivenValidTestObjectAsString_ShouldReturnDeserializedObject()
        {
            // arrange

            var expectedString = "<?xml version=\"1.0\" encoding=\"utf-16\"?><TestObject><Name>name</Name></TestObject>";

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

            var expectedString = "<?xml version=\"1.0\" encoding=\"utf-16\"?><TestObme</Name></TestObject>";

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
