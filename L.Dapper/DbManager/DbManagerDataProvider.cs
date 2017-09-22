using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace L.Dapper.AspNetCore.DbManager
{
    public class DbManagerDataProvider : IDbManagerDataProvider
    {
        private readonly DbFactory _dbFactory;

        public DbManagerDataProvider(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        /// <summary>
        /// 添加数据备份
        /// </summary>
        /// <param name="datetime">备份时间</param>
        /// <param name="sPath">文件路径</param>
        public void AddDataBackup(DateTime? datetime, string sPath)
        {
            //判断文件路径是否存在   不存在就创建目录
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);
            }
            string dTime = datetime.Value.ToString("yyyy-MM-dd");
            sPath = Path.Combine(sPath, "CoreTest" + dTime + ".bak");
            string strSql = "backup  database CoreTest to disk='" + sPath + "'";
            using (var db = _dbFactory.GetDbInstance())
            {
                db.ExcuteSql(strSql, new { });
            }
        }

        /// <summary>
        /// 获取所有表数据
        /// </summary>
        /// <returns></returns>
        public IList<GetDbInput> GetTableData()
        {
            string strSql = "create table tablesize (name varchar(50),rows int,reserved varchar(50),data varchar(50),index_size varchar(50),unused varchar(50))insert into tablesize(name, rows, reserved,data, index_size, unused) exec sp_msforeachTable @Command1 = \"sp_spaceused '?'\"";
            string sSql = "select name,rows,reserved from tablesize";
            string sDropSql = "drop table tablesize";
            using (var db = _dbFactory.GetDbInstance())
            {
                db.ExcuteSql(strSql, new { });
                var list = db.QueryList<GetDbInput>(sSql, null).ToList();
                db.ExcuteSql(sDropSql, new { });
                return list;
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
        public string Reserved { get; set; }
    }
}