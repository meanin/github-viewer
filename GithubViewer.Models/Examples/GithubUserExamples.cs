using System.Collections.Generic;

namespace GithubViewer.Models.Examples
{
    /// <inheritdoc />
    /// <summary>
    /// GithubUser examples
    /// </summary>
    public class GithubUserExamples : GithubViewerExamplesBase<GithubUser>
    {
        public override GithubUser GetExample()
        {
            return new GithubUser
            {
                Id = 6974668,
                Login = "meanin",
                AvatarUrl = "",
                Location = "internet",
                BlogUrl = "",
                RepositoryList = new List<GithubRepository>{new GithubRepositoryExamples().GetExample()},
                StarredRepositoryList = new List<GithubRepository>()
            };
        }
    }
}