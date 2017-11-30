using System;

namespace L.Application.Dto
{
    public class ProxyListOutput
    {
        public int Id { get; set; }
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
        public string LastVerifyDateTime { get; set; }
    }
}