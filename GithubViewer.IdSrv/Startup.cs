using System;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GithubViewer.IdSrv.App_Start;
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
            
            IdSrvConfig.Configure(app);
        }
    }
}