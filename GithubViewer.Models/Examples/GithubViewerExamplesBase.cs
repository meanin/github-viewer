using System.Collections.Generic;
using Swashbuckle.Examples;

namespace GithubViewer.Models.Examples
{
    /// <summary>
    /// Base class for Examples Provider used in Swagger for GithubViewer.Api
    /// </summary>
    /// <typeparam name="T">Type of Example</typeparam>
    public abstract class GithubViewerExamplesBase<T> : IExamplesProvider
    {
        /// <summary>
        /// Get examples
        /// </summary>
        /// <returns>Returns list of examples with only one item</returns>
        public object GetExamples()
        {
            return new List<T>
            {
                GetExample()
            };
        }

        /// <summary>
        /// Single example
        /// </summary>
        /// <returns>Returns single example</returns>
        public abstract T GetExample();
    }
}
