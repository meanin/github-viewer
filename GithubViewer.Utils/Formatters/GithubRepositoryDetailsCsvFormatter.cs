using System;
using System.IO;
using GithubViewer.Models;
using GithubViewer.Utils.Extensions;

namespace GithubViewer.Utils.Formatters
{
    public class GithubRepositoryDetailsCsvFormatter : GithubViewerCsvFormatterBase<GithubRepositoryDetails>
    {
        public override void WriteHeader(StreamWriter writer)
        {
            writer.WriteLine("Repository Id;Name;Language;Star Count;Created;Last update;Url");
        }

        public override void WriteItem(GithubRepositoryDetails repository, StreamWriter writer)
        {
            writer.WriteLine($"{repository.Id};{repository.Name};{repository.Language};{repository.StargazesCount};{repository.Created};{repository.LastUpdate};{repository.Url}");
        }
    }
}
