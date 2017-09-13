using System;
using System.Net.Http;
using GithubViewer.Utils.Domain;

namespace GithubViewer.Utils.Services
{
    public class WebApiClientService : IWebApiClient
    {
        private readonly ICache<string> _cache;
        private readonly Uri _webApiDomain;

        public WebApiClientService(string webApiUri, ICache<string> cache)
        {
            _cache = cache;
            try
            {
                _webApiDomain = new Uri(webApiUri);
            }
            catch (Exception e)
            {
                throw new ApplicationException($"Web Api Domain was not defined, or it is not uri: {webApiUri}", e);
            }
        }

        public string Get(string method)
        {
            var cachedObject = _cache.Get(method);
            if (cachedObject != string.Empty)
                return cachedObject;

            var result = string.Empty;
            using (var client = new HttpClient())
            {
                var methodUri = new Uri(_webApiDomain, method);
                client.DefaultRequestHeaders.Add("User-Agent", "*");
                var response = client.GetAsync(methodUri).Result;
                if (!response.IsSuccessStatusCode)
                    return result;

                result = response.Content.ReadAsStringAsync().Result;
                _cache.Put(method, result);
            }
            return result;
        }
    }
}