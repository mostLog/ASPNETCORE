using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    /// <summary>
    /// 搜索条件类
    /// </summary>
    public class PushTextSearchInput: PagedInputDto
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsWriteDb { get; set; } = false;
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 数据类型名称
        /// </summary>
        public string DataTypeName { get; set; }
        /// <summary>
        /// 数据类型id
        /// </summary>
        public int? DataTypeId { get; set; }
    }
}
