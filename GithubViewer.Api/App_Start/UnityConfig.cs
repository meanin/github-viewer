using System.Web.Configuration;
using Microsoft.Practices.Unity;
using System.Web.Http;
using GithubViewer.Utils.Domain;
using GithubViewer.Utils.Services;
using Unity.WebApi;

namespace GithubViewer.Api
{
    /// <summary>
    /// Configuration class for unity DI
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registering all needed components
        /// </summary>
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterInstance<ICache<string>>(new StringCache());
            container.RegisterType<IGithubApiService, GithubApiService>();
            container.RegisterType<ISerializer, JsonSerializerService>();
            container.RegisterType<IWebApiClient, WebApiClientService>
                (new InjectionConstructor(
                    WebConfigurationManager.AppSettings.Get("GithubApiUrl"), 
                    container.Resolve<ICache<string>>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}