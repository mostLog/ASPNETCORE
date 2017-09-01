using Autofac;
using Autofac.Extensions.DependencyInjection;
using L.LCore.Infrastructure.Dependeny;
using L.LCore.Infrastructure.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

        public void Initial(IServiceCollection services)
        {
            
        }
        /// <summary>
        /// 通过IHttpContextAccessor 提供服务
        /// </summary>
        /// <returns></returns>
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
        public IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var typeFinder = new AssemblyTypeFinder();

            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();


            //var config = GetServiceProvider().GetRequiredService<ILConfig>();


            //配置服务
            var startUps = typeFinder.FindTypesByInterface<IStartUp>();

            var instances = startUps.Select(r => (IStartUp)Activator.CreateInstance(r))
                .OrderBy(r => r.Order);

            foreach (var register in instances)
            {
                register.ConfigureServices(services);
            }

            RegisterDependencies(services, typeFinder);

            return ServiceProvider;
        }
        /// <summary>
        /// 配置请求中间件
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureRequestMiddleware(IApplicationBuilder app)
        {
            var typeFinder= (ITypeFinder)GetServiceProvider().GetRequiredService(typeof(ITypeFinder));

            var startUps=typeFinder.FindTypesByInterface<IStartUp>();

            var instances=startUps
                .Select(r => (IStartUp)Activator.CreateInstance(r))
                .OrderBy(r => r.Order);

            foreach (var register in instances)
            {
                register.Configure(app);
            }
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
            var container=containerBuilder.Build();
            ServiceProvider = new AutofacServiceProvider(container);
            //
            ContainerManager.SetContainer(container);
            return ServiceProvider;
        }


    }
}
