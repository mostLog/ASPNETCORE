﻿using L.Application.Dto;
using L.Application.Services.Dto;
using L.EntityFramework;
using L.LCore.Domain.Entities;
using L.LCore.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace L.Application.Services
{
    public class SpiderService : ISpiderService
    {
        //爬虫任务仓储
        private readonly IBaseRepository<SpiderTask> _spiderRepository;

        public SpiderService(IBaseRepository<SpiderTask> spiderRepository)
        {
            _spiderRepository = spiderRepository;
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PageListDto<SpiderTaskListOutput>> GetSpiderTaskPagedList(SearchInput input)
        {
            var tmplist= _spiderRepository.Table
                .AsNoTracking()
                .WhereIf(!input.Name.IsNullOrEmpty(), p => p.Name.Contains(input.Name))
                .OrderByDescending(p => p.CreateDateTime);

            var list = (await tmplist
                .PageBy(input.PageIndex, input.PageSize)
                .ToListAsync()).MapTo<IList<SpiderTaskListOutput>>();
            //总数
            int count = list.Count();

            return new PageListDto<SpiderTaskListOutput>(list, count);
        }
        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <returns></returns>
        public async Task AddOrUpdateSpiderTask(AddOrEditTaskInput input)
        {
            //是否存在有效值
            if (input.SpiderTask.Id.HasValue)
            {
                await UpdateSpiderTask(input);
            }else
            {
                await CreateSpiderTask(input);
            }
        }
        /// <summary>
        /// 创建爬虫任务
        /// </summary>
        /// <returns></returns>
        private async Task CreateSpiderTask(AddOrEditTaskInput input)
        {
            SpiderTask task=input.SpiderTask.MapTo<SpiderTask>();
            await _spiderRepository.InsertAsync(task);
        }
        /// <summary>
        /// 更新爬虫任务
        /// </summary>
        /// <returns></returns>
        private async Task UpdateSpiderTask(AddOrEditTaskInput input)
        {
            SpiderTask task = input.SpiderTask.MapTo<SpiderTask>();
            await _spiderRepository.UpdateAsync(task);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public async Task DeleteSpiderTask()
        {

        }
        /// <summary>
        /// 更具id获取实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<SpiderTaskEditDto> GetTaskById(BaseDto input)
        {
            var task=await _spiderRepository.GetEntityByIdAsync(input.Id.Value);
            return task.MapTo<SpiderTaskEditDto>();
        }
    }
}
