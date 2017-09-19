using System.Web.Mvc;

namespace GithubViewer.Api
{
    /// <summary>
    /// Configuration class for flitering
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// Registering filers
        /// </summary>
        /// <param name="filters">Filters</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // require authentication for all controllers
            filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
