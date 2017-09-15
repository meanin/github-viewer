using System.Web.Configuration;
using Microsoft.Practices.Unity;
using System.Web.Http;
using GithubViewer.Utils.Domain;
using GithubViewer.Utils.Services;
using Unity.WebApi;
using Serilog;
using Serilog.Events;
using System.IO;
using System;
using Serilog.Core;

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
            var httpLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "httplogs", "log-{Date}.txt");
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log-{Date}.txt");
            Log.Logger = CreateLogger(httpLogPath, logPath);

            var githubApiUrl = WebConfigurationManager.AppSettings.Get("GithubApiUrl") ?? string.Empty;
            container.RegisterType<IWebApiClient, WebApiClientService>
                (new InjectionConstructor(githubApiUrl, 
                    container.Resolve<ICache<string>>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static Logger CreateLogger(string httpLogPath, string logPath)
        {
            return new LoggerConfiguration().MinimumLevel.Verbose()
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Properties.ContainsKey("LogMessageHandler"))
                    .WriteTo.RollingFile(httpLogPath, LogEventLevel.Verbose))
                .WriteTo.Logger(l => l.Filter.ByExcluding(e => e.Properties.ContainsKey("LogMessageHandler"))
                    .WriteTo.RollingFile(logPath, LogEventLevel.Verbose))
                .CreateLogger();
        }
    }
}