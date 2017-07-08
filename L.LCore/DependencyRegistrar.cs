using Autofac;
using L.LCore.Infrastructure.Dependeny;
using L.LCore.Infrastructure.Reflection;
using System.Reflection;

namespace L.LCore
{
    /// <summary>
    /// Core层依赖注入配置
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            
           
        }
        public int Order { get; set; } = 1;
    }
}
