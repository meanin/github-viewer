namespace GithubViewer.Utils.Domain
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
        /// <returns>Response content as string, or string.empty</returns>
        string Get(string method);
    }
}