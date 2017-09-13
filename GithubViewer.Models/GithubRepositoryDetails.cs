using System;
using Newtonsoft.Json;

namespace GithubViewer.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Github users repository with detailed information
    /// </summary>
    public class GithubRepositoryDetails : GithubRepository
    {
        /// <summary>
        /// Url to github repository
        /// </summary>
        [JsonProperty("html_url")]
        public string Url { get; set; }
        /// <summary>
        /// Created date time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }
        /// <summary>
        /// Last update date time
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime LastUpdate { get; set; }

        public static GithubRepositoryDetails NullDetails = new GithubRepositoryDetails {Name = "No repository"};
    }
}