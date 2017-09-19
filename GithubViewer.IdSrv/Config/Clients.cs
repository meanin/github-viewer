using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace GithubViewer.IdSrv.Config
{
    internal static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                // swagger involved
                new Client
                {
                    ClientName = "GithubViewerApi.Swagger",
                    ClientId = "swagger",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,
                    AllowClientCredentialsOnly = true,
                    ClientSecrets = new List<Secret> { new Secret("secret".Sha256()) },
                    AllowedScopes = new List<string> { "api" }, 
                    AllowedCorsOrigins = new List<string>{ "http://localhost:50000/" }
                },

                // human is involved
                new Client
                {
                    ClientName = "GithubViewerWeb",
                    ClientId = "web",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("websecret".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "api"
                    }
                }
            };
        }
    }
}