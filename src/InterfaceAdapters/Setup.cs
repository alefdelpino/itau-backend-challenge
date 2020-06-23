using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApplicationBusinessRules;
using System.Diagnostics.CodeAnalysis;

namespace InterfaceAdapters
{
    public static class Setup
    {
        public static IServiceCollection AddInterfaceAdapters(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddApplicationBusinessRules(configuration);                
        }        

        public static IApplicationBuilder UseInterfaceAdapters(this IApplicationBuilder app, 
            IWebHostEnvironment env, IConfiguration configuration)
        {            
            app
                .UseApplicationBusinessRules(env, configuration);

            return app;
        }
    }
}