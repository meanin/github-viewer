using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace GithubViewer.Swashbuckle.OperationFilters
{
    /// <summary>
    /// Provides possibility to set client credentials on swagger test page
    /// </summary>
    public class OAuth2SecurityFilter : IOperationFilter
    {
        /// <summary>
        /// Adds oauth2 requirements into operation security
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <param name="schemaRegistry">Schema Registry</param>
        /// <param name="apiDescription">Api Description</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var actFilters = apiDescription.ActionDescriptor.GetFilterPipeline();
            var allowsAnonymous = actFilters.Select(f => f.Instance).OfType<OverrideAuthorizationAttribute>().Any();
            if (allowsAnonymous)
                return;

            if (operation.security == null)
                operation.security = new List<IDictionary<string, IEnumerable<string>>>();

            var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
            {
                {"oauth2", new List<string> {"api"}}// TODO: get all of scopes
            };

            operation.security.Add(oAuthRequirements);
        }
    }
}
