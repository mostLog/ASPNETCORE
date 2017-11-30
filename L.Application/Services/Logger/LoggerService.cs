using L.Application.Dto;
using L.Dapper.AspNetCore.Logger;
using L.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace L.Application.Services
{
    /// <summary>
    /// 日志记录服务
    /// </summary>
    public class LoggerService : ILoggerService
    {
        /// <summary>
        /// 日志服务
        /// </summary>
        private readonly ILoggerDataProvider _loggerDataProvider;

        /// <summary>
        ///
        /// </summary>
        public LoggerService(ILoggerDataProvider loggerDataProvider)
        {
            _loggerDataProvider = loggerDataProvider;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <returns></returns>
        public void WriteLog(Log log)
        {
            //加入队列
            //_hangFireService.AddEnqueue<ILoggerDataProvider>(c=>c.WriteLog(log));
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public PagedListResult<LogListOutput> GetLogPagedList(LogSearchInput input)
        {
            int count = 0;
            var list = _loggerDataProvider.GetLogs(input.DateTime, input.LogLevel, input.PageIndex, input.PageSize, ref count);
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Log, LogListOutput>());
            return new PagedListResult<LogListOutput>()
            {
                Data = AutoMapper.Mapper.Map<IList<LogListOutput>>(list),
                Count = count,
                Code = 0
            };
        }
    }
}