namespace GithubViewer.Utils
{
    public static class GithubApiMethodAppendixBuilder
    {
        public static string GetUserMethod(string login) => $"users/{login}";
        public static string GetUsersRepositoriesMethod(string login) => $"users/{login}/repos";
        public static string GetUsersStarredRepositoriesMethod(string login) => $"users/{login}/starred";
        public static string GetRepositoryDetailsMethod(string login, string repository) => $"repos/{login}/{repository}";
    }
}