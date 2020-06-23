using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FrameworksAndDrivers.Web.Cors;
using FrameworksAndDrivers.Web.Swagger;
using FrameworksAndDrivers.Web.Checks;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FrameworksAndDrivers.Web
{
    public static class Setup
    {
        public static IServiceCollection AddFrameworksAndDriversWeb(this IServiceCollection services, IConfiguration configuration)
        {           
            services
                .AddControllers();
            return services
                .AddFrameworksAndDriversWebCors(configuration)
                .AddFrameworksAndDriversWebSwagger(configuration)   
                .AddFrameworksAndDriversWebChecks(configuration);
        }

        public static IApplicationBuilder UseFrameworksAndDriversWeb(this IApplicationBuilder app, 
            IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }   
         
            //app.UseHttpsRedirection();

            app.UseRouting();

            return app
                .UseFrameworksAndDriversWebCors(env, configuration)
                .UseFrameworksAndDriversWebSwagger(env, configuration)
                .UseFrameworksAndDriversWebChecks(env, configuration);                
        }
    }
}
