﻿using Autofac;
using L.Dapper.AspNetCore.DbManager;
using L.Dapper.AspNetCore.Logger;
using L.LCore.Infrastructure.Dependeny;

namespace L.Dapper.AspNetCore
{
    /// <summary>
    /// dapper层依赖注入配置
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            //初始化数据库配置
            builder.Register(c => new Dapper(new DapperConfig()
            {
                ConnectionString = "data source=.;initial catalog=CoreTest;uid=sa;pwd=sa;Integrated Security=true",
                DbType = DbType.MSSQLServer
            })).SingleInstance();

            builder.RegisterType<DbFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LoggerDataProvider>()
                .As<ILoggerDataProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DbManagerDataProvider>()
                .As<IDbManagerDataProvider>()
                .InstancePerLifetimeScope();
        }

        public int Order { get; set; } = 2;
    }
}