using L.Application.Services.Dto;
using L.EntityFramework;
using L.LCore.Domain.Entities;
using L.LCore.Infrastructure.Extension;
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
        /// 添加或者更新
        /// </summary>
        /// <returns></returns>
        public async Task AddOrUpdateSpiderTask(AddOrEditTaskInputDto input)
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
        private async Task CreateSpiderTask(AddOrEditTaskInputDto input)
        {
            SpiderTask task=input.SpiderTask.MapTo<SpiderTask>();
            await _spiderRepository.InsertAsync(task);
        }
        /// <summary>
        /// 更新爬虫任务
        /// </summary>
        /// <returns></returns>
        private async Task UpdateSpiderTask(AddOrEditTaskInputDto input)
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

    }
}
