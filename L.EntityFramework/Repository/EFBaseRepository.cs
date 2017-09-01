using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace L.EntityFramework
{
    /// <summary>
    /// EF仓储实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFBaseRepository<T>:IBaseRepository<T> where T: class
    {
        private readonly IDbContext _context;

        private DbSet<T> _entities;
        
        public EFBaseRepository(IDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntityById(int id)
        {
            return Entities.Find(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="t"></param>
        public T Insert(T t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException(nameof(t));
                }
                return Entities.Add(t).Entity;
            }
            catch (Exception)
            {
                throw;
            }
            
        }    
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        public T Update(T t)
        {
            try
            {
                if (t==null)
                {
                    throw new ArgumentNullException(nameof(t));
                }
                AttachIfNot(t);
                _context.GetEntry(t).State = EntityState.Modified;
                return t;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="t"></param>
        public T Delete(T t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException(nameof(t));
                }
                return this.Entities.Remove(t).Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 整表数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        } 
        /// <summary>
        /// 获取上下文实体对象
        /// </summary>
        public DbSet<T> Entities
        {
            get
            {
                return _entities ?? _context.SetEntity<T>();
            }
        }
        /// <summary>
        /// 如果上下文对象不纯在当前实体则附加上
        /// </summary>
        /// <param name="entity"></param>
        public virtual void AttachIfNot(T entity)
        {
            if (!Entities.Local.Contains(entity))
            {
                Entities.Attach(entity);
            }
        }
        /// <summary>
        /// 异步获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await Entities.FindAsync(id);
        }
        /// <summary>
        /// 异步插入
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<T> InsertAsync(T t)
        {
            return Task.FromResult(Insert(t)) ;
        }
        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<T> UpdateAsync(T t)
        {
            AttachIfNot(t);
            _context.GetEntry(t).State = EntityState.Modified;
            return Task.FromResult(t);
        }
        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<T> DeleteAsync(T t)
        {
            Entities.Remove(t);
            return Task.FromResult(t);
        }
        /// <summary>
        /// 更具id删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> DeleteAsync(int id)
        {
            T model=GetEntityById(id);
            return DeleteAsync(model);
        }
    }
}
