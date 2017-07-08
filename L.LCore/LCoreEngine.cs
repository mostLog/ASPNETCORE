using Autofac;
using Autofac.Extensions.DependencyInjection;
using L.LCore.Infrastructure.Configuration;
using L.LCore.Infrastructure.Dependeny;
using L.LCore.Infrastructure.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace L.LCore
{
    /// <summary>
    /// 项目启动核心类
    /// </summary>
    public class LCoreEngine : ILCoreEngine
    {
        private IServiceProvider ServiceProvider { get; set; }

        public void Initial(IServiceCollection services)
        {
            
        }

        protected IServiceProvider GetServiceProvider()
        {
            var accessor = ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context != null ? context.RequestServices : ServiceProvider;
        }
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            var typeFinder = new AssemblyTypeFinder();

            //
            //var config = GetServiceProvider().GetRequiredService<ILConfig>();

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
                register.Register(containerBuilder);
            }

            containerBuilder.Populate(services);

            ServiceProvider = new AutofacServiceProvider(containerBuilder.Build());

            return ServiceProvider;
        }


    }
}
