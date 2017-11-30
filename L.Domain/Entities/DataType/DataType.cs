using L.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.Domain.Entities
{
    public class DataType: AuditEntity
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 分类信息
        /// </summary>
        public virtual DataTypeClassification DataTypeClassification { get; set; }
    }

}
