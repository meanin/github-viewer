using System.Collections.Generic;
using GithubViewer.Utils.Domain;

namespace GithubViewer.Utils.Services
{
    public class WebApiClientCache : IWebApiClient
    {
        private readonly WebApiClientService _clientService;
        private readonly Dictionary<string, string> _cache;

        public WebApiClientCache(WebApiClientService clientService)
        {
            _clientService = clientService;
            _cache = new Dictionary<string, string>();
        }

        public string Get(string method)
        {
            if (!_cache.ContainsKey(method))
                _cache[method] = _clientService.Get(method);

            return _cache[method];
        }
    }
}
