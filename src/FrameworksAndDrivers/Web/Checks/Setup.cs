using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace FrameworksAndDrivers.Web.Checks
{
    public static class Setup
    {
        public static IServiceCollection AddFrameworksAndDriversWebChecks(this IServiceCollection services, IConfiguration configuration)
        {           
            services
                .AddHealthChecks();
            return services;
        }

        public static IApplicationBuilder UseFrameworksAndDriversWebChecks(this IApplicationBuilder app, 
            IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseHealthChecks(configuration["HEALTHCHECK_ROUTE"]);
            return app;
        }
    }
}
