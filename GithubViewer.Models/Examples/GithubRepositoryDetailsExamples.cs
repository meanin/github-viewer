using System;

namespace GithubViewer.Models.Examples
{
    /// <inheritdoc />
    /// <summary>
    /// GithubRepositoryDetails examples
    /// </summary>
    public class GithubRepositoryDetailsExamples : GithubViewerExamplesBase<GithubRepositoryDetails>
    {
        public override GithubRepositoryDetails GetExample()
        {
            var r = new GithubRepositoryExamples().GetExample();
            var rd = new GithubRepositoryDetails
            {
                Url = "https://github.com/meanin/GithubViewer",
                Created = DateTime.Parse("2017-09-03T08:35:22Z"),
                LastUpdate = DateTime.UtcNow,
                Id = r.Id,
                Name = r.Name,
                Language = r.Language,
                StargazesCount = r.StargazesCount
            };

            return rd;
        }
    }
}