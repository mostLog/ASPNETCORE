using L.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace L.Application.Services
{
    public interface ISpiderService
    {
        /// <summary>
        /// 创建或者更新爬虫
        /// </summary>
        /// <returns></returns>
        Task AddOrUpdateSpiderTask(AddOrEditTaskInputDto input);

    }
}
