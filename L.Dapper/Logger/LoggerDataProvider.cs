using L.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Dapper.AspNetCore.Logger
{
    /// <summary>
    /// 数据提供对象
    /// </summary>
    public class LoggerDataProvider : ILoggerDataProvider
    {
        private readonly DbFactory _factory;

        public LoggerDataProvider(DbFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// 写入日志信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="level"></param>
        /// <param name="e"></param>
        public int WriteLog(Log log)
        {
            int result = 0;
            string sql = "insert into T_Log(DateTime,Msg,ClassName,ActionName,Duration,LogLevel) Values(@DateTime,@Msg,@ClassName,@ActionName,@Duration,@LogLevel)";
            using (var db = _factory.GetDbInstance())
            {
                result = db.ExcuteSql(sql, log);
            }
            return result;
        }
        /// <summary>
        /// 写入日志信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="level"></param>
        /// <param name="e"></param>
        public async Task<int> WriteLogAsync(Log log)
        {
            int result = 0;
            string sql = "insert into T_Log(DateTime,Msg,ClassName,ActionName,Duration,LogLevel) Values(@DateTime,@Msg,@ClassName,@ActionName,@Duration,@LogLevel)";
            using (var db = _factory.GetDbInstance())
            {
                result = await db.ExcuteSqlAsync(sql, log);

            }
            return result;
        }
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <returns></returns>
        public IList<Log> GetLogs(DateTime? date, int logLevel, int pageIndex, int pageSize, ref int count)
        {
            string strWhere = string.Empty;
            var whereValue = new GetLogInput();
            if (date.HasValue)
            {
                strWhere += " and DateTime between @sDateTime and @eDateTime";
                whereValue.SDateTime = date.Value;
                whereValue.EDateTime = date.Value.AddDays(1);
            }
            if (logLevel != 0)
            {
                strWhere += " and logLevel=@logLevel";
                whereValue.LogLevel = logLevel;
            }
            //分页sql
            string strSql = string.Format("select Id,ActionName,ClassName,DateTime,Duration,LogLevel,Msg from T_Log where 1=1 {0} order by DateTime desc offset " + (pageIndex - 1) * pageSize + " row fetch next " + pageSize + " rows only ", strWhere);
            string csql = "select count(id) from T_Log where 1=1 " + strWhere;
            using (var db = _factory.GetDbInstance())
            {
                var list = db.QueryList<Log>(strSql, whereValue).ToList();
                //获取数量
                count = db.QueryScalar<int>(csql, whereValue);
                return list;
            }
        }
    }

    public class GetLogInput
    {
        public int LogLevel { get; set; }
        public DateTime SDateTime { get; set; }
        public DateTime EDateTime { get; set; }
    }
}