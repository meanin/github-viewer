namespace GithubViewer.Models.Examples
{
    /// <inheritdoc />
    /// <summary>
    /// GithubRepository examples
    /// </summary>
    public class GithubRepositoryExamples : GithubViewerExamplesBase<GithubRepository>
    {
        public override GithubRepository GetExample()
        {
            return new GithubRepository
            {
                Id = 102251318,
                Name = "GithubViewer",
                Language = "C#",
                StargazesCount = 0
            };
        }
    }
}