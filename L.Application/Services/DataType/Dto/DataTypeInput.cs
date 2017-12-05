using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class DataTypeInput
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        public int? ClassId { get; set; }
    }
}
