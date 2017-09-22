using System.Linq;
using System.Web.Http.Description;
using GithubViewer.Swashbuckle.Attributes;
using Swashbuckle.Swagger;

namespace GithubViewer.Swashbuckle.OperationFilters
{
    /// <summary>
    /// Operation filter for setting response type in swagger document
    /// </summary>
    public class ResponseContentTypeOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Adds response types into operation produces
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <param name="schemaRegistry">Schema Registry</param>
        /// <param name="apiDescription">Api Description</param>
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