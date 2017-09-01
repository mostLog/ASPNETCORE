using Autofac;
using L.Application;
using L.Application.Services;
using L.LCore.Infrastructure.Dependeny;
using L.SpiderCore.Crawler;
using System.Linq;
using System.Reflection;

namespace L.SpiderCore
{
    /// <summary>
    /// SpiderCore层依赖注入配置
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            //注册爬虫
            var baseType = typeof(ISpiderCrawler);
            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                .Where(b => b.GetInterfaces()
                .Any(c => c == baseType && b != baseType))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<SpiderManager>();
        }
        public int Order { get; set; } =6;
    }
}
