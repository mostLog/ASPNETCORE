using L.Domain.Base;
using System;

namespace L.Domain.Entities
{
    public class Notice : AuditEntity
    {
        /// <summary>
        /// 公告类型,0=一般公告、1=紧急通知
        /// </summary>
        public bool? Type { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 有效开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 有效结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 是否停止
        /// </summary>
        public bool? IsTop { get; set; }
    }
}