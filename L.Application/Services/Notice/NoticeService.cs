﻿using L.EntityFramework;
using L.LCore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace L.Application
{
    public class NoticeService : INoticeService
    {
        //公共仓储
        private readonly IBaseRepository<Notice> _noticeRepository;

        public NoticeService(IBaseRepository<Notice> noticeRepository)
        {
            _noticeRepository = noticeRepository;
        }
        /// <summary>
        /// 返回所有公共信息
        /// </summary>
        /// <returns></returns>
        public IList<Notice> GetNotices()
        {
            
            return _noticeRepository.Table.ToList();
        }
    }
}
