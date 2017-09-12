using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace L.EntityFramework
{
    public interface IDbContext
    {
        DbSet<T> SetEntity<T>() where T : class;

        int SaveChanges();

        EntityEntry<T> GetEntry<T>(T t) where T : class;

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        int SqlQuery<T>(string sql, params object[] parameters);

        IDbContextTransaction CreateTransaction();
    }
}