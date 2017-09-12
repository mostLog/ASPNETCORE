using System.Linq;
using System.Threading.Tasks;

namespace L.EntityFramework
{
    /// <summary>
    /// 基类仓储接口
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntityById(int id);

        /// <summary>
        /// 异步根据id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetEntityByIdAsync(int id);

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="t"></param>
        T Insert(T t);

        /// <summary>
        /// 异步添加数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<T> InsertAsync(T t);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        T Update(T t);

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <returns></returns>
        Task<T> UpdateAsync(T t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        T Delete(T t);

        /// <summary>
        /// 异步删除
        /// </summary>
        /// <returns></returns>
        Task<T> DeleteAsync(T t);

        /// <summary>
        /// 通过id删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> DeleteAsync(int id);
    }
}