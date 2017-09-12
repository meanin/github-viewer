using Newtonsoft.Json;

namespace GithubViewer.Models
{
    public class GithubRepository
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("stargazers_count")]
        public int StargazesCount { get; set; }
    }
}