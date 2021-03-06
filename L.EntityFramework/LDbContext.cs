﻿using L.EntityFramework.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System.Threading.Tasks;

namespace L.EntityFramework
{
    /// <summary>
    /// 上下文对象
    /// </summary>
    public class LDbContext : DbContext, IDbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public LDbContext(DbContextOptions options) : base(options)
        {
        }

        public EntityEntry<T> GetEntry<T>(T t) where T : class
        {
            return base.Entry<T>(t);
        }

        public DbSet<T> SetEntity<T>() where T : class
        {
            return base.Set<T>();
        }

        /// <summary>
        /// 执行sql查询语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int SqlQuery<T>(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// 创建事务
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction CreateTransaction()
        {
            return Database.BeginTransaction();
        }
        /// <summary>
        /// 异步创建事务
        /// </summary>
        /// <returns></returns>
        public async Task<IDbContextTransaction> CreateTransactionAsync()
        {
            return await Database.BeginTransactionAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }

    /// <summary>
    /// 用于数据迁移
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<LDbContext>
    {
        public LDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LDbContext>();

            optionsBuilder.UseSqlServer("data source=.;initial catalog=CoreTest;uid=sa;pwd=sa;Integrated Security=true");
            return new LDbContext(optionsBuilder.Options);
        }
    }
}