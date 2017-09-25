using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework;
using L.LCore.Http;
using L.LCore.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L.Application.Services
{
    public class ProxyService : IProxyService
    {
        private readonly IBaseRepository<Proxy> _proxyRepository;

        public ProxyService(IBaseRepository<Proxy> proxyRepository)
        {
            _proxyRepository = proxyRepository;
        }

        #region 增删改查

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedListResult<ProxyListOutput>> GetProxyPagedList(ProxySearchInput input)
        {
            var query = _proxyRepository.Table.AsNoTracking();
            var tmpList = query
                .WhereIf(input.Port != 0, m => m.Port == input.Port);
            var list = await tmpList
                .PageBy(input.PageIndex, input.PageSize)
                .ToListAsync();
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Proxy, ProxyListOutput>());
            //总数
            int count = await tmpList.CountAsync();
            return new PagedListResult<ProxyListOutput>()
            {
                Data = AutoMapper.Mapper.Map<IList<ProxyListOutput>>(list),
                Count = count,
                Code = 0
            };
        }

        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <returns></returns>
        public async Task AddOrUpdateProxy(ProxyAddOrEditInput input)
        {
            //是否存在有效值
            if (input.Proxy.Id.HasValue)
            {
                await UpdateProxy(input);
            }
            else
            {
                await CreateProxy(input);
            }
        }

        /// <summary>
        /// 创建爬虫任务
        /// </summary>
        /// <returns></returns>
        private async Task CreateProxy(ProxyAddOrEditInput input)
        {
            Proxy proxy = input.Proxy.MapTo<Proxy>();
            await _proxyRepository.InsertAsync(proxy);
        }

        /// <summary>
        /// 更新爬虫任务
        /// </summary>
        /// <returns></returns>
        private async Task UpdateProxy(ProxyAddOrEditInput input)
        {
            var spiderTask = await _proxyRepository.GetEntityByIdAsync(input.Proxy.Id.Value);
            if (spiderTask != null)
            {
                var newSpiderTask = input.Proxy.MapTo<Proxy>();

                await _proxyRepository.UpdateAsync(spiderTask);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public async Task DeleteProxy(BaseDto input)
        {
            if (input.Id.HasValue)
            {
                await _proxyRepository.DeleteAsync(input.Id.Value);
            }
        }

        /// <summary>
        /// 更具id获取实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ProxyEditDto> GetProxyById(BaseDto input)
        {
            var task = await _proxyRepository.GetEntityByIdAsync(input.Id.Value);
            return task.MapTo<ProxyEditDto>();
        }

        #endregion 增删改查

        public async void PingProxyIsAvailable()
        {
            
            var list=await _proxyRepository.Table
                .Where(c=>c.LastVerifyDateTime==null)
                .Take(10)
                .ToListAsync();
            //并行验证代理是否可用
            Parallel.ForEach(list,proxy=> {
                ProxyHelper.PingProxy(proxy.IP,proxy.Port);
            });
            //获取总记录数
            int count =await _proxyRepository.Table.CountAsync();

        }
    }
}