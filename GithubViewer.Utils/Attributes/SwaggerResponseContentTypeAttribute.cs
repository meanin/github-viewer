using System;

namespace GithubViewer.Utils.Attributes
{
    /// <inheritdoc />
    /// <summary>
    /// SwaggerResponseContentTypeAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class SwaggerResponseContentTypeAttribute : Attribute
    {
        /// <inheritdoc />
        /// <summary>
        /// SwaggerResponseContentTypeAttribute ctor
        /// </summary>
        /// <param name="responseType"></param>
        public SwaggerResponseContentTypeAttribute(string responseType)
        {
            ResponseType = responseType;
        }
        /// <summary>
        /// Response Content Type
        /// </summary>
        public string ResponseType { get; }
    }
}