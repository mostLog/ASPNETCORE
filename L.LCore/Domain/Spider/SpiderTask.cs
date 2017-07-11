using L.LCore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.LCore.Domain.Entities
{
    public class SpiderTask: AuditEntity
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 任务描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
         public int Status { get; set; }
    }
}
