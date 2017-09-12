using System;
using System.Linq;
using System.Linq.Expressions;

namespace L.LCore.Infrastructure.Extension
{
    /// <summary>
    /// Queryable扩展
    /// </summary>
    public static class QueryableExtension
    {
        /// <summary>
        /// 分页扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">数据行数</param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 如果条件为true执行Where条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }
    }
}