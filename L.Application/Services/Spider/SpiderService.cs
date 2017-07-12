using L.EntityFramework;
using L.LCore.Domain.Entities;
using System.Threading.Tasks;

namespace L.Application.Services
{
    public class SpiderService : ISpiderService
    {
        //
        private readonly IBaseRepository<SpiderTask> _spiderRepository;


        public SpiderService(IBaseRepository<SpiderTask> spiderRepository)
        {
            _spiderRepository = spiderRepository;
        }
        /// <summary>
        /// 创建爬虫任务
        /// </summary>
        /// <returns></returns>
        public async Task CreateSpiderTask()
        {
            //_spiderRepository.InsertAsync();
        }
        /// <summary>
        /// 更新爬虫任务
        /// </summary>
        /// <returns></returns>
        public async Task UpdateSpiderTask()
        {

        }

    }
}
