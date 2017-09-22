using L.Application.Dto;
using L.Dapper.AspNetCore.DbManager;
using System;
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

        public DbManagerService(IDbManagerDataProvider dbManagerDataProvider)
        {
            _dbManagerDataProvider = dbManagerDataProvider;
        }

        /// <summary>
        /// 添加数据备份
        /// </summary>
        /// <param name="dt">备份日期</param>
        public void AddDataBackup(DateTime? dt)
        {
            if (dt != null)
            {
                string sPath = Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFiles");
                _dbManagerDataProvider.AddDataBackup(dt, sPath);
                List<FileInfoList> lstFileInfo = new List<FileInfoList>();
                DirectoryInfo dicInfo = new DirectoryInfo(sPath);
                //返回当前目录搜索匹配的文件列表
                foreach (FileInfo fileInfo in dicInfo.GetFiles("*.bak"))
                {
                    FileInfoList fileInfoList = new FileInfoList();
                    fileInfoList.sFileName = fileInfo.Name.ToString();
                    fileInfoList.sFileDirectory = fileInfo.FullName.ToString();
                    lstFileInfo.Add(fileInfoList);
                }
                //判断文件信息是否大于31
                if (lstFileInfo.Count > 31)
                {
                    string strRes = lstFileInfo[0].sFileDirectory;
                    if (File.Exists(strRes))
                    {
                        File.Delete(strRes);
                    }
                }
            }
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <returns></returns>
        public PagedListResult<DbManagerListOutput> GetTableData()
        {
            var list = _dbManagerDataProvider.GetTableData().Where(p => p.Name != "tablesize").ToList();
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

    /// <summary>
    /// 文件信息集合
    /// </summary>
    public class FileInfoList
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string sFileName { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string sFileDirectory { get; set; }
    }
}