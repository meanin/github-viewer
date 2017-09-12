using System.Collections.Generic;
using Newtonsoft.Json;

namespace GithubViewer.Models
{
    public class GithubUser
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("blog")]
        public string BlogUrl { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        public List<GithubRepository> StarredRepositoryList { get; set; }
        public List<GithubRepository> RepositoryList { get; set; }

        [JsonIgnore]
        public static GithubUser NullUser = new GithubUser {Login = "No user"};
    }
}