using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace GithubViewer.Utils.Handlers
{
    /// <inheritdoc />
    /// <summary>
    /// Logs http requests and produced responses
    /// </summary>
    public sealed class LogMessageHandler : DelegatingHandler
    {
        private const string LogMessageString = "LogMessageHandler";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LogRequest(request);
            var response = await base.SendAsync(request, cancellationToken);
            LogResponse(response);
            return response;
        }

        private static void LogRequest(HttpRequestMessage request)
        {
            Log.Verbose(PutLogMessagePrefix("Request uri:\t {uri}"), LogMessageString, request.RequestUri.AbsolutePath);
            Log.Verbose(PutLogMessagePrefix("Request headers:\t {headers}"), LogMessageString, request.Headers.Select(header => new KeyValuePair<string, string>(
                    header.Key, header.Value.Aggregate((a, b) => $"{a}, {b}"))));
            Log.Verbose(PutLogMessagePrefix("Request body:\t {body}"), LogMessageString, request.Content.ReadAsStringAsync().Result);
        }

        private static void LogResponse(HttpResponseMessage response)
        {
            Log.Verbose(PutLogMessagePrefix("Response headers:\t {headers}"), LogMessageString, response.Headers.Select(header => new KeyValuePair<string, string>(
                header.Key, header.Value.Aggregate((a, b) => $"{a}, {b}"))));
            Log.Verbose(PutLogMessagePrefix("Response body:\t {body}"), LogMessageString, response.Content.ReadAsStringAsync().Result);
        }

        private static string PutLogMessagePrefix(string message)
        {
            return $"[{{LogMessageHandler}}]{message}";
        }
    }
}
