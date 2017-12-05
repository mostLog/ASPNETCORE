using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class DataTypeSearchInput: PagedInputDto
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public int? ClassId { get; set; }
        /// <summary>
        /// 数据类型名称
        /// </summary>
        public string DataTypeName { get; set; }
    }
}
