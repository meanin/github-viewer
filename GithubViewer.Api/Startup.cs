using System;
using System.IO;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GithubViewer.Api.Startup))]

namespace GithubViewer.Api
{
    /// <summary>
    /// Startup class for owin pipeline
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration of owin pipeline
        /// </summary>
        /// <param name="app">Application builder</param>
        public void Configuration(IAppBuilder app)
        {
            var httpLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "httplogs", "log-{Date}.txt");
            var controllerLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log-{Date}.txt");
            var githubApiUrl = WebConfigurationManager.AppSettings.Get("GithubApiUrl") ?? string.Empty;
            var authorityUrl = WebConfigurationManager.AppSettings.Get("AuthorityUrl") ?? string.Empty;
            var xmlPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\bin\SwaggerGithubViewerApi.xml";

            UnityConfig.RegisterComponents(httpLogPath, controllerLogPath, githubApiUrl);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            SwaggerConfig.Register(xmlPath, authorityUrl);
            ConfigureTokenValidationEndpoint(app, authorityUrl);
            app.UseWebApi(GlobalConfiguration.Configuration);
        }

        private static void ConfigureTokenValidationEndpoint(IAppBuilder app, string authorityUrl)
        {
            var options = new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = authorityUrl,
                RequiredScopes = new[] {"api"},
                ValidationMode = ValidationMode.ValidationEndpoint,
                ClientSecret = "apisecret"
            };
            app.UseIdentityServerBearerTokenAuthentication(options);
        }
    }
}
