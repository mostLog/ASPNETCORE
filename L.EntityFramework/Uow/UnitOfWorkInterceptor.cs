using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace L.EntityFramework.Uow
{
    public class UnitOfWorkInterceptor : IInterceptor
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkInterceptor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Intercept(IInvocation invocation)
        {
            //获取该方法的类 类型
            var classType=invocation.Method.DeclaringType;
            IList<Attribute> units = classType
                .GetTypeInfo()
                .GetCustomAttributes(typeof(UnitOfWorkAttribute))
                .ToList();
            if (units.Count>0)
            {
                //过滤NoUnitOfWork
                if (!invocation
                    .Method
                    .CustomAttributes
                    .Select(c => c.AttributeType).Contains(typeof(NoUnitOfWorkAttribute)))
                {
                    //获取工作单元参数信息
                    var unitOfWork = (UnitOfWorkAttribute)units.FirstOrDefault();

                    _unitOfWork.Begin(new UnitOfWorkOptions() { IsTransactional = unitOfWork.IsTransactional });
                    invocation.Proceed();
                    _unitOfWork.Complete();
                }else
                {
                    invocation.Proceed();
                }
            }
        }
    }
}
