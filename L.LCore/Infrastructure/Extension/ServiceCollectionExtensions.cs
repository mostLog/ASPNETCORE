using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace L.LCore.Infrastructure.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var engine = LCoreEngineManager.CreateEngine();

            var serviceProvider = engine.ConfigureServices(services, configuration);

            return serviceProvider;
        }

        public static void ConfigureRequestMiddleware(this IApplicationBuilder app)
        {
            var engine = LCoreEngineManager.CurrentEngine();

            engine.ConfigureRequestMiddleware(app);
        }
    }
}