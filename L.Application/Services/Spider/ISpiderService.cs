using L.Application.Dto;
using L.EntityFramework.Uow;
using System.Threading.Tasks;

namespace L.Application.Services
{
    [UnitOfWork]
    public interface ISpiderService : IAppService
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NoUnitOfWork]
        Task<PagedListResult<TaskListOutput>> GetSpiderTaskPagedList(TaskSearchInput input);

        /// <summary>
        /// 创建或者更新爬虫
        /// </summary>
        /// <returns></returns>
        Task AddOrUpdateSpiderTask(TaskAddOrEditInput input);

        /// <summary>
        /// 更具id获取实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NoUnitOfWork]
        Task<TaskEditDto> GetTaskById(BaseDto input);

        /// <summary>
        /// 更具id删除实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteSpiderTask(BaseDto input);

        /// <summary>
        /// 是否开启定时任务
        /// </summary>
        /// <param name="spiderId"></param>
        /// <param name="runOrStop"></param>
        /// <returns></returns>
        void RunOrStopRecurrentTask(string spiderId, bool runOrStop);
    }
}