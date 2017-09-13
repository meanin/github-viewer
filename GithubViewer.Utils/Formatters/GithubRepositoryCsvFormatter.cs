using System.IO;
using GithubViewer.Models;

namespace GithubViewer.Utils.Formatters
{
    public class GithubRepositoryCsvFormatter : GithubViewerCsvFormatterBase<GithubRepository>
    {
        public override void WriteHeader(StreamWriter writer)
        {
            writer.WriteLine("Repository Id;Name;Language;Star Count");
        }

        public override void WriteItem(GithubRepository repository, StreamWriter writer)
        {
            writer.WriteLine($"{repository.Id};{repository.Name};{repository.Language};{repository.StargazesCount}");
        }
    }
}
