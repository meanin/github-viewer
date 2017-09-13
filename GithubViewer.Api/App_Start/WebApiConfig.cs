using System.Web.Http;
using GithubViewer.Utils.Extensions;

namespace GithubViewer.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.AddGithubViewerFormatters();

            config.Routes.MapHttpRoute(
                name: "swagger",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
