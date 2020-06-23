using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FrameworksAndDrivers.Web;
using InterfaceAdapters;

namespace FrameworksAndDrivers
{
    public static class Setup
    {
        public static IServiceCollection AddFrameworksAndDrivers(this IServiceCollection services, IConfiguration configuration)
        {
            return services   
                .AddFrameworksAndDriversWeb(configuration)
                .AddInterfaceAdapters(configuration);
        }

        public static IApplicationBuilder UseFrameworksAndDrivers(this IApplicationBuilder app, 
            IWebHostEnvironment env, IConfiguration configuration)
        {
            return app
                .UseFrameworksAndDriversWeb(env, configuration)
                .UseInterfaceAdapters(env, configuration);
        }
    }
}
