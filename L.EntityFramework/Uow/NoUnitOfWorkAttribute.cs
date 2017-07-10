using System;

namespace L.EntityFramework.Uow
{
    /// <summary>
    /// 过滤不需要拦截的方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class NoUnitOfWorkAttribute:Attribute
    {

    }
}
