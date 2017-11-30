using L.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace L.Domain.Entities
{
    /// <summary>
    /// 代理实体
    /// </summary>
    public class Proxy: BaseEntity<int>
    {
        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 响应速度
        /// </summary>
        public long ResponseSpeed { get; set; }
        /// <summary>
        /// 最后验证时间
        /// </summary>
        public DateTime? LastVerifyDateTime { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsAvailable { get; set; }

    }
}
