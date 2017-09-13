using System.Collections.Generic;
using GithubViewer.Utils.Domain;

namespace GithubViewer.Utils.Services
{
    public class StringCache  : ICache<string>
    {
        private readonly Dictionary<string, string> _cache;

        public StringCache()
        {
            _cache = new Dictionary<string, string>();
        }

        public string Get(string method)
        {
            return !_cache.ContainsKey(method) ? string.Empty : _cache[method];
        }

        public void Put(string key, string objectToStore)
        {
            _cache[key] = objectToStore;
        }
    }
}
