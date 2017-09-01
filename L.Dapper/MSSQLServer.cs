using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dapper;

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
        public static IDbConnection GetDbInstance()
        {
            IDbConnection db = new SqlConnection();
            db.Open();
            return db;
        }
        /// <summary>
        /// 查询
        /// </summary>
        public static IEnumerable<T> Query<T>(this IDbConnection db,string sql,object param) 
        {
            return db.Query<T>(sql,param);
        }
        /// <summary>
        /// 添加
        /// </summary>
        public static int Insert<T>(this IDbConnection db,string sql,T t) where T:class
        {
             return db.Execute(sql,t);
        }
        
    }
}
