using System;
using System.Collections.Generic;
using System.Linq;

namespace MI.Data
{
    public class BaseRepository<T>:IBaseRepository<T> where T: class
    {
        private readonly IDbContext _context;

        private IQueryable<T> _entities;
        
        public BaseRepository(IDbContext context)
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
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {

            return Entities;
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="t"></param>
        public void Insert(T t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException(nameof(t));
                }
                this.Entities.Add(t);
                //return _context.SaveChanges();
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
        public void Update(T t)
        {
            try
            {
                if (t==null)
                {
                    throw new ArgumentNullException(nameof(t));
                }
                AttachIfNot(t);
                _context.GetEntry(t).State = EntityState.Modified;
                //return _context.SaveChanges();
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
        public void Delete(T t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException(nameof(t));
                }
                this.Entities.Remove(t);
                //return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="query"></param>s
        /// <returns></returns>
        public void Delete(IEnumerable<T> query)
        {
            foreach (var item in query)
            {
               this.Entities.Remove(item);
            }
            //return _context.SaveChanges();
        }
        /// <summary>
        /// 获取上下文实体对象
        /// </summary>
        public IDbSet<T> Entities
        {
            get
            {
                return _entities ?? _context.SetEntity<T>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void AttachIfNot(T entity)
        {
            if (!Entities.Local.Contains(entity))
            {
                Entities.Attach(entity);
            }
        }
    }
}
