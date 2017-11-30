using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework;
using L.LCore.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L.Application.Services
{
    public class ChromeService:IChromeService
    {

        private readonly IBaseRepository<PushText> _pushTextRepository;
        public ChromeService(IBaseRepository<PushText> pushTextRepository)
        {
            _pushTextRepository = pushTextRepository;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedListResult<PushTextListOutput>> GetPushTextPagedList(PushTextSearchInput input)
        {
            var tmplist = _pushTextRepository.Table
                .AsNoTracking();

            try
            {
                var list = await tmplist
                       .PageBy(input.PageIndex, input.PageSize)
                       .ToListAsync();
                AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<PushText, PushTextListOutput>());

                //总数
                int count = list.Count();

                return new PagedListResult<PushTextListOutput>()
                {
                    Data = AutoMapper.Mapper.Map<IList<PushTextListOutput>>(list),
                    Count = count,
                    Code = 0
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <returns></returns>
        public async Task AddOrUpdatePushText(PushTextAddOrEditInput input)
        {
            //是否存在有效值
            if (input.PushText.Id.HasValue)
            {
                await UpdatePushText(input);
            }
            else
            {
                await CreatePushText(input);
            }
        }

        /// <summary>
        /// 添加推送信息
        /// </summary>
        /// <returns></returns>
        private async Task CreatePushText(PushTextAddOrEditInput input)
        {
            PushText pushText = input.PushText.MapTo<PushText>();
            pushText.PushDateTime = DateTime.Now;
            await _pushTextRepository.InsertAsync(pushText);
        }

        /// <summary>
        /// 更新推送信息
        /// </summary>
        /// <returns></returns>
        private async Task UpdatePushText(PushTextAddOrEditInput input)
        {
            var spiderTask = await _pushTextRepository.GetEntityByIdAsync(input.PushText.Id.Value);
            if (spiderTask != null)
            {
                var newSpiderTask = input.PushText.MapTo<PushText>();

                await _pushTextRepository.UpdateAsync(spiderTask);
            }
        }
    }
}
