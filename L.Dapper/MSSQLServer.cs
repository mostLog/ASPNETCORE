using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace L.Dapper.AspNetCore
{
    /// <summary>
    /// sql server
    /// </summary>
    public static class MSSQLServer
    {
        /// <summary>
        ///
        /// </summary>
        public static IDbConnection GetDbInstance(string connections)
        {
            IDbConnection db = new SqlConnection(connections);
            db.Open();
            return db;
        }

        /// <summary>
        /// 查询
        /// </summary>
        public static IEnumerable<T> QueryList<T>(this IDbConnection db, string sql, object param)
        {
            return db.Query<T>(sql, param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QueryScalar<T>(this IDbConnection db,string sql,object param=null)
        {
            if (param==null)
            {
                return db.ExecuteScalar<T>(sql);
            }
            else
            {
                return db.ExecuteScalar<T>(sql, param);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        public static int Insert<T>(this IDbConnection db, string sql, T t) where T : class
        {
            return db.Execute(sql, t);
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int ExcuteSql<T>(this IDbConnection db,string sql,T p)
        {
            return db.Execute(sql,p);
        }
    }
}