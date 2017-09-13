using System.Web.Mvc;

namespace GithubViewer.Api
{
    /// <summary>
    /// Configuration class for flitering
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registering filers
        /// </summary>
        /// <param name="filters">Filters</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
