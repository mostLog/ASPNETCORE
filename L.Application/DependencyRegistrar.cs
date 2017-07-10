using Autofac;
using L.LCore.Infrastructure.Configuration;
using L.LCore.Infrastructure.Dependeny;
using L.LCore.Infrastructure.Reflection;
using System.Reflection;
using Autofac.Extras.DynamicProxy;

namespace L.Application
{
    /// <summary>
    /// Application层依赖注入配置
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            //注册服务层
            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .EnableInterfaceInterceptors()
             .AsImplementedInterfaces();
        }
        public int Order { get; set; } =2;
    }
}
