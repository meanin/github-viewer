using System.Web.Configuration;
using Microsoft.Practices.Unity;
using System.Web.Http;
using GithubViewer.Utils.Services;
using Unity.WebApi;
using Serilog;
using Serilog.Events;
using System.IO;
using System;
using GithubViewer.Utils.Contract;
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
        /// <param name="httpLogPath">Where to store http logs</param>
        /// <param name="controllerLogPath">Where to store controller logs</param>
        /// <param name="githubApiUrl">Github Api url</param>
        public static void RegisterComponents(string httpLogPath, string controllerLogPath, string githubApiUrl)
        {
			var container = new UnityContainer();

            container.RegisterInstance<ICache<string>>(new SimpleInMemoryCache<string>());
            container.RegisterType<IGithubApiService, GithubApiService>();
            Log.Logger = CreateLogger(httpLogPath, controllerLogPath);

            container.RegisterType<ISerializer, JsonSerializerService>();
            container.RegisterType<IWebApiClient, WebApiClientService>
                (new InjectionConstructor(githubApiUrl, 
                    container.Resolve<ICache<string>>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static Logger CreateLogger(string httpLogPath, string logPath)
        {
            var loggerConfiguration = new LoggerConfiguration().MinimumLevel.Verbose();

            if(!string.IsNullOrEmpty(httpLogPath))
                loggerConfiguration.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Properties.ContainsKey("LogMessageHandler"))
                    .WriteTo.RollingFile(httpLogPath, LogEventLevel.Verbose));
            if (!string.IsNullOrEmpty(logPath))
                loggerConfiguration.WriteTo.Logger(l => l.Filter.ByExcluding(e => e.Properties.ContainsKey("LogMessageHandler"))
                    .WriteTo.RollingFile(logPath, LogEventLevel.Verbose));
                
            return loggerConfiguration.CreateLogger();
        }
    }
}