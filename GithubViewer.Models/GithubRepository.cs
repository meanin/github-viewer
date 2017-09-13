using Newtonsoft.Json;

namespace GithubViewer.Models
{
    /// <summary>
    /// Github users repository
    /// </summary>
    public class GithubRepository
    {
        /// <summary>
        /// Repository id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Repository name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Used language
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }
        /// <summary>
        /// Stars count
        /// </summary>
        [JsonProperty("stargazers_count")]
        public int StargazesCount { get; set; }
    }
}