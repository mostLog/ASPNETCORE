using L.Application.Dto;
using L.EntityFramework.Uow;
using System.Threading.Tasks;

namespace L.Application.Services
{
    [UnitOfWork]
    public interface IProxyService
    {
        [NoUnitOfWork]
        Task<PagedListResult<ProxyListOutput>> GetProxyPagedList(ProxySearchInput input);

        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddOrUpdateProxy(ProxyAddOrEditInput input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteProxy(BaseDto input);

        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NoUnitOfWork]
        Task<ProxyEditDto> GetProxyById(BaseDto input);
    }
}