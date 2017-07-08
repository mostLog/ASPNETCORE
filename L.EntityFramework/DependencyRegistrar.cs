using Autofac;
using L.LCore.Infrastructure.Configuration;
using L.LCore.Infrastructure.Dependeny;
using L.LCore.Infrastructure.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace L.EntityFramework
{
    /// <summary>
    /// 数据库访问层依赖注入配置
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ILConfig config)
        {
            //注册仓储
            builder.RegisterGeneric(typeof(EFBaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
            //注册数据库上下文对象
            builder.Register(c => (IDbContext)Activator.CreateInstance(typeof(LDbContext),new object[] {new DbContextOptionsBuilder().UseSqlServer(config.SqlServerConnection)})).InstancePerLifetimeScope();
        }
        public int Order { get; set; } = 1;
    }
}
