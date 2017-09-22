using System.Collections.Generic;
using GithubViewer.Utils.Contract;

namespace GithubViewer.Utils.Services
{
    public class SimpleInMemoryCache<T> : ICache<T>
    {
        private readonly Dictionary<string, T> _cache;

        public SimpleInMemoryCache()
        {
            _cache = new Dictionary<string, T>();
        }

        public T Get(string method)
        {
            return !_cache.ContainsKey(method) 
                ? default(T) 
                : _cache[method];
        }

        public void Put(string key, T objectToStore)
        {
            _cache[key] = objectToStore;
        }
    }
}
