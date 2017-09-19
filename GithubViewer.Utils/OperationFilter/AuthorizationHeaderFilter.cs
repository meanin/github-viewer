using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using Swashbuckle.Swagger;

namespace GithubViewer.Utils.OperationFilter
{
    /// <summary>
    /// Authorization header operation filter
    /// Provides additional input field for autorization header
    /// </summary>
    public class AuthorizationHeaderFilter: IOperationFilter
    {
        /// <summary>
        /// Applies input header field on controllers action which have [Autorize] attribute
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <param name="schemaRegistry">Schema Registry</param>
        /// <param name="apiDescription">Api Description</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            var isAuthorized = filterPipeline
                .Select(filterInfo => filterInfo.Instance)
                .Any(filter => filter is IAuthorizationFilter);

            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            if (isAuthorized && !allowAnonymous)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "access token",
                    required = false,
                    type = "string"
                });
            }
        }
    }
}
