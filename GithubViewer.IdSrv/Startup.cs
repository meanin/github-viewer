using System;
using System.IO;
using GithubViewer.IdSrv.Config;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using Serilog;

[assembly: OwinStartup(typeof(GithubViewer.IdSrv.Startup))]

namespace GithubViewer.IdSrv
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log-{Date}.txt");
            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
                .WriteTo.RollingFile(logPath)
                .CreateLogger();

            var options = new IdentityServerOptions
            {
                Factory = new IdentityServerServiceFactory()
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get())
                    .UseInMemoryUsers(Users.Get()),
                LoggingOptions = new LoggingOptions
                {
                    EnableHttpLogging = true,
                    EnableWebApiDiagnostics = true,
                    WebApiDiagnosticsIsVerbose = true
                },
                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}