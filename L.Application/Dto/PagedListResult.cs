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
        public IList<T> Data { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 状态信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 判断是否成功
        /// </summary>
        public int Code { get; set; }
    }
}
