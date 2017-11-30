using System;
using System.Collections.Generic;
using System.Text;
using L.Domain.Base;

namespace L.Domain.Entities
{
    /// <summary>
    /// 数据类型分类
    /// </summary>
    public class DataTypeClassification:BaseEntity<int>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set;}
        /// <summary>
        /// 分类标识
        /// </summary>
        public string ClassId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int? Seq { get; set; }
        /// <summary>
        /// 父级分类id
        /// </summary>
        public int? ParentId { get; set;}
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        public virtual DataTypeClassification ParentDataTypeClass { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        public virtual ICollection<DataTypeClassification> DataTypeClasses { get; set; }

        /// <summary>
        /// 对应分类下信息
        /// </summary>
        public virtual ICollection<DataType> DataTypes { get; set; }
    }
}
