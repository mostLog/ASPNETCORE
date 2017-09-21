using System;

namespace L.Application.Dto
{
    public class ProxyEditDto
    {
        public int? Id { get; set; }

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
    }
}