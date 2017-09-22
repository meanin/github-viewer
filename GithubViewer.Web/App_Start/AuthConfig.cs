using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace GithubViewer.Web
{
    public static class AuthConfig
    {
        public static void Configure(IAppBuilder app, string authorityUrl, string mvcUrl)
        {
            app.UseCors(CorsOptions.AllowAll);
            
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "web",
                Authority = $"{authorityUrl}",
                RedirectUri = mvcUrl,
                ResponseType = "id_token token",
                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false,
                Scope = "openid profile roles api",
                Notifications = OpenIdNotifications()
            });
        }

        private static OpenIdConnectAuthenticationNotifications OpenIdNotifications()
        {
            return new OpenIdConnectAuthenticationNotifications
            {
                SecurityTokenValidated = async n =>
                {
                    var nid = new ClaimsIdentity(
                        n.AuthenticationTicket.Identity.AuthenticationType,
                        "given_name",
                        "role");

                    // get userinfo data
                    var userInfoClient = new UserInfoClient(
                        new Uri(n.Options.Authority + "/connect/userinfo"),
                        n.ProtocolMessage.AccessToken);

                    var userInfo = await userInfoClient.GetAsync();
                    userInfo.Claims.ToList().ForEach(ui => nid.AddClaim(new Claim(ui.Item1, ui.Item2)));

                    // keep the id_token for logout
                    nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));

                    // add access token for sample API
                    nid.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

                    // keep track of access token expiration
                    nid.AddClaim(new Claim("expires_at", DateTimeOffset.Now.AddSeconds(int.Parse(n.ProtocolMessage.ExpiresIn)).ToString()));

                    // add some other app specific claim
                    nid.AddClaim(new Claim("app_specific", "some data"));

                    n.AuthenticationTicket = new AuthenticationTicket(
                        nid,
                        n.AuthenticationTicket.Properties);
                },

                RedirectToIdentityProvider = n =>
                {
                    if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                    {
                        var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                        if (idTokenHint != null)
                        {
                            n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                        }
                    }

                    return Task.FromResult(0);
                }
            };
        }
    }
}