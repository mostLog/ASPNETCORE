using Autofac;
using L.LCore.Infrastructure.Dependeny;
using Microsoft.EntityFrameworkCore;

namespace L.EntityFramework
{
    /// <summary>
    /// 数据库访问层依赖注入配置
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            //注册仓储
            builder.RegisterGeneric(typeof(EFBaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
            //注册数据库上下文对象
            //builder.RegisterType<LDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new LDbContext(
                    new DbContextOptionsBuilder()
                    .UseSqlServer("data source=.;initial catalog=CoreTest;Integrated Security=true")
                    .Options
                ))
                .InstancePerLifetimeScope();
        }
        public int Order { get; set; } = 1;
    }
}
