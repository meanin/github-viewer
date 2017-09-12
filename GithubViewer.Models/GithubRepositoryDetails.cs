using System;
using Newtonsoft.Json;

namespace GithubViewer.Models
{
    public class GithubRepositoryDetails : GithubRepository
    {
        [JsonProperty("html_url")]
        public string Url { get; set; }
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }
        [JsonProperty("updated_at")]
        public DateTime LastUpdate { get; set; }

        public static GithubRepositoryDetails NullDetails = new GithubRepositoryDetails {Name = "No repository"};
    }
}