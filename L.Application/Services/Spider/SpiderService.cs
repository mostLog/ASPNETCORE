using L.Application.Dto;
using L.Domain.Entities;
using L.EntityFramework;
using L.LCore.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L.Application.Services
{
    public class SpiderService : AppService, ISpiderService
    {
        /// <summary>
        /// 爬虫任务仓储
        /// </summary>
        private readonly IBaseRepository<SpiderTask> _spiderRepository;

        private readonly INoticeService _novelService;
        private readonly ILogger _logger;

        public SpiderService(
            IBaseRepository<SpiderTask> spiderRepository,
            INoticeService noticeService,
            ILogger<SpiderService> logger
            )
        {
            _spiderRepository = spiderRepository;
            _novelService = noticeService;
            _logger = logger;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedListResult<TaskListOutput>> GetSpiderTaskPagedList(TaskSearchInput input)
        {
            _logger.LogError(1000, "fff");
            var tmplist = _spiderRepository.Table
                .AsNoTracking()
                .WhereIf(!input.Name.IsNullOrEmpty(), p => p.Name.Contains(input.Name))
                .OrderByDescending(p => p.CreateDateTime);

            try
            {
                var list = await tmplist
                       .PageBy(input.PageIndex, input.PageSize)
                       .ToListAsync();
                AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<SpiderTask, TaskListOutput>());

                //总数
                int count = list.Count();

                return new PagedListResult<TaskListOutput>()
                {
                    Data = AutoMapper.Mapper.Map<IList<TaskListOutput>>(list),
                    Count = count,
                    Code = 0
                };
            }
            catch (System.Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <returns></returns>
        public void AddOrUpdateSpiderTask(TaskAddOrEditInput input)
        {
            //是否存在有效值
            if (input.SpiderTask.Id.HasValue)
            {
                UpdateSpiderTask(input);
            }
            else
            {
                CreateSpiderTask(input);
            }
        }

        /// <summary>
        /// 创建爬虫任务
        /// </summary>
        /// <returns></returns>
        private async void CreateSpiderTask(TaskAddOrEditInput input)
        {
            SpiderTask task = input.SpiderTask.MapTo<SpiderTask>();
            await _spiderRepository.InsertAsync(task);
        }

        /// <summary>
        /// 更新爬虫任务
        /// </summary>
        /// <returns></returns>
        private async void UpdateSpiderTask(TaskAddOrEditInput input)
        {
            var spiderTask = await _spiderRepository.GetEntityByIdAsync(input.SpiderTask.Id.Value);
            if (spiderTask != null)
            {
                var newSpiderTask = input.SpiderTask.MapTo<SpiderTask>();
                spiderTask.Name = newSpiderTask.Name;
                spiderTask.CrawlerType = newSpiderTask.CrawlerType;
                spiderTask.Description = newSpiderTask.Description;
                spiderTask.Urls = newSpiderTask.Urls;
                spiderTask.RecurrentCron = newSpiderTask.RecurrentCron;
                await _spiderRepository.UpdateAsync(spiderTask);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public async Task DeleteSpiderTask(BaseDto input)
        {
            if (input.Id.HasValue)
            {
                await _spiderRepository.DeleteAsync(input.Id.Value);
            }
        }

        /// <summary>
        /// 更具id获取实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<TaskEditDto> GetTaskById(BaseDto input)
        {
            var task = await _spiderRepository.GetEntityByIdAsync(input.Id.Value);
            return task.MapTo<TaskEditDto>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="spiderId"></param>
        /// <param name="runOrStop"></param>
        public void RunOrStopRecurrentTask(string spiderId, bool runOrStop)
        {
            var spiderTask = _spiderRepository.Table.FirstOrDefault(m => m.SpiderId == spiderId);
            if (spiderTask != null)
            {
                spiderTask.IsRecurrent = runOrStop;
            }
            _spiderRepository.UpdateAsync(spiderTask);
        }
    }
}