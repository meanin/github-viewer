using System.Web.Http;
using GithubViewer.Utils.Formatters;

namespace GithubViewer.Utils.Extensions
{
    public static class HttpConfigurationExtensions
    {
        public static void AddGithubViewerFormatters(this HttpConfiguration config)
        {
            config.Formatters.Add(new GithubUserCsvFormatter());
            config.Formatters.Add(new GithubRepositoryCsvFormatter());
            config.Formatters.Add(new GithubRepositoryDetailsCsvFormatter());
        }
    }
}
