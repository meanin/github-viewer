using System;
using GithubViewer.IdSrv.Config;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin.Security.Google;
using Owin;
using System.Web.Configuration;

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
                    EnablePostSignOutAutoRedirect = true,
                    PostSignOutAutoRedirectDelay = 2,
                    IdentityProviders = IdentityProviders
                },
                EnableWelcomePage = true
            };

            app.UseIdentityServer(options);
        }

        private static void IdentityProviders(IAppBuilder app, string signInAsType)
        {
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                SignInAsAuthenticationType = signInAsType,
                ClientId = WebConfigurationManager.AppSettings.Get("GoogleClientId"),
                ClientSecret = WebConfigurationManager.AppSettings.Get("GoogleClientSecret")
            });
        }
    }
}