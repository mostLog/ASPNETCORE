﻿using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace L.Dapper.AspNetCore
{
    public class SqlTool
    {
        #region Sql Server
        private IDbConnection OpenSqlServerConnection(string conString)
        {
            IDbConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }
        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public bool TableIsExist(string tableName)
        {
            using (IDbConnection con = OpenSqlServerConnection(""))
            {
                int result = con.Query<int>("select count(1) from sys.objects where name = '@tableName'",
                   new
                   {
                       tableName = tableName
                   }).FirstOrDefault();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 判断数据库是否存在
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        public bool DbIsExist(string dbName)
        {
            using (IDbConnection con = OpenSqlServerConnection(""))
            {
                int result = con.Query<int>("select count(1) From master.dbo.sysdatabases where name='@dbName'",
                    new
                    {
                        dbName = dbName
                    }).FirstOrDefault();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
        } 
        #endregion
    }
}
