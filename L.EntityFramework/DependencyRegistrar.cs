using Autofac;
using Castle.DynamicProxy;
using L.EntityFramework.Uow;
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
            builder.Register<IDbContext>(c => new LDbContext(
                    new DbContextOptionsBuilder()
                    .UseSqlServer("data source=.;initial catalog=CoreTest;Integrated Security=true")
                    .Options
                ))
                .SingleInstance();
            //注册拦截器
            builder.RegisterType<UnitOfWorkInterceptor>().Named<IInterceptor>("UnitOfWork").InstancePerLifetimeScope();
            //注册工作单元
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
        public int Order { get; set; } = 1;
    }
}
