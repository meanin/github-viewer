using GithubViewer.IdSrv.Config;
using IdentityServer3.Core.Configuration;
using Owin;

namespace GithubViewer.IdSrv.App_Start
{
    public static class IdSrvConfig
    {
        public static void Configure(IAppBuilder app)
        {
            var options = new IdentityServerOptions
            {
                SiteName = "Github Viewer - Identity Server",
                SigningCertificate = Cert.LoadCertificate(),
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
                RequireSsl = false,
                AuthenticationOptions = new AuthenticationOptions
                {
                    EnablePostSignOutAutoRedirect = true
                },
                EnableWelcomePage = true
            };

            app.UseIdentityServer(options);
        }
    }
}