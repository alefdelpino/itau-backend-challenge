using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseBusinessRules;
using ApplicationBusinessRules.Services;
using ApplicationBusinessRules.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ApplicationBusinessRules
{
    public static class Setup
    {
        public static IServiceCollection AddApplicationBusinessRules(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddEnterpriseBusinessRules(configuration)
                .AddScoped<IValidationService, ValidationService>();
        }

        public static IApplicationBuilder UseApplicationBusinessRules(this IApplicationBuilder app, 
            IWebHostEnvironment env, IConfiguration configuration)
        {
            return app
                .UseEnterpriseBusinessRules(env, configuration);
        }

    }
}
