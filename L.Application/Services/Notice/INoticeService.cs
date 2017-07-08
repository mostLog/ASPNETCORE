using L.LCore.Domain.Entities;
using System.Collections.Generic;

namespace L.Application
{
    public interface INoticeService
    {
        IList<Notice> GetNotices();
    }
}
