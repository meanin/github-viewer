using System.Web.Configuration;
using Microsoft.Practices.Unity;
using System.Web.Http;
using GithubViewer.Api.Domain;
using GithubViewer.Api.Services;
using GithubViewer.Utils.Domain;
using GithubViewer.Utils.Services;
using Unity.WebApi;

namespace GithubViewer.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IWebApiClient, WebApiClientService>
                (new InjectionConstructor(WebConfigurationManager.AppSettings.Get("GithubApiUrl")));
            container.RegisterType<IGithubViewerService, GithubViewerService>();
            container.RegisterType<ISerializer, JsonSerializerService>();
            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}