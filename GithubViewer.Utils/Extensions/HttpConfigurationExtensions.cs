using System.Web.Http;
using GithubViewer.Utils.Formatters;
using GithubViewer.Utils.Handlers;
using Serilog;

namespace GithubViewer.Utils.Extensions
{
    /// <summary>
    /// Class which handles all formatter within this solution
    /// </summary>
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        /// /// Add GithubViewer models formatters into http configuration pipeline
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        public static void AddGithubViewerFormatters(this HttpConfiguration config)
        {
            config.Formatters.Add(new GithubUserCsvFormatter());
            config.Formatters.Add(new GithubRepositoryCsvFormatter());
            config.Formatters.Add(new GithubRepositoryDetailsCsvFormatter());
        }

        public static void AddLogMessageHandler(this HttpConfiguration config)
        {
            config.MessageHandlers.Add(new LogMessageHandler());
        }
    }
}
