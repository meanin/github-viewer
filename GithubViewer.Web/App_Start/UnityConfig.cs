using System;
using Microsoft.Practices.Unity;
using GithubViewer.Utils.Contract;
using GithubViewer.Utils.Services;
using System.Web.Mvc;
using GithubViewer.Web.Contract;
using GithubViewer.Web.Domain;
using Microsoft.Practices.Unity.Mvc;

namespace GithubViewer.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(string githubViewerApiUrl)
        {
            var container = new UnityContainer();

            container.RegisterType<ISerializer, JsonSerializerService>();
            container.RegisterInstance<ICache<string>>(new SimpleInMemoryCache<string>());
            container.RegisterType<IWebApiClient, WebApiClientService>
            (new InjectionConstructor(githubViewerApiUrl,
                container.Resolve<ICache<string>>()));
            container.RegisterType<IGithubViewerApiService, GithubViewerApiService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
