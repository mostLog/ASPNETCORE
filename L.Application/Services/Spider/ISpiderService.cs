using L.Application.Dto;
using L.Application.Services.Dto;
using L.EntityFramework.Uow;
using System.Threading.Tasks;

namespace L.Application.Services
{
    [UnitOfWork]
    public interface ISpiderService
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

    }
}
