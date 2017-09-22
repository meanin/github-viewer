namespace GithubViewer.Utils.Contract
{
    /// <summary>
    /// Interface for communication with web api
    /// </summary>
    public interface IWebApiClient
    {
        /// <summary>
        /// Sends HttpGet for given method
        /// </summary>
        /// <param name="method">Method</param>
        /// <param name="token"></param>
        /// <returns>Response content as string, or string.empty</returns>
        string Get(string method, string token = null);
    }
}