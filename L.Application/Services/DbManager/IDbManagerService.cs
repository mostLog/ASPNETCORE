using L.Application.Dto;
using System;
using System.Collections.Generic;

namespace L.Application.Services
{
    public interface IDbManagerService
    {
        /// <summary>
        /// 添加数据备份
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        void AddDataBackup(DateTime? dt);

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <returns></returns>
        PagedListResult<DbManagerListOutput> GetTableData();
    }
}