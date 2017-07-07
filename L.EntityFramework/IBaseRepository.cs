using MI.Core;
using MI.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntityById(int id);
        /// <summary>
        /// 简单添加数据
        /// </summary>
        /// <param name="t"></param>
        void Insert(T t);
        /// <summary>
        /// 添加数据并返回id
        /// </summary>
        /// <returns></returns>
        //int InsertAndGetId(T t);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        void Update(T t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        void Delete(T t);


        void Delete(IEnumerable<T> query);

    }
}
