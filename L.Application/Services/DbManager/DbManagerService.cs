using L.Application.Dto;
using L.Dapper.AspNetCore.DbManager;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L.Application.Services
{
    public class DbManagerService : IDbManagerService
    {
        /// <summary>
        /// 数据服务
        /// </summary>
        private readonly IDbManagerDataProvider _dbManagerDataProvider;

        private readonly ILoggerService _loggerService;

        public DbManagerService(
            IDbManagerDataProvider dbManagerDataProvider,
            ILoggerService loggerService)
        {
            _dbManagerDataProvider = dbManagerDataProvider;
            _loggerService = loggerService;
        }

        /// <summary>
        /// 添加数据备份
        /// </summary>
        /// <param name="dt">备份日期</param>
        public void AddDataBackup(DbBackInput input)
        {
            if (input.DateTime.HasValue)
            {
                //获取数据库备份文件路径
                string sPath = Path.Combine(Directory.GetCurrentDirectory(), @"DbBack");
                //判断文件路径是否存在   不存在就创建目录
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                _dbManagerDataProvider.AddDataBackup(input.DateTime, input.DbName, sPath);

                IList<FileInfo> lstFileInfo = new List<FileInfo>();
                DirectoryInfo dicInfo = new DirectoryInfo(sPath);
                //返回当前目录搜索匹配的文件列表
                foreach (FileInfo fileInfo in dicInfo.GetFiles("*.bak"))
                {
                    lstFileInfo.Add(fileInfo);
                }
                //取前10个文件删除多余文件
                lstFileInfo = lstFileInfo.OrderByDescending(c => c.CreationTime).Skip(10).ToList();
                foreach (var file in lstFileInfo)
                {
                    File.Delete(file.FullName);
                }
            }
            else
            {
            }
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <returns></returns>
        public PagedListResult<DbManagerListOutput> GetTableData()
        {
            var list = _dbManagerDataProvider.GetTableData()
                .Where(p => p.Name != "tablesize")
                .ToList();
            //添加合计数据
            list.Add(new GetDbInput()
            {
                Name = "合计",
                Rows = list.Sum(c => c.Rows),
                Reserved = list.Sum(c => c.Reserved)
            });
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<GetDbInput, DbManagerListOutput>());
            //总数
            int count = list.Count;
            return new PagedListResult<DbManagerListOutput>()
            {
                Data = AutoMapper.Mapper.Map<IList<DbManagerListOutput>>(list),
                Count = count,
                Code = 0
            };
        }
    }
}