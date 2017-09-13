using System.Web.Http;
using Swashbuckle.Application;
using GithubViewer.Utils.Attributes;
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
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "GithubViewer.Api");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\SwaggerGithubViewerApi.xml",
                            System.AppDomain.CurrentDomain.BaseDirectory));
                        c.OperationFilter<ResponseContentTypeOperationFilter>();
                        c.OperationFilter<ExamplesOperationFilter>();
                        c.PrettyPrint();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Github-Viewer Swagger UI");
                    });
        }
    }
}
