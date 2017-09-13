using System.Web.Http;
using Swashbuckle.Application;
using GithubViewer.Utils.Attributes;

namespace GithubViewer.Api
{
    public static class SwaggerConfig
    {
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
                        c.PrettyPrint();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Github-Viewer Swagger UI");
                    });
        }
    }
}
