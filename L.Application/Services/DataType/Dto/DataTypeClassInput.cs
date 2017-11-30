using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class DataTypeClassInput
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 父级分类id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 父类标识id
        /// </summary>
        public string ParentClassId { get; set; }
    }
}
