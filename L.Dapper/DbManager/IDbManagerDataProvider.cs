using System;
using System.Collections.Generic;

namespace L.Dapper.AspNetCore.DbManager
{
    public interface IDbManagerDataProvider
    {
        /// <summary>
        /// 添加数据备份
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        void AddDataBackup(DateTime? datetime, string dbName, string sPath);

        /// <summary>
        /// 获取数据库表数据
        /// </summary>
        /// <returns></returns>
        IList<GetDbInput> GetTableData();
    }
}