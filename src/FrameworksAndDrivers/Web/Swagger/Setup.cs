using System.IO;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace FrameworksAndDrivers.Web.Swagger
{
    [ExcludeFromCodeCoverage]
    public static class Setup
    {
        public static IServiceCollection AddFrameworksAndDriversWebSwagger(this IServiceCollection services,
            IConfiguration configuration)
        {     
            return services;              
        }

        public static IApplicationBuilder UseFrameworksAndDriversWebSwagger(this IApplicationBuilder app, 
            IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(
                    configuration["SWAGGER_JSON_ROUTE"],
                    configuration["SWAGGER_API_NAME"]
                );
                c.RoutePrefix = string.Empty;
            });

            var deserializer = new DeserializerBuilder()
                .Build();

            var swaggerPath = Path.GetFullPath(configuration["SWAGGER_YAML_FILE"]); 
            var swaggerJson = "{}";

            if(File.Exists(swaggerPath)) {
                var swaggerObject = deserializer.Deserialize(File.OpenText(swaggerPath));
                swaggerJson = JsonConvert.SerializeObject(swaggerObject);
            }

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapGet(configuration["SWAGGER_JSON_ROUTE"], async context => {  
                    await context.Response.WriteAsync(swaggerJson);
                });
            });

            return app;
        }
    }
}