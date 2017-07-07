using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace L.LCore
{
    /// <summary>
    /// 项目启动核心类
    /// </summary>
    public class LCoreEngine : ILCoreEngine
    {
        private IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            return ServiceProvider;
        }
        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>

        protected virtual IServiceProvider RegisterDependencies(IServiceCollection services)
        {

            var containerBuilder = new ContainerBuilder();
            
            containerBuilder.RegisterInstance(this).As<ILCoreEngine>().SingleInstance();

            //register type finder
            //containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            //find dependency registrars provided by other assemblies
            //var dependencyRegistrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();

            //create and sort instances of dependency registrars
            //var instances = dependencyRegistrars
            //    //.Where(dependencyRegistrar => PluginManager.FindPlugin(dependencyRegistrar).Return(plugin => plugin.Installed, true)) //ignore not installed plugins
            //    .Select(dependencyRegistrar => (IDependencyRegistrar)Activator.CreateInstance(dependencyRegistrar))
            //    .OrderBy(dependencyRegistrar => dependencyRegistrar.Order);

            //register all provided dependencies
            //foreach (var dependencyRegistrar in instances)
            //    dependencyRegistrar.Register(containerBuilder, typeFinder, nopConfiguration);

            containerBuilder.Populate(services);

            //create service provider
            ServiceProvider = new AutofacServiceProvider(containerBuilder.Build());
            return ServiceProvider;
        }
    }
}
