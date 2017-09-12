using L.Domain.Entities;
using L.EntityFramework.Uow;
using System.Collections.Generic;

namespace L.Application
{
    [UnitOfWork(isTransactional: true)]
    public interface INoticeService
    {
        [NoUnitOfWork]
        IList<Notice> GetNotices();

        int AddNotice();
    }
}