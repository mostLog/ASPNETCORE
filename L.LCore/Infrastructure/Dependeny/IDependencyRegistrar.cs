using Autofac;
using L.LCore.Infrastructure.Configuration;
using L.LCore.Infrastructure.Reflection;

namespace L.LCore.Infrastructure.Dependeny
{
    /// <summary>
    /// 用于Autofac依赖注入接口
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 类型注册
        /// </summary>
        /// <param name="builder"></param>
        void Register(ContainerBuilder builder);
        /// <summary>
        /// 序号
        /// </summary>
        int Order { get; set; }
    }
}
