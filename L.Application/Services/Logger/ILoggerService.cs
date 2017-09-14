using L.Application.Dto;
using L.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace L.Application.Services
{
    /// <summary>
    /// 日志记录服务接口
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <returns></returns>
        void WriteLog(Log log);
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagedListResult<LogListOutput> GetLogPagedList(LogSearchInput input);


    }
}
