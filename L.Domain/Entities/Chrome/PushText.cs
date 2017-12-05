using L.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.Domain.Entities
{
    /// <summary>
    /// 信息推送实体
    /// </summary>
    public class PushText: BaseEntity<int>
    {
        /// <summary>
        /// 信息类型
        /// </summary>
        public string TextType { get; set; }
        /// <summary>
        /// 信息类型id
        /// </summary>
        public int? TextTypeId { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 推送时间
        /// </summary>
        public DateTime? PushDateTime { get; set; }

        /// <summary>
        /// 是否已经入库
        /// </summary>
        public bool IsWriteDb { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
    }
}
