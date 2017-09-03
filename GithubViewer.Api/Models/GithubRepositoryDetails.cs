using System;

namespace GithubViewer.Api.Models
{
    public class GithubRepositoryDetails : GithubRepository
    {
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}