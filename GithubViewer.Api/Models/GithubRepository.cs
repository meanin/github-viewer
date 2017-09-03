using System;

namespace GithubViewer.Api.Models
{
    public class GithubRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
    }
}