using Autofac;
using L.HangFire.AspNetCore.Services;
using L.LCore.Infrastructure.Dependeny;

namespace L.HangFire.AspNetCore
{
    /// <summary>
    /// Application层依赖注入配置
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            //注册服务层
            builder.RegisterType<HangFireService>()
                .As<IHangFireService>()
                .InstancePerLifetimeScope();
        }
        public int Order { get; set; } =2;
    }
}
