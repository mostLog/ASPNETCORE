using L.Dapper.AspNetCore.Logger;
using L.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L.Dapper.AspNetCore.DbManager
{
    public class DbManagerDataProvider : IDbManagerDataProvider
    {
        private readonly DbFactory _dbFactory;
        private readonly ILoggerDataProvider _logger;

        public DbManagerDataProvider(DbFactory dbFactory, ILoggerDataProvider logger)
        {
            _dbFactory = dbFactory;
            _logger = logger;
        }

        /// <summary>
        /// 添加数据备份
        /// </summary>
        /// <param name="datetime">备份时间</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="sPath">文件路径</param>
        public void AddDataBackup(DateTime? datetime, string dbName, string sPath)
        {
            try
            {
                if (datetime.HasValue)
                {
                    string dTime = datetime.Value.ToString("yyyy-MM-dd");
                    sPath = Path.Combine(sPath, dbName + dTime + ".bak");
                    string strSql = "backup  database " + dbName + " to disk='" + sPath + "'";
                    using (var db = _dbFactory.GetDbInstance())
                    {
                        db.ExcuteSql(strSql, new { });
                    }
                }
            }
            catch (Exception e)
            {
                _logger.WriteLog(new Log()
                {
                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    LogLevel = (int)LCore.Logger.LogLevel.Error,
                    ClassName = this.GetType().FullName,
                    ActionName = e.TargetSite.Name,
                    Msg = e.Message + "-----" + e.StackTrace
                });
            }
        }

        /// <summary>
        /// 获取所有表数据
        /// </summary>
        /// <returns></returns>
        public IList<GetDbInput> GetTableData()
        {
            try
            {
                string strSql = "create table tablesize (name varchar(50),rows int,reserved varchar(50),data varchar(50),index_size varchar(50),unused varchar(50))insert into tablesize(name, rows, reserved,data, index_size, unused) exec sp_msforeachTable @Command1 = \"sp_spaceused '?'\"";
                string sSql = "select name,rows,replace(reserved,'KB','') as reserved from tablesize";
                string sDropSql = "drop table tablesize";
                using (var db = _dbFactory.GetDbInstance())
                {
                    db.ExcuteSql(strSql, new { });
                    var list = db.QueryList<GetDbInput>(sSql, null).ToList();
                    db.ExcuteSql(sDropSql, new { });
                    return list;
                }
            }
            catch (Exception e)
            {
                _logger.WriteLog(new Log()
                {
                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    LogLevel = (int)LCore.Logger.LogLevel.Error,
                    ClassName = this.GetType().FullName,
                    ActionName = e.TargetSite.Name,
                    Msg = e.Message + "-----" + e.StackTrace
                });
                return new List<GetDbInput>();
            }
        }
    }

    /// <summary>
    /// 获取数据库表名和记录数
    /// </summary>
    public class GetDbInput
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 记录数
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// 表空间
        /// </summary>
        public long Reserved { get; set; }
    }
}