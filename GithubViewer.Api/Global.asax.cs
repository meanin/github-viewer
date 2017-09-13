using System.Web.Http;
using System.Web.Mvc;

namespace GithubViewer.Api
{
    /// <inheritdoc />
    /// <summary>
    /// Global asax web api class
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// WebApi Application start method
        /// </summary>
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            SwaggerConfig.Register();
        }
    }
}
