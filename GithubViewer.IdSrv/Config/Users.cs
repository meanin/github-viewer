using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;

namespace GithubViewer.IdSrv.Config
{
    internal static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "developer",
                    Password = "password",
                    Subject = "1",

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "developer"),
                        new Claim(Constants.ClaimTypes.Role, "rw")
                    }
                }
            };
        }
    }
}