using System;
using System.Collections.Generic;
using System.Text;

namespace L.LCore.Domain.Base
{
    /// <summary>
    /// 实体接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
