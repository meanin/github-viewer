using System;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

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
        /// SwaggerResponseContentTypeAttribute
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

    public class ResponseContentTypeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var requestAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerResponseContentTypeAttribute>().FirstOrDefault();
            if (requestAttributes == null)
                return;

            var responseType = requestAttributes.ResponseType;
            if(!operation.produces.Contains(responseType))
                operation.produces.Add(responseType);
        }
    }
}