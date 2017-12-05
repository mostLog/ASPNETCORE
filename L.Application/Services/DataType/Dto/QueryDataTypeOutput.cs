using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class QueryDataTypeOutput
    {
        /// <summary>
        /// 数据类型Id
        /// </summary>
        public int DataTypeId { get; set; }
        /// <summary>
        /// 数据类型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassName { get; set; }
    }
}
