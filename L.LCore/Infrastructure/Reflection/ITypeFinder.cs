using System;
using System.Collections.Generic;
using System.Text;

namespace L.LCore.Infrastructure.Reflection
{
    /// <summary>
    /// 类型查找
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<Type> FindTypesByInterface<T>();
    }
}
