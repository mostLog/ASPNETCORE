using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using System;

namespace L.EntityFramework.Uow
{
    public class UnitOfWorkAttribute : InterceptAttribute
    {
        private UnitOfWorkAttribute(Service interceptorService) : base(interceptorService)
        {
        }

        public UnitOfWorkAttribute(bool isTransactional = false, string interceptorServiceName = "UnitOfWork") : base(interceptorServiceName)
        {
            IsTransactional = isTransactional;
        }

        private UnitOfWorkAttribute(Type interceptorServiceType) : base(interceptorServiceType)
        {
        }

        /// <summary>
        /// 是否开启事务
        /// </summary>
        public bool IsTransactional { get; set; }
    }
}