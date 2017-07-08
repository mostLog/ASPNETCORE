using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace L.LCore.Infrastructure.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var engine = LCoreEngineManager.CreateEngine();

            var serviceProvider = engine.ConfigureServices(services,configuration);

            return serviceProvider;
        }

    }
}
