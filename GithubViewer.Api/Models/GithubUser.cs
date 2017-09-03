using System.Collections.Generic;

namespace GithubViewer.Api.Models
{
    public class GithubUser
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
        public string BlogUrl { get; set; }
        public List<GithubRepository> StarredRepositoryList { get; set; }
        public List<GithubRepository> RepositoryList { get; set; }
    }
}