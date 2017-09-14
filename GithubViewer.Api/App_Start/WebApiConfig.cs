using System.Web.Http;
using GithubViewer.Utils.Extensions;

namespace GithubViewer.Api
{
    /// <summary>
    /// Configuration for web api
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registering configuration for web api
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.AddGithubViewerFormatters();
            config.AddLogMessageHandler();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "swagger",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
