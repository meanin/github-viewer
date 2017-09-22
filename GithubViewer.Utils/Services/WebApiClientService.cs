using System;
using System.Net.Http;
using GithubViewer.Utils.Contract;

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

        public string Get(string method, string token = null)
        {
            var cachedObject = _cache.Get(method);
            if (!string.IsNullOrEmpty(cachedObject))
                return cachedObject;

            var result = GetMethodContentResult(method, token);
            _cache.Put(method, result);
            return result;
        }

        private string GetMethodContentResult(string method, string token)
        {
            using (var client = new HttpClient())
            {
                var methodUri = new Uri(_webApiDomain, method);
                client.DefaultRequestHeaders.Add("User-Agent", "*");
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var response = client.GetAsync(methodUri).Result;
                return !response.IsSuccessStatusCode
                    ? string.Empty 
                    : response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}