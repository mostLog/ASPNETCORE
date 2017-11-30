using System;
using System.Collections.Generic;
using System.Text;

namespace L.Application.Dto
{
    public class ProxyCountOutput
    {
        /// <summary>
        /// 正在验证数量
        /// </summary>
        public int InValidation { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
    }
}
