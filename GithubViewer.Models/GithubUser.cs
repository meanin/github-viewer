using System.Collections.Generic;
using Newtonsoft.Json;

namespace GithubViewer.Models
{
    /// <summary>
    /// Github User model
    /// </summary>
    public class GithubUser
    {
        /// <summary>
        /// User login
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// User avatar url
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        /// <summary>
        /// User blog url
        /// </summary>
        [JsonProperty("blog")]
        public string BlogUrl { get; set; }
        /// <summary>
        /// User origin location
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }
        /// <summary>
        /// Users starred repository list
        /// </summary>
        public List<GithubRepository> StarredRepositoryList { get; set; }
        /// <summary>
        /// Users repository list
        /// </summary>
        public List<GithubRepository> RepositoryList { get; set; }

        [JsonIgnore]
        public static GithubUser NullUser = new GithubUser {Login = "No user"};
    }
}