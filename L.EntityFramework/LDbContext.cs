using L.LCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using L.EntityFramework.Extension;
using System.Reflection;

namespace L.EntityFramework
{
    /// <summary>
    /// 上下文对象
    /// </summary>
    public class LDbContext : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public LDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Notice> Notices { get; set; }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
    

    

    
}

