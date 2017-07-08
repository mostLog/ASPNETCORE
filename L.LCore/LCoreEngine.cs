using Autofac;
using Autofac.Extensions.DependencyInjection;
using L.LCore.Infrastructure.Dependeny;
using L.LCore.Infrastructure.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
            var typeFinder = new AssemblyTypeFinder();

            RegisterDependencies(services, typeFinder);

            return ServiceProvider;
        }
        /// <summary>
        /// 通过Autofac注册依赖
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>

        protected virtual IServiceProvider RegisterDependencies(IServiceCollection services,ITypeFinder typeFinder)
        {

            var containerBuilder = new ContainerBuilder();
            
            containerBuilder.RegisterInstance(this).As<ILCoreEngine>().SingleInstance();

            containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            var registrars = typeFinder.FindTypesByInterface<IDependencyRegistrar>();

            var instances = registrars
                .Select(r => (IDependencyRegistrar)Activator.CreateInstance(r))
                .OrderBy(r => r.Order);

            foreach (var register in instances)
            {
                register.Register(containerBuilder, typeFinder);
            }

            containerBuilder.Populate(services);

            ServiceProvider = new AutofacServiceProvider(containerBuilder.Build());

            return ServiceProvider;
        }
    }
}
