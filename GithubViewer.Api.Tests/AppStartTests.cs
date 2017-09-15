using System;
using System.Web.Http;
using System.Web.Mvc;
using FluentAssertions;
using Xunit;

namespace GithubViewer.Api.Tests
{
    public class AppStartTests
    {
        [Fact]
        public void RegisterFilters_ShouldNotThrow()
        {
            // arrange

            var obj = new GlobalFilterCollection();

            // act

            Action act = () => FilterConfig.RegisterGlobalFilters(obj);

            // assert

            act.ShouldNotThrow();
        }

        [Fact]
        public void RegisterSwagger_ShouldNotThrow()
        {
            // arrange
            
            // act

            Action act = SwaggerConfig.Register;

            // assert

            act.ShouldNotThrow();
        }

        [Fact]
        public void RegisterUnity_ShouldNotThrow()
        {
            // arrange

            // act

            Action act = UnityConfig.RegisterComponents;

            // assert

            act.ShouldNotThrow();
        }

        [Fact]
        public void RegisterWebApi_ShouldNotThrow()
        {
            // arrange

            var config = new HttpConfiguration();

            // act

            Action act = () => WebApiConfig.Register(config);

            // assert

            act.ShouldNotThrow();
        }
    }
}
