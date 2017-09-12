using System;

namespace L.Domain.Base
{
    public class AuditEntity : BaseEntity<int>, IAuditEntity
    {
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDateTime
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatePerson
        {
            get;
            set;
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperaterDateTime
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperaterPerson
        {
            get;
            set;
        }
    }
}