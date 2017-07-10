using L.EntityFramework.Uow;
using L.LCore.Domain.Entities;
using System.Collections.Generic;

namespace L.Application
{
    [UnitOfWork(isTransactional:true)]
    public interface INoticeService
    {
        [NoUnitOfWork]
        IList<Notice> GetNotices();

        int AddNotice();
    }
}
