using System.Collections.Generic;
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
                    Subject = "1"
                }
            };
        }
    }
}