using System.Web.Http;
using Swashbuckle.Application;
using GithubViewer.Utils.OperationFilter;
using Swashbuckle.Examples;

namespace GithubViewer.Api
{
    /// <summary>
    /// Configuration class for Swagger
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Registering swagger components
        /// </summary>
        /// <param name="xmlPath">Path to xml documentation file</param>
        /// <param name="authorityUrl">Identity server url</param>
        public static void Register(string xmlPath, string authorityUrl)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "GithubViewer.Api");
                        c.IncludeXmlComments(xmlPath);

                        c.OperationFilter<ExamplesOperationFilter>();
                        c.OperationFilter<AuthorizationHeaderFilter>();
                        c.OperationFilter<AssignOAuth2SecurityRequirements>();
                        c.OperationFilter<ResponseContentTypeOperationFilter>();

                        c.OAuth2("oauth2")
                            .Flow("application")
                            .Scopes(s => s.Add("api", "Scope for swagger usage"))
                            .TokenUrl($"{authorityUrl}/connect/token");

                        c.PrettyPrint();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Github-Viewer Swagger UI");
                    });
        }
    }
}
