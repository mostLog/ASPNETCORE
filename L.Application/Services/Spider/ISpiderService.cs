using L.Application.Dto;
using L.Application.Services.Dto;
using L.EntityFramework.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace L.Application.Services
{
    [UnitOfWork]
    public interface ISpiderService
    {
        /// <summary>
        /// 创建或者更新爬虫
        /// </summary>
        /// <returns></returns>
        Task AddOrUpdateSpiderTask(AddOrEditTaskInputDto input);
        /// <summary>
        /// 更具id获取实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NoUnitOfWork]
        Task<SpiderTaskEditDto> GetTaskById(BaseDto input);

    }
}
