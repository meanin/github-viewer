using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GithubViewer.Web.Startup))]
namespace GithubViewer.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var authorityUrl = WebConfigurationManager.AppSettings.Get("AuthorityUrl") ?? string.Empty;
            var mvcUrl = WebConfigurationManager.AppSettings.Get("MvcUrl") ?? string.Empty;


            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.Configure(app, authorityUrl, mvcUrl);
        }
    }
}
