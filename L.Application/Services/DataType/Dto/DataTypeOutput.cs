using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class DataTypeOutput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
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
        /// 创建时间
        /// </summary>
        public string CreateDateTime { get; set; }
    }
}
