using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace L.EntityFramework
{
    public interface IDbContext
    {

        DbSet<T> SetEntity<T>() where T:class;

        int SaveChanges();

        EntityEntry<T> GetEntry<T>(T t) where T : class;
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        IEnumerable<T> SqlQuery<T>(string sql,params object[] parameters);
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, bool isTransaction = false, params object[] parameters);
    }
}
