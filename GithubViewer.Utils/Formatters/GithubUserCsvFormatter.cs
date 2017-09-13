using System.IO;
using System.Linq;
using GithubViewer.Models;

namespace GithubViewer.Utils.Formatters
{
    public class GithubUserCsvFormatter : GithubViewerCsvFormatterBase<GithubUser>
    {
        public override void WriteHeader(StreamWriter writer)
        {
            writer.WriteLine("User Id;Login;Location;Avatar Url;BlogUrl;Repository Id;Repository Name;Repository Language;Repository Star Count");
        }

        public override void WriteItem(GithubUser user, StreamWriter writer)
        {
            writer.WriteLine($"{user.Id};${user.Login};${user.Location};${user.AvatarUrl};${user.BlogUrl};");
            writer.WriteLine(";;;;;Repositories");
            foreach (var repository in user.RepositoryList)
            {
                writer.WriteLine($";;;;;{repository.Id};{repository.Name};{repository.Language};{repository.StargazesCount}");
            }
            if(user.StarredRepositoryList == null && !user.StarredRepositoryList.Any())
                return;

            writer.WriteLine(";;;;;Starred repositories");
            foreach (var repository in user.StarredRepositoryList)
            {
                writer.WriteLine($";;;;;{repository.Id};{repository.Name};{repository.Language};{repository.StargazesCount}");
            }
        }
    }
}
