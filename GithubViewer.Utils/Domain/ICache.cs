namespace GithubViewer.Utils.Domain
{
    /// <summary>
    /// Interface for caching values of type T
    /// </summary>
    /// <typeparam name="T">Type for caching purpose</typeparam>
    public interface ICache<T>
    {
        T Get(string key);
        void Put(string key, T objectToStore);
    }
}