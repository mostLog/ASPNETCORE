using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class PagedListResult<T>
    {
        /// <summary>
        /// 数据行数
        /// </summary>
        public IList<T> Rows { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 判断是否成功
        /// </summary>
        public bool Flag { get; set; }
    }
}
