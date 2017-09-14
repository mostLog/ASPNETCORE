using L.Domain.Entities;
using L.LCore.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.Dapper.AspNetCore.Logger
{
    public interface ILoggerDataProvider
    {
        /// <summary>
        /// 写入日志信息
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        int WriteLog(Log log);
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IList<Log> GetLogs(DateTime? date,int logLevel,int pageIndex, int pageSize, ref int count);
    }
}
