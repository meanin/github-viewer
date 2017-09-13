namespace GithubViewer.Utils.Domain
{
    public interface ICache<T>
    {
        T Get(string key);
        void Put(string key, T objectToStore);
    }
}