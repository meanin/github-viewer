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
            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
                            .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Properties.ContainsKey("LogMessageHandler"))
                                            .WriteTo.RollingFile(httpLogPath, LogEventLevel.Verbose))
                            .WriteTo.Logger(l => l.Filter.ByExcluding(e => e.Properties.ContainsKey("LogMessageHandler"))
                                            .WriteTo.RollingFile(logPath, LogEventLevel.Verbose))
                        .CreateLogger();

            container.RegisterType<IWebApiClient, WebApiClientService>
                (new InjectionConstructor(
                    WebConfigurationManager.AppSettings.Get("GithubApiUrl"), 
                    container.Resolve<ICache<string>>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}