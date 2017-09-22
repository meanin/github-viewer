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
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.Configure(app);
        }
    }
}
